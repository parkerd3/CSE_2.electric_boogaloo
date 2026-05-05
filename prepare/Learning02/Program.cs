using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning02 World!");
        
        Job job1 = new Job();
        job1._job_title = "Software Engineer";
        job1._company = "Tesla";
        job1._start_year = "2019";
        job1._end_year = "2023";
        
        Job job2 = new Job();
        job2._job_title = "Big kahuna inspector";
        job2._company = "Swax";
        job2._start_year = "2023";
        job2._end_year = "present";

        // job1.Display_Summary();
        // job2.Display_Summary();

        Resume my_resume = new Resume();
        my_resume._name = "Dawn Joe";
        my_resume._jobs.Add(job1);
        my_resume._jobs.Add(job2);

        my_resume.Print_Resume();
    }
}

