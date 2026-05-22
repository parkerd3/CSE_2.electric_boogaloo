public static class Menu
{

  private static string _standardWorks,
    _booksOT,
    _OTLaw,
    _OTHistory,
    _OTPoetry,
    _OTProphets1,
    _OTProphets2,
    _booksNT,
    _NTGospels,
    _NTPaul,
    _NTEpistles,
    _booksBM,
    _BMSmall,
    _BMLarge,
    _booksPP
    ;

  static Menu()
  {
    _standardWorks = """
      Choose a volume (Enter a number 0-5):
      0. (Quit)
      1. Old Testament
      2. New Testament
      3. Book of Mormon
      4. Pearl of Great Price
      5. Doctrine and Covenants
    """;

    _booksOT = """
      Choose a subsection:
         [Section]            [From] >> [To]
      0. (Go Back)
      1. The Law            | Genesis   Deuteronomy
      2. History            | Joshua    Esther
      3. Poetry             | Job       Song of Solomon
      4. The Prophets (1/2) | Isaiah    Obadiah
      5. The Prophets (2/2) | Jonah     Malachi
    """;

    _OTLaw = """
      Select book:
      0. (Go Back)
      1. Genesis
      2. Exodus
      3. Leviticus
      4. Numbers
      5. Deuteronomy
    """;

    _OTHistory = """
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

    _OTPoetry = """
      Select book:
      0. (Go Back)
      1. Job
      2. Psalms
      3. Proverbs
      4. Ecclesiastes
      5. Song of Solomon
    """;

    _OTProphets1 = """
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

    _OTProphets2 = """
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

    _booksNT = """
      Choose a subsection:
         [Section]            [From] >> [To]
      0. (Go Back)
      1. The Gospels +      | Matthew   Acts
      2. Pauline Epistles   | Romans    Philemon
      3. General Epistles + | Hebrews   Revelation
    """;

    _NTGospels = """
      Select book:
      0. (Go Back)
      1. Matthew
      2. Mark
      3. Luke
      4. John
      5. Acts
    """;

    _NTPaul = """
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
    """;
    // Dadgum Paul was a yapper.

    _NTEpistles = """
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

    _booksBM = """
      Choose a subsection:
         [Section]                [From]     >>     [To]
      0. (Go Back)
      1. Small Plates of Nephi  | 1 Nephi           Omni
      2. Mormon's Abridgement   | Words of Mormon   Moroni
    """;

    _BMSmall = """
      Select book:
      0. (Go Back)
      1. 1 Nephi
      2. 2 Nephi
      3. Jacob
      4. Enos
      5. Jarom
      6. Omni
    """;

    _BMLarge = """
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
  }

  // public static string Main()
  // {
    
  // }

}