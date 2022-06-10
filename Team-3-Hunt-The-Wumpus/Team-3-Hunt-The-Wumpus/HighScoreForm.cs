using Microsoft.VisualBasic;
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
    public partial class HighScoreForm : Form {
        public HighScoreManager MyHighScoreManager = new HighScoreManager();

        public PrivateFontCollection pfc = new PrivateFontCollection();
        public int NumberOfTurns { get; set; }
        public int Coins { get; set; }
        public int Arrows { get; set; }
        public bool KilledWumpus { get; set; }
        public int CaveNum { get; set; }

        public string Message { get; set; }
        public string NameOfUser { get; set; }
        public int isFirst = 0;
        public HighScoreForm() {
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

            label1.Font = new Font(pfc.Families[0], 31, FontStyle.Regular);
            labelScore.Font = new Font(pfc.Families[0], 20, FontStyle.Regular);

            label2.Font = new Font(pfc.Families[0], 18, FontStyle.Regular);
            label3.Font = new Font(pfc.Families[0], 17, FontStyle.Regular);
            label4.Font = new Font(pfc.Families[0], 16, FontStyle.Regular);
            label7.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
            label6.Font = new Font(pfc.Families[0], 14, FontStyle.Regular);
            NameOfUser = Interaction.InputBox("Enter your name.", "Enter your name.", "");

        }
        private void HighScoreForm_Load(object sender, EventArgs e) {

            label1.Text = Message;

            var highScores = MyHighScoreManager.GetSortedFinalStandings();

            List<string> wasWumpusKilled = new List<string>();
            for (int i = 0; i < highScores.Count; i++) {
                if (highScores[i].DefeatedWumpus) wasWumpusKilled.Add("Yes");
                else wasWumpusKilled.Add("No");
            }
            var score = 0;
            var wumpusBonus = 0;
            if (isFirst == 0) {
                wumpusBonus = 0;
                if (KilledWumpus) wumpusBonus += 50;
                score = 100 - NumberOfTurns + Coins + (5 * Arrows) + wumpusBonus;
                MyHighScoreManager.AddNewHighScore(NameOfUser, CaveNum, score, NumberOfTurns, Arrows, KilledWumpus, Coins);
                _ = MyHighScoreManager.SaveScores();
            }

            labelScore.Text = $"Your Score: {score}";

            switch (highScores.Count) {
                case 1:
                    label2.Text = $"First Place 🥇: Name: {highScores[0].Name} | Score: {highScores[0].Score}pts | Cave: {highScores[0].Cave} | Turns: {highScores[0].NumOfTurns} | Coins: {highScores[0].Coins} | Arrows Left: {highScores[0].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[0]}";
                    break;
                case 2:
                    label2.Text = $"First Place 🥇: Name: {highScores[0].Name} | Score: {highScores[0].Score}pts | Cave: {highScores[0].Cave} | Turns: {highScores[0].NumOfTurns} | Coins: {highScores[0].Coins} | Arrows Left: {highScores[0].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[0]}";
                    label3.Text = $"Second Place 🥈: Name: {highScores[1].Name} | Score: {highScores[1].Score}pts | Cave: {highScores[1].Cave} | Turns: {highScores[1].NumOfTurns} | Coins: {highScores[1].Coins} | Arrows Left: {highScores[1].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[1]}";
                    break;
                case 3:
                    label2.Text = $"First Place 🥇: Name: {highScores[0].Name} | Score: {highScores[0].Score}pts | Cave: {highScores[0].Cave} | Turns: {highScores[0].NumOfTurns} | Coins: {highScores[0].Coins} | Arrows Left: {highScores[0].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[0]}";
                    label3.Text = $"Second Place 🥈: Name: {highScores[1].Name} | Score: {highScores[1].Score}pts | Cave: {highScores[1].Cave} | Turns: {highScores[1].NumOfTurns} | Coins: {highScores[1].Coins} | Arrows Left: {highScores[1].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[1]}";
                    label4.Text = $"Third Place 🥉: Name: {highScores[2].Name} | Score: {highScores[2].Score}pts | Cave: {highScores[2].Cave} | Turns: {highScores[2].NumOfTurns} | Coins: {highScores[2].Coins} | Arrows Left: {highScores[2].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[2]}";
                    break;
                case 4:
                    label2.Text = $"First Place 🥇: Name: {highScores[0].Name} | Score: {highScores[0].Score}pts | Cave: {highScores[0].Cave} | Turns: {highScores[0].NumOfTurns} | Coins: {highScores[0].Coins} | Arrows Left: {highScores[0].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[0]}";
                    label3.Text = $"Second Place 🥈: Name: {highScores[1].Name} | Score: {highScores[1].Score}pts | Cave: {highScores[1].Cave} | Turns: {highScores[1].NumOfTurns} | Coins: {highScores[1].Coins} | Arrows Left: {highScores[1].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[1]}";
                    label4.Text = $"Third Place 🥉: Name: {highScores[2].Name} | Score: {highScores[2].Score}pts | Cave: {highScores[2].Cave} | Turns: {highScores[2].NumOfTurns} | Coins: {highScores[2].Coins} | Arrows Left: {highScores[2].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[2]}";
                    label7.Text = $"Fourth Place: Name: {highScores[3].Name} | Score: {highScores[3].Score}pts | Cave: {highScores[3].Cave} | Turns: {highScores[3].NumOfTurns} | Coins: {highScores[3].Coins} | Arrows Left: {highScores[3].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[3]}";
                    break;
                case 5:
                    label2.Text = $"First Place 🥇: Name: {highScores[0].Name} | Score: {highScores[0].Score}pts | Cave: {highScores[0].Cave} | Turns: {highScores[0].NumOfTurns} | Coins: {highScores[0].Coins} | Arrows Left: {highScores[0].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[0]}";
                    label3.Text = $"Second Place 🥈: Name: {highScores[1].Name} | Score: {highScores[1].Score}pts | Cave: {highScores[1].Cave} | Turns: {highScores[1].NumOfTurns} | Coins: {highScores[1].Coins} | Arrows Left: {highScores[1].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[1]}";
                    label4.Text = $"Third Place 🥉: Name: {highScores[2].Name} | Score: {highScores[2].Score}pts | Cave: {highScores[2].Cave} | Turns: {highScores[2].NumOfTurns} | Coins: {highScores[2].Coins} | Arrows Left: {highScores[2].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[2]}";
                    label7.Text = $"Fourth Place: Name: {highScores[3].Name} | Score: {highScores[3].Score}pts | Cave: {highScores[3].Cave} | Turns: {highScores[3].NumOfTurns} | Coins: {highScores[3].Coins} | Arrows Left: {highScores[3].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[3]}";
                    label6.Text = $"Fifth Place: Name: {highScores[4].Name} | Score: {highScores[4].Score}pts | Cave: {highScores[4].Cave} | Turns: {highScores[4].NumOfTurns} | Coins: {highScores[4].Coins} | Arrows Left: {highScores[4].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[4]}";
                    break;
                default:
                    label2.Text = $"First Place 🥇: Name: {highScores[0].Name} | Score: {highScores[0].Score}pts | Cave: {highScores[0].Cave} | Turns: {highScores[0].NumOfTurns} | Coins: {highScores[0].Coins} | Arrows Left: {highScores[0].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[0]}";
                    label3.Text = $"Second Place 🥈: Name: {highScores[1].Name} | Score: {highScores[1].Score}pts | Cave: {highScores[1].Cave} | Turns: {highScores[1].NumOfTurns} | Coins: {highScores[1].Coins} | Arrows Left: {highScores[1].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[1]}";
                    label4.Text = $"Third Place 🥉: Name: {highScores[2].Name} | Score: {highScores[2].Score}pts | Cave: {highScores[2].Cave} | Turns: {highScores[2].NumOfTurns} | Coins: {highScores[2].Coins} | Arrows Left: {highScores[2].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[2]}";
                    label7.Text = $"Fourth Place: Name: {highScores[3].Name} | Score: {highScores[3].Score}pts | Cave: {highScores[3].Cave} | Turns: {highScores[3].NumOfTurns} | Coins: {highScores[3].Coins} | Arrows Left: {highScores[3].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[3]}";
                    label6.Text = $"Fifth Place: Name: {highScores[4].Name} | Score: {highScores[4].Score}pts | Cave: {highScores[4].Cave} | Turns: {highScores[4].NumOfTurns} | Coins: {highScores[4].Coins} | Arrows Left: {highScores[4].NumOfArrowsLeft} | Was the Wumpus Killed? {wasWumpusKilled[4]}";
                    break;
            }
        }
    }
}
