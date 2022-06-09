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
        String[][] questionList;
        public int NumberOfQuestionsRight;
        int numberOfQuestionsAsked;
        //private int[] askedQuestions = new int[6];
        int caveNumber;
        List<int> checkDup = new List<int>();

        //constructor
        public Trivia(int cn)
        {
            caveNumber = cn;
            string text = File.ReadAllText(".\\TriviaQuestions.txt");
            questionList = text.Split('\n').Select(x => x.Split(',')).ToArray();
        }
    

        public string[] newTriviaQuestion (int cn)
        {
            numberOfQuestionsAsked++;
            caveNumber = cn;
            caveNumber -= 1;
            return askQuestion(); // ask trivia questions
        }

        public void recordAnswer(bool isRight)
        {
            // if answer is correct
            if (isRight == true) { 
                NumberOfQuestionsRight++; 
            }

            if (numberOfQuestionsAsked > 0) { askQuestion(); }

        }
        public string[] getOldAnswer() {
            Random rand = new Random();
            int randomAnswer = rand.Next(0, checkDup.Count() - 1);
            int awnserIndex = checkDup[randomAnswer];
            return new string[] { questionList[awnserIndex][0], questionList[awnserIndex][1] };
        }

        private string[] askQuestion ()
        {
            //random number generator (1-4)
            Random r = new Random();
            int indexOfRightAnswer = r.Next(4) + 1;

            int totalNumberQs = caveNumber * 10;
            //totalNumberQs += askedQuestions[caveNumber];
            int questionToBeAsked;
            //UI
            do {
                questionToBeAsked = r.Next(questionList.GetLength(0));
            } while (checkDup.Contains(questionToBeAsked));
            checkDup.Add(questionToBeAsked);
            if (checkDup.Count >= questionList.GetLength(0)) {
                checkDup = new List<int>();
            }

            switch (indexOfRightAnswer) {
                case 1:
                    return new string[] { 
                        questionList[questionToBeAsked][0], 
                        questionList[questionToBeAsked][1], 
                        questionList[questionToBeAsked][2], 
                        questionList[questionToBeAsked][3], 
                        questionList[questionToBeAsked][4],
                        indexOfRightAnswer.ToString()
                    };
                case 2:
                    return new string[] {
                        questionList[questionToBeAsked][0],
                        questionList[questionToBeAsked][2],
                        questionList[questionToBeAsked][1],
                        questionList[questionToBeAsked][3],
                        questionList[questionToBeAsked][4],
                        indexOfRightAnswer.ToString()
                    };
                case 3:
                    return new string[] {
                        questionList[questionToBeAsked][0],
                        questionList[questionToBeAsked][3],
                        questionList[questionToBeAsked][2],
                        questionList[questionToBeAsked][1],
                        questionList[questionToBeAsked][4],
                        indexOfRightAnswer.ToString()
                    };
                case 4:
                    return new string[] {
                        questionList[questionToBeAsked][0],
                        questionList[questionToBeAsked][4],
                        questionList[questionToBeAsked][2],
                        questionList[questionToBeAsked][3],
                        questionList[questionToBeAsked][1],
                        indexOfRightAnswer.ToString()
                    };
            }
            return new string[] { };
        }
    }

}
