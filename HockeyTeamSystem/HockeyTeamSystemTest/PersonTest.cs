using Microsoft.VisualStudio.TestTools.UnitTesting;
using HockeyTeamSystem;
using System;

namespace HockeyTeamSystemTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        [DataRow("Connor McDavid")]
        [DataRow("Ryan Nugent-Hopkins")]
        public void FullName_ValidValue_NoErrors(string fullname)
        {
            Person person1 = new Person(fullname);
            Assert.AreEqual(fullname, person1.FullName);

        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("     \n\t")]
        public void FullName_NoName_ThrowException(string fullname)
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Person person1 = new Person(fullname);
            });
            Assert.IsNotNull(exception);
            //Assert.AreEqual("FullName", exception.ParamName);
            //Assert.IsTrue(exception.Message.Contains("FullName is required"));
            Assert.AreEqual("Person FullName is required.", exception.ParamName);
        }

        [TestMethod]
        [DataRow("A")]
        [DataRow("AB")]
        [DataRow("A B")]
        public void FullName_InvalidNameLength_ThrowException(string fullname)
        {
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Person person1 = new Person(fullname);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual("Person FullName must contain at least 5 characters.", exception.Message);
        }

        


    }
}