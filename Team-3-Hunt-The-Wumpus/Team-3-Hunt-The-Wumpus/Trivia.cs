using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    class Trivia
    {
        // inst variables
       // public static List<string> TriviaList;

        public int QuestionsAsked { get; set; }
        public int QuestionsRight { get; set; }
        public int QuestionsWrong { get; set; }


        public Trivia(int qa, int qr, int qw)
        {
            QuestionsAsked = qa;
            QuestionsRight = qr;
            QuestionsWrong = qw; 
        }

        public void PurchaseArrows(int qa, int qr, int qw, int goldCoinAmount)
        {
            int purchase = goldCoinAmount - 1;
         

            //user answers 2/3 trivia correct
            //costs 1 gold coin to answer trivia 
        }

        public void PurchaseSecret()
        {
            //user answers 2/3 trivia correct
        }

        public void SaveFromPit()
        {

        }
    }

}
