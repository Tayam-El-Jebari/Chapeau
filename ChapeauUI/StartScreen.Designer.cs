
namespace ChapeauUI
{
    partial class StartScreen
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
            this.startAsDesktopbts = new System.Windows.Forms.Button();
            this.startForHandheldbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startAsDesktopbts
            // 
            this.startAsDesktopbts.Location = new System.Drawing.Point(13, 13);
            this.startAsDesktopbts.Name = "startAsDesktopbts";
            this.startAsDesktopbts.Size = new System.Drawing.Size(269, 174);
            this.startAsDesktopbts.TabIndex = 0;
            this.startAsDesktopbts.Text = "START FOR DESKTOP";
            this.startAsDesktopbts.UseVisualStyleBackColor = true;
            this.startAsDesktopbts.Click += new System.EventHandler(this.startAsDesktopbts_Click);
            // 
            // startForHandheldbtn
            // 
            this.startForHandheldbtn.Location = new System.Drawing.Point(13, 205);
            this.startForHandheldbtn.Name = "startForHandheldbtn";
            this.startForHandheldbtn.Size = new System.Drawing.Size(269, 175);
            this.startForHandheldbtn.TabIndex = 1;
            this.startForHandheldbtn.Text = "START FOR HANDHELD";
            this.startForHandheldbtn.UseVisualStyleBackColor = true;
            this.startForHandheldbtn.Click += new System.EventHandler(this.startForHandheldbtn_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startForHandheldbtn);
            this.Controls.Add(this.startAsDesktopbts);
            this.Name = "StartScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startAsDesktopbts;
        private System.Windows.Forms.Button startForHandheldbtn;
    }
}