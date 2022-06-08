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

namespace Team_3_Hunt_The_Wumpus {
    public partial class Form1 : Form {
        public Cave MyCave;
        public GameLocation MyGameLocation;
        public Trivia MyTrivia;
        public PrivateFontCollection pfc = new PrivateFontCollection();
        public Player MyPlayer = new Player();
        public Wumpus MyWumpus = new Wumpus();
        int startingLocation;
        bool trivia = false;
        bool triviaPit = false;
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

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            label1.Font = new Font(pfc.Families[0], 72, FontStyle.Regular);
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Properties.Resources.background;

            textBoxCommand.Font = new Font(pfc.Families[0], 28, FontStyle.Regular);
            richTextBoxOutput.Font = new Font(pfc.Families[0], 18, FontStyle.Regular);
            label2.Font = new Font(pfc.Families[0], 28, FontStyle.Regular);
            richTextBoxWarn.Font = new Font(pfc.Families[0], 18, FontStyle.Regular);
            label3.Font = new Font(pfc.Families[0], 28, FontStyle.Regular);
            richTextBoxTrivia.Font = new Font(pfc.Families[0], 18, FontStyle.Regular);
            labelArrows.Font = new Font(pfc.Families[0], 25, FontStyle.Regular);
        }
        int[] adjRooms;
        List<int> connectedRoom;
        private void Form1_Load(object sender, EventArgs e) {
            Random random = new Random();
            int randomNumber = random.Next(1, 4);
            MyCave = new Cave(randomNumber);
            MyTrivia = new Trivia(MyCave.SelectedCave);

            MyGameLocation = new GameLocation();

            MyPlayer.Arrows = 3;

            startingLocation = MyGameLocation.PlayerLocation;

            TypeWriterEffect("Hunt the Wumpus", label1, 50);
            adjRooms = MyCave.GetAdjacentRooms(MyGameLocation.PlayerLocation);
            connectedRoom = MyCave.GetConnectedRooms(MyGameLocation.PlayerLocation);

            for (int i = 0; i <= adjRooms.Length - 1; i++) {
                for (int y = 0; y <= connectedRoom.Count - 1; y++) {
                    if (adjRooms[i] == connectedRoom[y]) {
                        if (i == 0) {
                            canRoom1 = true;
                        } else if (i == 1) {
                            canRoom2 = true;
                        } else if (i == 2) {
                            canRoom3 = true;
                        } else if (i == 3) {
                            canRoom4 = true;
                        } else if (i == 4) {
                            canRoom5 = true;
                        } else if (i == 5) {
                            canRoom6 = true;
                        }
                    }
                }
            }
            room1 = adjRooms[0];
            room2 = adjRooms[1];
            room3 = adjRooms[2];
            room4 = adjRooms[3];
            room5 = adjRooms[4];
            room6 = adjRooms[5];
            roomP = MyGameLocation.PlayerLocation;
            richTextBoxWarn.Text = MyGameLocation.GiveWarning(MyCave);
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
        bool canRoom1 = false;
        bool canRoom2 = false;
        bool canRoom3 = false;
        bool canRoom4 = false;
        bool canRoom5 = false;
        bool canRoom6 = false;

        int roomP;
        int room1;
        int room2;
        int room3;
        int room4;
        int room5;
        int room6;

        string[] questions;
        int triviaNumber = 0;
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

            //room player
            string drawStringP = roomP.ToString();
            Font drawFontP = new Font(pfc.Families[0], 48, FontStyle.Regular); ;
            SolidBrush drawBrushP = new SolidBrush(Color.Lime);
            float xP = 160F;
            if (drawStringP.Length > 1) xP -= 10;
            float yP = 200F;
            StringFormat drawFormatP = new StringFormat();
            graphics.DrawString(drawStringP, drawFontP, drawBrushP, xP, yP, drawFormatP);

            //room1
            string drawString = room1.ToString();
            Font drawFont = new Font(pfc.Families[0], 48, FontStyle.Regular); ;
            SolidBrush drawBrush = new SolidBrush(Color.Lime);
            if (!canRoom1) drawBrush = new SolidBrush(Color.Red);
            float x = 160F;
            if (drawString.Length > 1) x -= 10;
            float y = 80F;
            StringFormat drawFormat = new StringFormat();
            graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);


            //room2
            string drawString2 = room2.ToString();
            Font drawFont2 = new Font(pfc.Families[0], 48, FontStyle.Regular); ;
            SolidBrush drawBrush2 = new SolidBrush(Color.Lime);
            if (!canRoom2) drawBrush2 = new SolidBrush(Color.Red);
            float x2 = 270F;
            if (drawString2.Length > 1) x2 -= 10;
            float y2 = 140F;
            StringFormat drawFormat2 = new StringFormat();
            graphics.DrawString(drawString2, drawFont2, drawBrush2, x2, y2, drawFormat2);


            //room3
            string drawString3 = room3.ToString();
            Font drawFont3 = new Font(pfc.Families[0], 48, FontStyle.Regular); ;
            SolidBrush drawBrush3 = new SolidBrush(Color.Lime);
            if (!canRoom3) drawBrush3 = new SolidBrush(Color.Red);
            float x3 = 270F;
            if (drawString3.Length > 1) x3 -= 10;
            float y3 = 260F;
            StringFormat drawFormat3 = new StringFormat();
            graphics.DrawString(drawString3, drawFont3, drawBrush3, x3, y3, drawFormat3);

            //room4
            string drawString4 = room4.ToString();
            Font drawFont4 = new Font(pfc.Families[0], 48, FontStyle.Regular); ;
            SolidBrush drawBrush4 = new SolidBrush(Color.Lime);
            if (!canRoom4) drawBrush4 = new SolidBrush(Color.Red);
            float x4 = 160F;
            if (drawString4.Length > 1) x4 -= 10;
            float y4 = 320F;
            StringFormat drawFormat4 = new StringFormat();
            graphics.DrawString(drawString4, drawFont4, drawBrush4, x4, y4, drawFormat4);

            //room5
            string drawString5 = room5.ToString();
            Font drawFont5 = new Font(pfc.Families[0], 48, FontStyle.Regular); ;
            SolidBrush drawBrush5 = new SolidBrush(Color.Lime);
            if (!canRoom5) drawBrush5 = new SolidBrush(Color.Red);
            float x5 = 50F;
            if (drawString5.Length > 1) x5 -= 10;
            float y5 = 260F;
            StringFormat drawFormat5 = new StringFormat();
            graphics.DrawString(drawString5, drawFont5, drawBrush5, x5, y5, drawFormat5);

            //room6
            string drawString6 = room6.ToString();
            Font drawFont6 = new Font(pfc.Families[0], 48, FontStyle.Regular); ;
            SolidBrush drawBrush6 = new SolidBrush(Color.Lime);
            if (!canRoom6) drawBrush6 = new SolidBrush(Color.Red);
            float x6 = 50F;
            if (drawString6.Length > 1) x6 -= 10;
            float y6 = 140F;
            StringFormat drawFormat6 = new StringFormat();
            graphics.DrawString(drawString6, drawFont6, drawBrush6, x6, y6, drawFormat6);
        }

        private void textBoxCommand_KeyDown(object sender, KeyEventArgs e) {
            int roomMove;
            int roomShoot;
            if (e.KeyCode == Keys.Enter) {
                if (!trivia) {
                    if (textBoxCommand.Text.ToLower().StartsWith("move")) {
                        try {
                            roomMove = int.Parse(textBoxCommand.Text.Remove(0, 5));
                        } catch {
                            richTextBoxOutput.ForeColor = Color.Red;
                            richTextBoxOutput.Text = " Invalid Room";
                            return;
                        }
                        if (!MyCave.GetConnectedRooms(MyGameLocation.PlayerLocation).Contains(roomMove)) {
                            richTextBoxOutput.ForeColor = Color.Red;
                            richTextBoxOutput.Text += "\nyou can't enter room " + roomMove;
                            textBoxCommand.Clear();
                            return;
                        }
                        MyGameLocation.PlayerLocation = roomMove;
                        textBoxCommand.Clear();
                        MyPlayer.IncreaseTurns();
                        refresh();
                    } else if (textBoxCommand.Text.ToLower().StartsWith("shoot")) {
                        try {
                            roomShoot = int.Parse(textBoxCommand.Text.Remove(0, 6));
                        } catch {
                            richTextBoxOutput.ForeColor = Color.Red;
                            richTextBoxOutput.Text = " Invalid Room";
                            return;
                        }
                        if (!MyCave.GetConnectedRooms(MyGameLocation.PlayerLocation).Contains(roomShoot)) {
                            richTextBoxOutput.ForeColor = Color.Red;
                            richTextBoxOutput.Text += "\nyou can't shoot into room " + roomShoot;
                            textBoxCommand.Clear();
                            return;
                        }
                        MyPlayer.DecreaseArrows();
                        labelArrows.Text = $"Arrows: {MyPlayer.Arrows}";
                        if (MyGameLocation.WumpusLocation == roomShoot) {
                            //won
                        } else {
                            MyWumpus.WakeWumpus(MyCave);
                            richTextBoxOutput.ForeColor = Color.Red;
                            richTextBoxOutput.Text = "You missed! The Wumpus has awakend!";
                            textBoxCommand.Clear();
                            if (MyPlayer.Arrows == 0) {
                                richTextBoxOutput.Text = "You have run out of arrows! The wumpus has take this opportunity to eat you!.";
                                //lose
                            }
                        }
                        textBoxCommand.Clear();
                        MyPlayer.IncreaseTurns();
                        refresh();
                    }
                } else if (triviaPit) {
                    if (triviaNumber < 3) {
                        switch (textBoxCommand.Text) {
                            case "1":
                                if (textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    richTextBoxOutput.Text = "Correct!";
                                } else {
                                    richTextBoxOutput.ForeColor = Color.Red;
                                    richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "2":
                                if (textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    richTextBoxOutput.Text = "Correct!";
                                } else {
                                    richTextBoxOutput.ForeColor = Color.Red;
                                    richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "3":
                                if (textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    richTextBoxOutput.Text = "Correct!";
                                } else {
                                    richTextBoxOutput.ForeColor = Color.Red;
                                    richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "4":
                                if (textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    richTextBoxOutput.Text = "Correct!";
                                } else {
                                    richTextBoxOutput.ForeColor = Color.Red;
                                    richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                        }
                    } else {
                        if (MyTrivia.NumberOfQuestionsRight >= 2) {
                            richTextBoxTrivia.Text = "You were able to hack the firewall. But as a result you have been teleported back to the starting location.";
                            MyGameLocation.PlayerLocation = startingLocation;
                            trivia = false;
                            triviaNumber = 0;
                            MyTrivia.NumberOfQuestionsRight = 0;
                            textBoxCommand.Clear();
                            refresh();
                        } else {
                            richTextBoxTrivia.ForeColor = Color.Red;
                            richTextBoxTrivia.Text = "You have succumb to the firewall. Game over.";
                        }
                    }
                } else if (triviaNumber < 5) {
                    switch (textBoxCommand.Text) {
                        case "1":
                            if (textBoxCommand.Text == questions[5]) {
                                MyTrivia.recordAnswer(true);
                                richTextBoxOutput.ForeColor = Color.LimeGreen;
                                richTextBoxOutput.Text = "Correct!";
                            } else {
                                richTextBoxOutput.ForeColor = Color.Red;
                                richTextBoxOutput.Text = "Wrong!";
                            }
                            triviaNumber++;
                            askTriviaUI(triviaNumber, 5, 3);
                            break;
                        case "2":
                            if (textBoxCommand.Text == questions[5]) {
                                MyTrivia.recordAnswer(true);
                                richTextBoxOutput.ForeColor = Color.LimeGreen;
                                richTextBoxOutput.Text = "Correct!";
                            } else {
                                richTextBoxOutput.ForeColor = Color.Red;
                                richTextBoxOutput.Text = "Wrong!";
                            }
                            triviaNumber++;
                            askTriviaUI(triviaNumber, 5, 3);
                            break;
                        case "3":
                            if (textBoxCommand.Text == questions[5]) {
                                MyTrivia.recordAnswer(true);
                                richTextBoxOutput.ForeColor = Color.LimeGreen;
                                richTextBoxOutput.Text = "Correct!";
                            } else {
                                richTextBoxOutput.ForeColor = Color.Red;
                                richTextBoxOutput.Text = "Wrong!";
                            }
                            triviaNumber++;
                            askTriviaUI(triviaNumber, 5, 3);
                            break;
                        case "4":
                            if (textBoxCommand.Text == questions[5]) {
                                MyTrivia.recordAnswer(true);
                                richTextBoxOutput.ForeColor = Color.LimeGreen;
                                richTextBoxOutput.Text = "Correct!";
                            } else {
                                richTextBoxOutput.ForeColor = Color.Red;
                                richTextBoxOutput.Text = "Wrong!";
                            }
                            triviaNumber++;
                            askTriviaUI(triviaNumber, 5, 3);
                            break;
                    }
                } else {
                    if (MyTrivia.NumberOfQuestionsRight >= 3) {
                        richTextBoxTrivia.Text = "You were able to bypass the Wumpus. But as a result the Wumpus has moved.";
                        MyGameLocation.RunAwayWumpusLocation(MyCave);
                        trivia = false;
                        triviaNumber = 0;
                        MyTrivia.NumberOfQuestionsRight = 0;
                        textBoxCommand.Clear();
                        refresh();
                    } else {
                        richTextBoxTrivia.ForeColor = Color.Red;
                        richTextBoxTrivia.Text = "You have succumb to the Wumpus. Game over.";
                    }
                }
            }
        }
        private void refresh() {
            if (MyGameLocation.Bat1Location == MyGameLocation.PlayerLocation || MyGameLocation.Bat2Location == MyGameLocation.PlayerLocation) {
                richTextBoxOutput.Text = "You have been attacked by bats.\nYour location has been randomized.";
                MyGameLocation.RandomizePlayerLocation();
                MyGameLocation.RandomizeBatsLocation();
                refresh();
            }
            canRoom1 = false;
            canRoom2 = false;
            canRoom3 = false;
            canRoom4 = false;
            canRoom5 = false;
            canRoom6 = false;
            adjRooms = MyCave.GetAdjacentRooms(MyGameLocation.PlayerLocation);
            connectedRoom = MyCave.GetConnectedRooms(MyGameLocation.PlayerLocation);

            for (int i = 0; i <= adjRooms.Length - 1; i++) {
                for (int y = 0; y <= connectedRoom.Count - 1; y++) {
                    if (adjRooms[i] == connectedRoom[y]) {
                        if (i == 0) {
                            canRoom1 = true;
                        } else if (i == 1) {
                            canRoom2 = true;
                        } else if (i == 2) {
                            canRoom3 = true;
                        } else if (i == 3) {
                            canRoom4 = true;
                        } else if (i == 4) {
                            canRoom5 = true;
                        } else if (i == 5) {
                            canRoom6 = true;
                        }
                    }
                }
            }
            room1 = adjRooms[0];
            room2 = adjRooms[1];
            room3 = adjRooms[2];
            room4 = adjRooms[3];
            room5 = adjRooms[4];
            room6 = adjRooms[5];
            roomP = MyGameLocation.PlayerLocation;
            richTextBoxWarn.Clear();
            richTextBoxWarn.Text = MyGameLocation.GiveWarning(MyCave);
            panel1.Invalidate();


            if (MyGameLocation.Pit1Location == MyGameLocation.PlayerLocation || MyGameLocation.Pit2Location == MyGameLocation.PlayerLocation) {
                askTriviaUI(triviaNumber, 3, 2);
                trivia = true;
                triviaPit = true;
            }
            if (MyGameLocation.PlayerLocation == MyGameLocation.WumpusLocation) {
                askTriviaUI(triviaNumber, 5, 3);
                trivia = true;
            }
        }
        private void askTriviaUI(int number, int rounds, int correct) {
            textBoxCommand.Clear();
            if (number < rounds) {
                questions = MyTrivia.newTriviaQuestion(MyCave.SelectedCave);

                switch (rounds) {
                    case 3:
                        richTextBoxTrivia.Text = "You gave encountered a firewall. Awnser at least 2 questions correct in order to secsesfully bypass the firewall.\n" +
                            questions[0] + ":\n" +
                            "1: " + questions[1] + "\n" +
                            "2: " + questions[2] + "\n" +
                            "3: " + questions[3] + "\n" +
                            "4: " + questions[4] + "\n" +
                            "Enter correct number";
                        break;
                    case 5:
                        richTextBoxTrivia.Text = "You gave encountered a Wumpus. Awnser at least 3 questions correct in order to secsesfully bypass the Wumpus.\n" +
                            questions[0] + ":\n" +
                            "1: " + questions[1] + "\n" +
                            "2: " + questions[2] + "\n" +
                            "3: " + questions[3] + "\n" +
                            "4: " + questions[4] + "\n" +
                            "Enter correct number";
                        break;
                }
            } else if (rounds == 3) {
                if (MyTrivia.NumberOfQuestionsRight >= correct) {
                    richTextBoxTrivia.Text = "You were able to hack the firewall. But as a result you have been teleported back to the starting location.";
                    MyGameLocation.PlayerLocation = startingLocation;
                    trivia = false;
                    triviaPit = false;
                    triviaNumber = 0;
                    MyTrivia.NumberOfQuestionsRight = 0;
                    textBoxCommand.Clear();
                    refresh();
                } else {
                    richTextBoxTrivia.ForeColor = Color.Red;
                    richTextBoxTrivia.Text = "You have succumb to the firewall. Game over.";
                }
                return;
            } else {
                if (MyTrivia.NumberOfQuestionsRight >= correct) {
                    richTextBoxTrivia.Text = "You were able to bypass the Wumpus. But as a result the Wumpus has moved.";

                    Random rand = new Random();
                    int moves = rand.Next(2, 4);
                    for (int i = 0; i <= moves; i++) {
                        MyGameLocation.RunAwayWumpusLocation(MyCave);
                    }
                    trivia = false;
                    triviaNumber = 0;
                    MyTrivia.NumberOfQuestionsRight = 0;
                    textBoxCommand.Clear();
                    refresh();
                } else {
                    richTextBoxTrivia.ForeColor = Color.Red;
                    richTextBoxTrivia.Text = "You have succumb to the Wumpus. Game over.";
                }
            }
        }
    }
}
