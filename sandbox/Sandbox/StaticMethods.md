# Static Methods

## Getting User Inputs

### Integers

```csharp
static int GetUserInputInteger(string Prompt)
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
      Console.WriteLine($"An error occurred: {e}\nPlease type an integer")
    }
  }
  return returnValue;
}
```

### Floats

```csharp
static float GetUserInputFloat(string Prompt)
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
      Console.WriteLine($"An error occurred: {e}\nPlease type a number")
    }
  }
}
```

### Strings

```csharp
static string GetUserInputString(string Prompt)
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
      Console.WriteLine($"An error occurred: {e}")
    }
  }
  return returnValue;
}
