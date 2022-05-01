using StarWarsCharacterModels.CharacterClassifications;
using StarWarsCharacterModels.CharacterSpecies;
using StarWarsCharacterModels.Weapons;

namespace StarWarsCharacterModels.Characters
{
    public interface ICharacter
    {
        string Name { get; set; }
        int Age { get; set; }
        double Height { get; set; }
        double Weight { get; set; }
        IWeapon Weapon { get; set; }
        ICharacterClassification Classification { get; set; }
        ICharacterSpecies Species { get; set; }
    }
}
