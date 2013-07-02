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
            Id = ObjectId.Empty;
            Address = new AddressEditVM();
            EmailAddresses = new List<string>();
            PhoneNumbers = new List<string>();
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
}