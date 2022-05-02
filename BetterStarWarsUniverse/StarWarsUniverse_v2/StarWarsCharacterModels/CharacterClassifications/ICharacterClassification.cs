namespace StarWarsCharacterModels.CharacterClassifications
{
    public interface ICharacterClassification
    {
        bool ChallengeRequested { get; set; }
        string PerformAction();
    }
}
