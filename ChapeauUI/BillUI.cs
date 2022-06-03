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
        public BillUI(Reservation reservation)
        {
            InitializeComponent();
            //ShowHeader();
            MakeBill(reservation.ReservationId);//reservation.ReservationId);
        }

        public void ShowHeader()
        {
             //headerLabel.Text = $"bill table {table.TableID}";
             //headerLabel.Text = headerLabel.Text.ToUpper();
        }
        private void MakeBill(int reservation)
        {
            BillService billService = new BillService();
            Bill bill = billService.MakeBill(reservation);
            labelExVAT.Text = bill.TotalPriceExclVAT.ToString("€ 0.00");
            labelInVAT.Text = bill.TotalPriceInclVAT.ToString("€ 0.00");
            //also display vat
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
            double tip = double.Parse(Interaction.InputBox("Do you want to add a tip?", "Add tip", "Amount"));
            if(tip > 0)
            {
                labelTip.Text = tip.ToString("€ 0.00");
                double newTotal = double.Parse(labelInVAT.Text.Substring(1)) + tip;
                labelInVAT.Text = newTotal.ToString("€ 0.00");
            }
            else
            {
                ConfirmOrderUI confirmBackButton = new ConfirmOrderUI("Tip can not be negative");
                confirmBackButton.ShowDialog();
                MessageBox.Show("Tip can not be negative");
            }
            
        }
    }
}
