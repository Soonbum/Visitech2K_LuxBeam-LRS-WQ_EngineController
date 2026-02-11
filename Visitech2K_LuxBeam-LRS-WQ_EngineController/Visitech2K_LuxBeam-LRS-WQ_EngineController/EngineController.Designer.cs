namespace Visitech2K_LuxBeam_LRS_WQ_EngineController
{
    partial class EngineController
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonConnect = new Button();
            ButtonSetLEDDAC = new Button();
            TextBoxLEDDACValue = new TextBox();
            CheckBoxLEDOnOff = new CheckBox();
            TextBoxEngine1Conn = new TextBox();
            TextBoxEngine2Conn = new TextBox();
            LabelTemp1 = new Label();
            LabelTemp2 = new Label();
            ButtonGetTemp = new Button();
            ButtonGetLEDDAC = new Button();
            LabelLEDDAC1 = new Label();
            LabelLEDDAC2 = new Label();
            SuspendLayout();
            // 
            // ButtonConnect
            // 
            ButtonConnect.Location = new Point(23, 23);
            ButtonConnect.Name = "ButtonConnect";
            ButtonConnect.Size = new Size(172, 52);
            ButtonConnect.TabIndex = 1;
            ButtonConnect.Text = "연결 (Connect)";
            ButtonConnect.UseVisualStyleBackColor = true;
            ButtonConnect.Click += ButtonConnect_Click;
            // 
            // ButtonSetLEDDAC
            // 
            ButtonSetLEDDAC.Location = new Point(23, 212);
            ButtonSetLEDDAC.Name = "ButtonSetLEDDAC";
            ButtonSetLEDDAC.Size = new Size(172, 47);
            ButtonSetLEDDAC.TabIndex = 3;
            ButtonSetLEDDAC.Text = "LED DAC 설정";
            ButtonSetLEDDAC.UseVisualStyleBackColor = true;
            ButtonSetLEDDAC.Click += ButtonSetLEDDAC_Click;
            // 
            // TextBoxLEDDACValue
            // 
            TextBoxLEDDACValue.Location = new Point(23, 265);
            TextBoxLEDDACValue.MaxLength = 5;
            TextBoxLEDDACValue.Name = "TextBoxLEDDACValue";
            TextBoxLEDDACValue.Size = new Size(172, 23);
            TextBoxLEDDACValue.TabIndex = 5;
            TextBoxLEDDACValue.Text = "100";
            TextBoxLEDDACValue.Validating += TextBoxLEDDACValue_Validating;
            // 
            // CheckBoxLEDOnOff
            // 
            CheckBoxLEDOnOff.Appearance = Appearance.Button;
            CheckBoxLEDOnOff.Location = new Point(213, 212);
            CheckBoxLEDOnOff.Name = "CheckBoxLEDOnOff";
            CheckBoxLEDOnOff.Size = new Size(172, 47);
            CheckBoxLEDOnOff.TabIndex = 6;
            CheckBoxLEDOnOff.Text = "LED OFF";
            CheckBoxLEDOnOff.TextAlign = ContentAlignment.MiddleCenter;
            CheckBoxLEDOnOff.UseVisualStyleBackColor = true;
            CheckBoxLEDOnOff.CheckedChanged += CheckBoxLEDOnOff_CheckedChanged;
            // 
            // TextBoxEngine1Conn
            // 
            TextBoxEngine1Conn.Location = new Point(213, 23);
            TextBoxEngine1Conn.MaxLength = 5;
            TextBoxEngine1Conn.Name = "TextBoxEngine1Conn";
            TextBoxEngine1Conn.Size = new Size(172, 23);
            TextBoxEngine1Conn.TabIndex = 7;
            TextBoxEngine1Conn.Text = "192.168.0.2:5000";
            // 
            // TextBoxEngine2Conn
            // 
            TextBoxEngine2Conn.Location = new Point(213, 52);
            TextBoxEngine2Conn.MaxLength = 5;
            TextBoxEngine2Conn.Name = "TextBoxEngine2Conn";
            TextBoxEngine2Conn.Size = new Size(172, 23);
            TextBoxEngine2Conn.TabIndex = 8;
            TextBoxEngine2Conn.Text = "192.168.0.3:5000";
            // 
            // LabelTemp1
            // 
            LabelTemp1.AutoSize = true;
            LabelTemp1.Location = new Point(213, 90);
            LabelTemp1.Name = "LabelTemp1";
            LabelTemp1.Size = new Size(72, 15);
            LabelTemp1.TabIndex = 9;
            LabelTemp1.Text = "LabelTemp1";
            // 
            // LabelTemp2
            // 
            LabelTemp2.AutoSize = true;
            LabelTemp2.Location = new Point(213, 122);
            LabelTemp2.Name = "LabelTemp2";
            LabelTemp2.Size = new Size(72, 15);
            LabelTemp2.TabIndex = 10;
            LabelTemp2.Text = "LabelTemp2";
            // 
            // ButtonGetTemp
            // 
            ButtonGetTemp.Location = new Point(23, 90);
            ButtonGetTemp.Name = "ButtonGetTemp";
            ButtonGetTemp.Size = new Size(172, 47);
            ButtonGetTemp.TabIndex = 11;
            ButtonGetTemp.Text = "온도 정보 업데이트";
            ButtonGetTemp.UseVisualStyleBackColor = true;
            ButtonGetTemp.Click += ButtonGetTemp_Click;
            // 
            // ButtonGetLEDDAC
            // 
            ButtonGetLEDDAC.Location = new Point(23, 150);
            ButtonGetLEDDAC.Name = "ButtonGetLEDDAC";
            ButtonGetLEDDAC.Size = new Size(172, 47);
            ButtonGetLEDDAC.TabIndex = 12;
            ButtonGetLEDDAC.Text = "LED DAC 가져오기";
            ButtonGetLEDDAC.UseVisualStyleBackColor = true;
            ButtonGetLEDDAC.Click += ButtonGetLEDDAC_Click;
            // 
            // LabelLEDDAC1
            // 
            LabelLEDDAC1.AutoSize = true;
            LabelLEDDAC1.Location = new Point(213, 150);
            LabelLEDDAC1.Name = "LabelLEDDAC1";
            LabelLEDDAC1.Size = new Size(88, 15);
            LabelLEDDAC1.TabIndex = 13;
            LabelLEDDAC1.Text = "LabelLEDDAC1";
            // 
            // LabelLEDDAC2
            // 
            LabelLEDDAC2.AutoSize = true;
            LabelLEDDAC2.Location = new Point(213, 182);
            LabelLEDDAC2.Name = "LabelLEDDAC2";
            LabelLEDDAC2.Size = new Size(88, 15);
            LabelLEDDAC2.TabIndex = 14;
            LabelLEDDAC2.Text = "LabelLEDDAC2";
            // 
            // EngineController
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 306);
            Controls.Add(LabelLEDDAC2);
            Controls.Add(LabelLEDDAC1);
            Controls.Add(ButtonGetLEDDAC);
            Controls.Add(ButtonGetTemp);
            Controls.Add(LabelTemp2);
            Controls.Add(LabelTemp1);
            Controls.Add(TextBoxEngine2Conn);
            Controls.Add(TextBoxEngine1Conn);
            Controls.Add(CheckBoxLEDOnOff);
            Controls.Add(TextBoxLEDDACValue);
            Controls.Add(ButtonSetLEDDAC);
            Controls.Add(ButtonConnect);
            Name = "EngineController";
            Text = "Visitech 2K LuxBeam LRS-WQ 컨트롤러";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ButtonConnect;
        private Button ButtonSetLEDDAC;
        private TextBox TextBoxLEDDACValue;
        private CheckBox CheckBoxLEDOnOff;
        private TextBox TextBoxEngine1Conn;
        private TextBox TextBoxEngine2Conn;
        private Label LabelTemp1;
        private Label LabelTemp2;
        private Button ButtonGetTemp;
        private Button ButtonGetLEDDAC;
        private Label LabelLEDDAC1;
        private Label LabelLEDDAC2;
    }
}
