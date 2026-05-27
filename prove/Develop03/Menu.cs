using System.ComponentModel;
/*
I wanted to challenge myself by providing the user with a familiar menu-like
experience. Part of this came from the desire to have the user be able to select
any scripture they like from a database, rather than have them hard-coded in. I
decided it would be nicer to be able to select the book you want instead of
worrying about correct spelling.

The Class takes advantage of array indices. Since the user inputs numbers to
select their options, I wanted to be able to reference a specific index based on
those numbers to return and display the appropriate string.

Keeping track of the navigation logic, however, was an absolute nightmare. Even
after sketching the whole thing out in flowcharts and on paper, I made myself
dizzy trying to keep track of what menu strings belonged where. Additionally, 
not having a consistent naming scheme going into the project made things all the
more confusing. I will definitely need to nail down a more consistent approach
if I try something similar in the future.
*/
public static class MenuPD
{
  private static int _volumeIdxPD = 0;
  private static int _subIdxPD = 0;
  private static int _bookIdxPD = 0;


  /*
  These include all of the differen pages the menu could possibly display.
  Putting titles within the strings themselves helped me sort out where they
  should appear with greater ease.

  Not every string actually ends up getting used for the main program, but I
  needed them as a placeholder to help me mentally map out how the navigation
  would play out.
  */
  private static string _mainMenuStringPD = """
  MAIN MENU
  Choose a volume (Enter a number 0-5):
  0. (Quit)
  1. Old Testament
  2. New Testament
  3. Book of Mormon
  4. Pearl of Great Price
  5. Doctrine and Covenants
  """,

  // The Old Testament in particular has so many books, that it was clear to me
  // that it would be more readable to have each main volume split into smaller
  // sub-collections to choose from, rather than a single menu 50+ lines long.
  // I tried to keep most menus less than 10 lines, but a few end up in the low 
  // teens.
  _volumeMenuStringOTPD = """
  OLD TESTAMENT
  Choose a subsection:
     [Section]            [From] >> [To]
  0. (Go Back)
  1. The Law            | Genesis   Deuteronomy
  2. History            | Joshua    Esther
  3. Poetry             | Job       Song of Solomon
  4. The Prophets (1/2) | Isaiah    Obadiah
  5. The Prophets (2/2) | Jonah     Malachi
  """,

  _subMenuString_LawPD = """
  THE LAW (OLD TESTAMENT)
  Select book:
  0. (Go Back)
  1. Genesis
  2. Exodus
  3. Leviticus
  4. Numbers
  5. Deuteronomy
  """,

  _subMenuString_HistoryPD = """
  HISTORY (OLD TESTAMENT)
  Select book:
   0. (Go Back)
   1. Joshua
   2. Judges
   3. Ruth
   4. 1 Samuel
   5. 2 Samuel
   6. 1 Kings
   7. 2 Kings
   8. 1 Chronicles
   9. 2 Chronicles
  10. Ezra
  11. Nehemiah
  12. Esther
  """,

  _subMenuString_PoetryPD = """
  POETRY (OLD TESTAMENT)
  Select book:
  0. (Go Back)
  1. Job
  2. Psalms
  3. Proverbs
  4. Ecclesiastes
  5. Song of Solomon
  """,

  _subMenuString_Prophets1PD = """
  THE PROPHETS pg 1/2 (OLD TESTAMENT)
  Select book:
  0. (Go Back)
  1. Isaiah
  2. Jeremiah
  3. Lamentations
  4. Ezekiel
  5. Daniel
  6. Hosea
  7. Joel
  8. Amos
  9. Obadiah
  """,

  _subMenuString_Prophets2PD = """
  THE PROPHETS pg 2/2 (OLD TESTAMENT)
  Select book:
  0. (Go Back)
  1. Jonah
  2. Micah
  3. Nahum
  4. Habakkuk
  5. Zephaniah
  6. Haggai
  7. Zechariah
  8. Malachi
  """,

  _volumeMenuStringNTPD = """
  NEW TESTAMENT
  Choose a subsection:
     [Section]            [From] >> [To]
  0. (Go Back)
  1. The Gospels +      | Matthew   Acts
  2. Pauline Epistles   | Romans    Hebrews
  3. General Epistles + | James   Revelation
  """,

  _subMenuString_GospelsPD = """
  THE FOUR GOSPELS + ACTS (NEW TESTAMENT)
  Select book:
  0. (Go Back)
  1. Matthew
  2. Mark
  3. Luke
  4. John
  5. Acts
  """,

  _subMenuString_PaulPD = """
  THE EPISTLES OF PAUL (NEW TESTAMENT)
  Select book:
   0. (Go Back)
   1. Romans
   2. 1 Corinthians
   3. 2 Corinthians
   4. Galatians
   5. Ephesians
   6. Philippians
   7. Colossians
   8. 1 Thessalonians
   9. 2 Thessalonians
  10. 1 Timothy
  11. 2 Timothy
  12. Titus
  13. Philemon
  14. Hebrews
  """, // Dadgum Paul was a yapper.

  _subMenuString_EpistlesPD = """
  THE GENERAL EPISTLES + REVELATION (NEW TESTAMENT)
  Select book:
  0. (Go Back)
  1. James
  2. 1 Peter
  3. 2 Peter
  4. 1 John
  5. 2 John
  6. 3 John
  7. Jude
  8. Revelation
  """,

  _volumeMenuStringBMPD = """
  THE BOOK OF MORMON
  Choose a subsection:
     [Section]                [From]     >>     [To]
  0. (Go Back)
  1. Small Plates of Nephi  | 1 Nephi           Omni
  2. Mormon's Abridgement   | Words of Mormon   Moroni
  """,

  _subMenuString_SmallPlatesPD = """
  THE SMALL PLATES OF NEPHI (BOOK OF MORMON)
  Select book:
  0. (Go Back)
  1. 1 Nephi
  2. 2 Nephi
  3. Jacob
  4. Enos
  5. Jarom
  6. Omni
  """,

  _subMenuString_LargePlatesPD = """
  MORMON'S ABRIDGEMENT (BOOK OF MORMON)
  Select book:
  0. (Go Back)
  1. Words of Mormon
  2. Mosiah
  3. Alma
  4. Helaman
  5. 3 Nephi
  6. 4 Nephi
  7. Mormon
  8. Ether
  9. Moroni
  """,

  _volumeMenuStringPPPD = """
  THE PEARL OF GREAT PRICE
  Select book:
  0. (Go Back)
  1. Moses
  2. Abraham
  3. JST-Matthew
  4. Joseph Smith History
  5. Articles of Faith
  """,

  _askForChapterPD = """
  Enter chapter number:
  """;

  /*
  These arrays are designed to return the correct menu string based on the
  integer inputs from the user. E.g. _subMenuStringsArray[2][2] will return the
  menu string with all of the books that are considered the Pauline episles:
  (2. New Testament) -> (2. Pauline Epistles) -> _subMenuString_PaulPD

  Since 0 is always the option which returns the user to the previous screen, I
  decided to make each 0-index value empty. Perhaps it would have been better to
  just adjust the input integers to be 0-indexed values, but I thought this was
  a simpler approach.
  */
  private static string[] _volumeMenuStringsArrayPD = {
    // First index: Volume
    "Exiting Program",
    _volumeMenuStringOTPD,
    _volumeMenuStringNTPD,
    _volumeMenuStringBMPD,
    _volumeMenuStringPPPD,
    _askForChapterPD
    };
  
  private static string[][] _subMenuStringsArrayPD = {
    // First index: Volume
    // Second index: Subsection
    new string[] { "" },
    new string[] {
    _mainMenuStringPD,
    _subMenuString_LawPD,
    _subMenuString_HistoryPD,
    _subMenuString_PoetryPD,
    _subMenuString_Prophets1PD,
    _subMenuString_Prophets2PD
    },
    new string[] {
    _mainMenuStringPD,
    _subMenuString_GospelsPD,
    _subMenuString_PaulPD,
    _subMenuString_EpistlesPD
    },
    new string[] {
    _mainMenuStringPD,
    _subMenuString_SmallPlatesPD,
    _subMenuString_LargePlatesPD
    }
  };

  // All the titles have been hard-coded in, taking the burden of spelling off
  // the user.
  private static string[][][] _bookTitlesArrayPD = {
    // First index: Volume
    // Second index: Subsection
    // Third index: Book title
    new string[][] { // 0-index
      new string [] { // 0-index
        "",
      }
    },
    new string[][] { // OT
      new string [] { // 0-index
        "",
      },
      new string [] { // Law
        _volumeMenuStringOTPD,
        "Genesis",
        "Exodus",
        "Leviticus",
        "Numbers",
        "Deuteronomy"
      },
      new string [] { // History
        _volumeMenuStringOTPD,
        "Joshua",
        "Judges",
        "Ruth",
        "1 Samuel",
        "2 Samuel",
        "1 Kings",
        "2 Kings",
        "1 Chronicles",
        "2 Chronicles",
        "Ezra",
        "Nehemiah",
        "Esther"
      },
      new string [] { // Poetry
        _volumeMenuStringOTPD,
        "Job",
        "Psalms",
        "Proverbs",
        "Ecclesiastes",
        "Song of Solomon"
      },
      new string [] { // Prophets1
        _volumeMenuStringOTPD,
        "Isaiah",
        "Jeremiah",
        "Lamentations",
        "Ezekiel",
        "Daniel",
        "Hosea",
        "Joel",
        "Amos",
        "Obadiah"
      },
      new string [] { // Prophets2
        _volumeMenuStringOTPD,
        "Jonah",
        "Micah",
        "Nahum",
        "Habakkuk",
        "Zephaniah",
        "Haggai",
        "Zechariah",
        "Malachi"
      },
    },
    new string[][] { // NT
      new string [] { // 0-index
        ""
      },
      new string [] { // Gospels
        _volumeMenuStringNTPD,
        "Matthew",
        "Mark",
        "Luke",
        "John",
        "Acts"
      },
      new string [] { // Paul
        _volumeMenuStringNTPD,
        "Romans",
        "1 Corinthians",
        "2 Corinthians",
        "Galatians",
        "Ephesians",
        "Philippians",
        "Colossians",
        "1 Thessalonians",
        "2 Thessalonians",
        "1 Timothy",
        "2 Timothy",
        "Titus",
        "Philemon",
        "Hebrews"
      },
      new string [] { // Epistles
        _volumeMenuStringNTPD,
        "James",
        "1 Peter",
        "2 Peter",
        "1 John",
        "2 John",
        "3 John",
        "Jude",
        "Revelation"
      },      
    },
    new string[][] { // BM
      new string [] { // 0-index
        "",
      },
      new string [] { // Small
        _volumeMenuStringBMPD,
        "1 Nephi",
        "2 Nephi",
        "Jacob",
        "Enos",
        "Jarom",
        "Omni"
      },
      new string [] { // Large
        _volumeMenuStringBMPD,
        "Words of Mormon",
        "Mosiah",
        "Alma",
        "Helaman",
        "3 Nephi",
        "4 Nephi",
        "Mormon",
        "Ether",
        "Moroni"
      }
    },
    new string[][] { // PP
      new string [] { // PP
        "",
        "Moses",
        "Abraham",
        "Joseph Smith--Matthew",
        "Joseph Smith--History",
        "Articles of Faith"
      }
    },
    new string[][] { // DC
      new string [] {
        "Doctrine and Covenants"
      }
    }

  };

  /*
  This class contains attributes to keep track of what menu level the user is
  in. This way, Program.cs doesn't have to keep track of what's already been
  entered, and only has to supply one input integer at a time.

  To be honest, it would be nicer to have the Menu class handle ALL of the menu
  navigation logic, but since this is inherently related to the console, it's a
  bit split between this class and the GetBook() function in Program.cs ln 89.
  */
  public static string MainMenuPD()
  {
    return _mainMenuStringPD;
  }
  public static string VolumeMenuPD(int inputVolumeIdxPD)
  {
    _volumeIdxPD = inputVolumeIdxPD;
    return _volumeMenuStringsArrayPD[_volumeIdxPD];
  }
  
  public static string SubsectionMenuPD(int inputSubIndexPD)
  {
    _subIdxPD = inputSubIndexPD;
    return _subMenuStringsArrayPD[_volumeIdxPD][_subIdxPD];
  }

  public static string BookTitlePD(int inputBookIndexPD)
  {
    _bookIdxPD = inputBookIndexPD;
    return _bookTitlesArrayPD[_volumeIdxPD][_subIdxPD][_bookIdxPD];
  }
  
  /*
  The program is intended to loop from the beginning, so this is just a
  catch-all function to set the attributes back to initial conditions in case
  the logic doesn't do it automatically.
  */
  public static void ResetPD()
  {
    _volumeIdxPD = 0;
    _subIdxPD = 0;
    _bookIdxPD = 0;
  }

}