# Hello MarkDown World!
This is me finally dipping my toes into markdown, as it's going to be an 
important part of my work from here on out.

## Journal Program Flowchart
This is for my own sake, I wanted to see how I could create my own flowcharts in
VS Code

```mermaid
classDiagram
    direction LR
    class Program {
        +Main(args: string[])
        +GetTitle()
    }
    class Entry {
        +string _prompt
        +string _response
        +string _date
        -string s
        +Read(jargon: string)
        +Write() string
        +ToString() string
    }
    class Journal {
        +string _title
        +string _file
        +List~Entry~ _entries
        +Load()
        +Save()
        +AddEntry(newEntry: Entry)
        +ToString() string
    }
    class Prompt {
        +List~string~ _pList
        +string _file
        +Generate_pbd() string
        +LoadPrompts()
        +AddPrompt(new_prompt: string)
        +ToString() string
    }

    Program --> Journal : Creates & Manages
    Program --> Prompt : Creates & Manages
    Journal "1" *-- "many" Entry : Contains
    Program --> Entry : Creates temporarily
```