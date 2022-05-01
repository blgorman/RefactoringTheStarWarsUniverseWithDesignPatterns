namespace StarWarsCharacterModels.CharacterClassifications
{
    public class Droid : CharacterClassification
    {
        private string _nextAction = string.Empty;

        public Droid()
        {
            Actions = new List<string>() {
                new string("Droid Duty")
            };
            ClassificationType = ClassificationType.Droid;
        }
        public override string GetNextAction()
        {
            _nextAction = Actions[0];
            return $"Starting: {_nextAction}";
        }

        public override string PerformNextAction()
        {
            Actions.RemoveAt(0);
            return $"Performing: {_nextAction}";
        }

        public override string ReportResults()
        {
            return $"Completed: {_nextAction}";
        }

        public override string ToString()
        {
            return ClassificationType.ToString();
        }
    }
}
