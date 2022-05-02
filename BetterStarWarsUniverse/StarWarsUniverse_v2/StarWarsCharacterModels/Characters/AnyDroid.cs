using StarWarsCharacterModels.Behaviors;
using StarWarsCharacterModels.CharacterClassifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Characters
{
    public class AnyDroid : Character
    {
        public AnyDroid(string name, int age, double height, double weight, int speciesChoice, int weaponChoice, Random random) :
            base(name, age, height, weight, (int)ClassificationType.Droid, speciesChoice, weaponChoice, false, false, random)
        {

        }

        public AnyDroid(string name, int age, double height, double weight, int speciesChoice, int weaponChoice, Random random, IAttackBehavior attack, IDefendBehavior defend) :
            base(name, age, height, weight, (int)ClassificationType.Droid, speciesChoice, weaponChoice, false, false, random)
        {
            AttackBehavior = attack;
            DefendBehavior = defend;
        }

        public override void SetClass(ClassificationType c)
        {
            var characterFactory = new NoForceAbilityFactory();
            Classification = characterFactory.SetClass(c);
        }
    }
}
