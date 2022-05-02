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

        //cannot override a sealed method, algorithm is protected.
        //public override string PerformAction()
        //{
        //    //attempting to override the algorithm..
        //    return "We did it!";
        //}

        public override string PerformChallengeAction()
        {
            return "Asking for identification...";
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
