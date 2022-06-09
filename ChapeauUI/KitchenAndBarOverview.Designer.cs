
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
            this.labelBottomBar = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labelTopBar = new System.Windows.Forms.Label();
            this.foodButtonOrder = new System.Windows.Forms.Button();
            this.foodButtonAmount = new System.Windows.Forms.Button();
            this.foodButtonComments = new System.Windows.Forms.Button();
            this.foodButtonTable = new System.Windows.Forms.Button();
            this.foodButtonDuration = new System.Windows.Forms.Button();
            this.labelLabelSortBy = new System.Windows.Forms.Label();
            this.radioButtonSortForwards = new System.Windows.Forms.RadioButton();
            this.radioButtonSortBackwards = new System.Windows.Forms.RadioButton();
            this.listViewComments = new System.Windows.Forms.ListView();
            this.progressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.buttonSortByAlcoholic = new System.Windows.Forms.Button();
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
            this.kitchenListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
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
            this.finishedFoodButton.BackColor = System.Drawing.SystemColors.Control;
            this.finishedFoodButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.finishedFoodButton.FlatAppearance.BorderSize = 4;
            this.finishedFoodButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finishedFoodButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.finishedFoodButton.Location = new System.Drawing.Point(1313, 845);
            this.finishedFoodButton.Name = "finishedFoodButton";
            this.finishedFoodButton.Size = new System.Drawing.Size(206, 49);
            this.finishedFoodButton.TabIndex = 2;
            this.finishedFoodButton.Text = "Food is ready to be served\r\n";
            this.finishedFoodButton.UseVisualStyleBackColor = false;
            this.finishedFoodButton.Click += new System.EventHandler(this.finishedFoodButton_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonLogOut.Font = new System.Drawing.Font("Trebuchet MS", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.barListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
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
            this.finishedDrinkButton.BackColor = System.Drawing.SystemColors.Control;
            this.finishedDrinkButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.finishedDrinkButton.FlatAppearance.BorderSize = 4;
            this.finishedDrinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finishedDrinkButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.finishedDrinkButton.Location = new System.Drawing.Point(1313, 845);
            this.finishedDrinkButton.Name = "finishedDrinkButton";
            this.finishedDrinkButton.Size = new System.Drawing.Size(206, 49);
            this.finishedDrinkButton.TabIndex = 6;
            this.finishedDrinkButton.Text = "Drink is ready to be served";
            this.finishedDrinkButton.UseVisualStyleBackColor = false;
            this.finishedDrinkButton.Click += new System.EventHandler(this.finishedDrinkButton_Click);
            // 
            // labelBottomBar
            // 
            this.labelBottomBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.labelBottomBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.labelBottomBar.Location = new System.Drawing.Point(124, 959);
            this.labelBottomBar.Name = "labelBottomBar";
            this.labelBottomBar.Size = new System.Drawing.Size(1806, 81);
            this.labelBottomBar.TabIndex = 9;
            this.labelBottomBar.Text = "label1";
            // 
            // labelTopBar
            // 
            this.labelTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.labelTopBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.labelTopBar.Location = new System.Drawing.Point(-13, -5);
            this.labelTopBar.Name = "labelTopBar";
            this.labelTopBar.Size = new System.Drawing.Size(1931, 81);
            this.labelTopBar.TabIndex = 12;
            this.labelTopBar.Text = "labelHeader";
            // 
            // foodButtonOrder
            // 
            this.foodButtonOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.foodButtonOrder.FlatAppearance.BorderSize = 4;
            this.foodButtonOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodButtonOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.foodButtonOrder.Location = new System.Drawing.Point(1558, 243);
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
            this.foodButtonAmount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
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
            this.foodButtonComments.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.foodButtonComments.FlatAppearance.BorderSize = 4;
            this.foodButtonComments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodButtonComments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
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
            this.foodButtonTable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
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
            this.foodButtonDuration.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
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
            // labelLabelSortBy
            // 
            this.labelLabelSortBy.AutoSize = true;
            this.labelLabelSortBy.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLabelSortBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.labelLabelSortBy.Location = new System.Drawing.Point(1558, 153);
            this.labelLabelSortBy.Name = "labelLabelSortBy";
            this.labelLabelSortBy.Size = new System.Drawing.Size(112, 38);
            this.labelLabelSortBy.TabIndex = 22;
            this.labelLabelSortBy.Text = "Sort by\r\n";
            // 
            // radioButtonSortForwards
            // 
            this.radioButtonSortForwards.AutoSize = true;
            this.radioButtonSortForwards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.radioButtonSortForwards.Location = new System.Drawing.Point(1558, 536);
            this.radioButtonSortForwards.Name = "radioButtonSortForwards";
            this.radioButtonSortForwards.Size = new System.Drawing.Size(121, 24);
            this.radioButtonSortForwards.TabIndex = 28;
            this.radioButtonSortForwards.TabStop = true;
            this.radioButtonSortForwards.Text = "Sort forwards";
            this.radioButtonSortForwards.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortBackwards
            // 
            this.radioButtonSortBackwards.AutoSize = true;
            this.radioButtonSortBackwards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
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
            this.listViewComments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
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
            // buttonSortByAlcoholic
            // 
            this.buttonSortByAlcoholic.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonSortByAlcoholic.FlatAppearance.BorderSize = 4;
            this.buttonSortByAlcoholic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSortByAlcoholic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonSortByAlcoholic.Location = new System.Drawing.Point(1750, 243);
            this.buttonSortByAlcoholic.Name = "buttonSortByAlcoholic";
            this.buttonSortByAlcoholic.Size = new System.Drawing.Size(126, 63);
            this.buttonSortByAlcoholic.TabIndex = 32;
            this.buttonSortByAlcoholic.Text = "Alcoholic";
            this.buttonSortByAlcoholic.UseVisualStyleBackColor = true;
            this.buttonSortByAlcoholic.Click += new System.EventHandler(this.buttonSortByAlcoholic_Click);
            // 
            // KitchenAndBarOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::ChapeauUI.Properties.Resources.winebgdesktop;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1033);
            this.Controls.Add(this.buttonSortByAlcoholic);
            this.Controls.Add(this.progressBarUpdate);
            this.Controls.Add(this.listViewComments);
            this.Controls.Add(this.radioButtonSortBackwards);
            this.Controls.Add(this.radioButtonSortForwards);
            this.Controls.Add(this.labelLabelSortBy);
            this.Controls.Add(this.foodButtonDuration);
            this.Controls.Add(this.foodButtonTable);
            this.Controls.Add(this.foodButtonComments);
            this.Controls.Add(this.foodButtonAmount);
            this.Controls.Add(this.foodButtonOrder);
            this.Controls.Add(this.labelKitchen);
            this.Controls.Add(this.labelBar);
            this.Controls.Add(this.labelBottomBar);
            this.Controls.Add(this.finishedDrinkButton);
            this.Controls.Add(this.barListView);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.finishedFoodButton);
            this.Controls.Add(this.kitchenListView);
            this.Controls.Add(this.labelTopBar);
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
        private System.Windows.Forms.Label labelBottomBar;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labelTopBar;
        private System.Windows.Forms.Button foodButtonOrder;
        private System.Windows.Forms.Button foodButtonAmount;
        private System.Windows.Forms.Button foodButtonComments;
        private System.Windows.Forms.Button foodButtonTable;
        private System.Windows.Forms.Button foodButtonDuration;
        private System.Windows.Forms.Label labelLabelSortBy;
        private System.Windows.Forms.RadioButton radioButtonSortForwards;
        private System.Windows.Forms.RadioButton radioButtonSortBackwards;
        private System.Windows.Forms.ListView listViewComments;
        private System.Windows.Forms.ProgressBar progressBarUpdate;
        private System.Windows.Forms.Button buttonSortByAlcoholic;
    }
}