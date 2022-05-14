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
    public partial class ChapeauUI : Form
    {
        public ChapeauUI()
        {
            InitializeComponent();
            ShowMenu();
        }
        public void ShowMenu()
        {
            MenuItemService menuItemService = new MenuItemService(); ;
            List<MenuItem> menuList = menuItemService.GetMenuItems(); ;


            testView.Items.Clear();
            testView.View = View.Details;
            testView.Columns.Add("Id", 80);
            testView.Columns.Add("Product name", 150);
            testView.Columns.Add("Price", 100);
            testView.Columns.Add("Description", 80);


            foreach (MenuItem m in menuList)
            {
                ListViewItem liMenu = new ListViewItem(m.MenuItemId.ToString());
                liMenu.SubItems.Add(m.ProductName);
                liMenu.SubItems.Add(m.Price.ToString());
                liMenu.SubItems.Add(m.Description);

                testView.Items.Add(liMenu);
            }
        }

    }
}
