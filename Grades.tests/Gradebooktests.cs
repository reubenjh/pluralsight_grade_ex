using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.tests
{
    [TestClass]
    public class GradebookTests
    {
        [TestMethod]
        public void AddGrade()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(100f);

            bool isRightLength;
            if (book.grades.Count == 1) isRightLength = true;
            else isRightLength = false;

            Assert.IsTrue(isRightLength);
        }

        [TestMethod]
        public void ComputeHighestGrade ()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(10f);
            book.AddGrade(90f);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(90f, result.HighestGrade);
        }

        [TestMethod]
        public void ComputeLowestGrade()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(10f);
            book.AddGrade(90f);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(10f, result.LowestGrade);
        }

        [TestMethod]
        public void ComputeAverageGrade()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(91f);
            book.AddGrade(89.5f);
            book.AddGrade(75f);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(85.16f, result.AverageGrade, 0.01);
        }
    }
}
