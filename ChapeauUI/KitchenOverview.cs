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
            List<OrderItem> ordersFoodList = orderService.GetActiveFoodOrders();

            kitchenListView.Clear();
            kitchenListView.View = View.Details;
            kitchenListView.FullRowSelect = true;
            kitchenListView.Columns.Add("Order ID", 100);
            kitchenListView.Columns.Add("Reservation ID", 100);
            kitchenListView.Columns.Add("Order", 100); //productname
            kitchenListView.Columns.Add("Amount of order", 100);
            kitchenListView.Columns.Add("Description", 100);
            kitchenListView.Columns.Add("Table", 100);
            kitchenListView.Columns.Add("Comments", 100);
            kitchenListView.Columns.Add("Is Finished", 100);//true/false
            kitchenListView.Columns.Add("Time of ordering", 100);
            foreach (OrderItem order in ordersFoodList)
            {
                ListViewItem li = new ListViewItem(order.OrderId.ToString());
                li.SubItems.Add(order.ReservationId.ToString());
                li.SubItems.Add(order.ProductName);
                li.SubItems.Add(order.Amount.ToString());
                li.SubItems.Add(order.Description);
                li.SubItems.Add(order.TableId.ToString());
                li.SubItems.Add(order.Comments);
                li.SubItems.Add(order.IsFinished.ToString());
                li.SubItems.Add(order.TimePlaced.ToString());
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

            Order order = (Order)kitchenListView.SelectedItems[0].Tag;
            order.IsFinished = true;
            OrderService orderService = new OrderService();
            orderService.GetUpdateStateIsFinished(order.IsFinished);
        }


    }
}
