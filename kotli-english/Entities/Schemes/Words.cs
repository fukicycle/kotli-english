namespace kotli_english.Entities.Schemes;
public sealed class Words
{
    public Words(
        Guid wordId,
        string word,
        string meaning,
        string partOfSpeech,
        string exampleSentence,
        string exampleTranslation)
    {
        WordId = wordId;
        Word = word;
        Meaning = meaning;
        PartOfSpeech = partOfSpeech;
        ExampleSentence = exampleSentence;
        ExampleTranslation = exampleTranslation;
    }
    public Guid WordId { get; }
    public string Word { get; }
    public string Meaning { get; }
    public string PartOfSpeech { get; }
    public string ExampleSentence { get; }
    public string ExampleTranslation { get; }
}
