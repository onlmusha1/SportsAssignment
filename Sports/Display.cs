using System;
using System.Windows.Forms;

namespace Sports
{
    public partial class Display : Form
    {
        Golf golf = new Golf(6, 32,"Phil Mickelson","Spyglass Hill", 100000, 20000, 250000, 20000);
        private int swingCounter;
        private int swingYards;

        Football fb = new Football("Chatt State Tigers", "Louisana Losers", true, "I dunno", 1200000, 300000, 24000000, 120000);
        private int team1Yards;
        private int team2Yards;
        private int downCounter = 0;
        private int downYards = 0;
        private int currYard = 0;
        
        Random runYards = new Random();
        public Display()
        {
            InitializeComponent();
        }

        private void Display_Load(object sender, EventArgs e)
        {
            fb.OffensiveTeam = fb.Team1Name;
            //GOLF
            LblPlayerName.Text = golf.GolferName;
            LblCourseName.Text = golf.CourseName;
            LblTotalObs.Text = ""+golf.NumberOfObstacles;
            LblTotalYards.Text = "0";
            LblStrokes.Text = "";
            LblTotalSwings.Text = "0";
            swingCounter = 0;
            LblToString.Text = golf.ToString();

            //FOOTBALL
            LblTeam1.Text = fb.Team1Name;
            LblTeam2.Text = fb.Team2Name;
            LblRunningYards1.Text = "0";
            LblRunningYards2.Text = "0";
            LblGain1.Text = "0";
            LblGain2.Text = "0";
            LblScore1.Text = "0";
            LblScore2.Text = "0";
            LblCurrYard.Text = "0";
            LblCurrTeam.Text = fb.OffensiveTeam;
            LblCurrDown.Text = "0";
            LblFBToString.Text = fb.ToString();

        }

        private void btnSwing_Click(object sender, EventArgs e)
        {
            swingCounter++;
            Random rnd = new Random();
            swingYards += rnd.Next(35, 400);
            LblTotalYards.Text = "" + swingYards;
            LblTotalSwings.Text = "" + swingCounter;
            
            if(swingYards >= 400)
            {
                if(swingCounter == 1)
                {
                    LblStrokes.Text = "Hole In One!"; 
                }
                else if(swingCounter == 2)
                {
                    LblStrokes.Text = Golf.Strokes.Condor.ToString()+ "!"; golf.ChangeScore(Golf.Strokes.Condor);
                }
                else if(swingCounter == 3)
                {
                    LblStrokes.Text = Golf.Strokes.Albatross.ToString() + "!"; golf.ChangeScore(Golf.Strokes.Condor); 
                    //Yes I know theres two, but this is out of scope for project anyway /shrug
                }
                else if(swingCounter == 4)
                {
                    LblStrokes.Text = Golf.Strokes.Eagle.ToString() + "!"; golf.ChangeScore(Golf.Strokes.Eagle);
                }
                else if(swingCounter == 5)
                {
                    LblStrokes.Text = Golf.Strokes.Birdie.ToString() + "!"; golf.ChangeScore(Golf.Strokes.Birdie);
                }
                else if(swingCounter == 6)
                {
                    LblStrokes.Text = Golf.Strokes.par.ToString() + "!"; golf.ChangeScore(Golf.Strokes.par);
                }
                else
                {
                    LblStrokes.Text = "Above Par!"; golf.ChangeScore(Golf.Strokes.Bogey);
                }
                LblTotalYards.Text = "0"; swingCounter = 0; swingYards = 0; LblToString.Text = golf.ToString();
            }
        }

        
        private int checkKick(int kickVal)
        {
            if(currYard >= 100)
            {
                currYard = 15;
            }
            else
            {
                currYard = kickVal;
            }
            return currYard;
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            LblScore1.Text = "" + fb.Team1Score;
            LblScore2.Text = "" + fb.Team2Score;
            if (LblCurrYard.Text == "0")
            {
                this.checkKick(fb.kick());
            }
            int tempInt = runYards.Next(0, 65) - runYards.Next(0, 25);
            currYard += tempInt;
            downYards += tempInt;
            LblCurrYard.Text = "" + currYard;
            downCounter++;
            LblCurrDown.Text = "" + downCounter;

            if(downYards >= 10)
            {
                downCounter = 0; downYards = 0;
            }
            if (fb.OffensiveTeam == fb.Team1Name)
            {
                team1Yards += tempInt;
                LblGain1.Text = "" + tempInt;
                LblRunningYards1.Text = "" + team1Yards;
                if (currYard < 0)
                {
                    currYard = fb.kick(); downCounter = 0; downYards = 0; this.checkKick(fb.kick()); LblGain1.Text = "0"; LblCurrTeam.Text = fb.Team2Name; fb.OffensiveTeam = fb.Team2Name;
                }
                if(downCounter >= 4)//turnover
                {
                    fb.OffensiveTeam = fb.Team2Name; downCounter = 0;  downYards = 0; LblGain1.Text = "0"; LblCurrTeam.Text = fb.Team2Name;
                }
                if (currYard >= 100) //touchdown
                {
                    currYard = 0;  downCounter = 0; downYards = 0; LblGain1.Text = "0"; LblCurrYard.Text = "0";
                    fb.OffensiveTeam = fb.Team2Name; LblCurrTeam.Text = fb.Team2Name; fb.changeScore(8, 0);
                }
            }
            else if (fb.OffensiveTeam == fb.Team2Name)
            {
               
                team2Yards += tempInt; // Total running yards for game
                LblRunningYards2.Text = "" + team2Yards;
                LblGain2.Text = "" + tempInt;
                if (currYard < 0)
                {
                    this.checkKick(fb.kick()); fb.OffensiveTeam = fb.Team1Name; downCounter = 0; downYards = 0; LblGain2.Text = "0"; LblCurrTeam.Text = fb.Team1Name;
                }
                if (downCounter >= 4)//turnover
                {
                    fb.OffensiveTeam = fb.Team1Name; downCounter = 0; downYards = 0; LblGain2.Text = "0"; LblCurrTeam.Text = fb.Team1Name;
                }
                if (currYard >= 100) //touchdown
                {
                    fb.changeScore(0, 8); currYard = 0; downCounter = 0; downYards = 0;
                    LblGain2.Text = "0"; LblCurrYard.Text = "0"; fb.OffensiveTeam = fb.Team1Name; LblCurrTeam.Text = fb.Team1Name;
                }
            }
            tempInt = 0;
            LblFBToString.Text = fb.ToString();
        }
    }
}
