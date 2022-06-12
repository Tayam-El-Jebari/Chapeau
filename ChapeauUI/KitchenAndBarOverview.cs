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
        private List<Order> ordersFoodList;
        private List<Order> ordersDrinkList;
        private SortingType sortingType;
        private OrderService orderService;

        public KitchenAndBarOverview(StaffJob staffJob)
        {
            InitializeComponent();
            //radioButtonSortForwards.Enabled = true;
            this.BartenderOrChef.StaffJob = staffJob;
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                KitchenListView();
            }
            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                BarListView();
                comboBoxThreeCourseMeal.Hide();
                titleSelectThreeCourseMeal.Hide();
                SelectAllMenuItemType.Hide();
            }
            else
            {
                this.Close();
            }
            ProgressBar();
            listViewComments.Show();
            comboBoxThreeCourseMeal.Text = "--Select--";
            comboBoxThreeCourseMeal.Items.Add(MenuItemType.Starter);
            comboBoxThreeCourseMeal.Items.Add(MenuItemType.MainCourse);
            comboBoxThreeCourseMeal.Items.Add(MenuItemType.Desserts);
            orderService = new OrderService();
            sortingType = new SortingType();
        }
        private void ProgressBar()
        {
            progressBarUpdate.ForeColor = Color.FromArgb(159, 56, 59);
            progressBarUpdate.Show();
            Timer timer = new Timer();
            timer.Interval = 300;
            timer.Tick += new System.EventHandler(timerProgress_Tick);
            timer.Start();
        }
        private void timerProgress_Tick(object sender, EventArgs e)
        {
            if(progressBarUpdate.Value < 100)
            progressBarUpdate.Value += 1;
            else  
                progressBarUpdate.Value = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sortingType == SortingType.duration)
                sortButtonDuration_Click(sender, e);
            else if (sortingType == SortingType.orderName)
                sortButtonOrder_Click(sender, e);
            else if (sortingType == SortingType.amount)
                sortButtonAmount_Click(sender, e);
            else if (sortingType == SortingType.table)
                sortButtonTable_Click(sender, e);
            else if (sortingType == SortingType.alcoholic)
                sortButtonByAlcoholic_Click(sender, e);
            else if (sortingType == SortingType.orderID)
                sortButtonOrderID_Click(sender, e);
            else
            {
                if (BartenderOrChef.StaffJob == StaffJob.Chef)
                {
                    KitchenListView();
                }
                else
                {
                    BarListView();
                }
            }
        }
        private void KitchenOverview_Load(object sender, EventArgs e)
        {
            Timer timer1 = new Timer();
            timer1.Interval = 30000;
            timer1.Tick += new System.EventHandler(timerProgress_Tick);
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
                int correctOrderIndex = ordersDrinkList.FindIndex(x => x.OrderId == Convert.ToInt32(barListView.SelectedItems[i].SubItems[0].Text));
                ListViewItem li = new ListViewItem(barListView.SelectedItems[i].SubItems[0].Text);
                li.SubItems.Add(barListView.SelectedItems[i].SubItems[1].Text);
                li.SubItems.Add(ordersDrinkList[correctOrderIndex].Comments);
                //li.SubItems.Add(ordersFoodList[correctOrderIndex].OrderItems.Find(x => x.MenuItem.MenuItemId = ).Text);

                listViewComments.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewComments.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewComments.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);

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
            try
            {
                for (int i = 0; i < kitchenListView.SelectedItems.Count; i++)
                {
                    int correctOrderIndex = ordersFoodList.FindIndex(x => x.OrderId == Convert.ToInt32(kitchenListView.SelectedItems[i].SubItems[0].Text));
                    ListViewItem li = new ListViewItem(kitchenListView.SelectedItems[i].SubItems[0].Text);
                    li.SubItems.Add(kitchenListView.SelectedItems[i].SubItems[1].Text);
                    li.SubItems.Add(ordersFoodList[correctOrderIndex].Comments);

                    listViewComments.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                    listViewComments.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                    listViewComments.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);

                    listViewComments.Items.Add(li);
                }
            }
            catch
            {
                
            }
           
            ColorListView(listViewComments);
            listViewComments.EndUpdate();
        }


        public void KitchenListView()
        {
            kitchenListView.Show();
            labelKitchen.Show();

            barListView.Hide();
            labelBar.Hide();
            finishedDrinkButton.Hide();
            sortButtonByAlcoholic.Hide();

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
            kitchenListView.Columns.Add("ThreeCourseMeal", 200);
            foreach (Order order in ordersFoodList)
            {
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
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemType.ToString());
                        kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
                        kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.ColumnContent);
                        kitchenListView.Items.Add(li);
                    }
            }
            ColorListView(kitchenListView);
            kitchenListView.EndUpdate();
        }
        private void BarListView()
        {
            kitchenListView.Hide();
            labelKitchen.Hide();
            barListView.Show();
            labelBar.Show();
            finishedDrinkButton.Show();

            sortButtonByAlcoholic.Show();
            listViewComments.Hide();
            progressBarUpdate.Show();
            barListView.BeginUpdate();

            OrderService orderService = new OrderService();
            ordersDrinkList = orderService.GetActiveDrinkOrders();

            barListView.Clear();
            barListView.View = View.Details;
            barListView.FullRowSelect = true;
            barListView.Columns.Add("Order ID", 100);
            barListView.Columns.Add("Menuitem ID", 100);
            barListView.Columns.Add("Order", 500); //productname
            barListView.Columns.Add("Amount of order", 100);
            barListView.Columns.Add("Alcoholic", 100);
            barListView.Columns.Add("Table", 200);
            barListView.Columns.Add("Duration of Order (hh:mm)", 200);
            barListView.Columns.Add("Time of ordering", 200);
            foreach (Order order in ordersDrinkList)
            {

                TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        ListViewItem li = new ListViewItem(order.OrderId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                        li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                        li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                        li.SubItems.Add(order.OrderItems[i].IsAlcoholic.ToString());
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
                        barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);

                        barListView.Items.Add(li);
                    }
            }
            ColorListView(barListView);
            barListView.EndUpdate();

        }
        private void ButtonSort(List<Order>ordersFoodList)
        {
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                kitchenListView.BeginUpdate();
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
                kitchenListView.Columns.Add("ThreeCourseMeal", 200);
                foreach (Order order in ordersFoodList)
                {

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
                            li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemType.ToString());
                            kitchenListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                            kitchenListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                            kitchenListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                            kitchenListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                            kitchenListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                            kitchenListView.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
                            kitchenListView.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.ColumnContent);
                            kitchenListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.ColumnContent);

                            kitchenListView.Items.Add(li);

                    }
                }
                kitchenListView.EndUpdate();

                ColorListView(kitchenListView);
            }
            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                barListView.BeginUpdate();

                barListView.Clear();
                barListView.View = View.Details;
                barListView.FullRowSelect = true;
                barListView.Columns.Add("Order ID", 100);
                barListView.Columns.Add("MenuItem ID", 100);
                barListView.Columns.Add("Order", 500); //productname
                barListView.Columns.Add("Amount of order", 100);
                barListView.Columns.Add("Alcoholic", 100);
                barListView.Columns.Add("Table", 200);
                barListView.Columns.Add("Duration of Order (hh:mm)", 200);
                barListView.Columns.Add("Time of ordering", 200);
                foreach (Order order in ordersDrinkList)
                {                                          

                        TimeSpan timeOfOrder = DateTime.Now - order.TimePlaced;
                        for (int i = 0; i < order.OrderItems.Count; i++)
                        {
                            ListViewItem li = new ListViewItem(order.OrderId.ToString());
                            li.SubItems.Add(order.OrderItems[i].MenuItem.MenuItemId.ToString());
                            li.SubItems.Add(order.OrderItems[i].MenuItem.ProductName);
                            li.SubItems.Add(order.OrderItems[i].Amount.ToString());
                            li.SubItems.Add(order.OrderItems[i].IsAlcoholic.ToString());
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
                            barListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);

                            barListView.Items.Add(li);
                        }
                    
                }
            }
            barListView.EndUpdate();

            ColorListView(barListView);
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
                KitchenListView();
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
                timer1_Tick(sender, e);
                progressBarUpdate.Show();
                BarListView();
            }
            catch
            {
                MessageBox.Show("Please make sure to select an order to complete");
            }
        }

        private void barListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            //e.Graphics.FillRectangle(Brush);
        }






        private void sortButtonOrder_Click(object sender, EventArgs e)
        {
            sortingType = SortingType.orderName;

            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                OrderService orderService = new OrderService();
                ordersFoodList = orderService.GetActiveFoodOrders();
                if (radioButtonSortForwards.Checked)
                {
                    foreach (Order order in ordersFoodList)
                    {
                        order.OrderItems = order.OrderItems.OrderBy(x => x.MenuItem.ProductName).ToList();
                    }
                    ordersFoodList = ordersFoodList.OrderBy(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                }
                else if (radioButtonSortBackwards.Checked)
                {
                    foreach (Order order in ordersFoodList)
                    {
                        order.OrderItems = order.OrderItems.OrderByDescending(x => x.MenuItem.ProductName).ToList();
                    }
                    ordersFoodList = ordersFoodList.OrderByDescending(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                }

                ButtonSort(ordersFoodList);
                
            }
            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                OrderService orderService = new OrderService();
                ordersDrinkList = orderService.GetActiveDrinkOrders();
                if (radioButtonSortForwards.Checked)
                {
                    foreach (Order order in ordersDrinkList)
                    {
                        order.OrderItems = order.OrderItems.OrderBy(x => x.MenuItem.ProductName).ToList();
                    }
                    ordersDrinkList = ordersDrinkList.OrderBy(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                }
                else if (radioButtonSortBackwards.Checked)
                {
                    foreach (Order order in ordersDrinkList)
                    {
                        order.OrderItems = order.OrderItems.OrderByDescending(x => x.MenuItem.ProductName).ToList();
                    }
                    ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.OrderItems[0].MenuItem.ProductName).ToList();
                }
   
                ButtonSort(ordersDrinkList);
            }
        }

        private void sortButtonAmount_Click(object sender, EventArgs e)
        {
            sortingType = SortingType.amount;
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                OrderService orderService = new OrderService();
                ordersFoodList = orderService.GetActiveFoodOrders();
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
                ButtonSort(ordersFoodList);
            }
            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
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
                ButtonSort(ordersDrinkList);
            }
        }



        private void sortButtonTable_Click(object sender, EventArgs e)
        {
            sortingType = SortingType.table;
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {

                if (radioButtonSortForwards.Checked)
                {
                    ordersFoodList = ordersFoodList.OrderBy(x => x.TableId).ToList();
                }
                else if (radioButtonSortBackwards.Checked)
                {
                    ordersFoodList = ordersFoodList.OrderByDescending(x => x.TableId).ToList();
                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }
                ButtonSort(ordersFoodList);
            }

            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                if (radioButtonSortForwards.Checked)
                {
                    ordersDrinkList = ordersDrinkList.OrderBy(x => x.TableId).ToList();
                }
                else if (radioButtonSortBackwards.Checked)
                {
                    ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.TableId).ToList();
                }
                else
                {
                    MessageBox.Show("Please select first if you want to sort forwards or backwards");
                }
                ButtonSort(ordersDrinkList);
                
            }
        }
        private void sortButtonDuration_Click(object sender, EventArgs e)
        {
            sortingType = SortingType.duration;
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                if (radioButtonSortForwards.Checked)
                {
                    ordersFoodList = ordersFoodList.OrderBy(x => x.TimePlaced).ToList();
                }
                else if (radioButtonSortBackwards.Checked)
                {
                    ordersFoodList = ordersFoodList.OrderByDescending(x => x.TimePlaced).ToList();
                }
                ButtonSort(ordersFoodList);
            }


            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
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
                ButtonSort(ordersDrinkList);
            }
        }

        private void drinkButtonTable_Click(object sender, EventArgs e)
        {

        }

        private void sortButtonByAlcoholic_Click(object sender, EventArgs e)
        {
            sortingType = SortingType.alcoholic;
            if (radioButtonSortForwards.Checked)
            {
                OrderService orderService = new OrderService();
                ordersFoodList = orderService.GetActiveFoodOrders();
                ButtonSort(ordersFoodList);
            }
            else if (radioButtonSortBackwards.Checked)
            {
                OrderService orderService = new OrderService();
                ButtonSort(ordersDrinkList);

            }

        }

        private void sortButtonOrderID_Click(object sender, EventArgs e)
        {
            sortingType = SortingType.orderID;

            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                OrderService orderService = new OrderService();
                ordersDrinkList = orderService.GetActiveFoodOrders();
                if (radioButtonSortForwards.Checked)
                {

                    ordersDrinkList = ordersDrinkList.OrderBy(x => x.OrderId).ToList();
                }
                else if (radioButtonSortBackwards.Checked)
                {

                    ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.OrderId).ToList();
                }

                ButtonSort(ordersDrinkList);

            }
            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                OrderService orderService = new OrderService();
                ordersDrinkList = orderService.GetActiveDrinkOrders();
                if (radioButtonSortForwards.Checked)
                {

                    ordersDrinkList = ordersDrinkList.OrderBy(x => x.OrderId).ToList();
                }
                else if (radioButtonSortBackwards.Checked)
                {

                    foreach (Order order in ordersDrinkList)
                    {
                        order.OrderItems = order.OrderItems.OrderByDescending(x => x.IsAlcoholic).ToList();
                    }
                    ordersDrinkList = ordersDrinkList.OrderByDescending(x => x.OrderItems[0].IsAlcoholic).ToList();
                }

                ButtonSort(ordersDrinkList);
            }
        }

        private void SelectAllOnOrderID_Click(object sender, EventArgs e)
        {
            if (BartenderOrChef.StaffJob == StaffJob.Chef)
            {
                kitchenListView.SelectedItems.Clear();
                foreach(ListViewItem li in kitchenListView.Items)
                {
                    if(li.SubItems[0].Text == textBoxOrderId.Text)
                    {
                        li.Selected = true;
                    }
                }

            }
            else if (BartenderOrChef.StaffJob == StaffJob.Bartender)
            {
                barListView.SelectedItems.Clear();
                foreach (ListViewItem li in barListView.Items)
                {
                    if (li.SubItems[0].Text == textBoxOrderId.Text)
                    {
                        li.Selected = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

                kitchenListView.SelectedItems.Clear();
                foreach (ListViewItem li in kitchenListView.Items)
                {
                    if (li.SubItems[7].Text == comboBoxThreeCourseMeal.Text)
                    {
                        li.Selected = true;
                    }
                }
        }
    }
    

}

