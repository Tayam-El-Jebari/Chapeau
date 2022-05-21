using System;
using System.Collections.Generic;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class MenuItemService
    {

        MenuItemDao menuItemdb;

        public MenuItemService()
        {
            menuItemdb = new MenuItemDao();
        }
       
        public List<MenuItem> GetMenuItems(int threeCourseMealCode)
        {
            List<MenuItem> menuItems = menuItemdb.GetAllMenuItems(threeCourseMealCode);
            return menuItems;
        }
    }
}
