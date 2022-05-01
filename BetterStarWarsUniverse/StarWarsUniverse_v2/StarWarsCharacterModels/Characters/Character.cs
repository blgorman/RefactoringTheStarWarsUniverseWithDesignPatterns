using StarWarsCharacterModels.Behaviors;
using StarWarsCharacterModels.CharacterClassifications;
using StarWarsCharacterModels.CharacterSpecies;
using StarWarsCharacterModels.Weapons;

namespace StarWarsCharacterModels.Characters
{
    public abstract class Character : ICharacter
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        //character's weapon
        public IWeapon Weapon { get; set; }

        public bool HasForcePower { get; set; }
        //null = unknown/untrained, 0 = Sith, 1 = Jedi
        public bool? ForceAlignment { get; set; } 

        //what type of character is this
        public ICharacterClassification Classification { get; set; }

        //what race of character is this
        public ICharacterSpecies Species { get; set; }

        protected readonly Random _random;

        //behaviors
        public IAttackBehavior AttackBehavior { get; set; }
        public IDefendBehavior DefendBehavior { get; set; }

        public Character(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, bool canHaveTheForce, bool mustHaveTheForce, Random random)
        {
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
            _random = random;
            Species = new Species((KnownSpeciesType)speciesChoice, _random);
            Weapon = ConstructWeapon(weaponChoice);
            HasForcePower = false;
            if (canHaveTheForce)
            {
                HasForcePower = Species.ForceBonus > 0;
            }
            if (mustHaveTheForce)
            {
                HasForcePower = true;
            }
            SetClass((ClassificationType)classificationChoice);
        }

        public override string ToString()
        {
            return $"Name: {Name}\t|Age: {Age}\t|Height: {Height}\t|Weight: {Weight}\t|" +
                    $"Is a {Species.SpeciesType}\t|With Class: {Classification}\t|Using Weapon {Weapon}\n" +
                    $"Performs Action {Classification.PerformAction()}\n" +
                    $"Attacks {Attack()}\n" +
                    $"Defends {Defend()}\n";
        }

        public void ChangeAttackStrategy(IAttackBehavior attack)
        {
            AttackBehavior = attack;
        }
        public void ChangeDefendStrategy(IDefendBehavior defense)
        { 
            DefendBehavior = defense;
        }

        public virtual string Attack()
        {
            if (AttackBehavior is null)
            {
                if (HasForcePower)
                {
                    AttackBehavior = new AttackWithForce();
                }
                else
                {
                    AttackBehavior = new AttackNoWeapon();
                }
            }
                
            return AttackBehavior.Attack(HasForcePower, Weapon);
        }

        public virtual string Defend()
        {
            if (DefendBehavior is null)
            {
                if (HasForcePower)
                {
                    DefendBehavior = new DefendWithForce();
                }
                else
                {
                    DefendBehavior = new DefendRetreat();
                }
            }
            return DefendBehavior.Defend(HasForcePower, Weapon);
        }

        private void SetClass(ClassificationType c)
        {
            switch (c)
            {
                case ClassificationType.BountyHunter:
                    Classification = new BountyHunter();
                    break;
                case ClassificationType.Droid:
                    Classification = new Droid();
                    break;
                case ClassificationType.Raider:
                    Classification = new Raider();
                    break;
                case ClassificationType.Smuggler:
                    Classification = new Smuggler();
                    break;
                case ClassificationType.Trooper:
                    Classification = new Trooper();
                    break;
                case ClassificationType.Generic:
                    Classification = new GenericCharacter();
                    break;
                default:
                    Classification = new GenericCharacter();
                    break;
            }
        }

        private IWeapon ConstructWeapon(int weaponChoice)
        {
            
            switch (weaponChoice)
            {
                case 1:
                    return new Blaster();
                case 2:
                    return new Rifle(new Blaster());
                case 3:
                    return new Cannon(new Blaster());
                case 4:
                    return new Bowcaster();
                case 5:
                    return new Lightsaber();
                case 6:
                default:
                    return new Staff();
            }

        }
    }
}