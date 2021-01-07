using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteepleChase {
    class NotSelectedForRace : State {
        public void doAction(Horse horse) {
            Results.text +="\n" + horse.name + " Не используется ";
        }
    }
}
