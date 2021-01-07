using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteepleChase {
    class StableBuilder : Builder {
        private Stable stable;

        public void reset() {
            stable = new Stable();
        }

        public void setName(String name) {
            stable.name = name;
        }
        public void setHorses(Horse[] horses) {
            stable.horsers = horses;
        }
        public void setJockey(Jockey jockey) {
            stable.jockey = jockey;
        }
        public void setTrainer(Trainer trainer) {
            stable.trainer = trainer;
        }

        public Stable getResult() {
            return stable;
        }

    }
}
