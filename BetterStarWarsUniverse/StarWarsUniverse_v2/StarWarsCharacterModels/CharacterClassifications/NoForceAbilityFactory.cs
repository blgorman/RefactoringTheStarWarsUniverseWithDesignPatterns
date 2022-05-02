using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.CharacterClassifications
{
    public class NoForceAbilityFactory : CharacterClassificationFactory
    {
        protected override CharacterClassification CreateClass(ClassificationType c)
        {
            switch (c)
            {
                case ClassificationType.BountyHunter:
                    return new BountyHunter();
                case ClassificationType.Droid:
                    return new Droid();
                case ClassificationType.Raider:
                    return new Raider();
                case ClassificationType.Smuggler:
                    return new Smuggler();
                case ClassificationType.Trooper:
                    return new Trooper();
                case ClassificationType.Generic:
                    return new GenericCharacter();
                default:
                    return new GenericCharacter();
            }
        }
    }
}
