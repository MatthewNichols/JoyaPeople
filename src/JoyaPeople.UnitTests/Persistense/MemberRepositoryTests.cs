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
    }
}
