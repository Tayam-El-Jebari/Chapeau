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

            OrderItem order = (OrderItem)barListView.SelectedItems[0].Tag;
            OrderService orderService = new OrderService();
            order.Order.IsFinished = true;
            orderService.GetUpdateStateIsFinished(order.Order.IsFinished);
        }

        private void BarOverview_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 30000;//30 seconds
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //do whatever you want 
            OrderService orderService = new OrderService();
            OrderItem orderItem = new OrderItem();
            List<OrderItem> ordersDrinkList = orderService.GetActiveDrinkOrders();


            barListView.Clear();
            barListView.View = View.Details;
            barListView.FullRowSelect = true;
            barListView.Columns.Add("Order ID", 100);
            barListView.Columns.Add("MenuItem", 100);
            barListView.Columns.Add("Order", 100); //productname
            barListView.Columns.Add("Amount of order", 100);
            barListView.Columns.Add("Description", 100);
            barListView.Columns.Add("Comments", 100);
            barListView.Columns.Add("Is Finished", 100);//true/false
            barListView.Columns.Add("Time of ordering", 100);
            foreach (OrderItem order in ordersDrinkList)
            {
                ListViewItem li = new ListViewItem(order.Order.OrderId.ToString());
                li.SubItems.Add(order.MenuItem.MenuItemId.ToString());
                li.SubItems.Add(order.MenuItem.ProductName);
                li.SubItems.Add(order.Amount.ToString());
                li.SubItems.Add(order.MenuItem.Description);
                li.SubItems.Add(order.Order.Comments);
                li.SubItems.Add(order.Order.IsFinished.ToString());
                li.SubItems.Add(order.Order.TimePlaced.ToString());
                barListView.Items.Add(li);
            }
            ColorListView(barListView);

        }
    }


}

