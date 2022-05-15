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
            testView.Items.Clear();
            ShowOrders();
        }
        private void ShowMenu()
        {
            MenuItemService menuItemService = new MenuItemService(); ;
            List<MenuItem> menuList = menuItemService.GetMenuItems(); ;


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
        private void ShowBills()
        {
            BillService billService = new BillService(); ;
            List<Bill> billList = billService.GetBills(); ;


            testView.View = View.Details;
            testView.Columns.Add("BillID", 50);
            testView.Columns.Add("TableID", 50);
            testView.Columns.Add("StaffID", 50);
            testView.Columns.Add("TotalPriceInclVAT", 50);
            testView.Columns.Add("TotalPriceExclVAT", 50);
            testView.Columns.Add("Tip", 50);
            testView.Columns.Add("IsPaid", 50);
            testView.Columns.Add("Discount", 50);
            testView.Columns.Add("Date", 50);
            testView.Columns.Add("Comments", 50);


            foreach (Bill b in billList)
            {
                ListViewItem liMenu = new ListViewItem(b.BillID.ToString());
                liMenu.SubItems.Add(b.TableID.ToString());
                liMenu.SubItems.Add(b.StaffID.ToString());
                liMenu.SubItems.Add(b.TotalPriceInclVAT.ToString());
                liMenu.SubItems.Add(b.TotalPriceExclVAT.ToString());
                liMenu.SubItems.Add(b.Tip.ToString());
                liMenu.SubItems.Add(b.IsPaid.ToString());
                liMenu.SubItems.Add(b.Discount.ToString());
                liMenu.SubItems.Add(b.Date.ToString());
                liMenu.SubItems.Add(b.Comments.ToString());

                testView.Items.Add(liMenu);
            }
        }
        private void ShowOrders()
        {
            OrderService orderService = new OrderService(); ;
            List<Order> activeOrders = orderService.GetActiveOrders();


            testView.View = View.Details;
            testView.Columns.Add("Order Id", 40);
            testView.Columns.Add("product name", 80);
            testView.Columns.Add("product description", 150);
            testView.Columns.Add("table Id", 40);
            testView.Columns.Add("Order comments", 150);



            foreach (Order order in activeOrders)
            {
                ListViewItem liMenu = new ListViewItem(order.OrderId.ToString());
                liMenu.SubItems.Add(order.ProductName.ToString());
                liMenu.SubItems.Add(order.ProductDescription.ToString());
                liMenu.SubItems.Add(order.TableId.ToString());
                liMenu.SubItems.Add(order.Comments);

                testView.Items.Add(liMenu);
            }
        }

        private void ShowStaff()
        {
            StaffService staffService = new StaffService(); ;
            List<Staff> staffMembers = staffService.GetStaffs();


            testView.View = View.Details;
            testView.Columns.Add("Staff Id", 40);
            testView.Columns.Add("Fristname", 80);
            testView.Columns.Add("Lastname", 150);
            testView.Columns.Add("Phonenumber", 40);
            testView.Columns.Add("Email adress", 150);
            testView.Columns.Add("Salt", 40);
            testView.Columns.Add("Password", 40);



            foreach (Staff staff in staffMembers)
            {
                ListViewItem liMenu = new ListViewItem(staff.Staff_ID.ToString());
                liMenu.SubItems.Add(staff.firstName);
                liMenu.SubItems.Add(staff.lastName);
                liMenu.SubItems.Add(staff.phoneNumber.ToString());
                liMenu.SubItems.Add(staff.emailAdress);
                liMenu.SubItems.Add(staff.salt);
                liMenu.SubItems.Add(staff.passWord);

                testView.Items.Add(liMenu);
            }
        }
    }
}
