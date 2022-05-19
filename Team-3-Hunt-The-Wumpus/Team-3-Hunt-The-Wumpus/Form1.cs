using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Team_3_Hunt_The_Wumpus
{
    public partial class Form1 : Form
    {
        public GameLocation MyGameLocation = new GameLocation();
        public Cave MyCave;
        public Form1() {
            [DllImport("gdi32.dll")]
            static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

            InitializeComponent();

            byte[] fontArray = Properties.Resources.font;
            int dataLength = Properties.Resources.font.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            label1.Font = new Font(pfc.Families[0], 72, FontStyle.Regular);
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Properties.Resources.background;
            
            textBoxCommand.Font = new Font(pfc.Families[0], 28, FontStyle.Regular);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TypeWriterEffect("Hunt the Wumpus", label1, 50);
            MyGameLocation.RandomizePlayerLocation();
            MyCave = new Cave(MyGameLocation);
        }

        public Task TypeWriterEffect(string txt, Label lbl, int delay) {
            return Task.Run(() =>
            {
                for (int i = 0; i <= txt.Length; i++) {
                    lbl.Invoke((MethodInvoker)delegate {
                        lbl.Text = txt.Substring(0, i);
                    });
                    System.Threading.Thread.Sleep(delay); ;
                }
            });
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
