using Microsoft.Extensions.Configuration;
using StarWarsCharacterModels.Behaviors;
using StarWarsCharacterModels.CharacterClassifications;
using StarWarsCharacterModels.Characters;
using StarWarsCharacterModels.CharacterSpecies;
using StarWarsCharacterModels.Roller;
using StarWarsCharacterModels.Weapons;

namespace StarWarsUniverse_v2
{
    public class Program
    {
        private static IConfigurationRoot _configuration;


        public static void Main(string[] args)
        {
            BuildOptions();
            var AllCharacters = new List<ICharacter>();

            var shouldContinue = ConsoleHelpers.GetUserInputChoice("Would you like to add default main characters [y/n]?");
            if (shouldContinue)
            {
                foreach (var character in MainCharacters())
                {
                    AllCharacters.Add(character);
                }
            }

            //build characters
            shouldContinue = ConsoleHelpers.GetUserInputChoice("Would you like to generate additional characters [y/n]?");

            while (shouldContinue)
            {
                ICharacter newCharacter;

                //get choice of name, age, weapon, and species
                var name = ConsoleHelpers.GetUserInput("What is your character's name?");
                var age = ConsoleHelpers.GetUserInputInteger("What is your character's age?", false);
                var height = ConsoleHelpers.GetUserInputDouble("What is your character's height?", false);
                var weight = ConsoleHelpers.GetUserInputDouble("What is your character's weight?", false);
                var weaponChoice = ConsoleHelpers.PrintMenuAndGetChoice(Weapons(), 1, 6, false);
                var speciesChoice = ConsoleHelpers.PrintMenuAndGetChoice(Species(), 1, 10, false);
                var charactersChoice = ConsoleHelpers.PrintMenuAndGetChoice(Characters(), 1, 10, false);
                var classificationChoice = ConsoleHelpers.PrintMenuAndGetChoice(Classifications(), 1, 7, false);
                //compose the character
                switch (charactersChoice)
                {
                    case 1:
                        newCharacter = new JediKnight(name, age, height, weight, speciesChoice, weaponChoice, RandomRoller.Roller);
                        break;
                    case 2:
                        newCharacter = new Scavenger(name, age, height, weight, speciesChoice, weaponChoice, RandomRoller.Roller);
                        break;
                    case 3:
                        newCharacter = new SithLord(name, age, height, weight, speciesChoice, weaponChoice, RandomRoller.Roller);
                        break;
                    case 5:
                        newCharacter = new StormTrooper(name, age, height, weight, speciesChoice, weaponChoice, RandomRoller.Roller);
                        break;
                    case 6:
                        newCharacter = new Politician(name, age, height, weight, speciesChoice, weaponChoice,  RandomRoller.Roller);
                        break;
                    case 7:
                        newCharacter = new MobBoss(name, age, height, weight, speciesChoice, weaponChoice, RandomRoller.Roller);
                        break;
                    default:
                        newCharacter = new StormTrooper(name, age, height, weight, speciesChoice, weaponChoice, RandomRoller.Roller);
                        break;
                }
                AllCharacters.Add(newCharacter);

                var anotherCharacter = ConsoleHelpers.GetUserInput("Would you like to add another character?", false);
                if (string.IsNullOrEmpty(anotherCharacter) || !anotherCharacter.StartsWith("y", StringComparison.OrdinalIgnoreCase))
                {
                    shouldContinue = false;
                }
            }

            //Strategy - add ability to override default no attack behavior
            //han and chewy get new behaviors!
            var han = AllCharacters.FirstOrDefault(x => x.Name == "Han Solo");
            if (han is not null)
            {
                han.AttackBehavior = new AttackWithWeapon();
                //default defend is retreat...
            }
            var chewy = AllCharacters.FirstOrDefault(x => x.Name == "Chewbacca");
            if (chewy is not null)
            {
                //decorator: Chewy gets a bowcaster cannon, storm trooper gets a blaster cannon
                var bowcastercannon = new Cannon(new Bowcaster());
                chewy.Weapon = bowcastercannon; 

                chewy.AttackBehavior = new AttackWithWeapon();
                chewy.DefendBehavior = new DefendWithForce(); //fails - no ability
            }

            //palpatine chickens out
            var emporer = AllCharacters.FirstOrDefault(x => x.Name == "Emporer Palpatine");
            if (emporer is not null)
            {
                emporer.AttackBehavior = new AttackWithForceAndWeapon();
                emporer.DefendBehavior = new DefendRetreat();
            }

            //luke uses the force and a weapon
            var luke = AllCharacters.FirstOrDefault(x => x.Name == "Luke Skywalker");
            if (luke is not null)
            {
                //template, trooper, jedi encounter characters
                luke.Classification.ChallengeRequested = true;
                luke.AttackBehavior = new AttackWithForceAndWeapon();
            }

            //C3P0 tries to use the force
            var c3p0 = AllCharacters.FirstOrDefault(x => x.Name == "C3P0");
            if (c3p0 is not null)
            {
                c3p0.AttackBehavior = new AttackWithForce();
            }

            //decorator trooper gets blaster cannon
            var trooper = AllCharacters.FirstOrDefault(x => x.Name == "Finn");
            if (trooper != null)
            {
                trooper.Classification.ChallengeRequested = true;
                trooper.Weapon = new Cannon(new Blaster());
            }

            //decorator Maul gets double ls
            var maul = AllCharacters.FirstOrDefault(x => x.Name == "Darth Maul");
            if (maul != null)
            {
                maul.Weapon = new Lightsaber(new Lightsaber());
            }

            


            foreach (var c in AllCharacters)
            {
                Console.WriteLine(c);
            }

            
        }

        private static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
        }

        private static Dictionary<int, string> Weapons() => new Dictionary<int, string>
        {
            {1, "Blaster" },
            {2, "BlasterRifle" },
            {3, "BlasterCannon" },
            {4, "BowCaster" },
            {5, "Lightsaber" },
            {6, "Staff" }
        };

        private static Dictionary<int, string> Characters() => new Dictionary<int, string>
        {
            {1, "JediKnight" },
            {2, "Scavenger" },
            {3, "SithLord" },
            {5, "StormTrooper" },
            {6, "Politician" },
            {7, "MobBoss" }
        };

        private static Dictionary<int, string> Classifications() => new Dictionary<int, string>
        {
            {(int)ClassificationType.BountyHunter, ClassificationType.BountyHunter.ToString() },
            {(int)ClassificationType.Droid, ClassificationType.Droid.ToString() },
            {(int)ClassificationType.Raider, ClassificationType.Raider.ToString() },
            {(int)ClassificationType.Smuggler, ClassificationType.Smuggler.ToString() },
            {(int)ClassificationType.Trooper, ClassificationType.Trooper.ToString() },
            {(int)ClassificationType.Generic, ClassificationType.Generic.ToString() }
        };

        private static Dictionary<int, string> Species() => new Dictionary<int, string>
        {
            {(int)KnownSpeciesType.Human, KnownSpeciesType.Human.ToString() },
            {(int)KnownSpeciesType.Droid, KnownSpeciesType.Droid.ToString() },
            {(int)KnownSpeciesType.Wookie, KnownSpeciesType.Wookie.ToString() },
            {(int)KnownSpeciesType.YodaSpecies, KnownSpeciesType.YodaSpecies.ToString() },
            {(int)KnownSpeciesType.Tusken_Raider, KnownSpeciesType.Tusken_Raider.ToString() },
            {(int)KnownSpeciesType.Hutt, KnownSpeciesType.Hutt.ToString() },
            {(int)KnownSpeciesType.Mandalorian, KnownSpeciesType.Mandalorian.ToString() },
            {(int)KnownSpeciesType.Jawa, KnownSpeciesType.Jawa.ToString() },
            {(int)KnownSpeciesType.Ewok, KnownSpeciesType.Ewok.ToString() },
            {(int)KnownSpeciesType.Gungan, KnownSpeciesType.Gungan.ToString() },
        };

        private static List<ICharacter> MainCharacters() => new List<ICharacter>
        {
            new NoForceAbilityCharacter("Han Solo", 42, 6.04, 225, (int)ClassificationType.Smuggler, (int)KnownSpeciesType.Human, (int)WeaponChoices.Blaster, RandomRoller.Roller),
            new NoForceAbilityCharacter("Chewbacca", 152, 8.31, 423, (int)ClassificationType.Smuggler, (int)KnownSpeciesType.Wookie, (int)WeaponChoices.Bowcaster, RandomRoller.Roller),
            new ForceAbledCharacter("Luke Skywalker", 27, 5.72, 175, (int)ClassificationType.Jedi, (int)KnownSpeciesType.Human, (int)WeaponChoices.LightSaber, RandomRoller.Roller),
            new ForceAbledCharacter("Emporer Palpatine", 72, 5.61, 164, (int)ClassificationType.Sith, (int)KnownSpeciesType.Human, (int)WeaponChoices.LightSaber, RandomRoller.Roller),
            new ForceAbledCharacter("Princess Leia", 29, 5.4, 120, (int)ClassificationType.Generic, (int)KnownSpeciesType.Human, (int)WeaponChoices.Blaster, RandomRoller.Roller, new AttackWithWeapon(), new DefendWithWeapon()),
            new AnyDroid("C-3PO", 92, 5.9, 320, (int)KnownSpeciesType.Droid, (int)WeaponChoices.Staff, RandomRoller.Roller, new AttackNoWeapon(), new DefendRetreat()),
            new AnyCharacter("Finn", 27, 6.0, 190, (int)ClassificationType.Trooper, (int)KnownSpeciesType.Human, (int)WeaponChoices.Blaster, RandomRoller.Roller, new AttackWithWeapon(), new DefendWithWeapon()),
            new ForceAbledCharacter("Darth Maul", 27, 6.4, 252, (int)ClassificationType.Sith, (int)KnownSpeciesType.Human, (int)WeaponChoices.LightSaber, RandomRoller.Roller, new AttackWithForceAndWeapon(), new DefendWithWeapon())
        };
    }
}
