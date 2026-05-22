# README

## Assignment Details

Here are the pages associated with this assignment:

[Design Activity](https://byui-cse.github.io/cse210-course-2023/unit03/design.html)

[Program Requirements](https://byui-cse.github.io/cse210-course-2023/unit03/develop.html)

## Design

### Required Classes

- Scripture

- Reference

### Diagram

My class diagram for this program

```mermaid
classDiagram
    class Program {

    }
    class Menu {
        string _standardWorks = "";
        string _booksOT = "";
        string _booksNT = "";
        string _booksBoM = "";
        string _booksPGP = "";
    }
    class Scripture {
        - _reference: string
        - _scriptureText: string
    }
    class Reference {
        - _book: string
        - _chapter: int
        - _startingVerse: int
        - _endingVerse: int
    }
    class Word {
        + BlankOut(word: string) string
        
    }
    class Menu {

    }
```
