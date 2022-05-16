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
    public partial class BarOverview : Form
    {
        public BarOverview()
        {
            InitializeComponent();
        }

        private void barListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Order == drink)
            OrderService orderService = new OrderService();
            List<Order> ordersList = orderService.GetActiveOrders();

            barListView.Clear();
            barListView.View = View.Details;
            barListView.FullRowSelect = true;
            barListView.Columns.Add("Order ID", 100);
            barListView.Columns.Add("Order", 100); //productname
            barListView.Columns.Add("Description", 100);
            barListView.Columns.Add("Is Finished", 100);//true/false
            foreach(Order order in ordersList)
            {
                ListViewItem li = new ListViewItem(order.OrderId.ToString());
                li.SubItems.Add(order.ProductName);
                li.SubItems.Add(order.ProductDescription);
                li.SubItems.Add(order.IsFinished.ToString());
                barListView.Items.Add(li);
            }
        }

        private void finishedDrinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}
