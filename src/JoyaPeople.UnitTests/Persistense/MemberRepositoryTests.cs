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
    [TestFixture]
    public class MemberRepositoryTests
    {
        [Test]
        public void SaveTest_HappyPath()
        {
            var member = new Member
                {
                    FirstName = "John", 
                    LastName = "Smith"
                };

            var memberRepository = new MemberRepository();

            memberRepository.Save(member);
        }

        [Test]
        [Explicit]
        public void AddTestRecords()
        {
            var memberRepository = new MemberRepository();

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
