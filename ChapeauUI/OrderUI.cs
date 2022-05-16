using Microsoft.VisualBasic;
using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ChapeauUI
{
    public partial class OrderUI : Form
    {
        MenuItem item;

        public OrderUI()
        {
            try
            {
                Button menuItemButton;

                InitializeComponent();
                MenuItemService menuItemService = new MenuItemService();
                List<MenuItem> menuList = menuItemService.GetMenuItems();



                int x = 10;
                int y = 50;
                foreach (MenuItem menuItem in menuList)
                {
                    item = menuItem;
                    menuItemButton = new Button();
                    menuItemButton.Location = new Point(x, y);
                    menuItemButton.Click += new EventHandler(BtnOrderAdd_Click);
                    menuItemButton.Text = menuItem.ProductName;
                    y += 40;
                    menuItemButton.Visible = true;
                    Controls.Add(menuItemButton);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
            void BtnOrderAdd_Click(Object sender,EventArgs e)
        {
            MessageBox.Show(item.ProductName);
        }

        private void lunchDinnerLabel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void OrderUI_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(39, 39, 39), 10), 14, 20, 498, 81);

        }
    }
}
