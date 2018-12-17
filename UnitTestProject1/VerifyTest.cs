using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApplication.Functions;
using MyApplication.Models;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class VerifyTest
    {
        [TestMethod]
        public void TestOK()
        {
            //Arrange
            var id = 0;
            var age = "0-17";
            var student = "Yes";
            var income = "0";
            string productName = "Junior Saver Account";

            //Act
            Products product = new Products(0, productName);
            List<Products> products = new List<Products>();
            products.Add(product);
            WantedBundle wantedBundle = new WantedBundle(id, age, student, income, products);
            string returnCode = Verify.CheckValidity(wantedBundle);

            //Assert
            Assert.AreEqual(returnCode, "No reason");
        }

        [TestMethod]
        public void TestTooManyAccounts()
        {
            //Arrange
            var id = 0;
            var age = "0-17";
            var student = "Yes";
            var income = "0";
            string productName1 = "Junior Saver Account";
            string productName2 = "Customer Account";

            //Act
            Products product1 = new Products(0, productName1);
            Products product2 = new Products(0, productName2);
            List<Products> products = new List<Products>();
            products.Add(product1);
            products.Add(product2);
            WantedBundle wantedBundle = new WantedBundle(id, age, student, income, products);
            string returnCode = Verify.CheckValidity(wantedBundle);

            //Assert
            Assert.AreEqual(returnCode, "Bundle cannot contain more than one account");
        }

        [TestMethod]
        public void TestTooOldForJunior()
        {
            //Arrange
            var id = 0;
            var age = "18-64";
            var student = "Yes";
            var income = "0";
            string productName = "Junior Saver Account";

            //Act
            Products product = new Products(0, productName);
            List<Products> products = new List<Products>();
            products.Add(product);
            WantedBundle wantedBundle = new WantedBundle(id, age, student, income, products);
            string returnCode = Verify.CheckValidity(wantedBundle);

            //Assert
            Assert.AreEqual(returnCode, "Only people younger than 18 years old are eligible for Junior Saver Account");
        }
    }
}
