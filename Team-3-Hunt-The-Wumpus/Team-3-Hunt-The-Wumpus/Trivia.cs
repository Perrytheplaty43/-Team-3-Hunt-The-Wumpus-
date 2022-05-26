using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Team_3_Hunt_The_Wumpus
{
    public class Trivia
    {
        String[,] questionList;
        private int numberOfQuestionsRight;
        int numberOfQuestionsAsked;
        private int[] askedQuestions = new int[5];
        int caveNumber;

        //constructor
        public Trivia(int cn)
        {
            caveNumber = cn;
            string[] lines = System.IO.File.ReadAllLines("");
            //String[]lines = File.ReadAllLines() //read in trivia questions from txt file

            for (int i = 0; i < lines.Length; i++)
            {
                string[] questions = lines[i].Split(',');
                //for (int )

            }

        }
    

        public bool newTriviaRound (int cn, int totalNumberQs)
        {
            numberOfQuestionsAsked = totalNumberQs;
            caveNumber = cn;
            caveNumber -= 1;
            askQuestion(); // ask trivia questions
            return true;

        }

        public void recordAnswer(bool isRight)
        {
            // if answer is correct
            if (isRight == true) { numberOfQuestionsRight++; }

            if (numberOfQuestionsAsked > 0) { askQuestion(); }

        }

        private void askQuestion ()
        {
            //random number generator (1-4)
            Random r = new Random();
            int indexOfRightAnswer = r.Next(4) + 1;

            int totalNumberQs = caveNumber * 10;
            totalNumberQs += askedQuestions[caveNumber];

            //UI

        }
     
       

       

    }

}
