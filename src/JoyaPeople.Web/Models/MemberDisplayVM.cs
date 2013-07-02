using System.Collections.Generic;
using MongoDB.Bson;

namespace JoyaPeople.Web.Models
{
    public class MemberDisplayVM
    {   
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
     
        //These look a little funny now but the address properties are named the 
        // way they are to allow AutoMapper to automatically flatten them from 
        // the nested domain object
        public string AddressStreetAddress { get; set; }
        public string AddressCity { get; set; }
        public string AddressStateCode { get; set; }
        public string AddressZip { get; set; }

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
                           string.IsNullOrWhiteSpace(AddressStreetAddress) &&
                           string.IsNullOrWhiteSpace(AddressCity) &&
                           string.IsNullOrWhiteSpace(AddressStateCode) &&
                           string.IsNullOrWhiteSpace(AddressZip)
                       );
            }
        }
    }
}