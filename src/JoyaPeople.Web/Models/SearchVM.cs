using System.Collections.Generic;

namespace JoyaPeople.Web.Models
{
    public class SearchVM
    {
        public SearchVM()
        {
            FoundMembers = new List<MemberDisplayVM>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<MemberDisplayVM> FoundMembers { get; set; }
    }
}