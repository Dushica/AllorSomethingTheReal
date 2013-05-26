AllorSomethingTheReal
=====================


              <p> 1.Играта Се или Нешто е игра на среќа. Идејава за играта е преземена од телевизиска емисија каде што се игра играта за вистински пари, додека тука само заради забава. Правилата на играта се мошне едноставни . Во апликацијата имаме ставено кутии со броеви од 1 до 26 и секоја кутија си крие некоја сума која што е случајно генерирана со код. Играта започнува така што се клика на една кутија и таа кутија е ваша среќна кутија во која што се крие некоја сума на пари од 1 денар, до 1 000 000 денари  без да знае било кој која сума се наоѓа таму(на крајот на играта дознавате која сума се криела во вашата кутија). Потоа отварате 6 кутии   по ваш избор, и кога ќе ги отворите тие кутии потоа банкарот ви нуди понуда со која што сака да ја откупи вашата кутија. Ако ја прифатите понудата завршува играта и вие останувате со парите што банкарот ви ги понудил. Инаку, продолжувате со играта и во следната рунда отварате уште 5 кутии и после нив пак банкарот ви нуди нова и по можност поголема сума за да ја откупи вашата кутија. Ако успеете да ги задржите големите суми во игра веројатноста дека банкарот во секоја наредна рунда дека ќе ви понуди поголема сума за откуп на вашата кутија е многу поголема. После отварате 4, па 3, па 1 кутија и се додека не се испразнат сите кутии до крај ќе отварате по 1 кутија. Играта е завршена во оној момент кога ке прифатите понуда на банкарот или се додека не ја отворите последната кутија. Имате копче за нова игра ако сакате да играте повторно, копче за тоа како се игра играта и копче за излез од апликацијата.<p/><br/>
            <p> 2. Целиот визуелен дел на кутиите во апликацијата е направен со Sprites па поради тоа мора  како надворешни ресурси да се чуваат соодветните слики за една кутија без број, а потоа се додаваат броевите врз секоја кутија со Label. Поради тоа потребни ни се две низи PictureBox & Label во кои се чуваат тие податоци (истите тие податоци, соодветно секој елемент од низата, може да биде дел од секоја инстанца од класата Briefcase). Во класата Briefcase единствено се чува индексот на сумата која припаѓа во соодветната кутија. Секоја сума се чува во глобална низа од суми. Сумите се чуваат глобално затоа што мораат да се испишат на екран во растечки редослед и со клик на некоја кутија соодветната сума од екранот исчезнува. Исто така сумите се испишуваат во лабели. Другата класа Game ја содржи логиката на играта, односно таму се пресметува понудата на Банкарот и се пресметува соодветната порака која треба да се покаже на екран во однос на тоа во која етапа се наоѓа играта, која рунда е и дали има активна понуда на банкарот.
<p/>

<p>3. 


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
        // Briefcases opened in the currend round
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
<p/><br/>
<p>
<a href="http://i.imgur.com/DkmseIp.png">
Ова е изгледот на играта , кутиите со броеви од 1 до 26, сумите од 1 денар до 1000000 денари и копче за нова игра, правила на игра и затвори прозорец кои што се објаснети во првата точка од документацијава. Правилата на играта (види точка 1).




<p/><br/>
