using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.CharacterClassifications
{
    public abstract class CharacterClassificationAlgorithm : ICharacterClassification
    {
        public bool ChallengeRequested { get; set; }

        public virtual string PerformAction()
        {
            throw new NotImplementedException();
        }
    }
}
