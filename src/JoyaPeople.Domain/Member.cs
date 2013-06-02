using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace JoyaPeople.Domain
{
    public class Member
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Address Address { get; set; }
        public List<string> EmailAddresses { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string Notes { get; set; }
    }

    public class Address
    {
        public String StreetAddress { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string Zip { get; set; }
    }
}
