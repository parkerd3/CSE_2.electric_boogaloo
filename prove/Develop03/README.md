# README

## Assignment Details

Here are the pages associated with this assignment:

[Design Activity](https://byui-cse.github.io/cse210-course-2023/unit03/design.html)

[Program Requirements](https://byui-cse.github.io/cse210-course-2023/unit03/develop.html)

## Design

### Required Classes

- Scripture

  - Responsible for doing some fancy stuff

- Reference

  - Responsible for other stuff

- Word

  - Yet even more responsibilities.

### Class Diagram

My class diagram for this program

```mermaid
classDiagram
    direction LR
    namespace User_Interface {
        class Program {
            GetUserInput() int
            GetUserInput() String
        }
        class Menu {
            - String _standardWorks
            - String _booksOT
            - String _booksNT
            - String _booksBoM
            - String _booksPGP
            - [And a bunch others]
            + Main() String volumeMenu
            + Volume(int volChoice) String subsectionMenu
            + Subsection(int volChoice, int subChoice) String bookMenu
            + Books(int volChoice, int subChoice, int bookChoice) String book
        }
    }
    
    note for Reference "Reference class handles<br>turning the user input<br>into a useful list of<br>integers."
    note for Word "Takes in a Reference object<br>at construction, then<br>accesses the csv files for the<br>appropriate scripture texts."
    namespace Scripture_Handling{
        
        class Scripture {
            - Reference _reference
            - Word _text
            + Scripture(String book, String chVerses)
            + Obscure() String
            + Restore() String
            + ToString() String
        }
        class Reference {
            - String _book
            - int _chapter
            - List~int~ _verses
            + Reference(String book, String chVerses)
            - ParseVerses(String) List~int~
            + Verses() List~int~ _verses
            + ToString()
        }
        class Word {
            - String LDSCanonFileName = "lds-scriptures.csv"
            - String BibleFileName = "kjv-scriptures.csv"
            - String _scriptureText
            - String _obscuredText
            + Word(Reference)
            + Obscure() void
            + Restore() void
            + ToString() String 
        }
    }
    Program ..> Menu : Calls to get<br>menu strings<br>for display.
    Scripture *-- Word
    Scripture *-- Reference
    Scripture ..> Menu : Gets Book
    Scripture ..> Program : Gets Verse(s)
    Reference ..> Scripture : Gets Book<br>and verse(s)
    Program ..> Scripture : Calls to get<br>obscured string<br>for display.
```

### IPO Table

| Input | Processing | Output |
| --- | --- | --- |
| From `Menu` class | Call display methods to return menu Strings and write to console<br> Get user input to move into deeper levels<br> (E.g. New Testament -> Romans -> Chapter number -> verse number(s)) | Display scripture selection menu with quit program option |
| (While in the main menu) `0` | Clear console, end loop | Terminate Program |
| Scripture Selection (Book, Chapter, Verses) | 1. Open CSV file<br> 2. Return Scripture text<br> 3. Format Strings for display<br> *Bonus Processing*<br> Count # of characters in each word as they come into the list. <br> As soon as a length of 30-40 characters has been exceeded, insert a linebreak into the String. | Display chosen verses as numbered paragraphs (as they appear in the scriptures) with the correct reference<br> *Bonus: Force paragraphs to stay under 30-40 characters wide without splitting in the middle of words* |
| `Enter` | `Console.WriteLine(<Scripture>.Obscure())`<br>1. Isolate words within the scripture text String (e.g. into a list)<br> 2. Filter out already blanked-out words<br> 3. Pick 3 unblanked indices at random<br> 4. Blank those words, and reconstruct the String<br> 5. Return formatted String (so it can be handed over to `Console.WriteLine()`| Show the same verse(s) with a few words replaced with blanks at random |
| `0` (or `Enter` if all words have been blanked out) | Clear console window, loop program | Return to scripture selection/quit out menu |
| *Optional Ideas:* | | |
| "Got it" or<br> "Didn't get it" | If (Got it) {`Word.HideWords()`}<br> Else If (Didn't Get it) {`Word.RestoreBlank()`<br> 1. Pick a random blanked out spot from currently displayed String<br> 2. Reference original scripture text to find the word to restore<br> 3. Update display String<br> 4. Call `Console.WriteLine(Word)`<br>} | Proceed; remove 3 more words <br> Try again; restore 1 blanked out word |
