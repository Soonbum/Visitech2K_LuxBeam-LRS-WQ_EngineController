namespace Visitech2K_LuxBeam_LRS_WQ_EngineController;

public partial class EngineController : Form
{
    private VisitechWQXGAEngineController EngineControllerLeft;
    private VisitechWQXGAEngineController EngineControllerRight;

    public EngineController()
    {
        InitializeComponent();
    }

    private void ButtonConnect_Click(object sender, EventArgs e)
    {
        // 자동으로 IP 주소와 포트를 설정하는 로직 추가 필요 ...
    }

    private void ButtonSetLEDDAC_Click(object sender, EventArgs e)
    {
        // ...
    }

    private void CheckBoxLEDOnOff_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBoxLEDOnOff.Checked)
        {
            CheckBoxLEDOnOff.Text = "LED ON";
        }
        else
        {
            CheckBoxLEDOnOff.Text = "LED OFF";
        }
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
}
