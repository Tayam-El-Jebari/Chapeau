using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;

// using chapeau model (temp)
using ChapeauModel;


namespace ChapeauUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //DON'T FORGET TO REMOVE USING CHAPEAU MODEL SVP!
            Reservation reservation = new Reservation
            {
                ReservationId = 202,
                TableId = 4
            };
            Application.Run(new OrderUI(reservation, 8));
            //Application.Run(new StartScreen());
        }
    }
}
