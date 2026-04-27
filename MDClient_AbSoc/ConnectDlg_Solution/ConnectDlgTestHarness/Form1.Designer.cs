namespace ConnectDlgTestHarness
{
    partial class Form1
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
            txtLog = new TextBox();
            btnDefault = new Button();
            btnBothEditable = new Button();
            btnAdrressOnly = new Button();
            btnPortOnly = new Button();
            btnNeitherEditable = new Button();
            btnCtorBadAddress = new Button();
            btnCtorBadPort = new Button();
            btnBadAddress = new Button();
            btnGoodAddressBadPort = new Button();
            btnGoodAddressGoodPort = new Button();
            btnClear = new Button();
            SuspendLayout();
            // 
            // txtLog
            // 
            txtLog.Location = new Point(245, 11);
            txtLog.Margin = new Padding(3, 2, 3, 2);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(402, 316);
            txtLog.TabIndex = 0;
            // 
            // btnDefault
            // 
            btnDefault.Location = new Point(38, 21);
            btnDefault.Margin = new Padding(3, 2, 3, 2);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new Size(82, 22);
            btnDefault.TabIndex = 1;
            btnDefault.Text = "Default";
            btnDefault.UseVisualStyleBackColor = true;
            // 
            // btnBothEditable
            // 
            btnBothEditable.Location = new Point(38, 47);
            btnBothEditable.Margin = new Padding(3, 2, 3, 2);
            btnBothEditable.Name = "btnBothEditable";
            btnBothEditable.Size = new Size(157, 22);
            btnBothEditable.TabIndex = 2;
            btnBothEditable.Text = "Both Editable";
            btnBothEditable.UseVisualStyleBackColor = true;
            // 
            // btnAdrressOnly
            // 
            btnAdrressOnly.Location = new Point(38, 73);
            btnAdrressOnly.Margin = new Padding(3, 2, 3, 2);
            btnAdrressOnly.Name = "btnAdrressOnly";
            btnAdrressOnly.Size = new Size(130, 22);
            btnAdrressOnly.TabIndex = 3;
            btnAdrressOnly.Text = "Address Only";
            btnAdrressOnly.UseVisualStyleBackColor = true;
            // 
            // btnPortOnly
            // 
            btnPortOnly.Location = new Point(39, 99);
            btnPortOnly.Margin = new Padding(3, 2, 3, 2);
            btnPortOnly.Name = "btnPortOnly";
            btnPortOnly.Size = new Size(82, 22);
            btnPortOnly.TabIndex = 4;
            btnPortOnly.Text = "Port Only";
            btnPortOnly.UseVisualStyleBackColor = true;
            // 
            // btnNeitherEditable
            // 
            btnNeitherEditable.Location = new Point(38, 126);
            btnNeitherEditable.Margin = new Padding(3, 2, 3, 2);
            btnNeitherEditable.Name = "btnNeitherEditable";
            btnNeitherEditable.Size = new Size(130, 22);
            btnNeitherEditable.TabIndex = 5;
            btnNeitherEditable.Text = "Neither Editable";
            btnNeitherEditable.UseVisualStyleBackColor = true;
            // 
            // btnCtorBadAddress
            // 
            btnCtorBadAddress.Location = new Point(38, 152);
            btnCtorBadAddress.Margin = new Padding(3, 2, 3, 2);
            btnCtorBadAddress.Name = "btnCtorBadAddress";
            btnCtorBadAddress.Size = new Size(162, 22);
            btnCtorBadAddress.TabIndex = 6;
            btnCtorBadAddress.Text = "Ctor Bad Address";
            btnCtorBadAddress.UseVisualStyleBackColor = true;
            // 
            // btnCtorBadPort
            // 
            btnCtorBadPort.Location = new Point(39, 178);
            btnCtorBadPort.Margin = new Padding(3, 2, 3, 2);
            btnCtorBadPort.Name = "btnCtorBadPort";
            btnCtorBadPort.Size = new Size(156, 22);
            btnCtorBadPort.TabIndex = 7;
            btnCtorBadPort.Text = "Ctor Bad Port";
            btnCtorBadPort.UseVisualStyleBackColor = true;
            // 
            // btnBadAddress
            // 
            btnBadAddress.Location = new Point(38, 205);
            btnBadAddress.Margin = new Padding(3, 2, 3, 2);
            btnBadAddress.Name = "btnBadAddress";
            btnBadAddress.Size = new Size(130, 22);
            btnBadAddress.TabIndex = 8;
            btnBadAddress.Text = "Bad Address";
            btnBadAddress.UseVisualStyleBackColor = true;
            // 
            // btnGoodAddressBadPort
            // 
            btnGoodAddressBadPort.Location = new Point(38, 231);
            btnGoodAddressBadPort.Margin = new Padding(3, 2, 3, 2);
            btnGoodAddressBadPort.Name = "btnGoodAddressBadPort";
            btnGoodAddressBadPort.Size = new Size(182, 22);
            btnGoodAddressBadPort.TabIndex = 9;
            btnGoodAddressBadPort.Text = "Good Address Bad Port";
            btnGoodAddressBadPort.UseVisualStyleBackColor = true;
            // 
            // btnGoodAddressGoodPort
            // 
            btnGoodAddressGoodPort.Location = new Point(38, 257);
            btnGoodAddressGoodPort.Margin = new Padding(3, 2, 3, 2);
            btnGoodAddressGoodPort.Name = "btnGoodAddressGoodPort";
            btnGoodAddressGoodPort.Size = new Size(201, 22);
            btnGoodAddressGoodPort.TabIndex = 10;
            btnGoodAddressGoodPort.Text = "Good Address Good Port";
            btnGoodAddressGoodPort.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(39, 283);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(82, 22);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnClear);
            Controls.Add(btnGoodAddressGoodPort);
            Controls.Add(btnGoodAddressBadPort);
            Controls.Add(btnBadAddress);
            Controls.Add(btnCtorBadPort);
            Controls.Add(btnCtorBadAddress);
            Controls.Add(btnNeitherEditable);
            Controls.Add(btnPortOnly);
            Controls.Add(btnAdrressOnly);
            Controls.Add(btnBothEditable);
            Controls.Add(btnDefault);
            Controls.Add(txtLog);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLog;
        private Button btnDefault;
        private Button btnBothEditable;
        private Button btnAdrressOnly;
        private Button btnPortOnly;
        private Button btnNeitherEditable;
        private Button btnCtorBadAddress;
        private Button btnCtorBadPort;
        private Button btnBadAddress;
        private Button btnGoodAddressBadPort;
        private Button btnGoodAddressGoodPort;
        private Button btnClear;
    }
}
