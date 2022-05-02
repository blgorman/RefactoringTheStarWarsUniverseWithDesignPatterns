using StarWarsCharacterModels.Behaviors;
using StarWarsCharacterModels.CharacterClassifications;
using System.Text;

namespace StarWarsCharacterModels.Characters
{
    public class MobBoss : Character
    {
        public MobBoss(string name, int age, double height, double weight, int speciesChoice, int weaponChoice, Random random) :
            base(name, age, height, weight, (int)ClassificationType.MobBoss, speciesChoice, weaponChoice, true, false, random)
        {

        }

        public MobBoss(string name, int age, double height, double weight, int speciesChoice, int weaponChoice, Random random, IAttackBehavior attack, IDefendBehavior defend) :
            base(name, age, height, weight, (int)ClassificationType.MobBoss, speciesChoice, weaponChoice, true, false, random)
        {
            AttackBehavior = attack;
            DefendBehavior = defend;
        }

        public override void SetClass(ClassificationType c)
        {
            var characterFactory = new MightHaveForceCharacterFactory();
            Classification = characterFactory.SetClass(c);
        }
    }
}
