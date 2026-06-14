public static class Support
{
  public static void Clear()
  {
    Console.Clear();
    Console.Write("\x1b[3J");
  }

  public static int GetUserInt(string Prompt)
  {
    int returnValue = 0;
    bool flag = true;
    while (flag)
    {
      try
      {
        Console.WriteLine(Prompt);
        string userInputStr = Console.ReadLine();
        returnValue = int.Parse(userInputStr);
        flag = false;
      } catch (Exception e) {
        Console.WriteLine($"An error occurred: {e}\nPlease type an integer");
      }
    }
    return returnValue;
  }

  public static float GetUserFlt(string Prompt)
  {
    float returnValue = 0;
    bool flag = true;
    while (flag)
    {
      try
      {
        Console.WriteLine(Prompt);
        string userInputStr = Console.ReadLine();
        returnValue = float.Parse(userInputStr);
        flag = false;
      } catch (Exception e) {
        Console.WriteLine($"An error occurred: {e}\nPlease type a number");
      }
    }
    return returnValue;
  }

  static string GetUserStr(string Prompt)
  {
    string returnValue = "";
    bool flag = true;
    while (flag)
    {
      try
      {
        Console.WriteLine(Prompt);
        returnValue = Console.ReadLine();
        if (string.IsNullOrEmpty(returnValue)==true)
        {
          throw new Exception();
        }
        flag = false;
      } catch (Exception e) {
        Console.WriteLine($"An error occurred: {e}");
      }
    }
    return returnValue;
  }
}