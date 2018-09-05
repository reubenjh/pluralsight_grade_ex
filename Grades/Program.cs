using System;
using System.Collections.Generic;
using System.IO;
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
            Welcome();

            Gradebook book = new Gradebook();
            GetBookName(book);

            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        //

        private static void WriteResults(Gradebook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
            WriteResult("Description", stats.Description);
        }

        private static void SaveGrades(Gradebook book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(Gradebook book)
        {
            book.AddGrade(91f);
            book.AddGrade(89.5f);
            book.AddGrade(75f);
        }

        private static void Welcome()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello, this is a grade book program");
        }

        private static void GetBookName(Gradebook book)
        {
            book.NameChanged += OnNameChange;

            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void OnNameChange(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Name changed from {args.ExistingName} to {args.NewName}");
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
