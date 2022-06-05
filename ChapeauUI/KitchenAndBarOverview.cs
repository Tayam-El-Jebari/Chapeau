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
    public partial class KitchenAndBarOverview : Form
    {
        public KitchenAndBarOverview(StaffJob staffJob)
        {
            InitializeComponent();
            if (staffJob == StaffJob.Chef)
            {
                KitchenListView();
            }
            else if (staffJob == StaffJob.Bartender)
            {
                BarListView();
            }
            else
            {
                this.Close();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            StaffJob staffJob = new StaffJob();
            Staff staff = new Staff();
            if (staffJob == StaffJob.Bartender)
            {
                KitchenListView();
            }
            else if (staffJob == StaffJob.Bartender)
            {
                BarListView();
            }

        }        
        private void KitchenOverview_Load(object sender, EventArgs e)
        {

                System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                timer1.Interval = 30000;//30 seconds
                timer1.Tick += new System.EventHandler(timer1_Tick);
                timer1.Start();   
        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void barListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void KitchenListView()
        {
            kitchenListView.Show();
            labelKitchen.Show();
            finishedFoodButton.Show();
            foodButtonOrder.Show();
            foodButtonAmount.Show();
            foodButtonComments.Show();
            foodButtonTable.Show();
            foodButtonDuration.Show();
            barListView.Hide();
            labelBar.Hide();
            finishedDrinkButton.Hide();
            drinkButtonOrder.Hide();
            drinkButtonAmount.Hide();
            drinkButtonComments.Hide();
            drinkButtonTable.Hide();
            drinkButtonDuration.Hide();

            OrderService orderService = new OrderService();
            OrderItem orderItem = new OrderItem();
            List<Order> ordersFoodList = orderService.GetActiveFoodOrders();
            kitchenListView.Clear();
            kitchenListView.View = View.Details;
            kitchenListView.FullRowSelect = true;
            kitchenListView.Columns.Add("Order ID", 100);
            kitchenListView.Columns.Add("MenuItem ID", 100);
            kitchenListView.Columns.Add("Order", 500); //productname
            kitchenListView.Columns.Add("Amount of order", 100);
            kitchenListView.Columns.Add("Description", 200);
            kitchenListView.Columns.Add("Comments", 500);
            kitchenListView.Columns.Add("Table", 200);
            kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
            kitchenListView.Columns.Add("Time of ordering", 200);
            foreach (Order order in ordersFoodList)
            {
                //if (order.TimePlaced == DateTime.Today)
                //{
                TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;

                for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.Items.Add(li);
                    }
                }
                kitchenListView.Show();
                ColorListView(kitchenListView);
            //}
        }
        private void BarListView()
        {
            kitchenListView.Hide();
            labelKitchen.Hide();
            finishedFoodButton.Hide();
            foodButtonOrder.Hide();
            foodButtonAmount.Hide();
            foodButtonComments.Hide();
            foodButtonTable.Hide();
            foodButtonDuration.Hide();
            barListView.Show();
            labelBar.Show();
            finishedDrinkButton.Show();
            drinkButtonOrder.Show();
            drinkButtonAmount.Show();
            drinkButtonComments.Show();
            drinkButtonTable.Show();
            drinkButtonDuration.Show();
            OrderService orderService = new OrderService();
            OrderItem orderItem = new OrderItem();
            List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
            barListView.Clear();
            barListView.View = View.Details;
            barListView.FullRowSelect = true;
            barListView.Columns.Add("Order ID", 100);
            barListView.Columns.Add("Menuitem ID", 100);
            barListView.Columns.Add("Order", 500); //productname
            barListView.Columns.Add("Amount of order", 100);
            barListView.Columns.Add("Description", 200);
            barListView.Columns.Add("Comments", 500);
            barListView.Columns.Add("Table", 200);
            barListView.Columns.Add("Duration of Order (hh:mm)", 200);
            barListView.Columns.Add("Time of ordering", 200);
            foreach (Order order in ordersDrinkList)
            {
                if (order.TimePlaced == DateTime.Today)
                {
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString());
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                ColorListView(barListView);
            }
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
                    listview.Items[i].BackColor = Color.FromArgb(224, 188, 188);
                }
                //else if (listview.Visible && listview.Items.Count > 0)
                //{
                //    listview.Items[i].BackColor = Color.FromArgb(224, 188, 188);
                //}
            }
        }
        private void finishedFoodButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (barListView.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select an order!");
                    return;
                }
                for (int i = 0; i < kitchenListView.SelectedItems.Count; i++)
                {
                    Order order = new Order()
                    {
                        IsFinished = true,
                        OrderId = int.Parse(kitchenListView.SelectedItems[0].SubItems[0].Text),
                        OrderItems = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                MenuItem = new MenuItem()
                                {
                                    MenuItemId = int.Parse(kitchenListView.SelectedItems[0].SubItems[1].Text),
                                    ProductName = kitchenListView.SelectedItems[0].SubItems[2].Text
                                }
                            }
                        }
                    };

                    OrderService orderService = new OrderService();
                    orderService.GetUpdateStateIsFinished(order);
                    MessageBox.Show($"Order {order.OrderId}: {order.OrderItems[0].MenuItem.ProductName} has been succesfully finished\n" + "Notice has been sent to the waiter");
                }
                timer1_Tick(sender, e);
            }
            catch
            {
                MessageBox.Show("Please make sure to select an order to complete");
            }
        }
        private void finishedDrinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (barListView.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select an order!");
                    return;
                }
                for (int i = 0; i < kitchenListView.SelectedItems.Count; i++)
                {
                    Order order = new Order()
                    {
                        IsFinished = true,
                        OrderId = int.Parse(kitchenListView.SelectedItems[0].SubItems[0].Text),
                        OrderItems = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                MenuItem = new MenuItem()
                                {
                                    MenuItemId = int.Parse(kitchenListView.SelectedItems[0].SubItems[1].Text),
                                    ProductName = kitchenListView.SelectedItems[0].SubItems[2].Text
                                }
                            }
                        }
                    };
                    OrderService orderService = new OrderService();
                    orderService.GetUpdateStateIsFinished(order);
                    MessageBox.Show($"Order {order.OrderId}: {order.OrderItems[0].MenuItem.ProductName} has been succesfully finished\n" + "Notice has been sent to the waiter");
                } 
            }
            catch
            {

            }
        }

        private void barListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            //e.Graphics.FillRectangle(Brush);
        }






        private void foodButtonOrder_Click(object sender, EventArgs e)
        {
            if (radioButtonSortForwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersFoodList = orderService.GetActiveFoodOrders();
                kitchenListView.Clear();
                kitchenListView.View = View.Details;
                kitchenListView.FullRowSelect = true;
                kitchenListView.Columns.Add("Order ID", 100);
                kitchenListView.Columns.Add("MenuItem ID", 100);
                kitchenListView.Columns.Add("Order", 500); //productname
                kitchenListView.Columns.Add("Amount of order", 100);
                kitchenListView.Columns.Add("Description", 200);
                kitchenListView.Columns.Add("Comments", 500);
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);
                foreach (Order order in ordersFoodList)
                {
                    order.OrderItems = order.OrderItems.OrderBy(x => x.MenuItem.ProductName).ToList();
                }
                ordersFoodList = ordersFoodList.OrderBy(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                foreach (Order order in ordersFoodList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                kitchenListView.Show();
                ColorListView(kitchenListView);
                //}
            }
            else if (radioButtonSortBackwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersFoodList = orderService.GetActiveFoodOrders();
                kitchenListView.Clear();
                kitchenListView.View = View.Details;
                kitchenListView.FullRowSelect = true;
                kitchenListView.Columns.Add("Order ID", 100);
                kitchenListView.Columns.Add("MenuItem ID", 100);
                kitchenListView.Columns.Add("Order", 500); //productname
                kitchenListView.Columns.Add("Amount of order", 100);
                kitchenListView.Columns.Add("Description", 200);
                kitchenListView.Columns.Add("Comments", 500);
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);
                foreach (Order order in ordersFoodList)
                {
                    order.OrderItems = order.OrderItems.OrderByDescending(x => x.MenuItem.ProductName).ToList();
                }
                ordersFoodList = ordersFoodList.OrderByDescending(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                foreach (Order order in ordersFoodList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                kitchenListView.Show();
                ColorListView(kitchenListView);
                //}
            }
        }
        private void foodButtonAmount_Click(object sender, EventArgs e)
        {
            if (radioButtonSortForwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersFoodList = orderService.GetActiveFoodOrders();
                kitchenListView.Clear();
                kitchenListView.View = View.Details;
                kitchenListView.FullRowSelect = true;
                kitchenListView.Columns.Add("Order ID", 100);
                kitchenListView.Columns.Add("MenuItem ID", 100);
                kitchenListView.Columns.Add("Order", 500); //productname
                kitchenListView.Columns.Add("Amount of order", 100);
                kitchenListView.Columns.Add("Description", 200);
                kitchenListView.Columns.Add("Comments", 500);
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);
                foreach (Order order in ordersFoodList)
                {
                    order.OrderItems = order.OrderItems.OrderBy(x => x.Amount).ToList();
                }
                ordersFoodList = ordersFoodList.OrderBy(x => x.OrderItems[0].Amount).ToList();
                foreach (Order order in ordersFoodList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                kitchenListView.Show();
                ColorListView(kitchenListView);
                //}
            }else if (radioButtonSortBackwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersFoodList = orderService.GetActiveFoodOrders();
                kitchenListView.Clear();
                kitchenListView.View = View.Details;
                kitchenListView.FullRowSelect = true;
                kitchenListView.Columns.Add("Order ID", 100);
                kitchenListView.Columns.Add("MenuItem ID", 100);
                kitchenListView.Columns.Add("Order", 500); //productname
                kitchenListView.Columns.Add("Amount of order", 100);
                kitchenListView.Columns.Add("Description", 200);
                kitchenListView.Columns.Add("Comments", 500);
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);
                foreach (Order order in ordersFoodList)
                {
                    order.OrderItems = order.OrderItems.OrderByDescending(x => x.Amount).ToList();
                }
                ordersFoodList = ordersFoodList.OrderByDescending(x => x.OrderItems[0].Amount).ToList();
                foreach (Order order in ordersFoodList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                kitchenListView.Show();
                ColorListView(kitchenListView);
                //}
            }
        }

        private void foodButtonComments_Click(object sender, EventArgs e)
        {
            if (radioButtonSortForwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersFoodList = orderService.GetActiveFoodOrders();
                kitchenListView.Clear();
                kitchenListView.View = View.Details;
                kitchenListView.FullRowSelect = true;
                kitchenListView.Columns.Add("Order ID", 100);
                kitchenListView.Columns.Add("MenuItem ID", 100);
                kitchenListView.Columns.Add("Order", 500); //productname
                kitchenListView.Columns.Add("Amount of order", 100);
                kitchenListView.Columns.Add("Description", 200);
                kitchenListView.Columns.Add("Comments", 500);
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);
                ordersFoodList = ordersFoodList.OrderBy(x => x.Comments).ToList();
                foreach (Order order in ordersFoodList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                kitchenListView.Show();
                ColorListView(kitchenListView);
                //}
            }
            else if (radioButtonSortBackwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersFoodList = orderService.GetActiveFoodOrders();
                kitchenListView.Clear();
                kitchenListView.View = View.Details;
                kitchenListView.FullRowSelect = true;
                kitchenListView.Columns.Add("Order ID", 100);
                kitchenListView.Columns.Add("MenuItem ID", 100);
                kitchenListView.Columns.Add("Order", 500); //productname
                kitchenListView.Columns.Add("Amount of order", 100);
                kitchenListView.Columns.Add("Description", 200);
                kitchenListView.Columns.Add("Comments", 500);
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);
                ordersFoodList = ordersFoodList.OrderByDescending(x => x.Comments).ToList();
                foreach (Order order in ordersFoodList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                kitchenListView.Show();
                ColorListView(kitchenListView);
                //}
            }
        }
        private void foodButtonTable_Click(object sender, EventArgs e)
        {
            if (radioButtonSortForwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersFoodList = orderService.GetActiveFoodOrders();
                kitchenListView.Clear();
                kitchenListView.View = View.Details;
                kitchenListView.FullRowSelect = true;
                kitchenListView.Columns.Add("Order ID", 100);
                kitchenListView.Columns.Add("MenuItem ID", 100);
                kitchenListView.Columns.Add("Order", 500); //productname
                kitchenListView.Columns.Add("Amount of order", 100);
                kitchenListView.Columns.Add("Description", 200);
                kitchenListView.Columns.Add("Comments", 500);
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);

                ordersFoodList = ordersFoodList.OrderBy(x => x.TableId).ToList();
                foreach (Order order in ordersFoodList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                kitchenListView.Show();
                ColorListView(kitchenListView);
                //}
            }else if (radioButtonSortForwards.Checked) 
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersFoodList = orderService.GetActiveFoodOrders();
                kitchenListView.Clear();
                kitchenListView.View = View.Details;
                kitchenListView.FullRowSelect = true;
                kitchenListView.Columns.Add("Order ID", 100);
                kitchenListView.Columns.Add("MenuItem ID", 100);
                kitchenListView.Columns.Add("Order", 500); //productname
                kitchenListView.Columns.Add("Amount of order", 100);
                kitchenListView.Columns.Add("Description", 200);
                kitchenListView.Columns.Add("Comments", 500);
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);

                ordersFoodList = ordersFoodList.OrderByDescending(x => x.TableId).ToList();
                foreach (Order order in ordersFoodList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                kitchenListView.Show();
                ColorListView(kitchenListView);
                //}
            }
        }
        private void foodButtonDuration_Click(object sender, EventArgs e)
        {
            if (radioButtonSortForwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersFoodList = orderService.GetActiveFoodOrders();
                kitchenListView.Clear();
                kitchenListView.View = View.Details;
                kitchenListView.FullRowSelect = true;
                kitchenListView.Columns.Add("Order ID", 100);
                kitchenListView.Columns.Add("MenuItem ID", 100);
                kitchenListView.Columns.Add("Order", 500); //productname
                kitchenListView.Columns.Add("Amount of order", 100);
                kitchenListView.Columns.Add("Description", 200);
                kitchenListView.Columns.Add("Comments", 500);
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);

                ordersFoodList = ordersFoodList.OrderBy(x => x.TimePlaced).ToList();
                foreach (Order order in ordersFoodList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                kitchenListView.Show();
                ColorListView(kitchenListView);
                //}
            } else if (radioButtonSortBackwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersFoodList = orderService.GetActiveFoodOrders();
                kitchenListView.Clear();
                kitchenListView.View = View.Details;
                kitchenListView.FullRowSelect = true;
                kitchenListView.Columns.Add("Order ID", 100);
                kitchenListView.Columns.Add("MenuItem ID", 100);
                kitchenListView.Columns.Add("Order", 500); //productname
                kitchenListView.Columns.Add("Amount of order", 100);
                kitchenListView.Columns.Add("Description", 200);
                kitchenListView.Columns.Add("Comments", 500);
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);

                ordersFoodList = ordersFoodList.OrderByDescending(x => x.TimePlaced).ToList();
                foreach (Order order in ordersFoodList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                kitchenListView.Show();
                ColorListView(kitchenListView);
                //}
            }
        }

        private void drinkButtonOrder_Click(object sender, EventArgs e)
        {
            if (radioButtonSortForwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
                barListView.Clear();
                barListView.View = View.Details;
                barListView.FullRowSelect = true;
                barListView.Columns.Add("Order ID", 100);
                barListView.Columns.Add("MenuItem ID", 100);
                barListView.Columns.Add("Order", 500); //productname
                barListView.Columns.Add("Amount of order", 100);
                barListView.Columns.Add("Description", 200);
                barListView.Columns.Add("Comments", 500);
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);

                foreach (Order order in ordersDrinkList)
                {
                    order.OrderItems = order.OrderItems.OrderBy(x => x.MenuItem.ProductName).ToList();
                }
                ordersDrinkList = ordersDrinkList.OrderBy(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                foreach (Order order in ordersDrinkList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                barListView.Show();
                ColorListView(barListView);
                //}
            }else if (radioButtonSortBackwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
                barListView.Clear();
                barListView.View = View.Details;
                barListView.FullRowSelect = true;
                barListView.Columns.Add("Order ID", 100);
                barListView.Columns.Add("MenuItem ID", 100);
                barListView.Columns.Add("Order", 500); //productname
                barListView.Columns.Add("Amount of order", 100);
                barListView.Columns.Add("Description", 200);
                barListView.Columns.Add("Comments", 500);
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);

                foreach (Order order in ordersDrinkList)
                {
                    order.OrderItems = order.OrderItems.OrderByDescending(x => x.MenuItem.ProductName).ToList();
                }
                ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                foreach (Order order in ordersDrinkList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                barListView.Show();
                ColorListView(barListView);
                //}
            }
        }

        private void drinkButtonAmount_Click(object sender, EventArgs e)
        {
            if (radioButtonSortForwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
                barListView.Clear();
                barListView.View = View.Details;
                barListView.FullRowSelect = true;
                barListView.Columns.Add("Order ID", 100);
                barListView.Columns.Add("MenuItem ID", 100);
                barListView.Columns.Add("Order", 500); //productname
                barListView.Columns.Add("Amount of order", 100);
                barListView.Columns.Add("Description", 200);
                barListView.Columns.Add("Comments", 500);
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);

                foreach (Order order in ordersDrinkList)
                {
                    order.OrderItems = order.OrderItems.OrderBy(x => x.Amount).ToList();
                }
                ordersDrinkList = ordersDrinkList.OrderBy(x => x.OrderItems[0].Amount).ToList();
                foreach (Order order in ordersDrinkList)
                {
                    //if (order.TimePlaced  DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                barListView.Show();
                ColorListView(barListView);
                //}
            }else if (radioButtonSortBackwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
                barListView.Clear();
                barListView.View = View.Details;
                barListView.FullRowSelect = true;
                barListView.Columns.Add("Order ID", 100);
                barListView.Columns.Add("MenuItem ID", 100);
                barListView.Columns.Add("Order", 500); //productname
                barListView.Columns.Add("Amount of order", 100);
                barListView.Columns.Add("Description", 200);
                barListView.Columns.Add("Comments", 500);
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);

                foreach (Order order in ordersDrinkList)
                {
                    order.OrderItems = order.OrderItems.OrderByDescending(x => x.Amount).ToList();
                }
                ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.OrderItems[0].Amount).ToList();
                foreach (Order order in ordersDrinkList)
                {
                    //if (order.TimePlaced  DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                barListView.Show();
                ColorListView(barListView);
                //}
            }
        }

        private void drinkButtonTable_Click(object sender, EventArgs e)
        {
            if (radioButtonSortForwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
                barListView.Clear();
                barListView.View = View.Details;
                barListView.FullRowSelect = true;
                barListView.Columns.Add("Order ID", 100);
                barListView.Columns.Add("MenuItem ID", 100);
                barListView.Columns.Add("Order", 500); //productname
                barListView.Columns.Add("Amount of order", 100);
                barListView.Columns.Add("Description", 200);
                barListView.Columns.Add("Comments", 500);
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);

                ordersDrinkList = ordersDrinkList.OrderBy(x => x.TableId).ToList();

                foreach (Order order in ordersDrinkList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                barListView.Show();
                ColorListView(barListView);
                //}
            
            }else if (radioButtonSortBackwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
                barListView.Clear();
                barListView.View = View.Details;
                barListView.FullRowSelect = true;
                barListView.Columns.Add("Order ID", 100);
                barListView.Columns.Add("MenuItem ID", 100);
                barListView.Columns.Add("Order", 500); //productname
                barListView.Columns.Add("Amount of order", 100);
                barListView.Columns.Add("Description", 200);
                barListView.Columns.Add("Comments", 500);
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);

                ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.TableId).ToList();

                foreach (Order order in ordersDrinkList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                barListView.Show();
                ColorListView(barListView);
                //}
            }
        }

        private void drinkButtonComments_Click(object sender, EventArgs e)
        {
            if (radioButtonSortForwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
                barListView.Clear();
                barListView.View = View.Details;
                barListView.FullRowSelect = true;
                barListView.Columns.Add("Order ID", 100);
                barListView.Columns.Add("MenuItem ID", 100);
                barListView.Columns.Add("Order", 500); //productname
                barListView.Columns.Add("Amount of order", 100);
                barListView.Columns.Add("Description", 200);
                barListView.Columns.Add("Comments", 500);
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);

                ordersDrinkList = ordersDrinkList.OrderBy(x => x.Comments).ToList();

                foreach (Order order in ordersDrinkList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                barListView.Show();
                ColorListView(barListView);
                //}
            }
            else if (radioButtonSortBackwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
                barListView.Clear();
                barListView.View = View.Details;
                barListView.FullRowSelect = true;
                barListView.Columns.Add("Order ID", 100);
                barListView.Columns.Add("MenuItem ID", 100);
                barListView.Columns.Add("Order", 500); //productname
                barListView.Columns.Add("Amount of order", 100);
                barListView.Columns.Add("Description", 200);
                barListView.Columns.Add("Comments", 500);
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);

                ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.TableId).ToList();

                foreach (Order order in ordersDrinkList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                barListView.Show();
                ColorListView(barListView);
                //}
            }
        }



        private void drinkButtonDuration_Click(object sender, EventArgs e)
        {
            if (radioButtonSortForwards.Checked)
                {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
                barListView.Clear();
                barListView.View = View.Details;
                barListView.FullRowSelect = true;
                barListView.Columns.Add("Order ID", 100);
                barListView.Columns.Add("MenuItem ID", 100);
                barListView.Columns.Add("Order", 500); //productname
                barListView.Columns.Add("Amount of order", 100);
                barListView.Columns.Add("Description", 200);
                barListView.Columns.Add("Comments", 500);
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);

                ordersDrinkList = ordersDrinkList.OrderBy(x => x.TimePlaced).ToList();

                foreach (Order order in ordersDrinkList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                barListView.Show();
                ColorListView(barListView);
                //}
            }else if (radioButtonSortBackwards.Checked)
            {
                OrderService orderService = new OrderService();
                OrderItem orderItem = new OrderItem();
                List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
                barListView.Clear();
                barListView.View = View.Details;
                barListView.FullRowSelect = true;
                barListView.Columns.Add("Order ID", 100);
                barListView.Columns.Add("MenuItem ID", 100);
                barListView.Columns.Add("Order", 500); //productname
                barListView.Columns.Add("Amount of order", 100);
                barListView.Columns.Add("Description", 200);
                barListView.Columns.Add("Comments", 500);
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);

                ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.TimePlaced).ToList();

                foreach (Order order in ordersDrinkList)
                {
                    //if (order.TimePlaced == DateTime.Today)
                    //{
                    TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.Description);
                        li.SubItems.Add(order.Comments);
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                barListView.Show();
                ColorListView(barListView);
                //}
            }
        }
    }





}
