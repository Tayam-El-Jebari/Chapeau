using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauLogic;
using ChapeauModel;

namespace ChapeauUI
{
    public partial class KitchenOverview : Form
    {
        public KitchenOverview()
        {
            InitializeComponent();
        }

        private void kitchenListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderService orderService = new OrderService();
            List<Order> ordersList = orderService.GetActiveOrders();

            kitchenListView.Clear();
            kitchenListView.View = View.Details;
            kitchenListView.FullRowSelect = true;
            kitchenListView.Columns.Add("Order ID", 100);
            kitchenListView.Columns.Add("Order", 100); //productname
            kitchenListView.Columns.Add("Description", 100);
            kitchenListView.Columns.Add("Is Finished", 100);//true/false
            foreach (Order order in ordersList)
            {
                ListViewItem li = new ListViewItem(order.OrderId.ToString());
                li.SubItems.Add(order.ProductName);
                li.SubItems.Add(order.ProductDescription);
                li.SubItems.Add(order.IsFinished.ToString());
                kitchenListView.Items.Add(li);
            }
        }

        private void finishedFoodButton_Click(object sender, EventArgs e)
        {

        }
    }
}
