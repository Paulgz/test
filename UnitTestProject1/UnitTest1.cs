using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConsoleApplication1;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void testSurnameSort()
        {
            string[] test1 = { "JONES, ZAK, 100", "BROWN, ZAK, 100", "SMITH, ZAK, 100" };
            List<Program.Person> people = Program.createGrades(test1);
            Assert.IsTrue(people.Count==3);
            Assert.IsTrue(people[0].surname == "BROWN");
            Assert.IsTrue(people[1].surname == "JONES");
            Assert.IsTrue(people[2].surname == "SMITH");
        }
        [TestMethod]
        public void testScoreSort()
        {
            string[] test1 = { "JONES, BOB, 100", "BROWN, IAN, 23", "ZOG, BARBARA, 47" };
            List<Program.Person> people = Program.createGrades(test1);
            Assert.IsTrue(people.Count==3);
            Assert.IsTrue(people[0].name == "BOB");
            Assert.IsTrue(people[1].name == "BARBARA");
            Assert.IsTrue(people[2].name == "IAN");
        }
        [TestMethod]
        public void testBadScoreReject()
        {
            string[] test1 = { "JONES, BOB, 100", "BROWN, IAN, 2X", "ZOG, BARBARA, 47" };
            List<Program.Person> people = Program.createGrades(test1);
            Assert.IsTrue(people==null);
        }
        [TestMethod]
        public void testBadElementCountReject()
        {
            string[] test1 = { "JONES, BOB", "BROWN, IAN, 20", "ZOG, BARBARA, 47" };
            List<Program.Person> people = Program.createGrades(test1);
            Assert.IsTrue(people==null);

            string[] test2 = { "JONES, BOB, JIM, 23", "BROWN, IAN, 23", "ZOG, BARBARA, 47" };
            people = Program.createGrades(test1);
            Assert.IsTrue(people==null);
        }
    }
}
