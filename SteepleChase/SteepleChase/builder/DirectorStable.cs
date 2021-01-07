using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteepleChase {
    public class DirectorStable {
        Builder builder;
        Random rnd;
        public DirectorStable(Builder builder_) {
            builder = builder_;
            rnd = new Random();
        }

        public Stable constructStable(int valueHorsers, String nameStable) {
            builder.reset();
            builder.setName(nameStable);
            builder.setJockey(new Jockey("Jockey " + nameStable));
            builder.setTrainer(new Trainer("Trainer " + nameStable));


            Horse[] horsers = new Horse[valueHorsers];
            for (int i = 0; i < valueHorsers; i++) {
                int randomInt = rnd.Next(Stable.namesHorses.Count);
                horsers[i] = new Horse(Stable.namesHorses[randomInt], new NotSelectedForRace(), rnd.Next(50, 1000));
                Stable.namesHorses.RemoveAt(randomInt);
            }

            builder.setHorses(horsers);


            return builder.getResult();
        }
    }
}
