using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoyaPeople.Domain;
using MongoDB.Bson;

namespace JoyaPeople.Web.Models
{
    public class MemberAddEditVM
    {
        public MemberAddEditVM()
        {
            Address=new AddressEditVM();
            EmailAddresses = new List<string>();
            PhoneNumbers = new List<string>();
        }

        public MemberAddEditVM(Member member)
        {
            Id = member.Id;
            FirstName = member.FirstName;
            LastName = member.LastName;
            MiddleName = member.MiddleName;
            Address=new AddressEditVM(member.Address);
            EmailAddresses = member.EmailAddresses;
            PhoneNumbers = member.PhoneNumbers;
            Notes = member.Notes;

        }

        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public AddressEditVM Address { get; set; }
        public List<string> EmailAddresses { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string Notes { get; set; }
    }

    public class AddressEditVM
    {
        public AddressEditVM()
        { }

        public AddressEditVM(Address address)
        {
            StreetAddress = address.StreetAddress;
            City = address.City;
            StateCode = address.StateCode;
            Zip = address.Zip;
        }

        public String StreetAddress { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string Zip { get; set; }
    }
}
