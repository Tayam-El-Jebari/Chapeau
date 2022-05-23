
namespace ChapeauUI
{
    partial class BarOverview
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
            this.label1 = new System.Windows.Forms.Label();
            this.barListView = new System.Windows.Forms.ListView();
            this.finishedDrinkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bar";
            // 
            // barListView
            // 
            this.barListView.HideSelection = false;
            this.barListView.Location = new System.Drawing.Point(12, 78);
            this.barListView.Name = "barListView";
            this.barListView.Size = new System.Drawing.Size(160, 80);
            this.barListView.TabIndex = 2;
            this.barListView.UseCompatibleStateImageBehavior = false;
            this.barListView.SelectedIndexChanged += new System.EventHandler(this.barListView_SelectedIndexChanged);
            // 
            // finishedDrinkButton
            // 
            this.finishedDrinkButton.Location = new System.Drawing.Point(12, 413);
            this.finishedDrinkButton.Name = "finishedDrinkButton";
            this.finishedDrinkButton.Size = new System.Drawing.Size(776, 29);
            this.finishedDrinkButton.TabIndex = 3;
            this.finishedDrinkButton.Text = "Drink is ready to be served";
            this.finishedDrinkButton.UseVisualStyleBackColor = true;
            this.finishedDrinkButton.Click += new System.EventHandler(this.finishedDrinkButton_Click);
            // 
            // BarOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.finishedDrinkButton);
            this.Controls.Add(this.barListView);
            this.Controls.Add(this.label1);
            this.Name = "BarOverview";
            this.Text = "BarOverview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView barListView;
        private System.Windows.Forms.Button finishedDrinkButton;
    }
}