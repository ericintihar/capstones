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
    public class ChangeTests
    {
        [TestMethod()]
        public void MakeChangeTest()
        {
            Change c = new Change();
            Assert.AreEqual("Your change is 7 quarters 1 dime 1 nickle ", c.MakeChange(190));
        }
    }
}