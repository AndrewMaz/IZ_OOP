using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteepleChase {
    public class HorseInCompetition : Horse {
        public int raceResultTime;
        public Jockey jockey;
        public int boardsPassed = 7;

        public HorseInCompetition(Horse horse_,  Jockey jockey_) {
            raceResultTime = horse_.timeTraining;
            timeTraining = horse_.timeTraining;
            this.name = horse_.name;
            this.setState(new SelectedForRace());
            this.jockey = jockey_;

        }



    }
}
