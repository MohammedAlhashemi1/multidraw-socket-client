namespace MDClient_AlhashemiM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            UI_Connect_btn = new ToolStripButton();
            UI_Colour_btn = new ToolStripButton();
            UI_Thickness_lbl = new ToolStripLabel();
            UI_Alpha_lbl = new ToolStripLabel();
            UI_Frames_lbl = new ToolStripLabel();
            UI_Fragments_lbl = new ToolStripLabel();
            UI_Destack_lbl = new ToolStripLabel();
            UI_Bytes_lbl = new ToolStripLabel();
            UI_Disconnect_btn = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.Items.AddRange(new ToolStripItem[] { UI_Connect_btn, UI_Colour_btn, UI_Thickness_lbl, UI_Alpha_lbl, UI_Frames_lbl, UI_Fragments_lbl, UI_Destack_lbl, UI_Bytes_lbl, UI_Disconnect_btn });
            toolStrip1.Location = new Point(0, 313);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(729, 25);
            toolStrip1.TabIndex = 10;
            toolStrip1.Text = "toolStrip1";
            // 
            // UI_Connect_btn
            // 
            UI_Connect_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            UI_Connect_btn.Image = (Image)resources.GetObject("UI_Connect_btn.Image");
            UI_Connect_btn.ImageTransparentColor = Color.Magenta;
            UI_Connect_btn.Name = "UI_Connect_btn";
            UI_Connect_btn.Size = new Size(56, 22);
            UI_Connect_btn.Text = "Connect";
            // 
            // UI_Colour_btn
            // 
            UI_Colour_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            UI_Colour_btn.Image = (Image)resources.GetObject("UI_Colour_btn.Image");
            UI_Colour_btn.ImageTransparentColor = Color.Magenta;
            UI_Colour_btn.Name = "UI_Colour_btn";
            UI_Colour_btn.Size = new Size(40, 22);
            UI_Colour_btn.Text = "Color";
            // 
            // UI_Thickness_lbl
            // 
            UI_Thickness_lbl.Name = "UI_Thickness_lbl";
            UI_Thickness_lbl.Size = new Size(71, 22);
            UI_Thickness_lbl.Text = "Thickness: 5";
            // 
            // UI_Alpha_lbl
            // 
            UI_Alpha_lbl.Name = "UI_Alpha_lbl";
            UI_Alpha_lbl.Size = new Size(62, 22);
            UI_Alpha_lbl.Text = "Alpha: 255";
            // 
            // UI_Frames_lbl
            // 
            UI_Frames_lbl.Name = "UI_Frames_lbl";
            UI_Frames_lbl.Size = new Size(74, 22);
            UI_Frames_lbl.Text = "Frames RX: 0";
            // 
            // UI_Fragments_lbl
            // 
            UI_Fragments_lbl.Name = "UI_Fragments_lbl";
            UI_Fragments_lbl.Size = new Size(75, 22);
            UI_Fragments_lbl.Text = "Fragments: 0";
            // 
            // UI_Destack_lbl
            // 
            UI_Destack_lbl.Name = "UI_Destack_lbl";
            UI_Destack_lbl.Size = new Size(84, 22);
            UI_Destack_lbl.Text = "Destack Avg: 0";
            // 
            // UI_Bytes_lbl
            // 
            UI_Bytes_lbl.Name = "UI_Bytes_lbl";
            UI_Bytes_lbl.Size = new Size(64, 22);
            UI_Bytes_lbl.Text = "Bytes RX: 0";
            // 
            // UI_Disconnect_btn
            // 
            UI_Disconnect_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            UI_Disconnect_btn.Image = (Image)resources.GetObject("UI_Disconnect_btn.Image");
            UI_Disconnect_btn.ImageTransparentColor = Color.Magenta;
            UI_Disconnect_btn.Name = "UI_Disconnect_btn";
            UI_Disconnect_btn.Size = new Size(70, 22);
            UI_Disconnect_btn.Text = "Disconnect";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 338);
            Controls.Add(toolStrip1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton UI_Connect_btn;
        private ToolStripButton UI_Colour_btn;
        private ToolStripLabel UI_Thickness_lbl;
        private ToolStripLabel UI_Alpha_lbl;
        private ToolStripLabel UI_Frames_lbl;
        private ToolStripLabel UI_Fragments_lbl;
        private ToolStripLabel UI_Destack_lbl;
        private ToolStripLabel UI_Bytes_lbl;
        private ToolStripButton UI_Disconnect_btn;
    }
}
