namespace StarWarsCharacterModels.CharacterSpecies
{
    public interface ICharacterSpecies
    {
        public KnownSpeciesType SpeciesType { get; }
        public int ForceBonus { get;}
    }
}
