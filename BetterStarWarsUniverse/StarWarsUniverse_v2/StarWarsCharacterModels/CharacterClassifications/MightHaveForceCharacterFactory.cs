using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.CharacterClassifications
{
    public class MightHaveForceCharacterFactory : CharacterClassificationFactory
    {
        //might have the force, might not
        protected override CharacterClassification CreateClass(ClassificationType c)
        {
            switch (c)
            {
                case ClassificationType.BountyHunter:
                    return new BountyHunter();
                case ClassificationType.Raider:
                    return new Raider();
                case ClassificationType.Smuggler:
                    return new Smuggler();
                case ClassificationType.Trooper:
                    return new Trooper();
                case ClassificationType.Generic:
                    return new GenericCharacter();
                case ClassificationType.MobBoss:
                    return new MobBossClassification();
                case ClassificationType.Politician:
                    return new PoliticianClassification();
                case ClassificationType.Scavenger:
                    return new ScavengerClassification();
                default:
                    return new GenericCharacter();
            }
        }
    }
}
