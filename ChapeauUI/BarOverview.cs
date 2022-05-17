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

            OrderService orderService = new OrderService();
            List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();

            barListView.Clear();
            barListView.View = View.Details;
            barListView.FullRowSelect = true;
            barListView.Columns.Add("Order ID", 100);
            barListView.Columns.Add("Order", 100); //productname
            barListView.Columns.Add("Description", 100);
            barListView.Columns.Add("Comments", 100);
            barListView.Columns.Add("Is Finished", 100);//true/false
            foreach(Order order in ordersDrinkList)
            {
                ListViewItem li = new ListViewItem(order.OrderId.ToString());
                li.SubItems.Add(order.ProductName);
                li.SubItems.Add(order.ProductDescription);
                li.SubItems.Add(order.Comments);
                li.SubItems.Add(order.IsFinished.ToString());
                barListView.Items.Add(li);
            }
            ColorListView(barListView);
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
            //click 2 minutes groen op listview en daarna verdwijnt hij
            // melding naar de bediening
            Order order = (Order)barListView.SelectedItems[0].Tag;
            order.IsFinished = true;//specificeren op dat rijtje
            /*naam tablat van bediening*/
            MessageBox.Show("dish can be served");//nog welke dish can be served
        }
    }
}
