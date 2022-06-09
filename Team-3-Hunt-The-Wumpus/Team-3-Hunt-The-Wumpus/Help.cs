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

namespace Team_3_Hunt_The_Wumpus {
    public partial class Help : Form {
        public PrivateFontCollection pfc = new PrivateFontCollection();
        public Help() {
            InitializeComponent();
            [DllImport("gdi32.dll")]
            static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

            InitializeComponent();

            byte[] fontArray = Properties.Resources.font;
            int dataLength = Properties.Resources.font.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            label1.Font = new Font(pfc.Families[0], 20, FontStyle.Regular);
        }

        private void Help_Load(object sender, EventArgs e) {
            label1.ForeColor = Color.LimeGreen;
            label1.Text = "\nCommands:\n" +
                "MOVE [Room]: used to move rooms.\n" +
                "SHOOT [Room]: used to shoot arrows into room.\n" +
                "BUY ARROWS: used to buy arrows.\n" +
                "BUY HINTS: used to buy hints.\n";
        }
    }
}
