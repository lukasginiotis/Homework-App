using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApplication.Functions;
using MyApplication.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class GetBundleTest
    {
        [TestMethod]
        public void TestJunior()
        {
            //Arrange
            var id = 0;
            var age = "0-17";
            var student = "Yes";
            var income = "0";

            //Act
            Answers answers = new Answers(id, age, student, income);
            Bundle bundle = GetBundle.ReturnBundle(answers);

            //Assert
            Assert.AreEqual(bundle.Name, "Junior Saver");
        }

        [TestMethod]
        public void TestGold()
        {
            //Arrange
            var id = 0;
            var age = "18-64";
            var student = "Yes";
            var income = "40001+";

            //Act
            Answers answers = new Answers(id, age, student, income);
            Bundle bundle = GetBundle.ReturnBundle(answers);

            //Assert
            Assert.AreEqual(bundle.Name, "Gold");
        }

        [TestMethod]
        public void TestNoBundleAvailable()
        {
            //Arrange
            var id = 0;
            var age = "18-64";
            var student = "No";
            var income = "0";

            //Act
            Answers answers = new Answers(id, age, student, income);
            Bundle bundle = GetBundle.ReturnBundle(answers);

            //Assert
            Assert.IsNull(bundle);
        }
    }
}
