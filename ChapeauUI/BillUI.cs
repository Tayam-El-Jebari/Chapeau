using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;
using ChapeauLogic;
using Microsoft.VisualBasic;

namespace ChapeauUI
{
    public partial class BillUI : Form
    {

        private double totalPrice;
        private BillService billService;
        private Bill bill;
        private ConfirmOrderUI confirmOrder;
        private Reservation reservation;
        private double tip;
        private double priceAfterTip;
        private string comment;

        public BillUI(Reservation choosenReservation)
        {
            InitializeComponent();
            this.reservation = choosenReservation;
            ShowHeader();
            MakeBill();
        }

        public void ShowHeader()
        {
             headerLabel.Text = $"bill table {reservation.TableId}";
             headerLabel.Text = headerLabel.Text.ToUpper();
        }
        private void MakeBill()
        {
            billService = new BillService();
            bill = billService.MakeBill(reservation.ReservationId);
            totalPrice = bill.TotalPriceExclVAT;
            labelExVAT.Text = totalPrice.ToString("€ 0.00");
            labelVAT.Text = bill.TotalVAT.ToString("€ 0.00");
            labelInVAT.Text = bill.TotalPriceInclVAT.ToString("€ 0.00");
            FillGrid(billGrid);
        }

        private void buttonTip_Click(object sender, EventArgs e)
        {
          
            confirmOrder = new ConfirmOrderUI("Do you want to add a tip?", DialogResult.None);
            confirmOrder.ShowDialog();
            tip = confirmOrder.InputDouble();
            labelTip.Text = tip.ToString("€ 0.00");
            priceAfterTip = totalPrice + tip;
            labelInVAT.Text = priceAfterTip.ToString("€ 0.00");   
        }
        private void ReadComment()
        {
            comment = commentBox.Text;
            if (comment == "Add comment here...")
            {
                comment = "No Comment";
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowBill()
        {
            ReadComment();
            billPanel.Hide();
            completeBill.Show();

        }
        private void FillCompleteBill()
        {
            labelBillExVAT.Text = bill.TotalPriceExclVAT.ToString("€ 0.00");
            labelBillTotal.Text = totalPrice.ToString("€ 0.00");
            labelTip.Text = tip.ToString("€ 0.00");
            labelVAT.Text = bill.TotalVAT.ToString("€ 0.00");
            //labelPaymentMethod.Text = paymentMethod;
            labelSplitBill.Text = "3";
            

            FillGrid(gridCompleteBill);
        }
        private void FillGrid(DataGridView grid)
        {
            grid.ColumnCount = 3;
            grid.Columns[0].Name = "MENU ITEMS";
            grid.Columns[0].Width = 450;
            grid.Columns[1].Name = "QTY";
            grid.Columns[1].Width = 80;
            grid.Columns[2].Name = "PRICE";
            grid.Columns[2].Width = 120;
            for (int i = 0; i < bill.MenuItems.Count; i++)
            {
                grid.Rows.Add
                    (bill.MenuItems[i].MenuItem.ProductName,
                    bill.MenuItems[i].Amount,
                    bill.MenuItems[i].MenuItem.Price.ToString("€ 0.00"));
            };
        }
    }
}
