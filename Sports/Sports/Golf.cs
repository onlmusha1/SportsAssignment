namespace Sports
{
    class Golf : Sport, ISport
    {
        private const string DESCRIPTION = "Golf is a club-and-ball sport in which players use various clubs to hit balls into\na series of holes on a course in as few strokes as possible.";
        private int coursePar;
        private int numberOfObstacles;
        private string courseName;
        private string golferName;


        private double assetValues;
        private double fixedCosts;
        private double totalIncome;
        private double totalExpenses;
        

        public string CourseName { get => courseName; set => courseName = value; }
        public string GolferName { get => golferName; set => golferName = value; }
        public int NumberOfObstacles { get => numberOfObstacles; set => numberOfObstacles = value; }
        public int CoursePar { get => coursePar; set => coursePar = value; }

        public enum Strokes
        {
            Condor = -4, Albatross = -3, Eagle = -2, Birdie = -1, par = 0, Bogey = 1, DoubleBogey = 2, TripleBogey = 3
        }
        public Golf(int coursePar, double assetValue, double fixedCosts, double totalIncome, double totalExpenses) : base(false)
        {
            this.CoursePar = coursePar;
            this.assetValues = assetValue;
            this.totalExpenses = totalExpenses;
            this.totalIncome = totalIncome;
            this.fixedCosts = fixedCosts;
        }
        public Golf(int coursePar, int numberOfObstacles,string golferName, string courseName, double assetValue, double fixedCosts, double totalIncome, double totalExpenses) : base(DESCRIPTION, true, 1, false)
        {
            this.CoursePar = coursePar;
            this.NumberOfObstacles = numberOfObstacles;
            this.assetValues = assetValue;
            this.totalExpenses = totalExpenses;
            this.totalIncome = totalIncome;
            this.fixedCosts = fixedCosts;
            this.CourseName = courseName;
            this.GolferName = golferName;
        }

        public void ChangeScore(Strokes stroke)
        {
            base.changeScore((int)stroke);
        }
        public void ChangeScore(int stroke)
        {
            base.changeScore(stroke);
        }
        
        //COSTS
        public double getFixedCosts()
        {
            return fixedCosts;
        }
        public double getVarExpenses()
        {
            return totalExpenses;
        }
        
        //INCOME
        public double getTotalIncome()
        {
            return totalIncome;
        }
        public double getAssetVal()
        {
            return assetValues;
        }
        
        public double getGrossRevenue()
        {
            return ((this.getTotalIncome() + this.getAssetVal()) - (this.getVarExpenses() + this.getFixedCosts()));
        }

        public override string ToString()
        {
            string retString = SportDescription + "\nThis is an outside sport.\nThis is a single person sport, " + this.GolferName + " current has a score of " + base.Team1Score + "\nThe average gross revenue is : " + this.getGrossRevenue();
            return retString;
        }
    }
}
