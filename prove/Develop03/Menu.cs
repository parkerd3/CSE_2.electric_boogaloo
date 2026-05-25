using System.ComponentModel;

public static class Menu
{
  private static int _volumeIdx = 0;
  private static int _subIdx = 0;
  private static int _bookIdx = 0;

  private static string _mainMenuString = """
  MAIN MENU
  Choose a volume (Enter a number 0-5):
  0. (Quit)
  1. Old Testament
  2. New Testament
  3. Book of Mormon
  4. Pearl of Great Price
  5. Doctrine and Covenants
  """,

  _volumeMenuStringOT = """
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

  _subMenuString_Law = """
  THE LAW (OLD TESTAMENT)
  Select book:
  0. (Go Back)
  1. Genesis
  2. Exodus
  3. Leviticus
  4. Numbers
  5. Deuteronomy
  """,

  _subMenuString_History = """
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

  _subMenuString_Poetry = """
  POETRY (OLD TESTAMENT)
  Select book:
  0. (Go Back)
  1. Job
  2. Psalms
  3. Proverbs
  4. Ecclesiastes
  5. Song of Solomon
  """,

  _subMenuString_Prophets1 = """
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

  _subMenuString_Prophets2 = """
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

  _volumeMenuStringNT = """
  NEW TESTAMENT
  Choose a subsection:
     [Section]            [From] >> [To]
  0. (Go Back)
  1. The Gospels +      | Matthew   Acts
  2. Pauline Epistles   | Romans    Hebrews
  3. General Epistles + | James   Revelation
  """,

  _subMenuString_Gospels = """
  THE FOUR GOSPELS + ACTS (NEW TESTAMENT)
  Select book:
  0. (Go Back)
  1. Matthew
  2. Mark
  3. Luke
  4. John
  5. Acts
  """,

  _subMenuString_Paul = """
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

  _subMenuString_Epistles = """
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

  _volumeMenuStringBM = """
  THE BOOK OF MORMON
  Choose a subsection:
     [Section]                [From]     >>     [To]
  0. (Go Back)
  1. Small Plates of Nephi  | 1 Nephi           Omni
  2. Mormon's Abridgement   | Words of Mormon   Moroni
  """,

  _subMenuString_SmallPlates = """
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

  _subMenuString_LargePlates = """
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

  _volumeMenuStringPP = """
  THE PEARL OF GREAT PRICE
  Select book:
  0. (Go Back)
  1. Moses
  2. Abraham
  3. JST-Matthew
  4. Joseph Smith History
  5. Articles of Faith
  """,

  _askForChapter = """
  Enter chapter number:
  """;

  private static string[] _volumeMenuStringsArray = {
    // First index: Volume
    "Exiting Program",
    _volumeMenuStringOT,
    _volumeMenuStringNT,
    _volumeMenuStringBM,
    _volumeMenuStringPP,
    _askForChapter
    };
  
  private static string[][] _subMenuStringsArray = {
    // First index: Volume
    // Second index: Subsection
    // E.g. _subMenuStringsArray[2][2] -> _subMenuString_Paul
    new string[] { "" }, // It's impossible to get here with _volumeIdx of 0
    new string[] {
    _mainMenuString,
    _subMenuString_Law,
    _subMenuString_History,
    _subMenuString_Poetry,
    _subMenuString_Prophets1,
    _subMenuString_Prophets2
    },
    new string[] {
    _mainMenuString,
    _subMenuString_Gospels,
    _subMenuString_Paul,
    _subMenuString_Epistles
    },
    new string[] {
    _mainMenuString,
    _subMenuString_SmallPlates,
    _subMenuString_LargePlates
    }
  };
  private static string[][][] _bookTitlesArray = {
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
        _volumeMenuStringOT,
        "Genesis",
        "Exodus",
        "Leviticus",
        "Numbers",
        "Deuteronomy"
      },
      new string [] { // History
        _volumeMenuStringOT,
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
        _volumeMenuStringOT,
        "Job",
        "Psalms",
        "Proverbs",
        "Ecclesiastes",
        "Song of Solomon"
      },
      new string [] { // Prophets1
        _volumeMenuStringOT,
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
        _volumeMenuStringOT,
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
        _volumeMenuStringNT,
        "Matthew",
        "Mark",
        "Luke",
        "John",
        "Acts"
      },
      new string [] { // Paul
        _volumeMenuStringNT,
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
        _volumeMenuStringNT,
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
        _volumeMenuStringBM,
        "1 Nephi",
        "2 Nephi",
        "Jacob",
        "Enos",
        "Jarom",
        "Omni"
      },
      new string [] { // Large
        _volumeMenuStringBM,
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

  

  public static string MainMenu()
  {
    return _mainMenuString;
  }
  public static string VolumeMenu(int inputVolumeIdx)
  {
    _volumeIdx = inputVolumeIdx;
    return _volumeMenuStringsArray[_volumeIdx];
  }
  
  public static string SubsectionMenu(int inputSubIndex)
  {
    _subIdx = inputSubIndex;
    return _subMenuStringsArray[_volumeIdx][_subIdx];
  }

  public static string BookTitle(int inputBookIndex)
  {
    _bookIdx = inputBookIndex;
    return _bookTitlesArray[_volumeIdx][_subIdx][_bookIdx];
  }

  public static void Reset()
  {
    _volumeIdx = 0;
    _subIdx = 0;
    _bookIdx = 0;
  }

}