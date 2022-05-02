using System.Text;

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
        , Jedi = 7
        , Sith = 8
        , MobBoss = 9
        , Politician = 10
        , Scavenger = 11
    }

    public abstract class CharacterClassification : CharacterClassificationAlgorithm
    {
        public ClassificationType ClassificationType { get; set; }

        public sealed override string PerformAction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetNextAction());
            sb.AppendLine(PerformNextAction());
            if (ChallengeRequested)
            {
                sb.AppendLine(PerformChallengeAction());
            }
            sb.AppendLine(ReportResults());
            return sb.ToString();
        }

        public abstract string GetNextAction();
        public abstract string PerformNextAction();
        public abstract string ReportResults();
        public abstract string PerformChallengeAction();

        public List<string> Actions = new List<string>();
    }
}
