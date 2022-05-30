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
            Kitchen();
        }
        public void Kitchen()
        {
            OrderService orderService = new OrderService();
            OrderItem orderItem = new OrderItem();
            List<OrderItem> ordersFoodList = orderService.GetActiveFoodOrders();

            kitchenListView.Clear();
            kitchenListView.View = View.Details;
            kitchenListView.FullRowSelect = true;
            kitchenListView.Columns.Add("Order ID", 100);
            kitchenListView.Columns.Add("MenuItem", 100);
            kitchenListView.Columns.Add("Order", 100); //productname
            kitchenListView.Columns.Add("Amount of order", 100);
            kitchenListView.Columns.Add("Description", 100);
            kitchenListView.Columns.Add("Comments", 100);
            kitchenListView.Columns.Add("Is Finished", 100);//true/false
            kitchenListView.Columns.Add("Time of ordering", 100);
            foreach (OrderItem order in ordersFoodList)
            {
                ListViewItem li = new ListViewItem(order.Order.OrderId.ToString());
                li.SubItems.Add(order.MenuItem.MenuItemId.ToString());
                li.SubItems.Add(order.MenuItem.ProductName);
                li.SubItems.Add(order.Amount.ToString());
                li.SubItems.Add(order.MenuItem.Description);
                li.SubItems.Add(order.Order.Comments);
                li.SubItems.Add(order.Order.IsFinished.ToString());
                li.SubItems.Add(order.Order.TimePlaced.ToString());
                kitchenListView.Items.Add(li);
            }
            ColorListView(kitchenListView);

        }

        private void kitchenListView_SelectedIndexChanged(object sender, EventArgs e)
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
        private void finishedFoodButton_Click(object sender, EventArgs e)
        {

            OrderItem order = (OrderItem)kitchenListView.SelectedItems[0].Tag;
            OrderService orderService = new OrderService();
            order.Order.IsFinished = true;
            orderService.GetUpdateStateIsFinished(order.Order.IsFinished);
        }

        private void KitchenOverview_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 30000;//30 seconds
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Kitchen();

        }
    }
        
    
}
