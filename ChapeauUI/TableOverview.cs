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
            hideAllPanels();
            startMenuPnl.Show();
        }

        private void checkTimeSinceOrderPlaced()
        {
            OrderService orderService = new OrderService();
            List<Order> lastOrders = orderService.GetLastOrders();
            for(int i = 0; i < 10; i++)
            {

            }
        }
        private void hideAllPanels()
        {
            startMenuPnl.Hide();
            TableOverviewPnl.Hide();
            makeReservationPnl.Hide();
            markReservationPresentPnl.Hide();
            notificationsPnl.Hide();
        }
        private void tableWasSelected(int tableNr)
        {
            if (menuChoice == MenuChoice.TakeOrder)
            {
                ReservationService reservationService = new ReservationService();

                OrderUI orderUI = new OrderUI(reservationService.GetPresentReservationByTable(tableNr), loggedInStaffMember.Staff_ID);
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
                hideAllPanels();
                makeReservationPnl.Show();
                selectedTable = tableNr;
            }
        }

        private void takeOrderBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            menuChoice = MenuChoice.TakeOrder;
            TableOverviewPnl.Show();
        }
        private void showBillBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            menuChoice = MenuChoice.ShowBill;
            TableOverviewPnl.Show();
        }

        private void makeReservationBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            menuChoice = MenuChoice.MakeReservation;
            TableOverviewPnl.Show();
        }

        private void notificationsBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            notificationsPnl.Show();
            fillReadyOrderDataGrid();
            fillOngoingOrderDataGrid();
        }

        private void openTableOverviewPnl()
        {
            ReservationService reservationService = new ReservationService();
            List<Reservation> reservations = reservationService.
        }

        private void setTableImagePresent(int tableID)
        {
            switch (tableID)
            {
                case 1:
                    tableOneButton.BackgroundImage = Properties.Resources.Ta
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
            tableWasSelected(1);
        }

        private void tableTwoButton_Click(object sender, EventArgs e)
        {
            tableWasSelected(2);
        }

        private void tableThreeButton_Click(object sender, EventArgs e)
        {
            tableWasSelected(3);
        }

        private void tableFourButton_Click(object sender, EventArgs e)
        {
            tableWasSelected(4);
        }

        private void tableFiveButton_Click(object sender, EventArgs e)
        {
            tableWasSelected(5);
        }

        private void tableSixButton_Click(object sender, EventArgs e)
        {
            tableWasSelected(6);
        }

        private void tableSevenButton_Click(object sender, EventArgs e)
        {
            tableWasSelected(7);
        }

        private void tableEightButton_Click(object sender, EventArgs e)
        {
            tableWasSelected(8);
        }

        private void tableNineButton_Click(object sender, EventArgs e)
        {
            tableWasSelected(9);
        }

        private void tableTenButton_Click(object sender, EventArgs e)
        {
            tableWasSelected(10);
        }

        private void confirmReservationBtn_Click(object sender, EventArgs e)
        {
            ReservationService reservationService = new ReservationService();
            string customerName = reservationNameTextBox.Text;
            DateTime reservationTime = reservationDateTimePicker.Value;
            string comments = reservationCommentsTextBox.Text;
            int phoneNumber = int.Parse(reservationPhonenumberTextBox.Text);
            string emailAdress = reservationEmailTextBox.Text;
            reservationService.AddNewReservation(customerName, false, reservationTime, selectedTable, comments, phoneNumber, emailAdress);
            hideAllPanels();
            startMenuPnl.Show();
        }

        private void markReservationPresentBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();
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

        private void reservationOverviewDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            MessageBox.Show("test");
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
