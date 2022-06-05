
namespace ChapeauUI
{
    public partial class OrderUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelItems = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.bottomBarLabel = new System.Windows.Forms.Label();
            this.PanelChooseMenu = new System.Windows.Forms.Panel();
            this.labelTable = new System.Windows.Forms.Label();
            this.buttonLunch = new System.Windows.Forms.Button();
            this.buttonDinner = new System.Windows.Forms.Button();
            this.buttonDrinks = new System.Windows.Forms.Button();
            this.panelSelectMenu = new System.Windows.Forms.Panel();
            this.labelSelectMenu = new System.Windows.Forms.Label();
            this.buttonDesserts = new System.Windows.Forms.Button();
            this.buttonMainCourse = new System.Windows.Forms.Button();
            this.buttonStarters = new System.Windows.Forms.Button();
            this.itemAddedOrderPnl = new System.Windows.Forms.Panel();
            this.itemGridView = new System.Windows.Forms.DataGridView();
            this.MenuItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentsTextBox = new System.Windows.Forms.RichTextBox();
            this.labelCommentsTitle = new System.Windows.Forms.Label();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.viewOrder = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.FlowLayoutPanel();
            this.labelSelectedMenuName = new System.Windows.Forms.Label();
            this.labelTitleItems = new System.Windows.Forms.Label();
            this.labelBorder = new System.Windows.Forms.Label();
            this.topBarLabel = new System.Windows.Forms.Label();
            this.panelItems.SuspendLayout();
            this.PanelChooseMenu.SuspendLayout();
            this.panelSelectMenu.SuspendLayout();
            this.itemAddedOrderPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelItems
            // 
            this.panelItems.BackColor = System.Drawing.Color.Transparent;
            this.panelItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelItems.Controls.Add(this.buttonBack);
            this.panelItems.Controls.Add(this.bottomBarLabel);
            this.panelItems.Controls.Add(this.PanelChooseMenu);
            this.panelItems.Controls.Add(this.panelSelectMenu);
            this.panelItems.Controls.Add(this.itemAddedOrderPnl);
            this.panelItems.Controls.Add(this.viewOrder);
            this.panelItems.Controls.Add(this.menu);
            this.panelItems.Controls.Add(this.labelSelectedMenuName);
            this.panelItems.Controls.Add(this.labelTitleItems);
            this.panelItems.Controls.Add(this.labelBorder);
            this.panelItems.Location = new System.Drawing.Point(-2, 50);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(700, 1440);
            this.panelItems.TabIndex = 1;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(0, 1370);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(163, 66);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "<BACK";
            this.buttonBack.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // bottomBarLabel
            // 
            this.bottomBarLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.bottomBarLabel.Location = new System.Drawing.Point(0, 1367);
            this.bottomBarLabel.Name = "bottomBarLabel";
            this.bottomBarLabel.Size = new System.Drawing.Size(699, 74);
            this.bottomBarLabel.TabIndex = 3;
            this.bottomBarLabel.Text = "emptyString";
            // 
            // PanelChooseMenu
            // 
            this.PanelChooseMenu.BackColor = System.Drawing.Color.Transparent;
            this.PanelChooseMenu.Controls.Add(this.labelTable);
            this.PanelChooseMenu.Controls.Add(this.buttonLunch);
            this.PanelChooseMenu.Controls.Add(this.buttonDinner);
            this.PanelChooseMenu.Controls.Add(this.buttonDrinks);
            this.PanelChooseMenu.Location = new System.Drawing.Point(1, 0);
            this.PanelChooseMenu.Name = "PanelChooseMenu";
            this.PanelChooseMenu.Size = new System.Drawing.Size(700, 1390);
            this.PanelChooseMenu.TabIndex = 5;
            // 
            // labelTable
            // 
            this.labelTable.AutoSize = true;
            this.labelTable.Font = new System.Drawing.Font("Trebuchet MS", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.labelTable.Location = new System.Drawing.Point(32, 55);
            this.labelTable.Name = "labelTable";
            this.labelTable.Size = new System.Drawing.Size(151, 54);
            this.labelTable.TabIndex = 1;
            this.labelTable.Text = "TABLE ";
            // 
            // buttonLunch
            // 
            this.buttonLunch.BackColor = System.Drawing.Color.Transparent;
            this.buttonLunch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonLunch.FlatAppearance.BorderSize = 10;
            this.buttonLunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLunch.Font = new System.Drawing.Font("Trebuchet MS", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLunch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonLunch.Location = new System.Drawing.Point(31, 151);
            this.buttonLunch.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLunch.Name = "buttonLunch";
            this.buttonLunch.Size = new System.Drawing.Size(616, 255);
            this.buttonLunch.TabIndex = 0;
            this.buttonLunch.Text = "LUNCH";
            this.buttonLunch.UseVisualStyleBackColor = true;
            this.buttonLunch.Click += new System.EventHandler(this.buttonChooseMenuAndMenuType_Click);
            // 
            // buttonDinner
            // 
            this.buttonDinner.BackColor = System.Drawing.Color.Transparent;
            this.buttonDinner.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonDinner.FlatAppearance.BorderSize = 10;
            this.buttonDinner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDinner.Font = new System.Drawing.Font("Trebuchet MS", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDinner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonDinner.Location = new System.Drawing.Point(32, 436);
            this.buttonDinner.Margin = new System.Windows.Forms.Padding(60);
            this.buttonDinner.Name = "buttonDinner";
            this.buttonDinner.Size = new System.Drawing.Size(616, 255);
            this.buttonDinner.TabIndex = 0;
            this.buttonDinner.Text = "DINNER";
            this.buttonDinner.UseVisualStyleBackColor = false;
            this.buttonDinner.Click += new System.EventHandler(this.buttonChooseMenuAndMenuType_Click);
            // 
            // buttonDrinks
            // 
            this.buttonDrinks.BackColor = System.Drawing.Color.Transparent;
            this.buttonDrinks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonDrinks.FlatAppearance.BorderSize = 10;
            this.buttonDrinks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrinks.Font = new System.Drawing.Font("Trebuchet MS", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDrinks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonDrinks.Location = new System.Drawing.Point(32, 716);
            this.buttonDrinks.Margin = new System.Windows.Forms.Padding(60);
            this.buttonDrinks.Name = "buttonDrinks";
            this.buttonDrinks.Size = new System.Drawing.Size(616, 255);
            this.buttonDrinks.TabIndex = 2;
            this.buttonDrinks.Text = "DRINKS";
            this.buttonDrinks.UseVisualStyleBackColor = false;
            this.buttonDrinks.Click += new System.EventHandler(this.buttonChooseMenuAndMenuType_Click);
            // 
            // panelSelectMenu
            // 
            this.panelSelectMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelSelectMenu.Controls.Add(this.labelSelectMenu);
            this.panelSelectMenu.Controls.Add(this.buttonDesserts);
            this.panelSelectMenu.Controls.Add(this.buttonMainCourse);
            this.panelSelectMenu.Controls.Add(this.buttonStarters);
            this.panelSelectMenu.Location = new System.Drawing.Point(2, 3);
            this.panelSelectMenu.Name = "panelSelectMenu";
            this.panelSelectMenu.Size = new System.Drawing.Size(700, 1390);
            this.panelSelectMenu.TabIndex = 6;
            // 
            // labelSelectMenu
            // 
            this.labelSelectMenu.AutoSize = true;
            this.labelSelectMenu.Font = new System.Drawing.Font("Trebuchet MS", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSelectMenu.Location = new System.Drawing.Point(30, 64);
            this.labelSelectMenu.Name = "labelSelectMenu";
            this.labelSelectMenu.Size = new System.Drawing.Size(284, 54);
            this.labelSelectMenu.TabIndex = 3;
            this.labelSelectMenu.Text = "SELECT MENU";
            // 
            // buttonDesserts
            // 
            this.buttonDesserts.BackColor = System.Drawing.Color.Transparent;
            this.buttonDesserts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonDesserts.FlatAppearance.BorderSize = 10;
            this.buttonDesserts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDesserts.Font = new System.Drawing.Font("Trebuchet MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDesserts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonDesserts.Location = new System.Drawing.Point(30, 713);
            this.buttonDesserts.Margin = new System.Windows.Forms.Padding(60);
            this.buttonDesserts.Name = "buttonDesserts";
            this.buttonDesserts.Size = new System.Drawing.Size(616, 255);
            this.buttonDesserts.TabIndex = 1;
            this.buttonDesserts.Text = "DESSERTS";
            this.buttonDesserts.UseVisualStyleBackColor = false;
            this.buttonDesserts.Click += new System.EventHandler(this.buttonChooseMenuAndMenuType_Click);
            // 
            // buttonMainCourse
            // 
            this.buttonMainCourse.BackColor = System.Drawing.Color.Transparent;
            this.buttonMainCourse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonMainCourse.FlatAppearance.BorderSize = 10;
            this.buttonMainCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMainCourse.Font = new System.Drawing.Font("Trebuchet MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonMainCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonMainCourse.Location = new System.Drawing.Point(30, 433);
            this.buttonMainCourse.Margin = new System.Windows.Forms.Padding(60);
            this.buttonMainCourse.Name = "buttonMainCourse";
            this.buttonMainCourse.Size = new System.Drawing.Size(616, 255);
            this.buttonMainCourse.TabIndex = 0;
            this.buttonMainCourse.Text = "MAIN COURSE";
            this.buttonMainCourse.UseVisualStyleBackColor = false;
            this.buttonMainCourse.Click += new System.EventHandler(this.buttonChooseMenuAndMenuType_Click);
            // 
            // buttonStarters
            // 
            this.buttonStarters.BackColor = System.Drawing.Color.Transparent;
            this.buttonStarters.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonStarters.FlatAppearance.BorderSize = 10;
            this.buttonStarters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStarters.Font = new System.Drawing.Font("Trebuchet MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStarters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonStarters.Location = new System.Drawing.Point(31, 151);
            this.buttonStarters.Margin = new System.Windows.Forms.Padding(60);
            this.buttonStarters.Name = "buttonStarters";
            this.buttonStarters.Size = new System.Drawing.Size(616, 255);
            this.buttonStarters.TabIndex = 0;
            this.buttonStarters.Text = "STARTERS";
            this.buttonStarters.UseVisualStyleBackColor = false;
            this.buttonStarters.Click += new System.EventHandler(this.buttonChooseMenuAndMenuType_Click);
            // 
            // itemAddedOrderPnl
            // 
            this.itemAddedOrderPnl.AutoScroll = true;
            this.itemAddedOrderPnl.BackColor = System.Drawing.Color.Transparent;
            this.itemAddedOrderPnl.Controls.Add(this.itemGridView);
            this.itemAddedOrderPnl.Controls.Add(this.commentsTextBox);
            this.itemAddedOrderPnl.Controls.Add(this.labelCommentsTitle);
            this.itemAddedOrderPnl.Controls.Add(this.clearAllButton);
            this.itemAddedOrderPnl.Controls.Add(this.buttonCreateOrder);
            this.itemAddedOrderPnl.Location = new System.Drawing.Point(10, 115);
            this.itemAddedOrderPnl.Name = "itemAddedOrderPnl";
            this.itemAddedOrderPnl.Size = new System.Drawing.Size(700, 1440);
            this.itemAddedOrderPnl.TabIndex = 4;
            this.itemAddedOrderPnl.Visible = false;
            this.itemAddedOrderPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.itemAddedOrderPnl_Paint);
            // 
            // itemGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(192)))), ((int)(((byte)(201)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(192)))), ((int)(((byte)(201)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.itemGridView.BackgroundColor = System.Drawing.Color.White;
            this.itemGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 14.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.itemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MenuItemId,
            this.productName,
            this.amount});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.itemGridView.EnableHeadersVisualStyles = false;
            this.itemGridView.GridColor = System.Drawing.Color.White;
            this.itemGridView.Location = new System.Drawing.Point(0, 0);
            this.itemGridView.MultiSelect = false;
            this.itemGridView.Name = "itemGridView";
            this.itemGridView.ReadOnly = true;
            this.itemGridView.RowHeadersVisible = false;
            this.itemGridView.RowHeadersWidth = 51;
            this.itemGridView.RowTemplate.Height = 29;
            this.itemGridView.Size = new System.Drawing.Size(700, 532);
            this.itemGridView.TabIndex = 4;
            this.itemGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemGridView_CellClick);
            // 
            // MenuItemId
            // 
            this.MenuItemId.HeaderText = "id";
            this.MenuItemId.MinimumWidth = 6;
            this.MenuItemId.Name = "MenuItemId";
            this.MenuItemId.ReadOnly = true;
            this.MenuItemId.Width = 50;
            // 
            // productName
            // 
            this.productName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productName.HeaderText = "name";
            this.productName.MinimumWidth = 6;
            this.productName.Name = "productName";
            this.productName.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.HeaderText = "amnt";
            this.amount.MinimumWidth = 6;
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 70;
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.commentsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.commentsTextBox.Location = new System.Drawing.Point(31, 583);
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(627, 213);
            this.commentsTextBox.TabIndex = 7;
            this.commentsTextBox.Text = "";
            // 
            // labelCommentsTitle
            // 
            this.labelCommentsTitle.AutoSize = true;
            this.labelCommentsTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelCommentsTitle.Font = new System.Drawing.Font("Trebuchet MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCommentsTitle.Location = new System.Drawing.Point(10, 539);
            this.labelCommentsTitle.Name = "labelCommentsTitle";
            this.labelCommentsTitle.Size = new System.Drawing.Size(141, 32);
            this.labelCommentsTitle.TabIndex = 5;
            this.labelCommentsTitle.Text = "Comments:";
            // 
            // clearAllButton
            // 
            this.clearAllButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.clearAllButton.FlatAppearance.BorderSize = 8;
            this.clearAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearAllButton.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clearAllButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.clearAllButton.Location = new System.Drawing.Point(31, 825);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(202, 97);
            this.clearAllButton.TabIndex = 1;
            this.clearAllButton.Text = "CLEAR ALL";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonCreateOrder.FlatAppearance.BorderSize = 8;
            this.buttonCreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateOrder.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCreateOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonCreateOrder.Location = new System.Drawing.Point(463, 825);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(202, 97);
            this.buttonCreateOrder.TabIndex = 8;
            this.buttonCreateOrder.Text = "CREATE ORDER";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // viewOrder
            // 
            this.viewOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.viewOrder.FlatAppearance.BorderSize = 3;
            this.viewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewOrder.Font = new System.Drawing.Font("Trebuchet MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viewOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.viewOrder.Location = new System.Drawing.Point(576, 5);
            this.viewOrder.Name = "viewOrder";
            this.viewOrder.Size = new System.Drawing.Size(122, 104);
            this.viewOrder.TabIndex = 3;
            this.viewOrder.Text = "VIEW ORDER";
            this.viewOrder.UseVisualStyleBackColor = true;
            this.viewOrder.Click += new System.EventHandler(this.viewOrder_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.menu.Location = new System.Drawing.Point(0, 199);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(681, 1390);
            this.menu.TabIndex = 2;
            // 
            // labelSelectedMenuName
            // 
            this.labelSelectedMenuName.Font = new System.Drawing.Font("Trebuchet MS", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSelectedMenuName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.labelSelectedMenuName.Location = new System.Drawing.Point(96, 115);
            this.labelSelectedMenuName.Name = "labelSelectedMenuName";
            this.labelSelectedMenuName.Size = new System.Drawing.Size(510, 81);
            this.labelSelectedMenuName.TabIndex = 2;
            this.labelSelectedMenuName.Text = "ERROR";
            this.labelSelectedMenuName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTitleItems
            // 
            this.labelTitleItems.BackColor = System.Drawing.Color.Transparent;
            this.labelTitleItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTitleItems.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitleItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.labelTitleItems.Location = new System.Drawing.Point(14, 20);
            this.labelTitleItems.Name = "labelTitleItems";
            this.labelTitleItems.Padding = new System.Windows.Forms.Padding(20);
            this.labelTitleItems.Size = new System.Drawing.Size(520, 81);
            this.labelTitleItems.TabIndex = 1;
            this.labelTitleItems.Text = "LUNCH 11:00 - 16:00";
            // 
            // labelBorder
            // 
            this.labelBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.labelBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelBorder.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBorder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.labelBorder.Location = new System.Drawing.Point(11, 17);
            this.labelBorder.Name = "labelBorder";
            this.labelBorder.Padding = new System.Windows.Forms.Padding(20);
            this.labelBorder.Size = new System.Drawing.Size(526, 87);
            this.labelBorder.TabIndex = 7;
            this.labelBorder.Text = "emptyString";
            // 
            // topBarLabel
            // 
            this.topBarLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.topBarLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarLabel.Location = new System.Drawing.Point(0, 0);
            this.topBarLabel.Name = "topBarLabel";
            this.topBarLabel.Size = new System.Drawing.Size(699, 51);
            this.topBarLabel.TabIndex = 2;
            this.topBarLabel.Text = "emptyString";
            // 
            // OrderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.BackgroundImage = global::ChapeauUI.Properties.Resources.newhandheldbg;
            this.ClientSize = new System.Drawing.Size(720, 1097);
            this.Controls.Add(this.topBarLabel);
            this.Controls.Add(this.panelItems);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderUI";
            this.panelItems.ResumeLayout(false);
            this.PanelChooseMenu.ResumeLayout(false);
            this.PanelChooseMenu.PerformLayout();
            this.panelSelectMenu.ResumeLayout(false);
            this.panelSelectMenu.PerformLayout();
            this.itemAddedOrderPnl.ResumeLayout(false);
            this.itemAddedOrderPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelItems;
        private System.Windows.Forms.Label labelTitleItems;
        private System.Windows.Forms.FlowLayoutPanel menu;
        private System.Windows.Forms.Button viewOrder;
        private System.Windows.Forms.Panel itemAddedOrderPnl;
        private System.Windows.Forms.RichTextBox commentsTextBox;
        private System.Windows.Forms.Label labelCommentsTitle;
        private System.Windows.Forms.DataGridView itemGridView;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Panel PanelChooseMenu;
        private System.Windows.Forms.Button buttonLunch;
        private System.Windows.Forms.Label labelTable;
        private System.Windows.Forms.Button buttonDinner;
        private System.Windows.Forms.Panel panelSelectMenu;
        private System.Windows.Forms.Label labelSelectMenu;
        private System.Windows.Forms.Button buttonDrinks;
        private System.Windows.Forms.Button buttonDesserts;
        private System.Windows.Forms.Button buttonMainCourse;
        private System.Windows.Forms.Button buttonStarters;
        private System.Windows.Forms.Label labelSelectedMenuName;
        private System.Windows.Forms.Label topBarLabel;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label bottomBarLabel;
        private System.Windows.Forms.Label labelBorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
    }
}