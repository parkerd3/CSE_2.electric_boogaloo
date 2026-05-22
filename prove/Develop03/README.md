# README

## Assignment Details

Here are the pages associated with this assignment:

[Design Activity](https://byui-cse.github.io/cse210-course-2023/unit03/design.html)

[Program Requirements](https://byui-cse.github.io/cse210-course-2023/unit03/develop.html)

## Design

### Required Classes

- Scripture

- Reference

### Class Diagram

My class diagram for this program

```mermaid
classDiagram
    class Program {
        GetUserInput() int

    }
    class Menu {
        - _standardWorks: string
        - _booksOT: string
        - _booksNT: string
        - _booksBoM: string
        - _booksPGP: string
        + Main() str
        + (Volume)Subseciton() str
        + (Subsection)() str
    }
    class Scripture {
        - _reference: string
        - _scriptureText: string
        - VerseParser(Reference: str) List~int~
        - LookUp() string
        + Scripture(Book: str, Reference: str)
    }
    class Reference {
        - _book: string
        - _chapter: int
        - _startingVerse: int
        - _endingVerse: int
    }
    class Word {
        - _originalText: List~string~
        - _displayText: List~string~
        + HideWords() void
        + RestoreBlank() void
        + ToString() string _displayText
    }

    Program --> Menu
    Scripture *-- Word
    Scripture *-- Reference
```

### IPO Table

| Input | Processing | Output |
| --- | --- | --- |
| From `Menu` class | Call display methods to return menu strings and write to console<br> Get user input to move into deeper levels<br> (E.g. New Testament -> Romans -> Chapter number -> verse number(s)) | Display scripture selection menu with quit program option |
| (While in the main menu) `0` | Clear console, end loop | Terminate Program |
| Scripture Selection (Book, Chapter, Verses) | 1. Open CSV file<br> 2. Return Scripture text<br> 3. Format strings for display<br> *Bonus Processing*<br> Count # of characters in each word as they come into the list. <br> As soon as a length of 30-40 characters has been exceeded, insert a linebreak into the string. | Display chosen verses as numbered paragraphs (as they appear in the scriptures) with the correct reference<br> *Bonus: Force paragraphs to stay under 30-40 characters wide without splitting in the middle of words* |
| `Enter` | `Word.HideWords()`<br> 1. Isolate words within the scripture text string (e.g. into a list)<br> 2. Filter out already blanked-out words<br> 3. Pick 3 unblanked indices at random<br> 4. Blank those words, and reconstruct the string<br> 5. Return formatted string (so it can be handed over to `Console.WriteLine()`| Show the same verse(s) with a few words replaced with blanks at random |
| `0` (or `Enter` if all words have been blanked out) | Clear console window, loop program | Return to scripture selection/quit out menu |
| *Optional Ideas:* | | |
| "Got it" or<br> "Didn't get it" | If (Got it) {`Word.HideWords()`}<br> Else If (Didn't Get it) {`Word.RestoreBlank()`<br> 1. Pick a random blanked out spot from currently displayed string<br> 2. Reference original scripture text to find the word to restore<br> 3. Update display string<br> 4. Call `Console.WriteLine(Word)`<br>} | Proceed; remove 3 more words <br> Try again; reveal 1 blanked out word
