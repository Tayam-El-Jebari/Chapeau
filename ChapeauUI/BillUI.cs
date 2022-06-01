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

namespace ChapeauUI
{
    public partial class BillUI : Form
    {
        public BillUI()// Reservation reservation)
        {
            InitializeComponent();
            //ShowHeader();
            MakeBill(204);//reservation.ReservationId);
        }

        public void ShowHeader()
        {
             //headerLabel.Text = $"bill table {table.TableID}";
             //headerLabel.Text = headerLabel.Text.ToUpper();
             //InitFont(headerLabel);
        }
        private void MakeBill(int reservation)
        {
            BillService billService = new BillService();
            Bill bill = billService.MakeBill(reservation);
            labelExVAT.Text = bill.TotalPriceExclVAT.ToString("0.00");
            labelInVAT.Text = bill.TotalPriceInclVAT.ToString("0.00");

            billGrid.ColumnCount = 3;
            billGrid.Columns[0].Name = "Menu Item";
            billGrid.Columns[0].Width = 319;
            billGrid.Columns[1].Name = "Amount";
            billGrid.Columns[1].Width = 80;
            billGrid.Columns[2].Name = "Price";
            billGrid.Columns[2].Width = 200;
            for (int i = 0; i < bill.MenuItems.Count; i++)
            {
                billGrid.Rows.Add(bill.MenuItems[i].ProductName, bill.MenuItems[i].Amount, bill.MenuItems[i].Price);
            };
        }
        public void InitFont(Label label)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            int fontLength = Properties.Resources.Cabin.Length;
            byte[] fontdata = Properties.Resources.Cabin;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
            label.Font = new Font(pfc.Families[0], label.Font.Size);
        }

    }
}
