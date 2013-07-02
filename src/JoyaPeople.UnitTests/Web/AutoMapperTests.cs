using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JoyaPeople.Web.App_Start;
using NUnit.Framework;

namespace JoyaPeople.UnitTests.Web
{
    [TestFixture]
    public class AutoMapperTests
    {
        [Test]
        public void TestAddressMaps()
        {
            AutoMapperConfig.Config();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
