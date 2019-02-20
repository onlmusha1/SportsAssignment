using System;

namespace Sports
{
    class Football : Sport, ISport
    {
        private const string DESCRIPTION = "A sport played by two teams of eleven players on a rectangular field with goalposts at each end.\nThe offense, which is the team controlling the oval-shaped football,\nattempts to advance down the field by running with or passing the ball,\nwhile the defense, which is the team without control of the ball,\naims to stop the offense's advance and aims to take control of the ball for themselves.";
        private string team1Name;
        private string team2Name;
        private string coachName;
        private bool isCollege;
        private string offensiveTeam;


        private double assetVal;
        private double fixedCosts;
        private double totalIncome;
        private double varCosts;

        public Football(bool isCollege, double assetVal, double fixedCosts, double totalIncome, double varCosts) : base(true)
        {
            this.isCollege = isCollege;
            this.assetVal = assetVal;
            this.fixedCosts = fixedCosts;
            this.totalIncome = totalIncome;
            this.varCosts = varCosts;
        }

        public Football(string team1Name, string team2Name, bool isCollege, string coachName, double assetVal, double fixedCosts, double totalIncome, double varCosts) : base(DESCRIPTION, true, 22, true)
        {
            this.isCollege = isCollege;
            Team1Name = team1Name;
            Team2Name = team2Name;
            this.CoachName = coachName;
            this.assetVal = assetVal;
            this.fixedCosts = fixedCosts;
            this.totalIncome = totalIncome;
            this.varCosts = varCosts;
        }

        public string Team1Name { get => team1Name; set => team1Name = value; }
        public string Team2Name { get => team2Name; set => team2Name = value; }
        public bool IsCollege { get => isCollege; }
        public string CoachName { get => coachName; set => coachName = value; }
        public string OffensiveTeam { get => offensiveTeam; set => offensiveTeam = value; }

        
        public int kick()
        {
            Random rnd = new Random();
            return rnd.Next(80, 110);
        }

        //COSTS
        public double getFixedCosts()
        {
            return fixedCosts;
        }
        public double getVarExpenses()
        {
            return this.varCosts;
        }

        //INCOME
        public double getTotalIncome()
        {
            return totalIncome;
        }
        public double getAssetVal()
        {
            return this.assetVal;
        }

        public double getGrossRevenue()
        {
            return ((this.getTotalIncome() + this.getAssetVal()) - (this.getVarExpenses() + this.getFixedCosts()));
        }

        public override string ToString()
        {
            string retString = "\n\n"+this.SportDescription+
                "\nThis is an outside sport, although sometimes played in stadiums\nThere are only 22 players on the field playing at any given time."+
                "\nTeam "+this.team1Name+"\tScore : "+Team1Score+ 
                "\nTeam "+this.Team2Name+"\tScore : "+Team2Score+"\nThe average gross revenue is : "+this.getGrossRevenue();
            return retString;
        }
    }
}
