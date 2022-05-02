using StarWarsCharacterModels.Behaviors;
using StarWarsCharacterModels.CharacterClassifications;
using System.Text;

namespace StarWarsCharacterModels.Characters
{
    public class SithLord : Character
    {
        public SithLord(string name, int age, double height, double weight, int speciesChoice, int weaponChoice, Random random) :
            base(name, age, height, weight, (int)ClassificationType.Sith, speciesChoice, weaponChoice, true, true, random)
        {
            HasForcePower = true;
            AttackBehavior = new AttackWithForceAndWeapon();
            DefendBehavior = new DefendWithWeapon();
        }

        public SithLord(string name, int age, double height, double weight, int speciesChoice, int weaponChoice, Random random, IAttackBehavior attack, IDefendBehavior defend) :
            base(name, age, height, weight, (int)ClassificationType.Sith, speciesChoice, weaponChoice, true, true, random)
        {
            HasForcePower = true;
            AttackBehavior = attack;
            DefendBehavior = defend;
        }

        public override void SetClass(ClassificationType c)
        {
            var characterFactory = new ForceAbleFactory();
            Classification = characterFactory.SetClass(c);
        }
    }
}
