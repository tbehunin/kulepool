using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SISSync;

namespace SISSync.IntegrationTests
{
    [TestClass]
    public class DistrictServiceTests
    {
        [TestMethod]
        public void CanRetrieveSchoolDistrictDataFromSIS()
        {
            var districtSvc = new DistrictService();
            var data = districtSvc.Get("DEMO_TOKEN");
            Assert.IsNotNull(data);
        }
    }
}
