using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.UnitTests.UtilityTests
{
    public class TestBase
    {
        protected TestObjectFactory testObjects;

        public TestBase()
        {
            testObjects = new TestObjectFactory();
        }
    }
}
