using System;


namespace Sports
{
    public abstract class Sport
    {
        private string sportDescription;
        private int team1Score = 0;
        private int team2Score = 0;
        private bool isOutside;
        private int numOfPlayers;
        private bool hasTeams;
        
        public Sport(bool hasTeams)
        {
            this.hasTeams = hasTeams;
        }

        public Sport(string description, bool isOutside, int numOfPlayers, bool hasTeams)
        {
            this.SportDescription = description;
            this.IsOutside = isOutside;
            
            this.hasTeams = hasTeams;
            if(hasTeams)
            {
                this.numOfPlayers = numOfPlayers;
            }
            else { this.numOfPlayers = 1; }
            
        }

        public string SportDescription { get => sportDescription; set => sportDescription = value; }
        public int Team1Score { get => team1Score; }
        public int Team2Score { get => team2Score; }
        public bool IsOutside { get => isOutside; set => isOutside = value; }
        public int NumOfPlayers { get => numOfPlayers; }
        public bool HasTeams { get => hasTeams; }

        public void changeScore(int changeVal)
        {
            try
            {
                if(!HasTeams)
                {
                    team1Score += changeVal;
                }
            }
            catch(Exception ex)
            { Console.WriteLine(ex.Message); }
        }
        public void changePlayers(int changeVal)
        {
            if(!hasTeams)
            {
                Console.WriteLine("You can't change the number of players without a team!");
            }
            else
            {
                numOfPlayers += changeVal;
            }
        }
        public void changeScore(int team1Val, int team2Val)
        {
            try
            {
                if(HasTeams)
                {
                    team1Score += team1Val;
                    team2Score += team2Val;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public override string ToString()
        {

            string retString = sportDescription+"\n";
            if(IsOutside)
            {
                retString += "This is an outside sport\n";
            }
            else
            {
                retString += "This is not an outside sport\n";
            }
            
            if (hasTeams)
            {
                retString += "This is a team sport \nThe respective scores are:\tTeam A: "+Team1Score+"\tTeam B: "+Team2Score;
            }
            else
            {
                retString += "This is a single person sport, the current person playing has a score of "+team1Score;
            }
            return retString;
        }
    }
}
