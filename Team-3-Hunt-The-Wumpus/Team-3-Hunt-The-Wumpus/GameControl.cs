using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team_3_Hunt_The_Wumpus {
    class GameControl {
        public Cave MyCave;
        public GameLocation MyGameLocation;
        public Trivia MyTrivia;
        public PrivateFontCollection pfc = new PrivateFontCollection();
        public Player MyPlayer = new Player();
        public Wumpus MyWumpus = new Wumpus();
        int startingLocation;
        bool trivia = false;
        bool triviaPit = false;
        int[] adjRooms;
        List<int> connectedRoom;
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

        bool buyingArrows = false;
        bool buyingHint = false;
        bool triviaWumpus = false;
        Form1 form1 { get; set; }
        public GameControl(Form1 form12) {
            form1 = form12;
        }
        public void FormInitialization() {
            [DllImport("gdi32.dll")]
            static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

            byte[] fontArray = Properties.Resources.font;
            int dataLength = Properties.Resources.font.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            form1.label1.Font = new Font(pfc.Families[0], 72, FontStyle.Regular);
            form1.BackgroundImage = Properties.Resources.background;

            form1.textBoxCommand.Font = new Font(pfc.Families[0], 28, FontStyle.Regular);
            form1.richTextBoxOutput.Font = new Font(pfc.Families[0], 18, FontStyle.Regular);
            form1.label2.Font = new Font(pfc.Families[0], 28, FontStyle.Regular);
            form1.richTextBoxWarn.Font = new Font(pfc.Families[0], 18, FontStyle.Regular);
            form1.label3.Font = new Font(pfc.Families[0], 28, FontStyle.Regular);
            form1.richTextBoxTrivia.Font = new Font(pfc.Families[0], 18, FontStyle.Regular);
            form1.labelArrows.Font = new Font(pfc.Families[0], 25, FontStyle.Regular);
            form1.labelCoins.Font = new Font(pfc.Families[0], 25, FontStyle.Regular);
            form1.button1.Font = new Font(pfc.Families[0], 18, FontStyle.Regular);
        }

        public void OnFormLoad() {
            Random random = new Random();
            int randomNumber = random.Next(1, 4);
            MyCave = new Cave(randomNumber);
            MyTrivia = new Trivia(MyCave.SelectedCave);

            MyGameLocation = new GameLocation();

            MyPlayer.Arrows = 3;

            startingLocation = MyGameLocation.PlayerLocation;

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
            form1.richTextBoxWarn.Text = MyGameLocation.GiveWarning(MyCave);
        }
        public void Paint(object sender, PaintEventArgs e) {
            var graphics = e.Graphics;

            //Get the middle of the panel
            var x_0 = form1.panel1.Width / 2;
            var y_0 = form1.panel1.Height / 2;

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
        public void Commands(object sender, KeyEventArgs e) {
            int roomMove;
            int roomShoot;
            if (e.KeyCode == Keys.Enter) {
                if (!trivia || buyingArrows || buyingHint) {
                    if (form1.textBoxCommand.Text.ToLower().StartsWith("move")) {
                        try {
                            roomMove = int.Parse(form1.textBoxCommand.Text.Remove(0, 5));
                        } catch {
                            form1.richTextBoxOutput.ForeColor = Color.Red;
                            form1.richTextBoxOutput.Text = " Invalid Room";
                            return;
                        }
                        if (!MyCave.GetConnectedRooms(MyGameLocation.PlayerLocation).Contains(roomMove)) {
                            form1.richTextBoxOutput.ForeColor = Color.Red;
                            form1.richTextBoxOutput.Text += "\nyou can't enter room " + roomMove;
                            form1.textBoxCommand.Clear();
                            return;
                        }
                        form1.richTextBoxTrivia.Clear();
                        form1.richTextBoxTrivia.Text = MyTrivia.getRandomTrivia();
                        MyGameLocation.PlayerLocation = roomMove;
                        MyPlayer.IncreaseCoins();
                        form1.textBoxCommand.Clear();
                        MyPlayer.IncreaseTurns();
                        refresh();
                    } else if (form1.textBoxCommand.Text.ToLower().StartsWith("shoot")) {
                        try {
                            roomShoot = int.Parse(form1.textBoxCommand.Text.Remove(0, 6));
                        } catch {
                            form1.richTextBoxOutput.ForeColor = Color.Red;
                            form1.richTextBoxOutput.Text = " Invalid Room";
                            return;
                        }
                        if (!MyCave.GetConnectedRooms(MyGameLocation.PlayerLocation).Contains(roomShoot)) {
                            form1.richTextBoxOutput.ForeColor = Color.Red;
                            form1.richTextBoxOutput.Text += "\nyou can't shoot into room " + roomShoot;
                            form1.textBoxCommand.Clear();
                            return;
                        }
                        MyPlayer.DecreaseArrows();
                        form1.labelArrows.Text = $"Arrows: {MyPlayer.Arrows}";
                        if (MyGameLocation.WumpusLocation == roomShoot) {
                            MyWumpus.IsDead = true;
                            endGame("You Killed the Wumpus!");
                        } else {
                            MyWumpus.WakeWumpus(MyCave);
                            form1.richTextBoxOutput.ForeColor = Color.Red;
                            form1.richTextBoxOutput.Text = "You missed! The Wumpus has awakend!";
                            form1.textBoxCommand.Clear();
                            if (MyPlayer.Arrows == 0) {
                                form1.richTextBoxOutput.Text = "You have run out of arrows! The wumpus has take this opportunity to eat you!.";

                                endGame("You have run out of arrows! The wumpus has take this opportunity to eat you!");
                            }
                        }
                        form1.textBoxCommand.Clear();
                        MyPlayer.IncreaseTurns();
                        refresh();
                    } else if (form1.textBoxCommand.Text.ToLower().StartsWith("buy arrows")) {
                        askTriviaUI(triviaNumber, 3, 2);
                        buyingArrows = true;
                    } else if (form1.textBoxCommand.Text.ToLower().StartsWith("buy hint")) {
                        askTriviaUI(triviaNumber, 3, 2);
                        buyingHint = true;
                    }
                } else if (triviaPit) {
                    if (triviaNumber < 3) {
                        switch (form1.textBoxCommand.Text) {
                            case "1":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "2":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "3":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "4":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                        }
                    } else {
                        if (MyTrivia.NumberOfQuestionsRight >= 2) {
                            form1.richTextBoxTrivia.Text = "You were able to hack the firewall. But as a result you have been teleported back to the starting location.";
                            MyGameLocation.PlayerLocation = startingLocation;
                            trivia = false;
                            triviaNumber = 0;
                            MyTrivia.NumberOfQuestionsRight = 0;
                            form1.textBoxCommand.Clear();
                            refresh();
                        } else {
                            form1.richTextBoxTrivia.ForeColor = Color.Red;
                            form1.richTextBoxTrivia.Text = "You have succumb to the firewall. Game over.";

                            endGame("You have succumb to the firewall. Game over.");
                        }
                    }
                }
                if (buyingArrows) {
                    if (triviaNumber < 3) {
                        switch (form1.textBoxCommand.Text) {
                            case "1":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "2":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "3":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "4":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                        }
                    }
                }
                if (buyingHint) {
                    if (triviaNumber < 3) {
                        switch (form1.textBoxCommand.Text) {
                            case "1":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "2":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "3":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                            case "4":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 3, 2);
                                break;
                        }
                    }
                }
                if (triviaWumpus) {
                    if (triviaNumber < 5) {
                        switch (form1.textBoxCommand.Text) {
                            case "1":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 5, 3);
                                break;
                            case "2":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 5, 3);
                                break;
                            case "3":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 5, 3);
                                break;
                            case "4":
                                if (form1.textBoxCommand.Text == questions[5]) {
                                    MyTrivia.recordAnswer(true);
                                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                                    form1.richTextBoxOutput.Text = "Correct!";
                                } else {
                                    form1.richTextBoxOutput.ForeColor = Color.Red;
                                    form1.richTextBoxOutput.Text = "Wrong!";
                                }
                                triviaNumber++;
                                askTriviaUI(triviaNumber, 5, 3);
                                break;
                        }
                    }
                }
            }
        }
        private void refresh() {
            form1.labelCoins.Text = $"Coins: {MyPlayer.Coins}";
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
            form1.richTextBoxWarn.Clear();
            form1.richTextBoxWarn.Text = MyGameLocation.GiveWarning(MyCave);
            form1.panel1.Invalidate();

            if (MyGameLocation.Pit1Location == MyGameLocation.PlayerLocation || MyGameLocation.Pit2Location == MyGameLocation.PlayerLocation) {
                askTriviaUI(triviaNumber, 3, 2);
                trivia = true;
                triviaPit = true;
            }
            if (MyGameLocation.PlayerLocation == MyGameLocation.WumpusLocation) {
                askTriviaUI(triviaNumber, 5, 3);
                trivia = true;
                triviaWumpus = true;
            }
            if (MyGameLocation.Bat1Location == MyGameLocation.PlayerLocation || MyGameLocation.Bat2Location == MyGameLocation.PlayerLocation) {
                MyGameLocation.RandomizePlayerLocation();
                MyGameLocation.RandomizeBatsLocation();
                form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                form1.richTextBoxOutput.Text = "You have been attacked by bats.\nYour location has been randomized.";
                refresh();
            }
        }
        private void askTriviaUI(int number, int rounds, int correct) {
            form1.textBoxCommand.Clear();
            if (MyPlayer.Coins < 0) {
                form1.richTextBoxOutput.ForeColor = Color.Red;
                form1.richTextBoxOutput.Text = "You dont have enough coins";
                return;
            }
            if (number < rounds) {
                questions = MyTrivia.newTriviaQuestion(MyCave.SelectedCave);
                MyPlayer.DecreaseCoins();
                switch (rounds) {
                    case 3:
                        form1.richTextBoxTrivia.Text = "You gave encountered a firewall. Awnser at least 2 questions correct in order to secsesfully bypass the firewall.\n" +
                            questions[0] + ":\n" +
                            "1: " + questions[1] + "\n" +
                            "2: " + questions[2] + "\n" +
                            "3: " + questions[3] + "\n" +
                            "4: " + questions[4] + "\n" +
                            "Enter correct number";
                        break;
                    case 5:
                        form1.richTextBoxTrivia.Text = "You gave encountered a Wumpus. Awnser at least 3 questions correct in order to secsesfully bypass the Wumpus.\n" +
                            questions[0] + ":\n" +
                            "1: " + questions[1] + "\n" +
                            "2: " + questions[2] + "\n" +
                            "3: " + questions[3] + "\n" +
                            "4: " + questions[4] + "\n" +
                            "Enter correct number";
                        break;
                }
            } else if (rounds == 3 && triviaPit) {
                if (MyTrivia.NumberOfQuestionsRight >= correct) {
                    form1.richTextBoxTrivia.Text = "You were able to hack the firewall. But as a result you have been teleported back to the starting location.";
                    MyGameLocation.PlayerLocation = startingLocation;
                    trivia = false;
                    triviaPit = false;
                    triviaNumber = 0;
                    MyTrivia.NumberOfQuestionsRight = 0;
                    form1.textBoxCommand.Clear();
                    refresh();
                } else {
                    form1.richTextBoxTrivia.ForeColor = Color.Red;
                    form1.richTextBoxTrivia.Text = "You have succumb to the firewall. Game over.";

                    endGame("You have succumb to the firewall. Game over.");
                }
                return;
            } else if (buyingArrows) {
                if (MyTrivia.NumberOfQuestionsRight >= correct) {
                    form1.richTextBoxTrivia.Text = "You were able to buy more arrows.";
                    trivia = false;
                    buyingArrows = false;
                    MyPlayer.IncreaseArrows();
                    MyPlayer.IncreaseArrows();
                    form1.labelArrows.Text = $"Arrows: {MyPlayer.Arrows}";
                    triviaNumber = 0;
                    MyTrivia.NumberOfQuestionsRight = 0;
                    form1.textBoxCommand.Clear();
                    refresh();
                } else {
                    form1.richTextBoxTrivia.ForeColor = Color.Red;
                    form1.richTextBoxTrivia.Text = "You were unable to buy more arrows.";
                    trivia = false;
                    buyingArrows = false;
                    form1.labelArrows.Text = $"Arrows: {MyPlayer.Arrows}";
                    triviaNumber = 0;
                    MyTrivia.NumberOfQuestionsRight = 0;
                    form1.textBoxCommand.Clear();
                    refresh();
                }
            } else if (buyingHint) {
                if (MyTrivia.NumberOfQuestionsRight >= correct) {
                    form1.richTextBoxTrivia.Text = "You were able to buy a hint.";
                    form1.richTextBoxOutput.ForeColor = Color.LimeGreen;
                    form1.richTextBoxOutput.Text = $"Hint:\n{MyGameLocation.GetHint(MyCave, MyTrivia)}";
                    trivia = false;
                    buyingHint = false;
                    triviaNumber = 0;
                    MyTrivia.NumberOfQuestionsRight = 0;
                    form1.textBoxCommand.Clear();
                    refresh();
                } else {
                    form1.richTextBoxTrivia.ForeColor = Color.Red;
                    form1.richTextBoxTrivia.Text = "You were unable to buy a hint.";
                    triviaNumber = 0;
                    MyTrivia.NumberOfQuestionsRight = 0;
                    form1.textBoxCommand.Clear();
                    refresh();
                }
            } else {
                if (MyTrivia.NumberOfQuestionsRight >= correct) {
                    form1.richTextBoxTrivia.Text = "You were able to bypass the Wumpus. But as a result the Wumpus has moved.";

                    Random rand = new Random();
                    int moves = rand.Next(2, 4);
                    for (int i = 0; i <= moves; i++) {
                        MyGameLocation.RunAwayWumpusLocation(MyCave);
                    }
                    trivia = false;
                    triviaNumber = 0;
                    MyTrivia.NumberOfQuestionsRight = 0;
                    form1.textBoxCommand.Clear();
                    refresh();
                } else {
                    form1.richTextBoxTrivia.ForeColor = Color.Red;
                    form1.richTextBoxTrivia.Text = "You have succumb to the Wumpus. Game over.";

                    endGame("You have succumb to the Wumpus. Game over.");
                }
            }
        }
        private void endGame(string message) {
            var highScoresForm = new HighScoreForm();
            //TODO: add turns everywhere
            highScoresForm.NumberOfTurns = MyPlayer.Turns;
            highScoresForm.Coins = MyPlayer.Coins;
            highScoresForm.Arrows = MyPlayer.Arrows;
            highScoresForm.KilledWumpus = MyWumpus.IsDead;
            highScoresForm.CaveNum = MyCave.SelectedCave;
            highScoresForm.Message = message;
            highScoresForm.ShowDialog();
        }
    }
}
