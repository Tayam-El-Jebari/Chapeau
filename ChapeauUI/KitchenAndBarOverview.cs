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
        Staff BartenderOrChef = new Staff();
        public KitchenAndBarOverview(StaffJob staffJob)
        {
            InitializeComponent();
            this.BartenderOrChef.StaffJob = staffJob;
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                KitchenListView();
            }
            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                BarListView();
            }
            else
            {
                this.Close();
            }
            ProgressBar();
            listViewComments.Show();

        }
        private void ProgressBar()
        {
            progressBarUpdate.ForeColor = Color.FromArgb(159, 56, 59);
            progressBarUpdate.Show();
            Timer timer = new Timer();
            timer.Interval = 296;
            timer.Tick += new System.EventHandler(timerProgress_Tick);
            timer.Start();
        }
        private void timerProgress_Tick(object sender, EventArgs e)
        {
            progressBarUpdate.Value += 1;
            if (progressBarUpdate.Value == 100)
            {
                progressBarUpdate.Value = 0;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                KitchenListView();
            }
            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                BarListView();
            }

        }
        private void KitchenOverview_Load(object sender, EventArgs e)
        {

            Timer timer1 = new Timer();
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
            listViewComments.BeginUpdate();
            listViewComments.Show();
            listViewComments.Clear();
            listViewComments.View = View.Details;
            listViewComments.FullRowSelect = true;
            listViewComments.Columns.Add("Order ID", 100);
            listViewComments.Columns.Add("Menuitem ID", 100);
            listViewComments.Columns.Add("Comments", 500);
            //listViewComments.Columns.Add("Description", 500);

            for (int i = 0; i < barListView.SelectedItems.Count; i++)
            {
                ListViewItem li = new ListViewItem(barListView.SelectedItems[i].SubItems[0].Text);
                li.SubItems.Add(barListView.SelectedItems[i].SubItems[1].Text);
                li.SubItems.Add(barListView.SelectedItems[i].SubItems[5].Text);
                //li.SubItems.Add(barListView.SelectedItems[i].SubItems[4].Text);

                listViewComments.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewComments.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewComments.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);

                listViewComments.Items.Add(li);
            }
            ColorListView(listViewComments);
            listViewComments.EndUpdate();
        }
        private void kitchenListview_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewComments.BeginUpdate();
            listViewComments.Show();
            listViewComments.Clear();
            listViewComments.View = View.Details;
            listViewComments.FullRowSelect = true;
            listViewComments.Columns.Add("Order ID", 100);
            listViewComments.Columns.Add("Menuitem ID", 100);
            listViewComments.Columns.Add("Comments", 500);
            //listViewComments.Columns.Add("Description", 500);

            for (int i = 0; i < kitchenListView.SelectedItems.Count; i++)
            {
                int correctOrderIndex = ordersFoodList.FindIndex(x => x.OrderId == Convert.ToInt32(kitchenListView.SelectedItems[i].SubItems[0].Text));
                ListViewItem li = new ListViewItem(kitchenListView.SelectedItems[i].SubItems[0].Text);
                li.SubItems.Add(kitchenListView.SelectedItems[i].SubItems[1].Text);
                li.SubItems.Add(ordersFoodList[correctOrderIndex].Comments);
                //li.SubItems.Add(ordersFoodList[correctOrderIndex].OrderItems.Find(x => x.MenuItem.MenuItemId = ).Text);

                listViewComments.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewComments.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewComments.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);

                listViewComments.Items.Add(li);
            }
            ColorListView(listViewComments);
            listViewComments.EndUpdate();
        }
        private List<Order> ordersFoodList;
        public void KitchenListView()
        {
            kitchenListView.Show();
            labelKitchen.Show();

            barListView.Hide();
            labelBar.Hide();
            finishedDrinkButton.Hide();


            listViewComments.Hide();
            progressBarUpdate.Show();
            kitchenListView.BeginUpdate();
            OrderService orderService = new OrderService();
            ordersFoodList = orderService.GetActiveFoodOrders();
            kitchenListView.Clear();
            kitchenListView.View = View.Details;
            kitchenListView.FullRowSelect = true;
            kitchenListView.Columns.Add("Order ID", 100);
            kitchenListView.Columns.Add("MenuItem ID", 100);
            kitchenListView.Columns.Add("Order", 500); //productname
            kitchenListView.Columns.Add("Amount of order", 100);
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
                    li.SubItems.Add(order.TableId.ToString());
                    li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                    li.SubItems.Add(order.TimePlaced.ToString());
                    kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                    kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                    kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                    kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                    kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                    kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                    kitchenListView.Items.Add(li);
                }
            }
            ColorListView(kitchenListView);
            kitchenListView.EndUpdate();
            //}
        }
        private void BarListView()
        {
            kitchenListView.Hide();
            labelKitchen.Hide();
            barListView.Show();
            labelBar.Show();
            finishedDrinkButton.Show();
 
            
            listViewComments.Hide();
            progressBarUpdate.Show();

            barListView.BeginUpdate();
            OrderService orderService = new OrderService();
            List<Order> ordersDrinkList = orderService.GetActiveDrinkOrders();
            barListView.Clear();
            barListView.View = View.Details;
            barListView.FullRowSelect = true;
            barListView.Columns.Add("Order ID", 100);
            barListView.Columns.Add("Menuitem ID", 100);
            barListView.Columns.Add("Order", 500); //productname
            barListView.Columns.Add("Amount of order", 100);
            barListView.Columns.Add("Table", 200);
            barListView.Columns.Add("Duration of Order (hh:mm)", 200);
            barListView.Columns.Add("Time of ordering", 200);
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
                    li.SubItems.Add(order.TableId.ToString());
                    li.SubItems.Add(timeOfOrder.ToString());
                    li.SubItems.Add(order.TimePlaced.ToString());
                    barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                    barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                    barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                    barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                    barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                    barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);

                    barListView.Items.Add(li);
                    //}
                }
            }
            ColorListView(barListView);
            barListView.EndUpdate();

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
                if (kitchenListView.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select an order!");
                    return;
                }
                for (int i = 0; i < kitchenListView.SelectedItems.Count; i++)
                {
                    Order order = new Order()
                    {
                        OrderId = int.Parse(kitchenListView.SelectedItems[i].SubItems[0].Text),
                        OrderItems = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Status = Status.Ready,
                                MenuItem = new MenuItem()
                                {
                                    MenuItemId = int.Parse(kitchenListView.SelectedItems[i].SubItems[1].Text),
                                    ProductName = kitchenListView.SelectedItems[i].SubItems[2].Text
                                }
                            }
                        }
                    };

                    OrderService orderService = new OrderService();
                    orderService.GetUpdateStateIsFinished(order);
                    MessageBox.Show($"Order {order.OrderId}: {order.OrderItems[0].MenuItem.ProductName} has been succesfully finished\n" + "Notice has been sent to the waiter");
                }
                timer1_Tick(sender, e);
                progressBarUpdate.Show();
            }
            catch
            {
                MessageBox.Show("Please make sure to select an order to complete");
            }
        }
        private void finishedDrinkButton_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (barListView.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select an order!");
                    return;
                }
                for (int i = 0; i < barListView.SelectedItems.Count; i++)
                {
                Order order = new Order()
                {
                    OrderId = int.Parse(barListView.SelectedItems[i].SubItems[0].Text),
                    OrderItems = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Status = Status.Ready,
                                MenuItem = new MenuItem()
                                {
                                    MenuItemId = int.Parse(barListView.SelectedItems[i].SubItems[1].Text),
                                    ProductName = barListView.SelectedItems[i].SubItems[2].Text
                                }
                            }
                        }
                    };
                    OrderService orderService = new OrderService();
                    orderService.GetUpdateStateIsFinished(order);
                    MessageBox.Show($"Order {order.OrderId}: {order.OrderItems[0].MenuItem.ProductName} has been succesfully finished\n" + "Notice has been sent to the waiter");
                }
        }

        private void barListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            //e.Graphics.FillRectangle(Brush);
        }






        private void foodButtonOrder_Click(object sender, EventArgs e)
        {
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                kitchenListView.BeginUpdate();
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
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);
                if (radioButtonSortForwards.Checked)
                {
                    foreach (Order order in ordersFoodList)
                    {
                        order.OrderItems = order.OrderItems.OrderBy(x => x.MenuItem.ProductName).ToList();
                    }
                    ordersFoodList = ordersFoodList.OrderBy(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                }
                if (radioButtonSortBackwards.Checked)
                {
                    foreach (Order order in ordersFoodList)
                    {
                        order.OrderItems = order.OrderItems.OrderByDescending(x => x.MenuItem.ProductName).ToList();
                    }
                    ordersFoodList = ordersFoodList.OrderByDescending(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }
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
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                ColorListView(kitchenListView);
                kitchenListView.EndUpdate();
                //}
            }
            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                barListView.BeginUpdate();
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
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);
                if (radioButtonSortForwards.Checked)
                {
                    foreach (Order order in ordersDrinkList)
                    {
                        order.OrderItems = order.OrderItems.OrderBy(x => x.MenuItem.ProductName).ToList();
                    }
                    ordersDrinkList = ordersDrinkList.OrderBy(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                }
                if (radioButtonSortBackwards.Checked)
                {
                    foreach (Order order in ordersDrinkList)
                    {
                        order.OrderItems = order.OrderItems.OrderByDescending(x => x.MenuItem.ProductName).ToList();
                    }
                    ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }
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
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                ColorListView(barListView);
                barListView.EndUpdate();
                //}


            }
        }

        private void foodButtonAmount_Click(object sender, EventArgs e)
        {
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                kitchenListView.BeginUpdate();
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
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);
                if (radioButtonSortForwards.Checked)
                {
                    foreach (Order order in ordersFoodList)
                    {
                        order.OrderItems = order.OrderItems.OrderBy(x => x.Amount).ToList();
                    }
                    ordersFoodList = ordersFoodList.OrderBy(x => x.OrderItems[0].Amount).ToList();

                }
                else if (radioButtonSortBackwards.Checked)
                {
                    foreach (Order order in ordersFoodList)
                    {
                        order.OrderItems = order.OrderItems.OrderByDescending(x => x.Amount).ToList();
                    }
                    ordersFoodList = ordersFoodList.OrderByDescending(x => x.OrderItems[0].Amount).ToList();

                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }
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
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                ColorListView(kitchenListView);
                kitchenListView.EndUpdate();
                //}

            }
            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                barListView.BeginUpdate();
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
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);
                if (radioButtonSortForwards.Checked)
                {
                    foreach (Order order in ordersDrinkList)
                    {
                        order.OrderItems = order.OrderItems.OrderBy(x => x.Amount).ToList();
                    }
                    ordersDrinkList = ordersDrinkList.OrderBy(x => x.OrderItems[0].Amount).ToList();

                }
                else if (radioButtonSortBackwards.Checked)
                {
                    foreach (Order order in ordersDrinkList)
                    {
                        order.OrderItems = order.OrderItems.OrderByDescending(x => x.Amount).ToList();
                    }
                    ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.OrderItems[0].Amount).ToList();

                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }
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
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                ColorListView(barListView);
                barListView.EndUpdate();
                //}
            }
        }


        private void foodButtonComments_Click(object sender, EventArgs e)
        {
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {

                kitchenListView.BeginUpdate();
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
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);
                if (radioButtonSortForwards.Checked)
                {
                    ordersFoodList = ordersFoodList.OrderBy(x => x.Comments).ToList();
                }
                else if (radioButtonSortBackwards.Checked)
                {
                    ordersFoodList = ordersFoodList.OrderByDescending(x => x.Comments).ToList();
                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }
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
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                ColorListView(kitchenListView);
                kitchenListView.EndUpdate();
                //}
            }

            if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                barListView.BeginUpdate();
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
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);
                if (radioButtonSortForwards.Checked)
                {
                    ordersDrinkList = ordersDrinkList.OrderBy(x => x.Comments).ToList();
                }
                else if (radioButtonSortBackwards.Checked)
                {
                    ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.Comments).ToList();
                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }
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
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                ColorListView(barListView);
                barListView.EndUpdate();
                //}
            }
        }

        private void foodButtonTable_Click(object sender, EventArgs e)
        {
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                kitchenListView.BeginUpdate();
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
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);
                if (radioButtonSortForwards.Checked)
                {
                    ordersFoodList = ordersFoodList.OrderBy(x => x.TableId).ToList();
                }
                else if (radioButtonSortForwards.Checked)
                {
                    ordersFoodList = ordersFoodList.OrderByDescending(x => x.TableId).ToList();
                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }

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
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                ColorListView(kitchenListView);
                kitchenListView.EndUpdate();
                //}
            }

            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                barListView.BeginUpdate();
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
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);
                if (radioButtonSortForwards.Checked)
                {
                    ordersDrinkList = ordersDrinkList.OrderBy(x => x.TableId).ToList();
                }
                else if (radioButtonSortForwards.Checked)
                {
                    ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.TableId).ToList();
                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }

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
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                ColorListView(barListView);
                barListView.EndUpdate();
                //}
            }
        }
        private void foodButtonDuration_Click(object sender, EventArgs e)
        {
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                kitchenListView.BeginUpdate();
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
                kitchenListView.Columns.Add("Table", 200);
                kitchenListView.Columns.Add("Duration of Order (hh:mm)", 200);
                kitchenListView.Columns.Add("Time of ordering", 200);
                if (radioButtonSortForwards.Checked)
                {
                    ordersFoodList = ordersFoodList.OrderBy(x => x.TimePlaced).ToList();
                }
                else if (radioButtonSortBackwards.Checked)
                {
                    ordersFoodList = ordersFoodList.OrderByDescending(x => x.TimePlaced).ToList();

                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }
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
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);

                        kitchenListView.Items.Add(li);
                    }
                }
                ColorListView(kitchenListView);
                kitchenListView.EndUpdate();
                //}
            }


            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                barListView.BeginUpdate();
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
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);
                if (radioButtonSortForwards.Checked)
                {
                    ordersDrinkList = ordersDrinkList.OrderBy(x => x.TimePlaced).ToList();
                }
                else if (radioButtonSortBackwards.Checked)
                {
                    ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.TimePlaced).ToList();

                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }
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
                        li.SubItems.Add(order.TableId.ToString());
                        li.SubItems.Add(timeOfOrder.ToString(@"hh\:mm"));
                        li.SubItems.Add(order.TimePlaced.ToString());
                        barListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        barListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
                        barListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
                }
                ColorListView(barListView);
                barListView.EndUpdate();
                //}
            }
        }

        private void drinkButtonTable_Click(object sender, EventArgs e)
        {

        }
    }
}
