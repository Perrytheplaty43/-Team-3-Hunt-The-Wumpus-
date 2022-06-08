using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    public class HighScoreManager
    {
        //add in list to keep track of highscores
        private List<HighScore> highscores = new List<HighScore>();

        public HighScoreManager()
        {
            try
            {
                openFile();
            }
            catch {
            
            }
        }


        public void AddNewHighScore(string name, int cave, int score, int numofturns, int numofarrowsleft, bool defeatedwumpus, string dateandtime)
        {
            HighScore hs = new HighScore(name, cave, score, numofturns, numofarrowsleft, defeatedwumpus, dateandtime);
            //add the new score to list
            highscores.Add(hs);
            
            //add the savetofile method
        }

        //return the high scores from the list
        public List<HighScore> GetHighScores()
        {
            return highscores;
        }

        private void openFile()
        {
            using (StreamReader sr = new StreamReader(".\\studentDataFile.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string text = File.ReadAllText(".\\TriviaQuestions.txt");
                    string[][] data = text.Split('\n').Select(x => x.Split(',')).ToArray();

                    for (int i = 0; i < data.Length; i++) {
                        string name = data[i][0];
                        int cave = int.Parse(data[i][1]);
                        int score = int.Parse(data[i][2]);
                        int numofturns = int.Parse(data[i][3]);
                        int numofarrowsleft = int.Parse(data[i][4]);
                        bool defeatedwumpus = bool.Parse(data[i][5]);
                        string dateandtime = data[i][6];
                        AddNewHighScore(name, cave, score, numofturns, numofarrowsleft, defeatedwumpus, dateandtime);
                    }
                }
            }
        }

        //add write to file
        public async Task SaveScores() {
            var textToSave = "";
            for (int i = 0; i < highscores.Count; i++) {
                textToSave += $"{highscores[i].Name},{highscores[i].Cave},{highscores[i].Score},{highscores[i].NumOfTurns},{highscores[i].NumOfArrowsLeft},{highscores[i].DefeatedWumpus},{highscores[i].DateAndTime}\n";
            }
            await File.WriteAllTextAsync(".\\studentDataFile.txt", textToSave);
        }

        //create a sort method to sort by scores
    }
}
