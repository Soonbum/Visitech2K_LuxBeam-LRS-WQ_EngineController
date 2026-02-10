using System.ComponentModel;
using System.Net.Sockets;
using System.Text;

namespace Visitech2K_LuxBeam_LRS_WQ_EngineController;

public class VisitechWQXGAEngineController
{
    private TcpClient? tcpClient;
    private NetworkStream? stream;
    private StreamWriter? writer;
    private StreamReader? reader;

    private readonly string ipAddress;
    private readonly int port;

    private bool isDeviceConnected;
    private bool isProjectorPowerOn;            // 프로젝터 전원 상태

    private bool isEngineLEDOn;                 // 엔진 UV 라이트를 켰는지 여부

    private bool isSetLECDAC;                   // LED DAC 설정 여부
    private int LEDDACValue;                    // LED DAC 값 (범위: 0 ~ 1023)

    private double TemperatureSensorValue;
    private int id;

    private int errorCount = 0;                 // 통신 오류 횟수
    private int errorCountPrev = 0;             // 이전 통신 오류 횟수

    public int GetEngineID()
    {
        return id;
    }

    public int GetErrorCount()
    {
        return errorCount;
    }

    private void Thread_DoWork(Object? sender, DoWorkEventArgs e)
    {
        while (true)
        {
            errorCountPrev = errorCount;

            if (!isProjectorPowerOn)
            {
                if (ProjectorPowerOn())
                {
                    isProjectorPowerOn = true;
                }
            }

            if (isProjectorPowerOn && isDeviceConnected)
            {
                TemperatureSensorValue = GetTemperatureSensor();

                // 통신 오류 체크
                if (TemperatureSensorValue == 0.0 || TemperatureSensorValue == -1)
                    errorCount++;

                bool returnValue;
                if (isEngineLEDOn)
                    returnValue = LEDPowerOn();
                else
                    returnValue = LEDPowerOff();

                // 통신 오류 체크
                if (!returnValue)
                    errorCount++;

                if (isSetLECDAC)
                {
                    SetLEDDAC(LEDDACValue);
                    isSetLECDAC = false;
                }
            }

            // 오류가 더 이상 발생하지 않는다면 카운트 변수 초기화
            if (errorCount == errorCountPrev)
            {
                errorCount = 0;
                errorCountPrev = 0;
            }
        }
    }

    public BackgroundWorker BackgroundWorkerThread;

    public void StartBackgroundThread()
    {
        Init();

        if (!BackgroundWorkerThread.IsBusy)
            BackgroundWorkerThread.RunWorkerAsync();
    }

    public VisitechWQXGAEngineController(string ipAddress, int port)
    {
        this.ipAddress = ipAddress;
        this.port = port;

        isDeviceConnected = false;
        isProjectorPowerOn = false;
        isEngineLEDOn = false;
        isSetLECDAC = false;

        TemperatureSensorValue = 0.0;

        BackgroundWorkerThread = new BackgroundWorker();
        BackgroundWorkerThread.DoWork += Thread_DoWork;
    }

    public void Connect(int index)
    {
        if (isDeviceConnected) return;

        try
        {
            tcpClient = new TcpClient();
            // 타임아웃 설정 (연결 시도 3초)
            var result = tcpClient.BeginConnect(ipAddress, port, null, null);
            var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));

            if (!success || !tcpClient.Connected)
            {
                throw new Exception("Visitech Engine: TCP Connection Timeout");
            }

            stream = tcpClient.GetStream();
            // AutoFlush를 true로 설정하여 즉시 전송되게 함
            writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            reader = new StreamReader(stream, Encoding.ASCII);

            this.isDeviceConnected = true;
            id = index;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Visitech Engine: Connect Error ({ex.Message})");
            this.isDeviceConnected = false;
        }
    }

    public void Disconnect()
    {
        if (isDeviceConnected)
        {
            BackgroundWorkerThread.CancelAsync();
            LEDPowerOff();
            ProjectorPowerOff();

            writer?.Close();
            reader?.Close();
            stream?.Close();
            tcpClient?.Close();

            this.isDeviceConnected = false;
        }
    }

    private void Init()
    {
        // 엔진 초기화 동작
        // 하나씩 보내고 응답을 하나씩 확인할 필요가 있음
        string response;

        response = SendCommand("GET LED TEMP");
        Console.WriteLine($"{id}: {response}");

        response = SendCommand("INIT HDMI");
        Console.WriteLine($"{id}: {response}");

        response = SendCommand("SET OPERATION MODE VIDEO_PATTERN_MODE");
        Console.WriteLine($"{id}: {response}");

        response = SendCommand("INIT HDMI");
        Console.WriteLine($"{id}: {response}");

        response = SendCommand("SET OPERATION MODE VIDEO_PATTERN_MODE");
        Console.WriteLine($"{id}: {response}");

        response = SendCommand("SET LUT DEFINITION 180000,0,0,8,0,0,0");
        Console.WriteLine($"{id}: {response}");

        response = SendCommand("SET LUT CONFIG 1 1000");
        Console.WriteLine($"{id}: {response}");
    }

    private string SendCommand(string cmd)
    {
        if (!isDeviceConnected || tcpClient == null || !tcpClient.Connected)
            return "Error: Socket Closed";

        if (stream == null)
            return "Error: Network Stream Unavailable";

        try
        {
            // 기존에 남아있던 쓰레기 데이터 청소 (선택 사항)
            while (stream.DataAvailable) { stream.ReadByte(); }

            // 명령어 전송
            byte[] data = Encoding.ASCII.GetBytes(cmd + "\r\n\r\n");
            stream.Write(data, 0, data.Length);
            stream.Flush();

            // 응답 대기 및 읽기 (ReadLine 스타일)
            Thread.Sleep(100);
            using StreamReader reader = new(stream, Encoding.ASCII, leaveOpen: true);
            // 응답이 올 때까지 대기 (타임아웃은 아래 '참고' 섹션 확인)
            // ReadLine()은 \n 또는 \r\n을 만날 때까지 블로킹(대기)됩니다.
            string? response = reader.ReadLine();

            if (response != null)
            {
                return response.Trim();
            }

            return "No Response";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public bool ProjectorPowerOn()
    {
        // dummy
        return true;
    }

    public bool ProjectorPowerOff()
    {
        // dummy
        return true;
    }

    public bool LEDPowerOn()
    {
        string returnStr = SendCommand("SET SEQ ON");
        Console.WriteLine($"{id}: LED ON --> {returnStr}");
        return true;
    }

    public bool LEDPowerOff()
    {
        string returnStr = SendCommand("SET SEQ OFF");
        Console.WriteLine($"{id}: LED OFF --> {returnStr}");
        return true;
    }

    public bool SetLEDDAC(int value)
    {
        int val = Math.Max(0, Math.Min(1023, value));
        LEDDACValue = val;
        string cmd = $"SET AMPLITUDE {val}";
        string returnStr = SendCommand(cmd);
        Console.WriteLine($"{id}: SET AMPLITUDE --> {returnStr}");
        return true;
    }

    public int GetLEDDAC()
    {
        return LEDDACValue;
    }

    public double GetTemperatureSensor()
    {
        string returnStr = SendCommand("GET LED TEMP");
        Console.WriteLine($"{id}: GET LED TEMP --> {returnStr}");

        if (double.TryParse(returnStr, out double value))
            return (double)value;

        return 0.0;
    }

    public bool GetDeviceConnected()
    {
        return this.isDeviceConnected;
    }

    public bool GetDeviceLEDOn()
    {
        return isEngineLEDOn;
    }

    public int GetLEDDACValue()
    {
        return LEDDACValue;
    }

    public bool GetSettingLEDDAC()
    {
        return isSetLECDAC;
    }

    public double GetTemperatureSensorValue()
    {
        return TemperatureSensorValue;
    }

    public void SetDeviceConnected(bool isConnected)
    {
        this.isDeviceConnected = isConnected;
    }

    public void SetDeviceLEDOn(bool isOn)
    {
        isEngineLEDOn = isOn;
    }

    public void SetLEDDACValue(int value)
    {
        LEDDACValue = value;
    }

    public void SetSettingLEDDAC(bool isSet)
    {
        isSetLECDAC = isSet;
    }
}
