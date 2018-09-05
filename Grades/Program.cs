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

            book.AddGrade(91f);
            book.AddGrade(89.5f);
            book.AddGrade(75f);

            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description }: {result:F2}");
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description }: {result}");
        }
    }
}
