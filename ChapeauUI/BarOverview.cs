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
            Bar();
        }
        private void Bar()
        {
            ListView list = new ListView();

            OrderService orderService = new OrderService();
            List<OrderItem> ordersDrinkList = orderService.GetActiveDrinkOrders();

            barListView.Clear();
            barListView.View = View.Details;
            barListView.FullRowSelect = true;
            barListView.Columns.Add("Order ID", 100);
            barListView.Columns.Add("Order", 100); //productname
            barListView.Columns.Add("Amount of order", 100);
            barListView.Columns.Add("Description", 100);
            barListView.Columns.Add("Comments", 100);
            barListView.Columns.Add("Is Finished", 100);//true/false
            barListView.Columns.Add("Time of ordering", 100);
            foreach (OrderItem order in ordersDrinkList)
            {
                //ListViewItem li = new ListViewItem(order.OrderId.ToString());
                //li.SubItems.Add(order.ProductName);
                //li.SubItems.Add(order.Amount.ToString());
                //li.SubItems.Add(order.Description);
                //li.SubItems.Add(order.Comments);
                //li.SubItems.Add(order.IsFinished.ToString());
                //li.SubItems.Add(order.TimePlaced.ToString());
                //barListView.Items.Add(li);

                /*barListView = new ListView();
                barListView.Width = list.Width - 10;
                list.Height = list.Height - 10;
                list.Controls.Add(barListView);*/
            }
            ColorListView(barListView);
        }
        private void barListView_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        private void finishedDrinkButton_Click(object sender, EventArgs e)
        {
            
            Order order = (Order)barListView.SelectedItems[0].Tag;
            order.IsFinished = true;
            OrderService orderService = new OrderService();
            orderService.GetUpdateStateIsFinished(order.IsFinished);
        }
    }
}
