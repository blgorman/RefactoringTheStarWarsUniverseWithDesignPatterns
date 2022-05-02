namespace StarWarsCharacterModels.CharacterClassifications
{
    public class Smuggler : CharacterClassification
    {
        private string _nextAction = string.Empty;

        public Smuggler()
        {
            Actions = new List<string>() {
                new string("Hiding the contraband"),
                new string("Transporting the contraband"),
                new string("Delivering the contraband"),
            };
            ClassificationType = ClassificationType.Smuggler;
        }
        public override string GetNextAction()
        {
            _nextAction = Actions[0];
            return $"Starting: {_nextAction}";
        }

        public override string PerformChallengeAction()
        {
            throw new NotImplementedException();
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
