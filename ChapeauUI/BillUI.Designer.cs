
namespace ChapeauUI
{
    partial class BillUI
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
            this.buttonLunch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLunch
            // 
            this.buttonLunch.BackColor = System.Drawing.Color.Transparent;
            this.buttonLunch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonLunch.FlatAppearance.BorderSize = 10;
            this.buttonLunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLunch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonLunch.Location = new System.Drawing.Point(47, 32);
            this.buttonLunch.Margin = new System.Windows.Forms.Padding(60);
            this.buttonLunch.Name = "buttonLunch";
            this.buttonLunch.Size = new System.Drawing.Size(616, 95);
            this.buttonLunch.TabIndex = 1;
            this.buttonLunch.Text = "Bill table nr";
            this.buttonLunch.UseVisualStyleBackColor = false;
            // 
            // BillUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 1055);
            this.Controls.Add(this.buttonLunch);
            this.Name = "BillUI";
            this.Text = "BillUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLunch;
    }
}