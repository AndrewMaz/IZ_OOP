using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteepleChase {
    public interface Builder {

        void reset();
        void setHorses(Horse[] horses);
        void setJockey(Jockey jockey);
        void setTrainer(Trainer trainer);
        void setName(String name);

        Stable getResult();
    }
}
