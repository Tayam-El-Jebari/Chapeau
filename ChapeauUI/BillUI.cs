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

namespace ChapeauUI
{
    public partial class BillUI : Form
    {
        public BillUI()
        {
            InitializeComponent();
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
