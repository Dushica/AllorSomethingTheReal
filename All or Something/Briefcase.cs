using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_or_Something
{
    class Briefcase
    {
        public int value;

        public Briefcase(int value) {
            this.value = value;
        }

        public void swap(Briefcase bc) {
            int temp = this.value;
            this.value = bc.value;
            bc.value = temp;
        }
    }
}