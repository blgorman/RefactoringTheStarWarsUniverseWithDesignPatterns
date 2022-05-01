namespace StarWarsCharacterModels.CharacterSpecies
{
    public enum KnownSpeciesType { 
        Human = 1,
        Droid = 2,
        Wookie = 3,
        YodaSpecies = 4,
        Tusken_Raider = 5,
        Hutt = 6,
        Mandalorian = 7,
        Jawa = 8,
        Ewok = 9,
        Gungan = 10
    };

    public class Species : ICharacterSpecies
    {
        public KnownSpeciesType SpeciesType { get; private set; } 

        //certain species can get a force bonus
        public int ForceBonus { get; private set; }

        private readonly Random _random;

        public Species(KnownSpeciesType species, Random random)
        { 
            SpeciesType = species;
            _random = random;
            //force ability is pseudo-random, negative means no ability
            ForceBonus = CalculateBonus(species);
        }

        private int CalculateBonus(KnownSpeciesType species)
        { 
            switch (species)
            {
                case KnownSpeciesType.Human:
                    return _random.Next(-3, 12);
                case KnownSpeciesType.Droid:
                    return -1;
                case KnownSpeciesType.Wookie:
                    return _random.Next(-7, 7);
                case KnownSpeciesType.YodaSpecies:
                    return _random.Next(-1, 15);
                case KnownSpeciesType.Hutt:
                    return _random.Next(-3, 2);
                case KnownSpeciesType.Tusken_Raider:
                    return _random.Next(-3, 1);
                case KnownSpeciesType.Mandalorian:
                    return -1;
                case KnownSpeciesType.Jawa:
                    return _random.Next(-12, 2);
                case KnownSpeciesType.Ewok:
                    return _random.Next(-8, 1);
                case KnownSpeciesType.Gungan:
                    return _random.Next(-7, 4);
                default:
                    return -1;
            }
        }
    }
}
