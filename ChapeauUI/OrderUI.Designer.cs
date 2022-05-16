
namespace ChapeauUI
{
    partial class OrderUI
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lunchDinnerLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Cabin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(274, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(355, 87);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lunchDinnerLabel);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 1440);
            this.panel1.TabIndex = 1;
            // 
            // lunchDinnerLabel
            // 
            this.lunchDinnerLabel.BackColor = System.Drawing.Color.Transparent;
            this.lunchDinnerLabel.Font = new System.Drawing.Font("Cabin", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lunchDinnerLabel.Location = new System.Drawing.Point(14, 20);
            this.lunchDinnerLabel.Name = "lunchDinnerLabel";
            this.lunchDinnerLabel.Padding = new System.Windows.Forms.Padding(20);
            this.lunchDinnerLabel.Size = new System.Drawing.Size(520, 81);
            this.lunchDinnerLabel.TabIndex = 1;
            this.lunchDinnerLabel.Text = "LUNCH 11:00 - 16:00";
            this.lunchDinnerLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.lunchDinnerLabel_Paint);
            // 
            // OrderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(702, 1055);
            this.Controls.Add(this.panel1);
            this.Name = "OrderUI";
            this.Text = "OrderUI";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OrderUI_Paint);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lunchDinnerLabel;
    }
}