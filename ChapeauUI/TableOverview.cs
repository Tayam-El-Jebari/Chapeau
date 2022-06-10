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

        
        private void HideAllPanels()
        {
            startMenuPnl.Hide();
            TableOverviewPnl.Hide();
            makeReservationPnl.Hide();
            markReservationPresentPnl.Hide();
            notificationsPnl.Hide();
        }

        // make switch
        private void TableWasSelected(int tableNr)
        {
            if (menuChoice == MenuChoice.TakeOrder)
            {
                ReservationService reservationService = new ReservationService();

                OrderUI orderUI = new OrderUI(reservationService.GetPresentReservationByTable(tableNr), loggedInStaffMember);
                this.Hide();
                orderUI.ShowDialog();
                this.Show();
            }
            else if (menuChoice == MenuChoice.ShowBill)
            {
                ReservationService reservationService = new ReservationService();
                BillUI billUI = new BillUI();
                this.Hide();
                billUI.ShowDialog();
                this.Show();
            }
            else if (menuChoice == MenuChoice.MakeReservation)
            {
                HideAllPanels();
                makeReservationPnl.Show();
                selectedTable = tableNr;
            }
        }

        private void takeOrderBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            menuChoice = MenuChoice.TakeOrder;
            openTableOverviewPnl();
        }
        private void showBillBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            menuChoice = MenuChoice.ShowBill;
            openTableOverviewPnl();
        }

        private void makeReservationBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            menuChoice = MenuChoice.MakeReservation;
            openTableOverviewPnl();
        }

        private void notificationsBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            notificationsPnl.Show();
            fillReadyOrderDataGrid();
            fillOngoingOrderDataGrid();
        }

        private void openTableOverviewPnl()
        {
            ReservationService reservationService = new ReservationService();
            List<Reservation> presentReservations = reservationService.GetAllPresentReservationsOrderedByTable();
            List<Reservation> reservations = reservationService.GetAllReservationsForToday();
            setAllTablesBackgroundFree();
            foreach(Reservation reservation in reservations)
            {
                setTableImageReservation(reservation.TableId);
            }
            foreach(Reservation presentReservation in presentReservations)
            {
                setTableImagePresent(presentReservation.TableId);
            }
            TableOverviewPnl.Show();
        }
        private void setAllTablesBackgroundFree()
        {
            tableOneButton.BackgroundImage = Properties.Resources.TableFree;
            tableTwoButton.BackgroundImage = Properties.Resources.TableFree;
            tableThreeButton.BackgroundImage = Properties.Resources.TableFree;
            tableFourButton.BackgroundImage = Properties.Resources.TableFree;
            tableFiveButton.BackgroundImage = Properties.Resources.TableFree;
            tableSixButton.BackgroundImage = Properties.Resources.TableFree;
            tableSevenButton.BackgroundImage = Properties.Resources.TableFree;
            tableEightButton.BackgroundImage = Properties.Resources.TableFree;
            tableNineButton.BackgroundImage = Properties.Resources.TableFree;
            tableTenButton.BackgroundImage = Properties.Resources.TableFree;
        }
        private void setTableImagePresent(int tableID)
        {
            switch (tableID)
            {
                case 1:
                    tableOneButton.BackgroundImage = Properties.Resources.TableOccupied;
                    break;
                case 2:
                    tableTwoButton.BackgroundImage = Properties.Resources.TableOccupied;
                    break;
                case 3:
                    tableThreeButton.BackgroundImage = Properties.Resources.TableOccupied;
                    break;
                case 4:
                    tableFourButton.BackgroundImage = Properties.Resources.TableOccupied;
                    break;
                case 5:
                    tableFiveButton.BackgroundImage = Properties.Resources.TableOccupied;
                    break;
                case 6:
                    tableSixButton.BackgroundImage = Properties.Resources.TableOccupied;
                    break;
                case 7:
                    tableSevenButton.BackgroundImage = Properties.Resources.TableOccupied;
                    break;
                case 8:
                    tableEightButton.BackgroundImage = Properties.Resources.TableOccupied;
                    break;
                case 9:
                    tableNineButton.BackgroundImage = Properties.Resources.TableOccupied;
                    break;
                case 10:
                    tableOneButton.BackgroundImage = Properties.Resources.TableOccupied;
                    break;
            }
        }

        private void setTableImageReservation(int tableID)
        {
            switch (tableID)
            {
                case 1:
                    tableOneButton.BackgroundImage = Properties.Resources.TableReserved;
                    break;
                case 2:
                    tableTwoButton.BackgroundImage = Properties.Resources.TableReserved;
                    break;
                case 3:
                    tableThreeButton.BackgroundImage = Properties.Resources.TableReserved;
                    break;
                case 4:
                    tableFourButton.BackgroundImage = Properties.Resources.TableReserved;
                    break;
                case 5:
                    tableFiveButton.BackgroundImage = Properties.Resources.TableReserved;
                    break;
                case 6:
                    tableSixButton.BackgroundImage = Properties.Resources.TableReserved;
                    break;
                case 7:
                    tableSevenButton.BackgroundImage = Properties.Resources.TableReserved;
                    break;
                case 8:
                    tableEightButton.BackgroundImage = Properties.Resources.TableReserved;
                    break;
                case 9:
                    tableNineButton.BackgroundImage = Properties.Resources.TableReserved;
                    break;
                case 10:
                    tableOneButton.BackgroundImage = Properties.Resources.TableReserved;
                    break;
            }
        }

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
                ongoingOrdersDataGridView.Rows.Add(foodOrder.OrderId, foodOrder.TableId, "Food", foodOrder.TimePlaced);
            }
            foreach (Order drinkOrder in ongoingDrinkOrders)
            {
                ongoingOrdersDataGridView.Rows.Add(drinkOrder.OrderId, drinkOrder.TableId, "Drink", drinkOrder.TimePlaced);
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

        private void confirmReservationBtn_Click(object sender, EventArgs e)
        {
            ReservationService reservationService = new ReservationService();
            string customerName = reservationNameTextBox.Text;
            DateTime time = TimePicker.Value;
            DateTime reservationTime = reservationDateTimePicker.Value.Date.AddHours(time.Hour).AddMinutes(time.Minute).AddSeconds(0);
            reservationTime.AddHours(time.Hour).AddMinutes(time.Minute).AddSeconds(0);
            string comments = reservationCommentsTextBox.Text;
            int phoneNumber = Convert.ToInt32(reservationPhonenumberTextBox.Text);
            string emailAdress = reservationEmailTextBox.Text;
            //maak object
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
            HideAllPanels();
            startMenuPnl.Show();
        }

        private void markReservationPresentBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            markReservationPresentPnl.Show();
            fillnonPresentReservationOverviewDataGrid();
        }

        private void fillnonPresentReservationOverviewDataGrid()
        {
            reservationOverviewDataGrid.Rows.Clear();
            ReservationService reservationService = new ReservationService();
            List<Reservation> reservations = reservationService.GetAllNonPresentReservationsOrderedByTable();
            reservationOverviewDataGrid.ColumnCount = 2;
            reservationOverviewDataGrid.Columns[0].Name = "Reservation ID";
            reservationOverviewDataGrid.Columns[1].Name = "Reservation time";
            foreach (Reservation reservation in reservations)
            {
                reservationOverviewDataGrid.Rows.Add(reservation.ReservationId, reservation.ReservationTime);
            }
        }

        private void setReservationPresentBtn_Click(object sender, EventArgs e)
        {
            ReservationService reservationService = new ReservationService();
            for(int i = 0; i < reservationOverviewDataGrid.SelectedCells.Count; i++)
            {
                reservationService.MarkReservationPresent(Convert.ToInt32(reservationOverviewDataGrid.SelectedCells[i].Value));
            }
            fillnonPresentReservationOverviewDataGrid();
        }

        private void markOrderReadyBtn_Click(object sender, EventArgs e)
        {
            OrderService orderService = new OrderService();
            OrderItemService orderItemService = new OrderItemService();
            int orderID = Convert.ToInt32(ordersReadyGridView.SelectedRows[0].Cells[0].Value);
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
}
