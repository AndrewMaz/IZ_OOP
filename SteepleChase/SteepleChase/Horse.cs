using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteepleChase {
   public class Horse  : IComparable{

        public String name;
        public int timeTraining;
        private  State state;
        public Stable stable;

        public Horse(String name_, State state_, int timeTraining_) {
            name = name_;
            state = state_;
            timeTraining = timeTraining_;
        }
        public Horse() {

        }

        public void setState(State state_) {
            state = state_;
        }


        int CompareTo(object o){
            Horse horse = o as Horse;
            if (this.timeTraining == horse.timeTraining) return 0;
            else
                return this.timeTraining < horse.timeTraining ? -1 : 1;
        }

        public State getState() {
            return state;
        }

        int IComparable.CompareTo(object obj)
        {
            Horse horse = obj as Horse;
            if (this.timeTraining == horse.timeTraining) return 0;
            else
                return this.timeTraining < horse.timeTraining ? -1 : 1;
        }
    }
}
