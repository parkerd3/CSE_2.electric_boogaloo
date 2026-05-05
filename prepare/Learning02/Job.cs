public class Job
{
    public string _company;
    public string _job_title;
    public string _start_year;
    public string _end_year;

    public void Display_Summary()
    {
        Console.WriteLine(
            $"{_job_title} ({_company}) {_start_year}-{_end_year}"
        );
    }
}