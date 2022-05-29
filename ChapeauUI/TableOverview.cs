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
        public TableOverview()
        {
            InitializeComponent();
        }

        private void hideAllPanels()
        {
            startMenuPnl.Hide();
            TableOverviewPnl.Hide();
            reservationPnl.Hide();
        }

        private void takeOrderBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            menuChoice = MenuChoice.TakeOrder;
            TableOverviewPnl.Show();
        }

        private void tableWasSelected(int tableNr)
        {
            if (menuChoice == MenuChoice.TakeOrder)
            {
                OrderUI orderUI = new OrderUI();
                this.Hide();
                orderUI.Show();
            }
            else if (menuChoice == MenuChoice.ShowBill)
            {

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
    }
}
