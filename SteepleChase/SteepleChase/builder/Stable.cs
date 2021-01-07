using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SteepleChase {
    public class Stable {
        static public  List<String> namesHorses = readFileWithNames();

        public String name;
       public Trainer trainer;
        public Horse[] horsers;
        public Jockey jockey;



        static private List<string> readFileWithNames() {
            namesHorses = new List<String>();

            int counter = 0;
            string line;
                

            System.IO.StreamReader file =   new System.IO.StreamReader("C://horsesNames.txt");
            while ((line = file.ReadLine()) != null)//
            {
                namesHorses.Add(line);
                counter++;
            }

            file.Close();

            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            return namesHorses;
        }

       

    }
}
