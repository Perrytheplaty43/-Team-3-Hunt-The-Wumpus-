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
                OpenFile();
            }
            catch { }
        }


        public void AddNewHighScore(string name, string cave, int score)
        {
            HighScore hs = new HighScore(name, cave, score);
            //add the new score to list
            highscores.Add(hs);
            
            //add the savetofile method
        }

        //return the high scores from the list
        public List<HighScore> GetHighScores()
        {
            return highscores;
        }

        private void OpenFile()
        {
            using (StreamReader sr = new StreamReader("studentDataFile"))
            {
                while (!sr.EndOfStream)
                {
                    string input = sr.ReadLine();
                    string[] data = input.Split(",");
                    string name = data[0];
                    string cave = data[1];
                    int score = int.Parse(data[2]); 

                    HighScore hs  = new HighScore(name, cave, score);
                }
            }
        }

        //add write to file

        //create a sort method to sort by scores
    }
}
