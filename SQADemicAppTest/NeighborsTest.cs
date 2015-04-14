using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQAdemicApp;


namespace SQADemicAppTest
{
    [TestClass]
    class NeighborsTest
    {

        [TestMethod]
        public void TestSettingAndGettingAdjacentCities1()
        {
            StringReader r = new StringReader("San Francisco;Tokyo,Manila,Chicago,Los Angeles");
            Create create = new Create();
            create.setAdjacentCities(r);
            List<string> result = create.getAdjacentCities("Tokyo");
            List<string> expected = new List<string>();
            expected.Add("San Francisco");
            Assert.AreEqual(result, expected);
        }
    }
}
