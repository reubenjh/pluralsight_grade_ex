using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.tests.Types
{
    [TestClass]
    public class TypeTests
    {

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);
            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "jeff";
            name = name.ToUpper();

            Assert.AreEqual("JEFF", name);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(ref x);
            Assert.AreEqual(47, x);
        }

        private void IncrementNumber(ref int num)
        {
            num += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            Gradebook g1 = new Gradebook();
            Gradebook g2 = g1;

            GiveBookAName(ref g2);
            Assert.AreEqual("A testy name", g2.Name);

        }

        private void GiveBookAName(ref Gradebook book)
        {
            book = new Gradebook();
            book.Name = "A testy name";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Jeff";
            string name2 = "jeff";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GradebookVariablesHoldAReference()
        {
            Gradebook g1 = new Gradebook();
            Gradebook g2 = g1;

            g1.Name = "Potatocake";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
