using System;
using System.Collections.Generic;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class MenuItemService
    {

        private MenuItemDao menuItemdb;

        public MenuItemService()
        {
            menuItemdb = new MenuItemDao();
        }
       
        public List<MenuItem> GetMenuItems()
        {
            return menuItemdb.GetAllMenuItems();
        }
    }
}
