using Microsoft.Extensions.Configuration;
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
                        newCharacter = new JediKnight(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, RandomRoller.Roller);
                        break;
                    case 2:
                        newCharacter = new Scavenger(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, false, RandomRoller.Roller);
                        break;
                    case 3:
                        newCharacter = new SithLord(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, RandomRoller.Roller);
                        break;
                    case 4:
                        newCharacter = new Scoundrel(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, false, RandomRoller.Roller);
                        break;
                    case 5:
                        newCharacter = new StormTrooper(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, false, RandomRoller.Roller);
                        break;
                    case 6:
                        newCharacter = new Politician(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, false, RandomRoller.Roller);
                        break;
                    case 7:
                        newCharacter = new MobBoss(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, false, RandomRoller.Roller);
                        break;
                    default:
                        newCharacter = new StormTrooper(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, false, RandomRoller.Roller);
                        break;
                }
                AllCharacters.Add(newCharacter);

                var anotherCharacter = ConsoleHelpers.GetUserInput("Would you like to add another character?", false);
                if (string.IsNullOrEmpty(anotherCharacter) || !anotherCharacter.StartsWith("y", StringComparison.OrdinalIgnoreCase))
                {
                    shouldContinue = false;
                }
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
            {4, "Scoundrel" },
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
            new Scoundrel("Han Solo", 42, 6.04, 225, (int)ClassificationType.Smuggler, (int)KnownSpeciesType.Human, (int)WeaponChoices.Blaster, false, false, RandomRoller.Roller),
            new Scoundrel("Chewbacca", 152, 8.31, 423, (int)ClassificationType.Smuggler, (int)KnownSpeciesType.Wookie, (int)WeaponChoices.Bowcaster, false, false, RandomRoller.Roller),
            new JediKnight("Luke Skywalker", 27, 5.72, 175, (int)ClassificationType.Generic, (int)KnownSpeciesType.Human, (int)WeaponChoices.LightSaber, RandomRoller.Roller),
            new SithLord("Emporer Palpatine", 72, 5.61, 164, (int)ClassificationType.Generic, (int)KnownSpeciesType.Human, (int)WeaponChoices.LightSaber, RandomRoller.Roller)
        };
    }
}
