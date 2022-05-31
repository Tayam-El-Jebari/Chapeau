
namespace ChapeauUI
{
    partial class KitchenAndBarOverview
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
            this.components = new System.ComponentModel.Container();
            this.labelKitchen = new System.Windows.Forms.Label();
            this.kitchenListView = new System.Windows.Forms.ListView();
            this.finishedFoodButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.barListView = new System.Windows.Forms.ListView();
            this.labelBar = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.finishedDrinkButton = new System.Windows.Forms.Button();
            this.radioButtonKitchen = new System.Windows.Forms.RadioButton();
            this.radioButtonBar = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelKitchen
            // 
            this.labelKitchen.AutoSize = true;
            this.labelKitchen.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelKitchen.Location = new System.Drawing.Point(12, 9);
            this.labelKitchen.Name = "labelKitchen";
            this.labelKitchen.Size = new System.Drawing.Size(116, 41);
            this.labelKitchen.TabIndex = 0;
            this.labelKitchen.Text = "Kitchen";
            // 
            // kitchenListView
            // 
            this.kitchenListView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kitchenListView.FullRowSelect = true;
            this.kitchenListView.HideSelection = false;
            this.kitchenListView.Location = new System.Drawing.Point(12, 78);
            this.kitchenListView.Name = "kitchenListView";
            this.kitchenListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kitchenListView.Size = new System.Drawing.Size(1500, 750);
            this.kitchenListView.TabIndex = 1;
            this.kitchenListView.UseCompatibleStateImageBehavior = false;
            this.kitchenListView.SelectedIndexChanged += new System.EventHandler(this.kitchenListView_SelectedIndexChanged);
            // 
            // finishedFoodButton
            // 
            this.finishedFoodButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.finishedFoodButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.finishedFoodButton.Location = new System.Drawing.Point(1313, 845);
            this.finishedFoodButton.Name = "finishedFoodButton";
            this.finishedFoodButton.Size = new System.Drawing.Size(199, 49);
            this.finishedFoodButton.TabIndex = 2;
            this.finishedFoodButton.Text = "Food is ready to be served\r\n";
            this.finishedFoodButton.UseVisualStyleBackColor = false;
            this.finishedFoodButton.Click += new System.EventHandler(this.finishedFoodButton_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLogOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLogOut.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonLogOut.Location = new System.Drawing.Point(-13, 955);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(141, 85);
            this.buttonLogOut.TabIndex = 3;
            this.buttonLogOut.Text = "<";
            this.buttonLogOut.UseVisualStyleBackColor = false;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // barListView
            // 
            this.barListView.HideSelection = false;
            this.barListView.Location = new System.Drawing.Point(12, 78);
            this.barListView.Name = "barListView";
            this.barListView.Size = new System.Drawing.Size(1500, 750);
            this.barListView.TabIndex = 4;
            this.barListView.UseCompatibleStateImageBehavior = false;
            this.barListView.SelectedIndexChanged += new System.EventHandler(this.barListView_SelectedIndexChanged);
            // 
            // labelBar
            // 
            this.labelBar.AutoSize = true;
            this.labelBar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBar.Location = new System.Drawing.Point(12, 9);
            this.labelBar.Name = "labelBar";
            this.labelBar.Size = new System.Drawing.Size(60, 41);
            this.labelBar.TabIndex = 5;
            this.labelBar.Text = "Bar";
            // 
            // finishedDrinkButton
            // 
            this.finishedDrinkButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.finishedDrinkButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.finishedDrinkButton.Location = new System.Drawing.Point(1313, 845);
            this.finishedDrinkButton.Name = "finishedDrinkButton";
            this.finishedDrinkButton.Size = new System.Drawing.Size(199, 49);
            this.finishedDrinkButton.TabIndex = 6;
            this.finishedDrinkButton.Text = "Drink is ready to be served";
            this.finishedDrinkButton.UseVisualStyleBackColor = false;
            this.finishedDrinkButton.Click += new System.EventHandler(this.finishedDrinkButton_Click);
            // 
            // radioButtonKitchen
            // 
            this.radioButtonKitchen.AutoSize = true;
            this.radioButtonKitchen.Location = new System.Drawing.Point(597, 24);
            this.radioButtonKitchen.Name = "radioButtonKitchen";
            this.radioButtonKitchen.Size = new System.Drawing.Size(79, 24);
            this.radioButtonKitchen.TabIndex = 7;
            this.radioButtonKitchen.TabStop = true;
            this.radioButtonKitchen.Text = "Kitchen";
            this.radioButtonKitchen.UseVisualStyleBackColor = true;
            this.radioButtonKitchen.CheckedChanged += new System.EventHandler(this.radioButtonKitchen_CheckedChanged);
            // 
            // radioButtonBar
            // 
            this.radioButtonBar.AutoSize = true;
            this.radioButtonBar.Location = new System.Drawing.Point(597, 54);
            this.radioButtonBar.Name = "radioButtonBar";
            this.radioButtonBar.Size = new System.Drawing.Size(52, 24);
            this.radioButtonBar.TabIndex = 8;
            this.radioButtonBar.TabStop = true;
            this.radioButtonBar.Text = "Bar";
            this.radioButtonBar.UseVisualStyleBackColor = true;
            this.radioButtonBar.CheckedChanged += new System.EventHandler(this.radioButtonBar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(124, 959);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1806, 81);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // KitchenAndBarOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::ChapeauUI.Properties.Resources.winebgdesktop;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1033);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonBar);
            this.Controls.Add(this.radioButtonKitchen);
            this.Controls.Add(this.finishedDrinkButton);
            this.Controls.Add(this.labelBar);
            this.Controls.Add(this.barListView);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.finishedFoodButton);
            this.Controls.Add(this.kitchenListView);
            this.Controls.Add(this.labelKitchen);
            this.DoubleBuffered = true;
            this.Name = "KitchenAndBarOverview";
            this.Text = "KitchenOverview";
            this.Load += new System.EventHandler(this.KitchenOverview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelKitchen;
        private System.Windows.Forms.ListView kitchenListView;
        private System.Windows.Forms.Button finishedFoodButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.ListView barListView;
        private System.Windows.Forms.Label labelBar;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button finishedDrinkButton;
        private System.Windows.Forms.RadioButton radioButtonKitchen;
        private System.Windows.Forms.RadioButton radioButtonBar;
        private System.Windows.Forms.Label label1;
    }
}