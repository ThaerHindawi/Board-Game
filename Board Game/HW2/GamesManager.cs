using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
   public class GamesManager
    {
        public static List<Profile> profiles = new List<Profile>();
        public static int countProfile;
        public static int numAllGames;

        public static int minDuration;
        public static int maxDuration;
        public static int totleDuration;

        public static int highScore;
        public static int lowScore;

        public static Bitmap[] allImage = new Bitmap[4];

        static GamesManager()
        {
            allImage[0] = new Bitmap(Properties.Resources._5c8954160c96b047950052);
            allImage[1] = new Bitmap(Properties.Resources._5c895373ba5e5773675130);
            allImage[2] = new Bitmap(Properties.Resources.donald_1);
            allImage[3] = new Bitmap(Properties.Resources._200w_d);
        }

        public static void calcStatiistcs()
        {
            var gameCalc = from p in profiles
                     select p.Games;

            minDuration = gameCalc.Min(x => x.Min(y => y.Duration));
            maxDuration = gameCalc.Max(x => x.Max(y => y.Duration));
            totleDuration = gameCalc.Sum(x => x.Sum(y => y.Duration));

            lowScore = gameCalc.Min(x=>x.Min(y=>y.Score));
            highScore = gameCalc.Max(x=>x.Max(y=>y.Score));

            countProfile = profiles.Count;

        }
    }
}
