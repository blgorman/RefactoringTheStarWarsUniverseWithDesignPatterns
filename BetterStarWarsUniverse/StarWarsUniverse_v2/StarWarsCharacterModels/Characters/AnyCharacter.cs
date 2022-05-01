using StarWarsCharacterModels.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Characters
{
    public class AnyCharacter : Character
    {
        public AnyCharacter(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, bool canHaveTheForce, bool mustHaveTheForce, Random random, IAttackBehavior attack, IDefendBehavior defense) 
            : base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, canHaveTheForce, mustHaveTheForce, random)
        {
            AttackBehavior = attack;
            DefendBehavior = defense;
        }
    }
}
