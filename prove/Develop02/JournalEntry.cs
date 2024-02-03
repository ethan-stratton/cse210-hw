//get date, input, prompt, etc
//display it in string format
public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public JournalEntry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
    public string Display()
    {
        string displayed = @$"{Date.ToString("yyyy-MM-dd")}: {Prompt} 
        {Response}";
        return displayed;
    }
}

