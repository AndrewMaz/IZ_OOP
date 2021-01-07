using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteepleChase {
    class Hippodrome {
        private const int PENALTY_TIME = 50;
        List<HorseInCompetition> horsers = new List<HorseInCompetition>();

        private Random rnd = new Random();
        public void addMember(Horse horse) {
            horsers.Add(new HorseInCompetition(horse, new Jockey("Жокей: " + horse.name )));
            horse.setState(new SelectedForRace());
           
        }

        public int getSizeHorses()
        {
            return horsers.Count();
        }
        public List<HorseInCompetition> runRace() {


            foreach (HorseInCompetition horse in horsers) {

                // перепрыгнула или нет?
                for(int j = 0; j < 6; j++) {
                    if(!jumpOverBarricade()) {
                        if(!jumpedAndNotSick()) {
                            horse.setState(new Sick());
                            horse.boardsPassed = j + 1;
                            break;
                        }
                        else {
                            horse.raceResultTime += PENALTY_TIME;
                        }
                    }
                }


            }


            // Нахождение победителя
            HorseInCompetition fastestHorse = null;
            bool flag = false;
            foreach(HorseInCompetition horse in horsers) {

                if(horse.getState() is Sick) continue;
                if(!flag) {
                    fastestHorse = horse;
                    flag = true;
                }

                if(horse.raceResultTime < fastestHorse.raceResultTime) fastestHorse = horse;
            }

            if (fastestHorse != null)fastestHorse.setState(new Winner());

            // Лечение лошадей
            Veterinarian veterinarian = Veterinarian.getVeterinarian();
            foreach (HorseInCompetition horse in horsers)
            {
                if (horse.getState() is Sick)
                {
                    veterinarian.treatment(horse);
                }

            }

            return horsers;
        }

        private Boolean jumpOverBarricade() {
            return rnd.Next(3)  > 0 ? true : false;
        }

        private Boolean jumpedAndNotSick() {
            return rnd.Next(2) > 0 ? true : false;
        }

    }
}
