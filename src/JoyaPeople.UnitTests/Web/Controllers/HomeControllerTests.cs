using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using JoyaPeople.Domain;
using JoyaPeople.Domain.Interfaces;
using JoyaPeople.Web.Controllers;
using JoyaPeople.Web.Models;
using Moq;
using NUnit.Framework;

namespace JoyaPeople.UnitTests.Web.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_NoInput_RecordsReturned()
        {
            var testData = new List<Member>
                {
                    new Member {FirstName = "Bill", LastName = "Smith"}, 
                    new Member {FirstName = "Jim", LastName = "Johnson"}
                };

            var mockRepos = new Mock<IMemberRepository>();            
            mockRepos.Setup(r => r.SearchByName(It.IsAny<string>(), It.IsAny<string>()))
                     .Returns(testData);

            var controller = new HomeController(mockRepos.Object);

            var viewResult = controller.Index(new SearchVM()) as ViewResult;

            Assert.IsNotNull(viewResult, "View Result");
            Assert.IsNotNull(viewResult.Model, "Model");

            var vm = viewResult.Model as SearchVM;

            Assert.AreEqual(testData.Count(), vm.FoundMembers.Count());
            foreach (var member in testData)
            {
                Assert.IsNotNull(vm.FoundMembers.Single(m => m.FirstName == member.FirstName && m.LastName == m.LastName));
            }
        }

        [Test]
        public void Index_NoInput_NoRecordsReturned()
        {
            var testData = new List<Member>();

            var mockRepos = new Mock<IMemberRepository>();
            mockRepos.Setup(r => r.SearchByName(It.IsAny<string>(), It.IsAny<string>()))
                     .Returns(testData);

            var controller = new HomeController(mockRepos.Object);

            var viewResult = controller.Index(new SearchVM()) as ViewResult;

            Assert.IsNotNull(viewResult, "View Result");
            Assert.IsNotNull(viewResult.Model, "Model");

            var vm = viewResult.Model as SearchVM;

            Assert.AreEqual(testData.Count(), vm.FoundMembers.Count());
            foreach (var member in testData)
            {
                Assert.IsNotNull(vm.FoundMembers.Single(m => m.FirstName == member.FirstName && m.LastName == m.LastName));
            }
        }
    }
}
