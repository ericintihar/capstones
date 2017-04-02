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
    public class VendingMachineTests
    {
        [TestMethod()]
        public void VendingMachineTest_constructor()
        {
            Dictionary<string, Product> testDictionary = new Dictionary<string, Product>();
            Product testProduct1 = new Product();

            testDictionary.Add("A1", new Product());
            testDictionary.Add("A2", new Product());
            testDictionary.Add("A3", new Product());

            VendingMachine vm = new VendingMachine(testDictionary);
            CollectionAssert.AreEqual(testDictionary, vm.Inventory);
        }

        [TestMethod()]
        public void LocationExistsTest()
        {
            Dictionary<string, Product> testDictionary = new Dictionary<string, Product>();
            Product testProduct1 = new Product();

            testDictionary.Add("A1", new Product());
            testDictionary.Add("A2", new Product());
            testDictionary.Add("A3", new Product());

            VendingMachine vm = new VendingMachine(testDictionary);

            Assert.AreEqual(true, vm.LocationExists("A1"));
            Assert.AreEqual(false, vm.LocationExists("A4"));
        }
    }
}