public class Reference
{

    string textReference;
    private string _book;
    int _chapter;
    int _verse;
    int _endingVerse;
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endingVerse = 0;
        setReference();

    }
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endingVerse = endVerse;
        setReference();
    }

    public string getReference()

    {
      return textReference;  
    }
    void setReference()
    {
        if (_endingVerse == 0)
        {
            textReference = $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            textReference = $"{_book} {_chapter}:{_verse}-{_endingVerse}";
        }
        
    }
}