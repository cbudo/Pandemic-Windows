using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQADemicApp.BL;

namespace SQADemicAppTest
{
    [TestClass]
    public class InfectorTest
    {
        [TestMethod]
        public void TestInfectCities()
        {
            InfectorBL.InfectCities();
        }
    }
}
