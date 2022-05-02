namespace StarWarsCharacterModels.CharacterClassifications
{
    public class GenericCharacter : CharacterClassification
    {
        private string _nextAction = string.Empty;

        public GenericCharacter()
        {
            Actions = new List<string>() {
                new string("Looking for their friends")
            };
            ClassificationType = ClassificationType.Generic;
        }
        public override string GetNextAction()
        {
            _nextAction = Actions[0];
            return $"Started: {_nextAction}";
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
