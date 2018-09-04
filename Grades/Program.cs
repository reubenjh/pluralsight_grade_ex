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
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello, this is a grade book program");

            Gradebook book = new Gradebook();

            book.NameChanged += new NameChangedDelegate(OnNameChanged);
            book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            book.Name = "Reuben's bookiewook";

            book.AddGrade(91f);
            book.AddGrade(89.5f);
            book.AddGrade(75f);

            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }

        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Gradebook changing name from {existingName} to {newName}");
        }

        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("***");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }
    }
}
