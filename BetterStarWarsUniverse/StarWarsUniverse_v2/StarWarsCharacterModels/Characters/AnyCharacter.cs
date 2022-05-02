using StarWarsCharacterModels.Behaviors;
using StarWarsCharacterModels.CharacterClassifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Characters
{
    public class AnyCharacter : Character
    {
        public AnyCharacter(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, Random random)
            : base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, false, random)
        {
        }

        public AnyCharacter(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, Random random, IAttackBehavior attack, IDefendBehavior defense) 
            : base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, false, random)
        {
            AttackBehavior = attack;
            DefendBehavior = defense;
        }

        public override void SetClass(ClassificationType c)
        {
            var characterFactory = new MightHaveForceCharacterFactory();
            Classification = characterFactory.SetClass(c);
        }
    }
}
