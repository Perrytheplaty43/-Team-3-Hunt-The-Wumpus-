using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team_3_Hunt_The_Wumpus {
    public partial class Form1 : Form {
        GameControl MyGameControl;
        public Form1() {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            MyGameControl = new GameControl(this);
            MyGameControl.FormInitialization();
        }
        private void Form1_Load(object sender, EventArgs e) {
            MyGameControl.OnFormLoad();
            TypeWriterEffect("Hunt the Wumpus", label1, 50);
        }

        public Task TypeWriterEffect(string txt, Label lbl, int delay) {
            return Task.Run(() => {
                for (int i = 0; i <= txt.Length; i++) {
                    lbl.Invoke((MethodInvoker)delegate {
                        lbl.Text = txt.Substring(0, i);
                    });
                    System.Threading.Thread.Sleep(delay); ;
                }
            });
        }
        private void panel1_Paint(object sender, PaintEventArgs e) {
            MyGameControl.Paint(sender, e);
        }

        private void textBoxCommand_KeyDown(object sender, KeyEventArgs e) {
            MyGameControl.Commands(sender, e);
        }
        private void button1_Click(object sender, EventArgs e) {
            var help = new Help();
            help.ShowDialog();
        }
    }
}
