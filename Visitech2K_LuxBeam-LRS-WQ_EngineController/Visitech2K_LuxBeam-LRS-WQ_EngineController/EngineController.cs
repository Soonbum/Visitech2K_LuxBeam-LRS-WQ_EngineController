using System.Runtime.InteropServices;

namespace Visitech2K_LuxBeam_LRS_WQ_EngineController;

public partial class EngineController : Form
{
    // 콘솔 할당 API
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();

    // 콘솔 해제 API (필요시)
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool FreeConsole();

    private VisitechWQXGAEngineController EngineControllerLeft;
    private VisitechWQXGAEngineController EngineControllerRight;

    public EngineController()
    {
        InitializeComponent();

        AllocConsole();
    }

    private void ButtonConnect_Click(object sender, EventArgs e)
    {
        try
        {
            string[] Engine1_ConnInfo = TextBoxEngine1Conn.Text.Split(':');
            string[] Engine2_ConnInfo = TextBoxEngine2Conn.Text.Split(':');

            string Engine1_IP = Engine1_ConnInfo[0];
            string Engine2_IP = Engine2_ConnInfo[0];
            int Engine1_Port = int.Parse(Engine1_ConnInfo[1]);
            int Engine2_Port = int.Parse(Engine2_ConnInfo[1]);

            EngineControllerLeft = new(Engine1_IP, Engine1_Port);
            EngineControllerRight = new(Engine2_IP, Engine2_Port);

            EngineControllerLeft.Connect(0);
            EngineControllerRight.Connect(1);

            EngineControllerLeft.StartBackgroundThread();
            EngineControllerRight.StartBackgroundThread();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"엔진 연결 정보 형식이 올바르지 않습니다. \"IP:포트\" 형식으로 입력해주세요.\n" + ex.Message, "연결 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    private void ButtonGetTemp_Click(object sender, EventArgs e)
    {
        LabelTemp1.Text = EngineControllerLeft.GetTemperatureSensorValue().ToString("F2") + " °C";
        LabelTemp2.Text = EngineControllerRight.GetTemperatureSensorValue().ToString("F2") + " °C";
    }

    private void ButtonSetLEDDAC_Click(object sender, EventArgs e)
    {
        try
        {
            EngineControllerLeft.SetLEDDACValue(int.Parse(TextBoxLEDDACValue.Text));
            EngineControllerRight.SetLEDDACValue(int.Parse(TextBoxLEDDACValue.Text));

            EngineControllerLeft.SetSettingLEDDAC(true);
            EngineControllerRight.SetSettingLEDDAC(true);
        }
        catch (Exception ex)
        {
            MessageBox.Show("LED DAC 값을 설정하는 중 오류가 발생했습니다.\n" + ex.Message, "설정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CheckBoxLEDOnOff_CheckedChanged(object sender, EventArgs e)
    {
        bool LedState = CheckBoxLEDOnOff.Checked;

        if (LedState)
        {
            CheckBoxLEDOnOff.Text = "LED ON";
        }
        else
        {
            CheckBoxLEDOnOff.Text = "LED OFF";
        }

        EngineControllerLeft.SetDeviceLEDOn(LedState);
        EngineControllerRight.SetDeviceLEDOn(LedState);
    }

    private void TextBoxLEDDACValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (int.TryParse(TextBoxLEDDACValue.Text, out int value))
        {
            if (value < 0 || value > 1023)
            {
                MessageBox.Show("LED DAC 값은 0에서 1023 사이여야 합니다.", "유효성 검사 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        else
        {
            MessageBox.Show("LED DAC 값은 정수여야 합니다.", "유효성 검사 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }
    }

    private void ButtonGetLEDDAC_Click(object sender, EventArgs e)
    {
        LabelLEDDAC1.Text = EngineControllerLeft.GetLEDDACValue().ToString("F2");
        LabelLEDDAC2.Text = EngineControllerRight.GetLEDDACValue().ToString("F2");
    }
}
