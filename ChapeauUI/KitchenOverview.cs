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
            List<Order> ordersFoodList = orderService.GetActiveFoodOrders();

            kitchenListView.Clear();
            kitchenListView.View = View.Details;
            kitchenListView.FullRowSelect = true;
            kitchenListView.Columns.Add("Order ID", 100);
            kitchenListView.Columns.Add("Order", 100); //productname
            kitchenListView.Columns.Add("Description", 100);
            kitchenListView.Columns.Add("Is Finished", 100);//true/false
            foreach (Order order in ordersFoodList)
            {
                ListViewItem li = new ListViewItem(order.OrderId.ToString());
                li.SubItems.Add(order.ProductName);
                li.SubItems.Add(order.ProductDescription);
                li.SubItems.Add(order.IsFinished.ToString());
                kitchenListView.Items.Add(li);
            }
            ColorListView(kitchenListView);

        }
        private void ColorListView(ListView listview)
        {
            for (int i = 0; i < listview.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    listview.Items[i].BackColor = Color.LightBlue;
                }
            }
        }
        private void finishedFoodButton_Click(object sender, EventArgs e)
        {

        }
    }
}
