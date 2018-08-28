using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello, this is a grade book program");

            Gradebook book = new Gradebook();
            book.AddGrade(91f);
            book.AddGrade(89.5f);
            book.AddGrade(75f);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine("Average grade: ");
            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine("Highest grade: ");
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine("Lowest grade: ");
            Console.WriteLine(stats.LowestGrade);
        }
    }
}
