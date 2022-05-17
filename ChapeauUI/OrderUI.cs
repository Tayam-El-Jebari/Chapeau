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
            itemGridView.ColumnCount = 3;
            itemGridView.Columns[0].Name = "product ID";
            itemGridView.Columns[1].Name = "Product Name";
            itemGridView.Columns[2].Name = "amount added";
            itemGridView.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Add",
                Text = "+",
                Name = "btnAddOrderItems",
                UseColumnTextForButtonValue = true
            });
            itemGridView.Columns.Add(
                new DataGridViewButtonColumn
                {
                    HeaderText = "Remove",
                    Text = "-",
                    Name = "btnAddOrderItems",
                    UseColumnTextForButtonValue = true
                });


            foreach (MenuItem menuItem in menuList)
            {
                menuItemButton = new Button();
                menuItemButton.Width = menu.Width - 10;
                menuItemButton.Height = 62;
                menuItemButton.Click += new EventHandler(BtnOrderAdd_Click);
                menuItemButton.Click += new EventHandler(BtnOrderAdd_MouseDown);
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
                    foreach (DataGridViewRow row in itemGridView.Rows)
                    {
                        if(Convert.ToInt32(row.Cells[0].Value) == menuList[i].MenuItemId)
                        {
                            row.Cells[2].Value = Convert.ToInt32(row.Cells[2].Value) + 1;
                            return;
                        }
                    }
                    itemGridView.Rows.Add(new string[] { menuList[i].MenuItemId.ToString(), menuList[i].ProductName, "1"});
                }
            }
        }
        public void BtnOrderAdd_MouseDown(object sender, EventArgs e)
        {
            for (int i = 0; i < menu.Controls.Count; i++)
            {
                if (menu.Controls[i] == sender)
                {
                    MessageBox.Show(menuList[i].Description);
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
            
        }

        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {

        }

        private void itemGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                itemGridView.Rows[e.RowIndex].Cells[2].Value = Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[2].Value) + 1;
            }
            else if (e.ColumnIndex == 4)
            {
                itemGridView.Rows[e.RowIndex].Cells[2].Value = Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[2].Value) - 1;
                if (Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[2].Value) == 0)
                {
                    itemGridView.Rows.Remove(itemGridView.Rows[e.RowIndex]);
                }
            }
        }
    }
}
