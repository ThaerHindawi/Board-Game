using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
   public class Games
    {
        
        public Games()
        {
            Date = DateTime.Now.ToString("MM/dd/yyyy");
        }

        public int Score
        {
            get
            {              
                return level * countBarrier * 10;
            }
            
        }
        private int numMoveUP;
        public int NumMoveUP
        {
            get
            {
                return numMoveUP;
            }
            set
            {
                numMoveUP = value;
            }
        }

        private int numMoveDown;
        public int NumMoveDown
        {
            get
            {
                return numMoveDown;
            }
            set
            {
                numMoveDown = value;
            }
        }

        private int numMoveLeft;
        public int NumMoveLeft
        {
            get
            {
                return numMoveLeft;
            }
            set
            {
                numMoveLeft = value;
            }
        }

        private int numMoveRight;
        public int NumMoveRight
        {
            get
            {
                return numMoveRight;
            }
            set
            {
                numMoveRight = value;
            }
        }

        public int successfulMoves
        {
            get
            {
                return NumMoveUP + NumMoveDown + NumMoveRight + NumMoveLeft;
            }

        }

        private int failedMoves;
        public int FailedMoves
        {
            get
            {
                return failedMoves;
            }
            set
            {
                failedMoves = value;
            }
        }

        public int TotleMoves
        {
            get
            {
                return failedMoves + successfulMoves;
            }
        }

        private int level;
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        private int countBarrier;
        public int CountBarrier
        {
            get
            {
                return countBarrier;
            }
            set
            {
                countBarrier = value;
            }
        }

        private int duration;
        public int Duration
        {
            set
            {
                duration = value;
            }
            get
            {
                return duration;
            }
        }

        public string Date
        {
            get;
            set;
        }

        public List<int> dirctionSteps = new List<int>();

        public List<string> arr = new List<string>();

        public int gameId;
    }
}
