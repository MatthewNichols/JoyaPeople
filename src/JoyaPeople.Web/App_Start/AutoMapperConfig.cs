using AutoMapper;
using JoyaPeople.Domain;
using JoyaPeople.Web.Models;

namespace JoyaPeople.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Config()
        {
            var memberDisplayVMMap = Mapper.CreateMap<Member, MemberDisplayVM>();
            //memberDisplayVMMap.ForAllMembers(opt => opt.NullSubstitute(""));
            //memberDisplayVMMap.ForMember(dest => dest.)

            Mapper.CreateMap<Member, MemberAddEditVM>();
            Mapper.CreateMap<MemberAddEditVM, Member>();
            
            Mapper.CreateMap<Address, AddressEditVM>();
            Mapper.CreateMap<AddressEditVM, Address>();
        }
    }
}