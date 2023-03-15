using AutoMapper;
using OFOP.API.DTO;
using OFOP.Entity.Models;

namespace OFOP.API
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel,User>();
            


        }
    }
}
