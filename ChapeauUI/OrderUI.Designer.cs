
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
            this.itemGridView = new System.Windows.Forms.DataGridView();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.viewOrders = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.FlowLayoutPanel();
            this.lunchDinnerLabel = new System.Windows.Forms.Label();
            this.panelOrders.SuspendLayout();
            this.itemAddedOrderPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelOrders
            // 
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
            this.itemAddedOrderPnl.Controls.Add(this.itemGridView);
            this.itemAddedOrderPnl.Controls.Add(this.buttonRemoveItem);
            this.itemAddedOrderPnl.Controls.Add(this.buttonCreateOrder);
            this.itemAddedOrderPnl.Controls.Add(this.clearAllButton);
            this.itemAddedOrderPnl.Location = new System.Drawing.Point(1, 129);
            this.itemAddedOrderPnl.Name = "itemAddedOrderPnl";
            this.itemAddedOrderPnl.Size = new System.Drawing.Size(678, 712);
            this.itemAddedOrderPnl.TabIndex = 4;
            // 
            // itemGridView
            // 
            this.itemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGridView.Location = new System.Drawing.Point(-1, 3);
            this.itemGridView.Name = "itemGridView";
            this.itemGridView.RowHeadersWidth = 51;
            this.itemGridView.RowTemplate.Height = 29;
            this.itemGridView.Size = new System.Drawing.Size(679, 523);
            this.itemGridView.TabIndex = 4;
            this.itemGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemGridView_CellClick);
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.Location = new System.Drawing.Point(194, 551);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(243, 71);
            this.buttonRemoveItem.TabIndex = 3;
            this.buttonRemoveItem.Text = "Remove Item";
            this.buttonRemoveItem.UseVisualStyleBackColor = true;
            this.buttonRemoveItem.Click += new System.EventHandler(this.buttonRemoveItem_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(3, 645);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(140, 55);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Create Order";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            // 
            // clearAllButton
            // 
            this.clearAllButton.Location = new System.Drawing.Point(516, 645);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(140, 55);
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
            this.menu.Location = new System.Drawing.Point(0, 115);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(671, 1325);
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
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelOrders;
        private System.Windows.Forms.Label lunchDinnerLabel;
        private System.Windows.Forms.FlowLayoutPanel menu;
        private System.Windows.Forms.Button viewOrders;
        private System.Windows.Forms.Panel itemAddedOrderPnl;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.DataGridView itemGridView;
    }
}