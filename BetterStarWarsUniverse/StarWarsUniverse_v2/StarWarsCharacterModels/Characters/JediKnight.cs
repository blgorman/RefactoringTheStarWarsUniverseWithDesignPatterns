using StarWarsCharacterModels.Behaviors;
using StarWarsCharacterModels.CharacterClassifications;
using System.Text;

namespace StarWarsCharacterModels.Characters
{
    public class JediKnight : Character
    {
        public JediKnight(string name, int age, double height, double weight, int speciesChoice, int weaponChoice, Random random) :
            base(name, age, height, weight, (int)ClassificationType.Jedi, speciesChoice, weaponChoice, true, true, random)
        {
            HasForcePower = true;
            AttackBehavior = new AttackWithForceAndWeapon();
            DefendBehavior = new DefendWithWeapon();
        }

        public JediKnight(string name, int age, double height, double weight, int speciesChoice, int weaponChoice, Random random, IAttackBehavior attack, IDefendBehavior defend) :
            base(name, age, height, weight, (int)ClassificationType.Jedi, speciesChoice, weaponChoice, true, true, random)
        {
            HasForcePower = true;
            AttackBehavior = attack;
            DefendBehavior = defend;
        }

        public override void SetClass(ClassificationType c)
        {
            var hasForceFactory = new ForceAbleFactory();
            Classification = hasForceFactory.SetClass(c);
        }
    }
}
