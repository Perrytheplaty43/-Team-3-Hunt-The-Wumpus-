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
        public Cave MyCave = new Cave();
        public GameLocation MyGameLocation = new GameLocation();
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
        bool canRoom1;
        bool canRoom2;
        bool canRoom3;
        bool canRoom4;
        bool canRoom5;
        bool canRoom6;
        private void panel1_Paint(object sender, PaintEventArgs e) {
            var graphics = e.Graphics;

            //Get the middle of the panel
            var x_0 = panel1.Width / 2;
            var y_0 = panel1.Height / 2;

            var shape = new PointF[6];
            var shape1 = new PointF[6];
            var shape2 = new PointF[6];
            var shape3 = new PointF[6];
            var shape4 = new PointF[6];
            var shape5 = new PointF[6];
            var shape6 = new PointF[6];

            var r = 70; //70 px radius 

            //center
            for (int a = 0; a < 6; a++) {
                shape[a] = new PointF(
                    x_0 + r * (float)Math.Cos(a * 60 * Math.PI / 180f) - 70,
                    y_0 + r * (float)Math.Sin(a * 60 * Math.PI / 180f));
            }

            //top left
            for (int a = 0; a < 6; a++) {
                shape1[a] = new PointF(
                    x_0 + r * (float)Math.Cos(a * 60 * Math.PI / 180f) - 180,
                    y_0 + r * (float)Math.Sin(a * 60 * Math.PI / 180f) - 60);
            }

            //top right
            for (int a = 0; a < 6; a++) {
                shape2[a] = new PointF(
                    x_0 + r * (float)Math.Cos(a * 60 * Math.PI / 180f) + 35,
                    y_0 + r * (float)Math.Sin(a * 60 * Math.PI / 180f) - 60);
            }

            //top
            for (int a = 0; a < 6; a++) {
                shape3[a] = new PointF(
                    x_0 + r * (float)Math.Cos(a * 60 * Math.PI / 180f) - 70,
                    y_0 + r * (float)Math.Sin(a * 60 * Math.PI / 180f) - 120);
            }

            //bottom
            for (int a = 0; a < 6; a++) {
                shape4[a] = new PointF(
                    x_0 + r * (float)Math.Cos(a * 60 * Math.PI / 180f) - 70,
                    y_0 + r * (float)Math.Sin(a * 60 * Math.PI / 180f) + 120);
            }

            //bottom right
            for (int a = 0; a < 6; a++) {
                shape5[a] = new PointF(
                    x_0 + r * (float)Math.Cos(a * 60 * Math.PI / 180f) + 35,
                    y_0 + r * (float)Math.Sin(a * 60 * Math.PI / 180f) + 60);
            }

            //bottom left
            for (int a = 0; a < 6; a++) {
                shape6[a] = new PointF(
                    x_0 + r * (float)Math.Cos(a * 60 * Math.PI / 180f) - 180,
                    y_0 + r * (float)Math.Sin(a * 60 * Math.PI / 180f) + 60);
            }

            Pen limePen = new Pen(Color.Lime, 10);
            limePen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;

            graphics.DrawPolygon(limePen, shape);
            graphics.DrawPolygon(limePen, shape1);
            graphics.DrawPolygon(limePen, shape2);
            graphics.DrawPolygon(limePen, shape3);
            graphics.DrawPolygon(limePen, shape4);
            graphics.DrawPolygon(limePen, shape5);
            graphics.DrawPolygon(limePen, shape6);
        }
    }
}
