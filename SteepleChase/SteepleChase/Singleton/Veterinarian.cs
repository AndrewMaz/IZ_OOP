using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteepleChase {
    class Veterinarian {

        private String name;
        private static string result;

        private static Veterinarian veterinarian;
        public static Veterinarian getVeterinarian() {
            if (veterinarian == null) {
                veterinarian = new Veterinarian("Veterinarian");
            }
            return veterinarian;
        }

        private Veterinarian(String name_) {
            name = name_;
        }

        public void treatment(Horse horse) {
            Results.text += "\nЛошадь " + horse.name + " была вылечена ветеринаром";
            horse.setState(new SelectedForRace());
        }
    }
}