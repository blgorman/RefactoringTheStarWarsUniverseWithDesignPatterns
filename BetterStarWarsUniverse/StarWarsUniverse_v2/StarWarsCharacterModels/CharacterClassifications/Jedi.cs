using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.CharacterClassifications
{
    public class Jedi : CharacterClassification
    {
        private string _nextAction = string.Empty;

        public Jedi()
        {
            Actions = new List<string>() {
                new string("Light Side stuff..")
            };
            ClassificationType = ClassificationType.Raider;

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
