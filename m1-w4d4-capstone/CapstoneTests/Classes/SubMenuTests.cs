using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes.Tests
{
    [TestClass()]
    public class SubMenuTests
    {
        [TestMethod()]
        public void DisplayTest_SubMenu()
        {
            Dictionary<string, Product> testDictionary = new Dictionary<string, Product>();
            Product testProduct1 = new Product();

            testDictionary.Add("A1", new Product());
            testDictionary.Add("A2", new Product());
            testDictionary.Add("A3", new Product());
            VendingMachine test = new VendingMachine(testDictionary);
            test.FeedMoney(5);

            Assert.AreEqual(5.00, test.Balance);
        }
    }
}