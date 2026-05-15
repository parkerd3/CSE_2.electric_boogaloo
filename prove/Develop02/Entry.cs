public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;
    // Spacer for saving entries.
    private string s = "~|~";

    /// <summary>
    /// Return a string formatted to display the date, prompt, and
    /// response of an entry.
    /// </summary>
    /// <returns></returns>
    public pverride string ToString()
    {
        return _date + $" |(Prompt: {_prompt})\n" +
        _response;
    }

    public override string Write()
    {
        return _date+s+_prompt+s+_response;
    }
}