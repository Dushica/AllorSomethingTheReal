using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_or_Something
{
    // Game logic
    class Game
    {
        // Sum of remaining values left in the game
        private int remSum;
        // number of remaining values/Briefcases
        private int remBriefs;
        // number of round
        private int round;
        // Briefcases opened in the current round
        private int open;

        // initialy we are in the first round, the remaining sum of all values is 2310919, we have 26 briefcases to open and we have opened -1
        // open = -1 because we first must choose one briefcase to be ours
        public Game() {
            remSum = 2310919;
            round = 1;
            remBriefs = 26;
            open = -1;
        }

        // calculates the messace that needs to be printed on the end of the round
        // detects end of a round
        public string turn(int value) {
            // if open != -1 then we have already chose our briefcase
            if (open != -1)
            {
                // we substruct the value of the current briefcase opened from the global sum
                remSum -= value;
                // we have one less briefcase to open in the future
                remBriefs--;
            }
            // we have opened another briefcase
            // if open == -1 then open will be 0, exactly the number of briefcases we have opened in this round
            open++;
            // each round the number of briefcases we need to open decreses by the following formula...
            if (open == Math.Max(7 - round, 1)) 
            {
                // we go into the next round
                open = 0;
                round++;
                // we calculate an offer and send the message ready for displaying
                return "Понудата на банкарот изнесува " + offer() + " денари, дали понудата важи?";
            }
            // else if it is not the end of the round we display this message
            return "Отвори кутија";
        }

        // calculates an offer based of remainign briefcases and number of briefcases alowed to be open in this round
        public int offer() {
            return remSum / remBriefs/ Math.Max(1, (7 - round));
        }

        // returns round
        public int getRound() {
            return round;
        }
    }
}