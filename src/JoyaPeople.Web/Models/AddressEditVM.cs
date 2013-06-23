using System;
using JoyaPeople.Domain;

namespace JoyaPeople.Web.Models
{
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

        public Address ToAddress()
        {
            return new Address
                {
                    StreetAddress = this.StreetAddress,
                    City=this.City,
                    StateCode = this.StateCode,
                    Zip = this.Zip
                };
        }
    }
}