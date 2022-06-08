
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
            this.finishedDrinkButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.foodButtonOrder = new System.Windows.Forms.Button();
            this.foodButtonAmount = new System.Windows.Forms.Button();
            this.foodButtonComments = new System.Windows.Forms.Button();
            this.foodButtonTable = new System.Windows.Forms.Button();
            this.foodButtonDuration = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonSortForwards = new System.Windows.Forms.RadioButton();
            this.radioButtonSortBackwards = new System.Windows.Forms.RadioButton();
            this.listViewComments = new System.Windows.Forms.ListView();
            this.progressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelKitchen
            // 
            this.labelKitchen.AutoSize = true;
            this.labelKitchen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.labelKitchen.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelKitchen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelKitchen.Location = new System.Drawing.Point(13, 9);
            this.labelKitchen.Name = "labelKitchen";
            this.labelKitchen.Size = new System.Drawing.Size(117, 38);
            this.labelKitchen.TabIndex = 0;
            this.labelKitchen.Text = "Kitchen";
            // 
            // kitchenListView
            // 
            this.kitchenListView.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kitchenListView.FullRowSelect = true;
            this.kitchenListView.HideSelection = false;
            this.kitchenListView.Location = new System.Drawing.Point(13, 79);
            this.kitchenListView.Name = "kitchenListView";
            this.kitchenListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kitchenListView.Size = new System.Drawing.Size(1500, 750);
            this.kitchenListView.TabIndex = 1;
            this.kitchenListView.UseCompatibleStateImageBehavior = false;
            this.kitchenListView.SelectedIndexChanged += new System.EventHandler(this.kitchenListview_SelectedIndexChanged);
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
            this.buttonLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
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
            this.barListView.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.barListView.HideSelection = false;
            this.barListView.Location = new System.Drawing.Point(13, 79);
            this.barListView.Name = "barListView";
            this.barListView.Size = new System.Drawing.Size(1500, 750);
            this.barListView.TabIndex = 4;
            this.barListView.UseCompatibleStateImageBehavior = false;
            this.barListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.barListView_DrawColumnHeader);
            this.barListView.SelectedIndexChanged += new System.EventHandler(this.barListView_SelectedIndexChanged);
            // 
            // labelBar
            // 
            this.labelBar.AutoSize = true;
            this.labelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.labelBar.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelBar.Location = new System.Drawing.Point(12, 9);
            this.labelBar.Name = "labelBar";
            this.labelBar.Size = new System.Drawing.Size(62, 38);
            this.labelBar.TabIndex = 5;
            this.labelBar.Text = "Bar";
            // 
            // finishedDrinkButton
            // 
            this.finishedDrinkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.finishedDrinkButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.finishedDrinkButton.Location = new System.Drawing.Point(1313, 845);
            this.finishedDrinkButton.Name = "finishedDrinkButton";
            this.finishedDrinkButton.Size = new System.Drawing.Size(199, 49);
            this.finishedDrinkButton.TabIndex = 6;
            this.finishedDrinkButton.Text = "Drink is ready to be served";
            this.finishedDrinkButton.UseVisualStyleBackColor = false;
            this.finishedDrinkButton.Click += new System.EventHandler(this.finishedDrinkButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label1.Location = new System.Drawing.Point(124, 959);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1806, 81);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label2.Location = new System.Drawing.Point(-13, -5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1931, 81);
            this.label2.TabIndex = 12;
            this.label2.Text = "labelHeader";
            // 
            // foodButtonOrder
            // 
            this.foodButtonOrder.FlatAppearance.BorderSize = 4;
            this.foodButtonOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodButtonOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.foodButtonOrder.Location = new System.Drawing.Point(1750, 243);
            this.foodButtonOrder.Name = "foodButtonOrder";
            this.foodButtonOrder.Size = new System.Drawing.Size(126, 63);
            this.foodButtonOrder.TabIndex = 15;
            this.foodButtonOrder.Text = "Order";
            this.foodButtonOrder.UseVisualStyleBackColor = true;
            this.foodButtonOrder.Click += new System.EventHandler(this.foodButtonOrder_Click);
            // 
            // foodButtonAmount
            // 
            this.foodButtonAmount.BackColor = System.Drawing.SystemColors.Control;
            this.foodButtonAmount.FlatAppearance.BorderSize = 4;
            this.foodButtonAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodButtonAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.foodButtonAmount.Location = new System.Drawing.Point(1558, 347);
            this.foodButtonAmount.Name = "foodButtonAmount";
            this.foodButtonAmount.Size = new System.Drawing.Size(126, 63);
            this.foodButtonAmount.TabIndex = 16;
            this.foodButtonAmount.Text = "Amount of order";
            this.foodButtonAmount.UseVisualStyleBackColor = false;
            this.foodButtonAmount.Click += new System.EventHandler(this.foodButtonAmount_Click);
            // 
            // foodButtonComments
            // 
            this.foodButtonComments.FlatAppearance.BorderSize = 4;
            this.foodButtonComments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodButtonComments.Location = new System.Drawing.Point(1558, 450);
            this.foodButtonComments.Name = "foodButtonComments";
            this.foodButtonComments.Size = new System.Drawing.Size(126, 63);
            this.foodButtonComments.TabIndex = 18;
            this.foodButtonComments.Text = "Comments";
            this.foodButtonComments.UseVisualStyleBackColor = true;
            this.foodButtonComments.Click += new System.EventHandler(this.foodButtonComments_Click);
            // 
            // foodButtonTable
            // 
            this.foodButtonTable.FlatAppearance.BorderSize = 4;
            this.foodButtonTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodButtonTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.foodButtonTable.Location = new System.Drawing.Point(1750, 347);
            this.foodButtonTable.Name = "foodButtonTable";
            this.foodButtonTable.Size = new System.Drawing.Size(126, 63);
            this.foodButtonTable.TabIndex = 19;
            this.foodButtonTable.Text = "Table";
            this.foodButtonTable.UseVisualStyleBackColor = true;
            this.foodButtonTable.Click += new System.EventHandler(this.foodButtonTable_Click);
            // 
            // foodButtonDuration
            // 
            this.foodButtonDuration.FlatAppearance.BorderSize = 4;
            this.foodButtonDuration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodButtonDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.foodButtonDuration.Location = new System.Drawing.Point(1750, 450);
            this.foodButtonDuration.Name = "foodButtonDuration";
            this.foodButtonDuration.Size = new System.Drawing.Size(126, 63);
            this.foodButtonDuration.TabIndex = 20;
            this.foodButtonDuration.Text = "Duration of Order";
            this.foodButtonDuration.UseVisualStyleBackColor = true;
            this.foodButtonDuration.Click += new System.EventHandler(this.foodButtonDuration_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1558, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 38);
            this.label3.TabIndex = 22;
            this.label3.Text = "Sort by\r\n";
            // 
            // radioButtonSortForwards
            // 
            this.radioButtonSortForwards.AutoSize = true;
            this.radioButtonSortForwards.Location = new System.Drawing.Point(1558, 536);
            this.radioButtonSortForwards.Name = "radioButtonSortForwards";
            this.radioButtonSortForwards.Size = new System.Drawing.Size(115, 44);
            this.radioButtonSortForwards.TabIndex = 28;
            this.radioButtonSortForwards.TabStop = true;
            this.radioButtonSortForwards.Text = "Sort forward\r\ns";
            this.radioButtonSortForwards.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortBackwards
            // 
            this.radioButtonSortBackwards.AutoSize = true;
            this.radioButtonSortBackwards.Location = new System.Drawing.Point(1750, 536);
            this.radioButtonSortBackwards.Name = "radioButtonSortBackwards";
            this.radioButtonSortBackwards.Size = new System.Drawing.Size(132, 24);
            this.radioButtonSortBackwards.TabIndex = 29;
            this.radioButtonSortBackwards.TabStop = true;
            this.radioButtonSortBackwards.Text = "Sort backwards\r\n";
            this.radioButtonSortBackwards.UseVisualStyleBackColor = true;
            // 
            // listViewComments
            // 
            this.listViewComments.HideSelection = false;
            this.listViewComments.Location = new System.Drawing.Point(12, 835);
            this.listViewComments.Name = "listViewComments";
            this.listViewComments.Size = new System.Drawing.Size(1295, 121);
            this.listViewComments.TabIndex = 30;
            this.listViewComments.UseCompatibleStateImageBehavior = false;
            // 
            // progressBarUpdate
            // 
            this.progressBarUpdate.BackColor = System.Drawing.Color.White;
            this.progressBarUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.progressBarUpdate.Location = new System.Drawing.Point(13, 75);
            this.progressBarUpdate.Name = "progressBarUpdate";
            this.progressBarUpdate.Size = new System.Drawing.Size(1500, 10);
            this.progressBarUpdate.TabIndex = 31;
            // 
            // KitchenAndBarOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::ChapeauUI.Properties.Resources.winebgdesktop;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1033);
            this.Controls.Add(this.progressBarUpdate);
            this.Controls.Add(this.listViewComments);
            this.Controls.Add(this.radioButtonSortBackwards);
            this.Controls.Add(this.radioButtonSortForwards);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.foodButtonDuration);
            this.Controls.Add(this.foodButtonTable);
            this.Controls.Add(this.foodButtonComments);
            this.Controls.Add(this.foodButtonAmount);
            this.Controls.Add(this.foodButtonOrder);
            this.Controls.Add(this.labelKitchen);
            this.Controls.Add(this.labelBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.finishedDrinkButton);
            this.Controls.Add(this.barListView);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.finishedFoodButton);
            this.Controls.Add(this.kitchenListView);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
        private System.Windows.Forms.Button finishedDrinkButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button foodButtonOrder;
        private System.Windows.Forms.Button foodButtonAmount;
        private System.Windows.Forms.Button foodButtonComments;
        private System.Windows.Forms.Button foodButtonTable;
        private System.Windows.Forms.Button foodButtonDuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonSortForwards;
        private System.Windows.Forms.RadioButton radioButtonSortBackwards;
        private System.Windows.Forms.ListView listViewComments;
        private System.Windows.Forms.ProgressBar progressBarUpdate;
    }
}