using StarWarsCharacterModels.Behaviors;
using StarWarsCharacterModels.CharacterClassifications;
using System.Text;

namespace StarWarsCharacterModels.Characters
{
    public class Politician : Character
    {
        public Politician(string name, int age, double height, double weight, int speciesChoice, int weaponChoice, Random random) :
            base(name, age, height, weight, (int)ClassificationType.Politician, speciesChoice, weaponChoice, true, false, random)
        {

        }

        public Politician(string name, int age, double height, double weight, int speciesChoice, int weaponChoice, Random random, IAttackBehavior attack, IDefendBehavior defend) :
            base(name, age, height, weight, (int)ClassificationType.Politician, speciesChoice, weaponChoice, true, false, random)
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
