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
            ListBoxEngineId = new ListBox();
            ButtonSetLEDDAC = new Button();
            ListBoxEngineTemp = new ListBox();
            TextBoxLEDDACValue = new TextBox();
            CheckBoxLEDOnOff = new CheckBox();
            SuspendLayout();
            // 
            // ButtonConnect
            // 
            ButtonConnect.Location = new Point(23, 23);
            ButtonConnect.Name = "ButtonConnect";
            ButtonConnect.Size = new Size(172, 47);
            ButtonConnect.TabIndex = 1;
            ButtonConnect.Text = "연결 (Connect)";
            ButtonConnect.UseVisualStyleBackColor = true;
            ButtonConnect.Click += ButtonConnect_Click;
            // 
            // ListBoxEngineId
            // 
            ListBoxEngineId.FormattingEnabled = true;
            ListBoxEngineId.ItemHeight = 15;
            ListBoxEngineId.Location = new Point(23, 85);
            ListBoxEngineId.Name = "ListBoxEngineId";
            ListBoxEngineId.Size = new Size(172, 94);
            ListBoxEngineId.TabIndex = 2;
            // 
            // ButtonSetLEDDAC
            // 
            ButtonSetLEDDAC.Location = new Point(23, 215);
            ButtonSetLEDDAC.Name = "ButtonSetLEDDAC";
            ButtonSetLEDDAC.Size = new Size(172, 47);
            ButtonSetLEDDAC.TabIndex = 3;
            ButtonSetLEDDAC.Text = "LED DAC 설정";
            ButtonSetLEDDAC.UseVisualStyleBackColor = true;
            ButtonSetLEDDAC.Click += ButtonSetLEDDAC_Click;
            // 
            // ListBoxEngineTemp
            // 
            ListBoxEngineTemp.FormattingEnabled = true;
            ListBoxEngineTemp.ItemHeight = 15;
            ListBoxEngineTemp.Location = new Point(213, 85);
            ListBoxEngineTemp.Name = "ListBoxEngineTemp";
            ListBoxEngineTemp.Size = new Size(172, 94);
            ListBoxEngineTemp.TabIndex = 4;
            // 
            // TextBoxLEDDACValue
            // 
            TextBoxLEDDACValue.Location = new Point(23, 268);
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
            CheckBoxLEDOnOff.Location = new Point(213, 215);
            CheckBoxLEDOnOff.Name = "CheckBoxLEDOnOff";
            CheckBoxLEDOnOff.Size = new Size(172, 47);
            CheckBoxLEDOnOff.TabIndex = 6;
            CheckBoxLEDOnOff.Text = "LED OFF";
            CheckBoxLEDOnOff.TextAlign = ContentAlignment.MiddleCenter;
            CheckBoxLEDOnOff.UseVisualStyleBackColor = true;
            CheckBoxLEDOnOff.CheckedChanged += CheckBoxLEDOnOff_CheckedChanged;
            // 
            // EngineController
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 320);
            Controls.Add(CheckBoxLEDOnOff);
            Controls.Add(TextBoxLEDDACValue);
            Controls.Add(ListBoxEngineTemp);
            Controls.Add(ButtonSetLEDDAC);
            Controls.Add(ListBoxEngineId);
            Controls.Add(ButtonConnect);
            Name = "EngineController";
            Text = "Visitech 2K LuxBeam LRS-WQ 컨트롤러";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ButtonConnect;
        private ListBox ListBoxEngineId;
        private Button ButtonSetLEDDAC;
        private ListBox ListBoxEngineTemp;
        private TextBox TextBoxLEDDACValue;
        private CheckBox CheckBoxLEDOnOff;
    }
}
