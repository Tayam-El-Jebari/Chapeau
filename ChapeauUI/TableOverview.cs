using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class TableOverview : Form
    {
        private int selectedTable;
        private MenuChoice menuChoice;
        private Staff loggedInStaffMember;
        public TableOverview(Staff loggedInStaffMember)
        {
            this.loggedInStaffMember = loggedInStaffMember;
            InitializeComponent();
            HideAllPanels();
            startMenuPnl.Show();
        }

        //Hide all the panels. 
        private void HideAllPanels()
        {
            startMenuPnl.Hide();
            TableOverviewPnl.Hide();
            makeReservationPnl.Hide();
            markReservationPresentPnl.Hide();
            notificationsPnl.Hide();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 30000;//30 seconds
            timer.Tick += new System.EventHandler(timer_Tick);
            timer.Start();
        }

        //Based on the choice made in the startmenu make the open the right window for the table that was selected.
        private void TableWasSelected(int tableNr)
        {
            try
            {
                ReservationService reservationService = new ReservationService();
                selectedTable = tableNr;
                switch (menuChoice)
                {
                    case MenuChoice.TakeOrder:
                        OrderUI orderUI = new OrderUI(reservationService.GetPresentReservationByTable(tableNr), loggedInStaffMember);
                        this.Hide();
                        orderUI.ShowDialog();
                        this.Show();
                        break;
                    case MenuChoice.ShowBill:
                        BillUI billUI = new BillUI(reservationService.GetPresentReservationByTable(tableNr), loggedInStaffMember);
                        this.Hide();
                        billUI.ShowDialog();
                        this.Show();
                        break;
                    case MenuChoice.MakeReservation:
                        HideAllPanels();
                        makeReservationPnl.Show();
                        break;
                }
            }
            catch (Exception e)
            {
                PopUpUI errorBox = new PopUpUI(e.Message, DialogResult.OK);
                errorBox.ShowDialog();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            openTableOverviewPnl();
            fillnonPresentReservationOverviewDataGrid();
            fillOngoingOrderDataGrid();
            fillReadyOrderDataGrid();
        }

        private void takeOrderBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            menuChoice = MenuChoice.TakeOrder;
            openTableOverviewPnl();
            TableOverviewPnl.Show();
        }
        private void showBillBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            menuChoice = MenuChoice.ShowBill;
            openTableOverviewPnl();
            TableOverviewPnl.Show();
        }

        private void makeReservationBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            menuChoice = MenuChoice.MakeReservation;
            openTableOverviewPnl();
            TableOverviewPnl.Show();
            reservationDateTimePicker.MinDate = DateTime.Today;
        }

        private void notificationsBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            menuChoice = MenuChoice.Notifications;
            notificationsPnl.Show();
            fillReadyOrderDataGrid();
            fillOngoingOrderDataGrid();
        }

        //Set the background image of each table to the right picture based on if a table is occupied or reserved.
        private void openTableOverviewPnl()
        {
            ReservationService reservationService = new ReservationService();
            List<Reservation> presentReservations = reservationService.GetAllPresentReservationsOrderedByTable();
            List<Reservation> reservations = reservationService.GetAllReservationsForToday();
            Dictionary<int, TableStatus> tableStatus = new Dictionary<int, TableStatus>();
            for(int i = 0; i < TableOverviewPnl.Controls.Count; i++)
            {
                tableStatus[i] = TableStatus.Free;
            }
            foreach(Reservation reservation in reservations)
            {
                tableStatus[reservation.TableId -1] = TableStatus.Reserved;
            }
            foreach(Reservation presentReservation in presentReservations)
            {
                tableStatus[presentReservation.TableId-1] = TableStatus.Occupied;
            }
            for(int i = 0; i < TableOverviewPnl.Controls.Count; i++)
            {
                Control control = TableOverviewPnl.Controls[i];
                setTableBackground(control, tableStatus[i]);
                //setTableBackground(control, TableStatus.Occupied);
            }
        }

        //Set the background image of a table to the right picture based on if a table is occupied or reserved.
        private void setTableBackground(Control control, TableStatus tableStatus)
        {
            switch (tableStatus)
            {
                case TableStatus.Free:
                    control.BackgroundImage = Properties.Resources.TableFree;
                    control.ForeColor = System.Drawing.Color.White;
                    break;
                case TableStatus.Reserved:
                    control.BackgroundImage = Properties.Resources.TableReserved;
                    control.ForeColor = System.Drawing.Color.Black;
                    break;
                case TableStatus.Occupied:
                    control.BackgroundImage = Properties.Resources.TableOccupied;
                    control.ForeColor = System.Drawing.Color.White;
                    break;
            }
        }
        
        //Get the orders that are ready to deliver and put it in the datagridview.
        private void fillReadyOrderDataGrid()
        {
            OrderService orderService = new OrderService();
            List<Order> readyFoodOrders = orderService.GetFoodOrdersForWaiterToDeliver(loggedInStaffMember.Staff_ID);
            List<Order> readyDrinkOrders = orderService.GetDrinkOrdersForWaiterToDeliver(loggedInStaffMember.Staff_ID);
            ordersReadyGridView.Rows.Clear();
            ordersReadyGridView.ColumnCount = 3;
            ordersReadyGridView.Columns[0].Name = "Order ID";
            ordersReadyGridView.Columns[1].Name = "Table ID";
            ordersReadyGridView.Columns[2].Name = "Order Type";
            foreach (Order foodOrder in readyFoodOrders)
            {
                ordersReadyGridView.Rows.Add(foodOrder.OrderId, foodOrder.TableId, "Food");
            }
            foreach (Order drinkOrder in readyDrinkOrders)
            {
                ordersReadyGridView.Rows.Add(drinkOrder.OrderId, drinkOrder.TableId, "Drink");
            }
        }

        //Get the orders that are still being prepared and put it in the datagridview.
        private void fillOngoingOrderDataGrid()
        {
            OrderService orderService = new OrderService();
            List<Order> ongoingFoodOrders = orderService.GetOngoingFoodOrdersForWaiter(loggedInStaffMember.Staff_ID);
            List<Order> ongoingDrinkOrders = orderService.GetOngoingDrinkOrdersForWaiter(loggedInStaffMember.Staff_ID);
            ongoingOrdersDataGridView.Rows.Clear();
            ongoingOrdersDataGridView.ColumnCount = 4;
            ongoingOrdersDataGridView.Columns[0].Name = "Order ID";
            ongoingOrdersDataGridView.Columns[0].Width = 100;
            ongoingOrdersDataGridView.Columns[1].Name = "Table ID";
            ongoingOrdersDataGridView.Columns[2].Name = "Order Type";
            ongoingOrdersDataGridView.Columns[3].Name = "Time placed";
            ongoingOrdersDataGridView.Columns[3].Width = 250;
            foreach (Order foodOrder in ongoingFoodOrders)
            {
                ongoingOrdersDataGridView.Rows.Add(foodOrder.OrderId, foodOrder.TableId, "Food", DateTime.Now.Subtract(foodOrder.TimePlaced).ToString(@"hh\:mm\:ss"));
            }
            foreach (Order drinkOrder in ongoingDrinkOrders)
            {
                ongoingOrdersDataGridView.Rows.Add(drinkOrder.OrderId, drinkOrder.TableId, "Drink", DateTime.Now.Subtract(drinkOrder.TimePlaced).ToString(@"hh\:mm\:ss"));
            }
        }

        private void tableOneButton_Click(object sender, EventArgs e)
        {
            TableWasSelected(1);
        }

        private void tableTwoButton_Click(object sender, EventArgs e)
        {
            TableWasSelected(2);
        }

        private void tableThreeButton_Click(object sender, EventArgs e)
        {
            TableWasSelected(3);
        }

        private void tableFourButton_Click(object sender, EventArgs e)
        {
            TableWasSelected(4);
        }

        private void tableFiveButton_Click(object sender, EventArgs e)
        {
            TableWasSelected(5);
        }

        private void tableSixButton_Click(object sender, EventArgs e)
        {
            TableWasSelected(6);
        }

        private void tableSevenButton_Click(object sender, EventArgs e)
        {
            TableWasSelected(7);
        }

        private void tableEightButton_Click(object sender, EventArgs e)
        {
            TableWasSelected(8);
        }

        private void tableNineButton_Click(object sender, EventArgs e)
        {
            TableWasSelected(9);
        }

        private void tableTenButton_Click(object sender, EventArgs e)
        {
            TableWasSelected(10);
        }

        //Get the information from the fields and make a new reservation and send it to the database.
        private void confirmReservationBtn_Click(object sender, EventArgs e)
        {
            ReservationService reservationService = new ReservationService();
            string customerName = reservationNameTextBox.Text;
            DateTime time = TimePicker.Value;
            DateTime reservationTime = reservationDateTimePicker.Value.Date.AddHours(time.Hour).AddMinutes(time.Minute).AddSeconds(0);
            reservationTime.AddHours(time.Hour).AddMinutes(time.Minute).AddSeconds(0);
            string comments = reservationCommentsTextBox.Text;
            int phoneNumber;
            try
            {
                phoneNumber = Convert.ToInt32(reservationPhonenumberTextBox.Text);
            }
            catch
            {
                PopUpUI crash = new PopUpUI("Please enter a correct phone number", DialogResult.OK);
                crash.ShowDialog();
                return;
            }
            string emailAdress = reservationEmailTextBox.Text;
            Reservation newReservation = new Reservation()
            {
                CustomerFullName = customerName,
                isPresent = false,
                ReservationTime = reservationTime,
                TableId = selectedTable,
                Comments = comments,
                Phonenumber = phoneNumber,
                Emailaddres = emailAdress
            };
            reservationService.AddNewReservation(newReservation);
            PopUpUI reservationMadeBox = new PopUpUI("The reservation has been made.", DialogResult.OK);
            reservationMadeBox.ShowDialog();
            HideAllPanels();
            startMenuPnl.Show();
        }

        private void markReservationPresentBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            menuChoice = MenuChoice.MarkPresent;
            markReservationPresentPnl.Show();
            fillnonPresentReservationOverviewDataGrid();
        }

        //Get the reservations that are not present and put it in the datagridview.
        private void fillnonPresentReservationOverviewDataGrid()
        {
            reservationOverviewDataGrid.Rows.Clear();
            ReservationService reservationService = new ReservationService();
            List<Reservation> reservations = reservationService.GetAllNonPresentReservationsOrderedByTable();
            reservationOverviewDataGrid.ColumnCount = 3;
            reservationOverviewDataGrid.Columns[0].Name = "Reservation ID";
            reservationOverviewDataGrid.Columns[1].Name = "Table ID";
            reservationOverviewDataGrid.Columns[2].Name = "Reservation time";
            foreach (Reservation reservation in reservations)
            {
                reservationOverviewDataGrid.Rows.Add(reservation.ReservationId, reservation.TableId, reservation.ReservationTime);
            }
        }

        private void setReservationPresentBtn_Click(object sender, EventArgs e)
        {
            ReservationService reservationService = new ReservationService();
            try
            {
                if (reservationService.GetPresentReservationByTable(Convert.ToInt32(reservationOverviewDataGrid.SelectedRows[0].Cells[1].Value)) != null)
                {
                    PopUpUI tableOccupiedBox = new PopUpUI("The reservation has been made.", DialogResult.OK);
                    tableOccupiedBox.ShowDialog();
                }
            }
            catch
            {
                reservationService.MarkReservationPresent(Convert.ToInt32(reservationOverviewDataGrid.SelectedRows[0].Cells[0].Value));
            }
            fillnonPresentReservationOverviewDataGrid();
        }

        private void markOrderReadyBtn_Click(object sender, EventArgs e)
        {
            OrderService orderService = new OrderService();
            OrderItemService orderItemService = new OrderItemService();
            int orderID = Convert.ToInt32(ordersReadyGridView.SelectedRows[0].Cells[0].Value);
            PopUpUI confirmDelivery = new PopUpUI($"Are you sure you want to deliver order {orderID}");
            confirmDelivery.ShowDialog();
            if(confirmDelivery.DialogResult == DialogResult.Yes)
            {
                if (Convert.ToString(ordersReadyGridView.SelectedRows[0].Cells[2].Value) == "Drink")
                {
                    orderItemService.UpdateDrinkOrderStatusToDeliverd(orderID);
                }
                if (Convert.ToString(ordersReadyGridView.SelectedRows[0].Cells[2].Value) == "Food")
                {
                    orderItemService.UpdateFoodOrderStatusToDeliverd(orderID);
                }
                orderService.UpdateStateIsFinished(orderID);
                fillReadyOrderDataGrid();
            }
        }

        //Go back to menu or log out depending on where you are in the application.
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (menuChoice != 0)
            {
                menuChoice = 0;
                HideAllPanels();
                startMenuPnl.Show();
            }
            else
            {
                this.Close();
            }
        }
    }
}
