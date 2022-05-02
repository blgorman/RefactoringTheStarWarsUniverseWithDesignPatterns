namespace StarWarsCharacterModels.CharacterClassifications
{
    public class BountyHunter : CharacterClassification
    {
        private string _nextAction = string.Empty;

        public BountyHunter()
        {
            Actions = new List<string>() {
                new string("Getting Assignment"),
                new string("Searching for the target"),
                new string("Capturing target"),
                new string("Collecting the bounty")
            };
            ClassificationType = ClassificationType.BountyHunter;
        }
        public override string GetNextAction()
        {
            _nextAction = Actions[0];
            return $"Starting: {_nextAction}";
        }

        public override string PerformChallengeAction()
        {
            return $"Talking to character: 'Tell me why I shouldn't haul you in right now!'";
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
