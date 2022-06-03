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
        public BillUI(Reservation reservation)
        {
            InitializeComponent();
            ShowHeader(reservation.TableId);
            MakeBill(reservation.ReservationId);//reservation.ReservationId);
        }

        public void ShowHeader(int table)
        {
             headerLabel.Text = $"bill table {table}";
             headerLabel.Text = headerLabel.Text.ToUpper();
        }
        private void MakeBill(int reservation)
        {
            BillService billService = new BillService();
            Bill bill = billService.MakeBill(reservation);
            this.totalPrice = bill.TotalPriceExclVAT;
            labelExVAT.Text = totalPrice.ToString("€ 0.00");
            labelVAT.Text = bill.TotalVAT.ToString("€ 0.00");
            labelInVAT.Text = bill.TotalPriceInclVAT.ToString("€ 0.00");
            //bon half cash half pin

            billGrid.ColumnCount = 3;
            billGrid.Columns[0].Name = "Menu Item";
            billGrid.Columns[0].Width = 319;
            billGrid.Columns[1].Name = "Amount";
            billGrid.Columns[1].Width = 80;
            billGrid.Columns[2].Name = "Price";
            billGrid.Columns[2].Width = 200;
            for (int i = 0; i < bill.MenuItems.Count; i++)
            {
                billGrid.Rows.Add(bill.MenuItems[i].MenuItem.ProductName, bill.MenuItems[i].Amount, bill.MenuItems[i].MenuItem.Price.ToString("€ 0.00"));
            };
        }

        private void buttonTip_Click(object sender, EventArgs e)
        {
          
                ConfirmOrderUI confirmOrder = new ConfirmOrderUI("Do you want to add a tip?", DialogResult.None);
                confirmOrder.ShowDialog();
                double tip = confirmOrder.InputDouble();
                labelTip.Text = tip.ToString("€ 0.00");
                double newTotal = totalPrice + tip;
                labelInVAT.Text = newTotal.ToString("€ 0.00");   
        }
    }
}
