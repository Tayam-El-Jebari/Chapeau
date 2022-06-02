using System;

namespace ChapeauModel
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int stock { get; set; }
        public MenuItemType MenuItemType { get; set; }
        public MenuType MenuType { get; set; }
    }
}
