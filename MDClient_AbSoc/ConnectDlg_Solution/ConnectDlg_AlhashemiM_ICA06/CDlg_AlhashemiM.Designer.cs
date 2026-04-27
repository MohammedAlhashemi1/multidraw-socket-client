namespace ConnectDlg_AlhashemiM_ICA06
{
    partial class CDlg_AlhashemiM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtAddress = new TextBox();
            txtPort = new TextBox();
            btnConnect = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtStatus = new TextBox();
            SuspendLayout();
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(123, 60);
            txtAddress.Margin = new Padding(3, 2, 3, 2);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(110, 23);
            txtAddress.TabIndex = 0;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(123, 97);
            txtPort.Margin = new Padding(3, 2, 3, 2);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(110, 23);
            txtPort.TabIndex = 1;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(74, 256);
            btnConnect.Margin = new Padding(3, 2, 3, 2);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(82, 22);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(178, 256);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 68);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 5;
            label1.Text = "Address: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 105);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 6;
            label2.Text = "Port: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(454, 9);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 7;
            label3.Text = "Status: ";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(275, 37);
            txtStatus.Margin = new Padding(3, 2, 3, 2);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.ScrollBars = ScrollBars.Vertical;
            txtStatus.Size = new Size(390, 241);
            txtStatus.TabIndex = 2;
            // 
            // CDlg_AlhashemiM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnConnect);
            Controls.Add(txtStatus);
            Controls.Add(txtPort);
            Controls.Add(txtAddress);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CDlg_AlhashemiM";
            Text = "CDlg_AlhashemiM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAddress;
        private TextBox txtPort;
        private Button btnConnect;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtStatus;
    }
}