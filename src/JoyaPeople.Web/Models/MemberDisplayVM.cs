using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoyaPeople.Domain;
using MongoDB.Bson;

namespace JoyaPeople.Web.Models
{
    public class MemberDisplayVM
    {
        public MemberDisplayVM(Member source)
        {
            Id = source.Id;
            FirstName = source.FirstName ?? "";
            LastName = source.LastName ?? "";
            MiddleName = source.MiddleName ?? "";

            if (source.Address != null)
            {
                StreetAddress = source.Address.StreetAddress ?? "";
                City = source.Address.City ?? "";
                StateCode = source.Address.StateCode ?? "";
                Zip = source.Address.Zip ?? "";
            }
            else
            {
                StreetAddress = "";
                City = "";
                StateCode = "";
                Zip = "";
            }
        }
        
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        
        public String StreetAddress { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string Zip { get; set; }

        public List<string> EmailAddresses { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string Notes { get; set; }

        /// <summary>
        /// Quick and easy indicator of whether to display Address info
        /// </summary>
        public bool HasAddress
        {
            get
            {
                return ! (
                           string.IsNullOrWhiteSpace(StreetAddress) &&
                           string.IsNullOrWhiteSpace(City) &&
                           string.IsNullOrWhiteSpace(StateCode) &&
                           string.IsNullOrWhiteSpace(Zip)
                       );
            }
        }
    }
}