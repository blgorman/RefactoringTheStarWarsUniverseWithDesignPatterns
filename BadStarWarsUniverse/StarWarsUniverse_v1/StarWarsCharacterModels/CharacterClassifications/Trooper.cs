namespace StarWarsCharacterModels.CharacterClassifications
{
    public class Trooper : CharacterClassification
    {
        private string _nextAction = string.Empty;
        public Trooper()
        {
            Actions = new List<string>() {
                new string("Patrolling")
            };
            ClassificationType = ClassificationType.Trooper;
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
