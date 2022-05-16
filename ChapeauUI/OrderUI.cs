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
            Button menuItemButton;

            InitializeComponent();
            MenuItemService menuItemService = new MenuItemService(); ;
            List<MenuItem> menuList = menuItemService.GetMenuItems(); ;
            int x = 10;
            int y = 50;
            foreach(MenuItem menuItem in menuList)
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

        void BtnOrderAdd_Click(Object sender,EventArgs e)
        {
            MessageBox.Show(item.ProductName);
        }
    }
}
