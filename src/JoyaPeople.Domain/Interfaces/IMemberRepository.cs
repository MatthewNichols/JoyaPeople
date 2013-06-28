using System.Collections.Generic;
using MongoDB.Bson;

namespace JoyaPeople.Domain.Interfaces
{
    public interface IMemberRepository
    {
        void Save(Member member);
        IList<Member> SearchByName(string firstNameString, string lastNameString);
        Member GetById(ObjectId id);
    }
}