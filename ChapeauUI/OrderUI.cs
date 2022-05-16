using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class OrderUI : Form
    {
        private List<MenuItem> menuList;
        public OrderUI()
        {
            Button menuItemButton;
            InitializeComponent();
            itemAddedOrderPnl.Hide();
            MenuItemService menuItemService = new MenuItemService();
            menuList = menuItemService.GetMenuItems();
            itemList.View = View.Details;
            itemList.Columns.Add("Item Id", 80);
            itemList.Columns.Add("Item Name", 80);

            foreach (MenuItem menuItem in menuList)
            {
                menuItemButton = new Button();
                menuItemButton.Width = menu.Width - 10;
                menuItemButton.Height = 62;
                menuItemButton.Click += new EventHandler(BtnOrderAdd_Click);
                menuItemButton.Text = $"{menuItem.MenuItemId}    {menuItem.ProductName}";
                menuItemButton.Font = new Font("Cabin", 14);
                menuItemButton.Visible = true;
                menu.Controls.Add(menuItemButton);
            }
        }
        void BtnOrderAdd_Click(Object sender, EventArgs e)
        {
            for (int i = 0; i < menu.Controls.Count; i++)
            {
                if (menu.Controls[i] == sender)
                {
                    ListViewItem liMenu = new ListViewItem(menuList[i].MenuItemId.ToString());
                    liMenu.SubItems.Add(menuList[i].ProductName);
                    itemList.Items.Add(liMenu);
                }
            }
        }


        private void panelOrders_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(39, 39, 39), 10), 14, 20, 498, 81);
        }

        private void viewOrders_Click(object sender, EventArgs e)
        {
            if (itemAddedOrderPnl.Visible)
            {
                itemAddedOrderPnl.Hide();
            }
            else
            {
                itemAddedOrderPnl.Show();
            }
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            itemList.Items.Clear();
        }

        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in itemList.SelectedItems)
            {
                itemList.Items.Remove(item);
            }
        }
    }
}
