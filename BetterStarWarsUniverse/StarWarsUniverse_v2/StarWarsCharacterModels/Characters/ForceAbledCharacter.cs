using StarWarsCharacterModels.Behaviors;
using StarWarsCharacterModels.CharacterClassifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Characters
{
    public class ForceAbledCharacter : Character
    {
        public ForceAbledCharacter(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, Random random)
            : base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, true, random)
        {
        }

        public ForceAbledCharacter(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, Random random, IAttackBehavior attack, IDefendBehavior defense)
            : base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, true, random)
        {
            AttackBehavior = attack;
            DefendBehavior = defense;
        }

        public override void SetClass(ClassificationType c)
        {
            var characterFactory = new ForceAbleFactory();
            Classification = characterFactory.SetClass(c);
        }
    }
}
