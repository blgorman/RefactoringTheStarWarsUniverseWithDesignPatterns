using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.CharacterClassifications
{
    public abstract class CharacterClassificationFactory
    {
        public CharacterClassification SetClass(ClassificationType c)
        {
            return CreateClass(c);
        }

        protected abstract CharacterClassification CreateClass(ClassificationType c);
    }
}
