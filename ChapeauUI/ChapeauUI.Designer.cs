
namespace ChapeauUI
{
    partial class ChapeauUI
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
            this.testView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // testView
            // 
            this.testView.GridLines = true;
            this.testView.HideSelection = false;
            this.testView.Location = new System.Drawing.Point(74, 54);
            this.testView.Name = "testView";
            this.testView.Size = new System.Drawing.Size(627, 335);
            this.testView.TabIndex = 0;
            this.testView.UseCompatibleStateImageBehavior = false;
            // 
            // ChapeauUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.testView);
            this.Name = "ChapeauUI";
            this.Text = "Chapeau";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView testView;
    }
}

