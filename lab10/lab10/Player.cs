using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Player
    {
        public double[] probs;
        public int[] dices;

        public Player()
        {
            dices = new int[5];
            probs = new double[6];
            for (int i = 0; i < 6; i++)
            {
                probs[i] = 1.0 / 6;
            }
        }
        public int roll()
        {
            Random rnd = new Random();
            double A = rnd.NextDouble();
            int event_id = -1;
            do
            {
               event_id++;
               A -= probs[event_id];
            } while (A > 0);
            return event_id+1;
        }

        public int[] cheat_roll()
        {
            int win_number = roll();
            dices[0] = win_number;
            int win_id = win_number-1;
            for (int i = 0; i < 6; i++)
            {
                probs[i] = 1.0 / 8;
            }
            probs[win_id] = 3.0 / 8;
            for (int i = 1; i < 5; i++)
            {
                dices[i] = roll();
            }
            for (int i = 0; i < 6; i++)
            {
                probs[i] = 1.0 / 6;
            }
            return dices;
        }

        public int[] common_roll()
        {
            for (int i = 0; i < 5; i++)
            {
                dices[i] = roll();
            }
            return dices;
        }

        public int[] check_combination()
        {
            var max_count = 0;
            var elder = 0;
            int[] comb = new int[6];
            foreach (var dice in dices)
            {
                comb[dice-1]++;
            }
            for (int i = 0; i < 6; i++)
            {
                if (comb[i]>=max_count)
                {
                    max_count = comb[i];
                    elder = i;
                }
            }
            int[] ans = { max_count, elder };
            return (ans);
        }

    }
}
