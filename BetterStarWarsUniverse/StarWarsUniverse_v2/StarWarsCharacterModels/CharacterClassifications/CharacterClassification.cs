namespace StarWarsCharacterModels.CharacterClassifications
{
    public enum ClassificationType
    {
        BountyHunter = 1
        , Droid = 2
        , Raider = 3
        , Smuggler = 4
        , Trooper = 5
        , Generic = 6
    }

    public abstract class CharacterClassification : ICharacterClassification
    {
        public ClassificationType ClassificationType { get; set; }

        public virtual string PerformAction()
        {
            return $"{GetNextAction()}{System.Environment.NewLine}" +
                    $"{PerformNextAction()}{System.Environment.NewLine}" +
                    $"{ReportResults()}{System.Environment.NewLine}";
        }

        public abstract string GetNextAction();
        public abstract string PerformNextAction();
        public abstract string ReportResults();

        public List<string> Actions = new List<string>();
    }
}
