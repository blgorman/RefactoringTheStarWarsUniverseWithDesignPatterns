using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.CharacterClassifications
{
    public class ForceAbleFactory : CharacterClassificationFactory
    {
        protected override CharacterClassification CreateClass(ClassificationType c)
        {
            switch (c)
            {
                case ClassificationType.Jedi:
                    return new Jedi();
                case ClassificationType.Sith:
                    return new Sith();
                default:
                    return new Jedi();
            }
        }
    }
}
