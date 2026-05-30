# Encapsulation

## What is Encapsulation and why is it important?

Encapsulation is highly related to "separation of responsibilities," a design
principle that focuses on restricting access/visibility to variables and
functions to only the things that strictly need it. While separation of
responsibilities is the paradigm, encapsulation is the actual implementation of
this paradigm. After figuring out what the program is supposed to do in the
abstraction/design stage, you write your classes so that each responsibility is
taken care of by its own class.

Designing your code via encapsulation is beneficial because it makes your
program incredibly modular. As you continue to develop and maintain your
project, you find that certain behaviors can be implemented in a more efficient
or more secure way; by encapsulating responsibilities within their own classes,
you can change how a certain behavior is implemented in one place: the class,
and everywhere else the program calls that method is automatically updated.
Otherwise, if things aren't encapsulated properly, then you may have to edit
every line in your program which deals with that behavior.

Encapsulation also deals with the problem of collaboration. When working on a
team, if you encapsulate a behavior within its own class, then other people can
work on other parts of the program and write calls to that class even while
you're still working on the specific implementation.

One example from the program I wrote recently dealt with randomly choosing words
to obscure within a passage in order to help somebody remember the passage. One
of the responsibilities then, of course was to have words be hidden, and as an
added measure, I wanted to ensure that words that had already been hidden would
not be "re-hidden" again. I designed my `Scripture`, `Passage`, and `Word`
classes with, among other things, the following considerations:

1. The `Obscure` method should only obscure one word at a time, and only
`Scripture` needs to keep track of how many times that method has been called;
only it knows how many times to call that function.

1. `Word` objects should only know about themselves and only `Word` should know
how to obscure itself, therefore

1. `Passage` is in charge of keeping track of which of its `Word` objects have
already been hidden, and only calling the `Obscure` method on `Word` instances
that have not yet been hidden.

Examples of these can be found below:

```csharp
public class Scripture
{
    public void Obscure()
    {
        int hideCount = int.Max(3, passages.Count()/2);
        Random random = new();
        int i = 0;
        while (i < hideCount)
        {
            int shoot = random.Next(passages.Count());
            if (!passages[shoot].IsAllHidden())
            {
            passages[shoot].Obscure();
            i ++;
            }
            else if (AllHidden()){ break; }
        }
    }
}

public class Passage
{
    private List<Word> _obscuredText;

    private List<int> _visibleWordIndices;
    private List<int> _hiddenWordIndices;

    public void Obscure()
    {
        Random random = new();
        int indexIndex = random.Next(_visibleWordIndices.Count());
        int wordIndex = _visibleWordIndices[indexIndex];

        _visibleWordIndices.RemoveAt(indexIndex);
        _hiddenWordIndices.Add(wordIndex);

        _obscuredText[wordIndex].Obscure();
    }
}

public class Word
{
    private string _text;

    public Word(string word)
    {
        _text = word;
    }
    
    public void Obscure()
    {
        int length = _text.Length;
        _text = new string('_', length);
    }

    public override string ToString()
    {
        return _text;
    }
}
```
