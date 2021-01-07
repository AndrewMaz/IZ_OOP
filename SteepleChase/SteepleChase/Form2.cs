using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;



namespace SteepleChase
{
    public partial class Form2 : Form
    {

        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();

        private List<int> racingResultForEachHorse = new List<int>();
        private List<HorseInCompetition> horserInRace = null;

        private int countForRacingDisplay = 0;

        private HorseInCompetition winner = null;
        private int maxTimeHorseInRace = 0;
        private int maxTimeHorseInTraining = 0;

        Hippodrome hippodrome = new Hippodrome();
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e){

            this.WindowState = FormWindowState.Maximized;

            List<Stable> stables = createStables();

            List<Horse> horses = new List<Horse>();

            foreach(Stable st in stables){
                foreach (Horse h in findForsestHorsesFromStable(st, 3)){
                    horses.Add(h);
                }
            }




            foreach(Horse h in horses){
                hippodrome.addMember(h);

            }

             horserInRace =  hippodrome.runRace();

            setHorsersNamesToForm(horserInRace);

            foreach(HorseInCompetition horse in horserInRace)
            {
                if (horse.getState() is Winner)
                {
                    winner = horse;
                    break;
                }
            }



            float currentSize = label8.Font.Size + 20.0F;
            label8.Font = new Font(label8.Font.Name, currentSize,
                label8.Font.Style, label8.Font.Unit);



            foreach (HorseInCompetition horse in horserInRace)
            {
                racingResultForEachHorse.Add(horse.boardsPassed * 10000 / 7);
                if (horse.raceResultTime >= maxTimeHorseInRace && horse.boardsPassed == 7) maxTimeHorseInRace = horse.raceResultTime;
                if (horse.timeTraining >= maxTimeHorseInTraining) maxTimeHorseInTraining = horse.timeTraining;
                    
                if (horse.boardsPassed != 7) horse.raceResultTime = horse.timeTraining;
            }


            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 500;
            timer1.Tick += new EventHandler(start_Tick);



        }


        private List<Stable> createStables(){
            Builder stableBuilder = new StableBuilder();
            DirectorStable directorStable = new DirectorStable(stableBuilder);

            List<Stable> stables = new List<Stable>();


            stables.Add(directorStable.constructStable(50, "Спартак"));
            stables.Add(directorStable.constructStable(50, "Зенит"));

            return stables;
        }



        private List<Horse> findForsestHorsesFromStable(Stable stable, int countHorses){
            List<Horse> horsesRes = new List<Horse>();

            Horse[] horsesInStable = stable.horsers;

            Array.Sort(horsesInStable);

            for(int i = 0; i < countHorses; i++){
                horsesRes.Add(horsesInStable[i]);
            }

            return horsesRes;

        }




        private void setHorsersNamesToForm(List<HorseInCompetition> horses){
            textBox1.Text = horses[0].name;
            label1.Text = horses[0].name;

            textBox2.Text = horses[1].name;
            label2.Text = horses[1].name;

            textBox3.Text = horses[2].name;
            label3.Text = horses[2].name;

            textBox4.Text = horses[3].name;
            label4.Text = horses[3].name;

            textBox5.Text = horses[4].name;
            label5.Text = horses[4].name;

            textBox6.Text = horses[5].name;
            label6.Text = horses[5].name;

        }




        void start_Tick(object sender, EventArgs e)
        {
            switch (label8.Text)
            {
                case ("3"): 
                    label8.Text = "2";
                    break;

                case ("2"):
                    label8.Text = "1";
                    break;

                case ("1"):
                    label8.Text = "GO!";
                    break;

                case ("GO!"):
                    timer1.Stop();
                    start_racing_display();
                    break;
            }



        }


        void start_racing_display()
        {
            timer2.Enabled = true;
            timer2.Start();
            timer2.Interval = 60;
           

            timer2.Tick += new EventHandler(racing_display_Tick);

            progressBar1.Maximum = 10000;
            progressBar2.Maximum = 10000;
            progressBar3.Maximum = 10000;
            progressBar4.Maximum = 10000;
            progressBar5.Maximum = 10000;
            progressBar6.Maximum = 10000;
        }

        void racing_display_Tick(object sender, EventArgs e)
        {
            countForRacingDisplay += 10000 / (maxTimeHorseInRace != 0 ? maxTimeHorseInRace : maxTimeHorseInTraining);
            if (countForRacingDisplay <= 10000)
            {
                if (progressBar1.Value < racingResultForEachHorse[0]) progressBar1.Value += progressBar1.Value + 10000 / horserInRace[0].raceResultTime < 10000 ? 10000 / horserInRace[0].raceResultTime : 10000 - progressBar1.Value;
                else if (progressBar1.Value != 10000) progressBar1.ForeColor = Color.Red;

                if (progressBar2.Value < racingResultForEachHorse[1]) progressBar2.Value += progressBar2.Value + 10000 / horserInRace[1].raceResultTime < 10000 ? 10000 / horserInRace[1].raceResultTime : 10000 - progressBar2.Value;
                else if (progressBar2.Value != 10000) progressBar2.ForeColor = Color.Red;

                if (progressBar3.Value < racingResultForEachHorse[2]) progressBar3.Value += progressBar3.Value + 10000 / horserInRace[2].raceResultTime < 10000 ? 10000 / horserInRace[2].raceResultTime : 10000 - progressBar3.Value;
                else if (progressBar3.Value != 10000) progressBar3.ForeColor = Color.Red;

                if (progressBar4.Value < racingResultForEachHorse[3]) progressBar4.Value += progressBar4.Value + 10000 / horserInRace[3].raceResultTime < 10000 ? 10000 / horserInRace[3].raceResultTime : 10000 - progressBar4.Value;
                else if (progressBar4.Value != 10000)  progressBar4.ForeColor = Color.Red;

                if (progressBar5.Value < racingResultForEachHorse[4]) progressBar5.Value += progressBar5.Value + 10000 / horserInRace[4].raceResultTime < 10000 ? 10000 / horserInRace[4].raceResultTime : 10000 - progressBar5.Value;
                else if(progressBar5.Value != 10000) progressBar5.ForeColor = Color.Red;

                if (progressBar6.Value < racingResultForEachHorse[5]) progressBar6.Value += progressBar6.Value + 10000 / horserInRace[5].raceResultTime < 10000 ? 10000 / horserInRace[5].raceResultTime : 10000 - progressBar6.Value;
                else if (progressBar6.Value != 10000) progressBar6.ForeColor = Color.Red;

            }
            else
            {
                timer2.Stop();
                if (winner == null) label8.Text = "Нет победителя";
                else label8.Text = "победила " + winner.name;

                float currentSize = label7.Font.Size + 6.0F;
                label7.Font = new Font(label7.Font.Name, currentSize,
                    label7.Font.Style, label7.Font.Unit);
                label7.Text = Results.text;
            }
        }

    }
}