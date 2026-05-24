using System.ComponentModel;

public static class Menu
{
  private static int chapter = 0;

  private static string _volumes,
    _subOT,
    _booksOTLaw,
    _booksOTHistory,
    _booksOTPoetry,
    _booksOTProphets1,
    _booksOTProphets2,
    _subNT,
    _booksNTGospels,
    _booksNTPaul,
    _booksNTEpistles,
    _subBM,
    _booksBMSmall,
    _booksBMLarge,
    _booksPP,
    _askForChapter
    ;
  private static string[] _mainMenu = {
    // Where each number in the Main menu will take you:
    "Exiting Program",
    _subOT,
    _subNT,
    _subBM,
    _booksPP,
    _askForChapter
    },
    _OTSubmenu = {
    _volumes,
    _booksOTLaw,
    _booksOTHistory,
    _booksOTPoetry,
    _booksOTProphets1,
    _booksOTProphets2
    },
    _NTSubmenu = {
    _volumes,
    _booksNTGospels,
    _booksNTPaul,
    _booksNTEpistles
    },
    _BMSubmenu = {
    _volumes,
    _booksBMSmall,
    _booksBMLarge
    }
    ;
  private static string[][] _subsections = {
    new string[] {
    // Usually the 0 index will always take you up a level, so there would be no
    // way for a zero to be input here. But throwing a garbage array here will
    // make it so that our arrays with indices >=1 are accessible.
    "If you're seeing this the program is broken."
    },
    new string[] {
      _subOT,
      
    },
    new string[] {
      _subNT
    },
    new string[] {
      _subBM
    },

  };

  static Menu()
  {
    // Assigning values in this constructor to keep the above definitions clean.
    _volumes = """
      Choose a volume (Enter a number 0-5):
      0. (Quit)
      1. Old Testament
      2. New Testament
      3. Book of Mormon
      4. Pearl of Great Price
      5. Doctrine and Covenants
    """;

    _subOT = """
      Choose a subsection:
         [Section]            [From] >> [To]
      0. (Go Back)
      1. The Law            | Genesis   Deuteronomy
      2. History            | Joshua    Esther
      3. Poetry             | Job       Song of Solomon
      4. The Prophets (1/2) | Isaiah    Obadiah
      5. The Prophets (2/2) | Jonah     Malachi
    """;

    _booksOTLaw = """
      Select book:
      0. (Go Back)
      1. Genesis
      2. Exodus
      3. Leviticus
      4. Numbers
      5. Deuteronomy
    """;

    _booksOTHistory = """
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
    """;

    _booksOTPoetry = """
      Select book:
      0. (Go Back)
      1. Job
      2. Psalms
      3. Proverbs
      4. Ecclesiastes
      5. Song of Solomon
    """;

    _booksOTProphets1 = """
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
    """;

    _booksOTProphets2 = """
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
    """;

    _subNT = """
      Choose a subsection:
         [Section]            [From] >> [To]
      0. (Go Back)
      1. The Gospels +      | Matthew   Acts
      2. Pauline Epistles   | Romans    Philemon
      3. General Epistles + | Hebrews   Revelation
    """;

    _booksNTGospels = """
      Select book:
      0. (Go Back)
      1. Matthew
      2. Mark
      3. Luke
      4. John
      5. Acts
    """;

    _booksNTPaul = """
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
    """; // Dadgum Paul was a yapper.

    _booksNTEpistles = """
      Select book:
      0. (Go Back)
      1. Hebrews
      2. James
      3. 1 Peter
      4. 2 Peter
      5. 1 John
      6. 2 John
      7. 3 John
      8. Jude
      9. Revelation
    """;

    _subBM = """
      Choose a subsection:
         [Section]                [From]     >>     [To]
      0. (Go Back)
      1. Small Plates of Nephi  | 1 Nephi           Omni
      2. Mormon's Abridgement   | Words of Mormon   Moroni
    """;

    _booksBMSmall = """
      Select book:
      0. (Go Back)
      1. 1 Nephi
      2. 2 Nephi
      3. Jacob
      4. Enos
      5. Jarom
      6. Omni
    """;

    _booksBMLarge = """
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
    """;

    _booksPP = """
      Select book:
      0. (Go Back)
      1. Moses
      2. Abraham
      3. JST-Matthew
      4. Joseph Smith History
      5. Articles of Faith
    """;

    _askForChapter = """
      Enter chapter number:
    """;
  }

  public static string Volumes()
  {
    return _volumes;
  }
  public static string Subsection(int volume)
  {
    return _mainMenu[volume];
  }
  /// <summary>
  /// Return the list of books to choose from based on volume -> subsection.
  /// </summary>
  /// <returns>String</returns>
  public static string Books(int volume, int sub)
  {
    return 
  }

}