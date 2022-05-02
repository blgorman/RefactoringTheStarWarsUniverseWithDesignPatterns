using StarWarsCharacterModels.Behaviors;
using StarWarsCharacterModels.CharacterClassifications;
using System.Text;

namespace StarWarsCharacterModels.Characters
{
    public class StormTrooper : Character
    {
        public StormTrooper(string name, int age, double height, double weight, int speciesChoice, int weaponChoice,Random random)
            : base(name, age, height, weight, (int)ClassificationType.Trooper, speciesChoice, weaponChoice, true, false, random)
        {
        }

        public StormTrooper(string name, int age, double height, double weight, int speciesChoice, int weaponChoice, Random random, IAttackBehavior attack, IDefendBehavior defense)
            : base(name, age, height, weight, (int)ClassificationType.Trooper, speciesChoice, weaponChoice, true, false, random)
        {
            AttackBehavior = attack;
            DefendBehavior = defense;
        }

        public override void SetClass(ClassificationType c)
        {
            var mightHave = new MightHaveForceCharacterFactory();
            Classification = mightHave.SetClass(c);
        }
    }
}
