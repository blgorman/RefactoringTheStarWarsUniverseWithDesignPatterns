using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Species(KnownSpeciesType species)
        { 
            SpeciesType = species;
            //force ability is pseudo-random, negative means no ability
            ForceBonus = CalculateBonus(species);
        }

        private int CalculateBonus(KnownSpeciesType species)
        { 
            Random random = new Random();
            switch (species)
            {
                case KnownSpeciesType.Human:
                    return random.Next(-3, 12);
                case KnownSpeciesType.Droid:
                    return -1;
                case KnownSpeciesType.Wookie:
                    return random.Next(-7, 7);
                case KnownSpeciesType.YodaSpecies:
                    return random.Next(-1, 15);
                case KnownSpeciesType.Hutt:
                    return random.Next(-3, 2);
                case KnownSpeciesType.Tusken_Raider:
                    return random.Next(-3, 1);
                case KnownSpeciesType.Mandalorian:
                    return -1;
                case KnownSpeciesType.Jawa:
                    return random.Next(-12, 2);
                case KnownSpeciesType.Ewok:
                    return random.Next(-8, 1);
                case KnownSpeciesType.Gungan:
                    return random.Next(-7, 4);
                default:
                    return -1;
            }
        }
    }
}
