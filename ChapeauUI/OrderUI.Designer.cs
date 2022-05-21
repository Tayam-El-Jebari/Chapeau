
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
            this.panelOrders = new System.Windows.Forms.Panel();
            this.itemAddedOrderPnl = new System.Windows.Forms.Panel();
            this.commentsTextBox = new System.Windows.Forms.RichTextBox();
            this.labelCommentsTitle = new System.Windows.Forms.Label();
            this.itemGridView = new System.Windows.Forms.DataGridView();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.viewOrders = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.FlowLayoutPanel();
            this.lunchDinnerLabel = new System.Windows.Forms.Label();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.panelOrders.SuspendLayout();
            this.itemAddedOrderPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelOrders
            // 
            this.panelOrders.BackgroundImage = global::ChapeauUI.Properties.Resources.achtergrond;
            this.panelOrders.Controls.Add(this.itemAddedOrderPnl);
            this.panelOrders.Controls.Add(this.viewOrders);
            this.panelOrders.Controls.Add(this.menu);
            this.panelOrders.Controls.Add(this.lunchDinnerLabel);
            this.panelOrders.Location = new System.Drawing.Point(-2, -2);
            this.panelOrders.Name = "panelOrders";
            this.panelOrders.Size = new System.Drawing.Size(681, 1440);
            this.panelOrders.TabIndex = 1;
            this.panelOrders.Paint += new System.Windows.Forms.PaintEventHandler(this.panelOrders_Paint);
            // 
            // itemAddedOrderPnl
            // 
            this.itemAddedOrderPnl.AutoScroll = true;
            this.itemAddedOrderPnl.BackgroundImage = global::ChapeauUI.Properties.Resources.achtergrond;
            this.itemAddedOrderPnl.Controls.Add(this.commentsTextBox);
            this.itemAddedOrderPnl.Controls.Add(this.labelCommentsTitle);
            this.itemAddedOrderPnl.Controls.Add(this.itemGridView);
            this.itemAddedOrderPnl.Controls.Add(this.clearAllButton);
            this.itemAddedOrderPnl.Controls.Add(this.buttonCreateOrder);
            this.itemAddedOrderPnl.Location = new System.Drawing.Point(1, 115);
            this.itemAddedOrderPnl.Name = "itemAddedOrderPnl";
            this.itemAddedOrderPnl.Size = new System.Drawing.Size(678, 940);
            this.itemAddedOrderPnl.TabIndex = 4;
            this.itemAddedOrderPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.itemAddedOrderPnl_Paint);
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.commentsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.commentsTextBox.Location = new System.Drawing.Point(31, 588);
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(627, 209);
            this.commentsTextBox.TabIndex = 7;
            this.commentsTextBox.Text = "";
            // 
            // labelCommentsTitle
            // 
            this.labelCommentsTitle.AutoSize = true;
            this.labelCommentsTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelCommentsTitle.Font = new System.Drawing.Font("Cabin", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCommentsTitle.Location = new System.Drawing.Point(10, 539);
            this.labelCommentsTitle.Name = "labelCommentsTitle";
            this.labelCommentsTitle.Size = new System.Drawing.Size(140, 37);
            this.labelCommentsTitle.TabIndex = 5;
            this.labelCommentsTitle.Text = "Comments:";
            // 
            // itemGridView
            // 
            this.itemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGridView.Location = new System.Drawing.Point(-1, 6);
            this.itemGridView.Name = "itemGridView";
            this.itemGridView.RowHeadersWidth = 51;
            this.itemGridView.RowTemplate.Height = 29;
            this.itemGridView.Size = new System.Drawing.Size(679, 532);
            this.itemGridView.TabIndex = 4;
            this.itemGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemGridView_CellClick);
            // 
            // clearAllButton
            // 
            this.clearAllButton.Location = new System.Drawing.Point(463, 825);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(202, 97);
            this.clearAllButton.TabIndex = 1;
            this.clearAllButton.Text = "Clear all";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // viewOrders
            // 
            this.viewOrders.Location = new System.Drawing.Point(540, 5);
            this.viewOrders.Name = "viewOrders";
            this.viewOrders.Size = new System.Drawing.Size(126, 104);
            this.viewOrders.TabIndex = 3;
            this.viewOrders.Text = "View Orders";
            this.viewOrders.UseVisualStyleBackColor = true;
            this.viewOrders.Click += new System.EventHandler(this.viewOrders_Click);
            // 
            // menu
            // 
            this.menu.BackgroundImage = global::ChapeauUI.Properties.Resources.achtergrond;
            this.menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menu.Location = new System.Drawing.Point(0, 115);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(681, 1440);
            this.menu.TabIndex = 2;
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
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(31, 825);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(202, 97);
            this.buttonCreateOrder.TabIndex = 8;
            this.buttonCreateOrder.Text = "Create order";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // OrderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(702, 1055);
            this.Controls.Add(this.panelOrders);
            this.Name = "OrderUI";
            this.Text = "OrderUI";
            this.panelOrders.ResumeLayout(false);
            this.itemAddedOrderPnl.ResumeLayout(false);
            this.itemAddedOrderPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelOrders;
        private System.Windows.Forms.Label lunchDinnerLabel;
        private System.Windows.Forms.FlowLayoutPanel menu;
        private System.Windows.Forms.Button viewOrders;
        private System.Windows.Forms.Panel itemAddedOrderPnl;
        private System.Windows.Forms.RichTextBox commentsTextBox;
        private System.Windows.Forms.Label labelCommentsTitle;
        private System.Windows.Forms.DataGridView itemGridView;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.Button buttonCreateOrder;
    }
}