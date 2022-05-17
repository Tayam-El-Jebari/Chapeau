
namespace ChapeauUI
{
    partial class KitchenOverview
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
            this.kitchenListView = new System.Windows.Forms.ListView();
            this.finishedFoodButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kitchen";
            // 
            // kitchenListView
            // 
            this.kitchenListView.HideSelection = false;
            this.kitchenListView.Location = new System.Drawing.Point(12, 78);
            this.kitchenListView.Name = "kitchenListView";
            this.kitchenListView.Size = new System.Drawing.Size(776, 329);
            this.kitchenListView.TabIndex = 1;
            this.kitchenListView.UseCompatibleStateImageBehavior = false;
            this.kitchenListView.SelectedIndexChanged += new System.EventHandler(this.kitchenListView_SelectedIndexChanged);
            // 
            // finishedFoodButton
            // 
            this.finishedFoodButton.Location = new System.Drawing.Point(12, 413);
            this.finishedFoodButton.Name = "finishedFoodButton";
            this.finishedFoodButton.Size = new System.Drawing.Size(776, 29);
            this.finishedFoodButton.TabIndex = 2;
            this.finishedFoodButton.Text = "Food is ready to be served\r\n";
            this.finishedFoodButton.UseVisualStyleBackColor = true;
            this.finishedFoodButton.Click += new System.EventHandler(this.finishedFoodButton_Click);
            // 
            // KitchenOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.finishedFoodButton);
            this.Controls.Add(this.kitchenListView);
            this.Controls.Add(this.label1);
            this.Name = "KitchenOverview";
            this.Text = "KitchenOverview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView kitchenListView;
        private System.Windows.Forms.Button finishedFoodButton;
    }
}