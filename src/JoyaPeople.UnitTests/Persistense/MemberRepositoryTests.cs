using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoyaPeople.Domain;
using JoyaPeople.Persistence.Repositories;
using NUnit.Framework;

namespace JoyaPeople.UnitTests.Persistense
{
    /// <summary>
    /// Persistense Unit tests using a disposible database.  Will be cleaned out after each test.
    /// </summary>
    [TestFixture]
    public class MemberRepositoryTests
    {
        /// <summary>
        /// Connection string to a disposable database for the tests.  Will be cleaned out after each test.
        /// </summary>
        private const string UnitTestConnectionString = "mongodb://localhost/joyapeopleunittests";

        [TestFixtureTearDown]
        public void CleanUp()
        {
            var memberRepository = new MemberRepository(UnitTestConnectionString);
            memberRepository.GetMongoCollection().Drop();
        }

        [Test]
        public void SaveTest_HappyPath_SingleInsert()
        {
            const string firstNameString = "John";
            const string lastNameString = "Smith";

            var member = new Member
                {
                    FirstName = firstNameString, 
                    LastName = lastNameString
                };

            var memberRepository = new MemberRepository(UnitTestConnectionString);

            memberRepository.Save(member);

            var membersByName = memberRepository.SearchByName(firstNameString, lastNameString);

            Assert.IsNotNull(membersByName);
            Assert.AreEqual(1, membersByName.Count);

            var retrivedMember = membersByName.Single();

            Assert.AreEqual(firstNameString, retrivedMember.FirstName);
            Assert.AreEqual(lastNameString, retrivedMember.LastName);
        }

        //Clearly more tests down here would be good
    }
}
