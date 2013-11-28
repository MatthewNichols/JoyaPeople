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
    /// Creates test records in the JoyaPeople database.  Not really a unit test; just using the convenience of a unit 
    /// test to package what is effectivly a script.
    /// </summary>
    [Explicit]
    [TestFixture]
    public class TestRecords
    {
        private const string UnitTestConnectionString = "mongodb://localhost/joyapeople";

        [Test]
        public void AddTestRecords()
        {
            var memberRepository = new MemberRepository(UnitTestConnectionString);

            var membersToInsert = new List<Member>
                {

                    new Member
                        {
                            FirstName = "Adam",
                            LastName = "Smith",
                            Address = new Address
                                {
                                    StreetAddress = "123 First St",
                                    City = "Denver",
                                    StateCode = "CO",
                                    Zip = "80242"
                                }
                        },
                        new Member
                        {
                            FirstName = "Bill",
                            LastName = "Jones",
                        },
                        new Member
                        {
                            FirstName = "Bo",
                            LastName = "Jangles",
                            Address = new Address
                                {
                                    StreetAddress = "234 Second St",
                                    City = "Denver",
                                    StateCode = "CO",
                                    Zip = "80242"
                                }
                        }
                };

            foreach (var member in membersToInsert)
            {
                memberRepository.Save(member);
            }
        }
    }
}
