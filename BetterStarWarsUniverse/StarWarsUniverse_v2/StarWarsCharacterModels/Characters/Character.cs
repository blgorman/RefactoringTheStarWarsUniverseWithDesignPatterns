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

        public Character(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, bool canHaveTheForce, bool mustHaveTheForce)
        {
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
            Species = new Species((KnownSpeciesType)speciesChoice);
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

        public abstract string Attack();
        public abstract string Defend();

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
                    return new BlasterRifle();
                case 3:
                    return new BlasterCannon();
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