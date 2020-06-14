using AutoMapper;
using ManageUsersApi.Dtos;
using ManageUsersApi.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source -> Target
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<UserCreateDto, User>().ReverseMap();           
            CreateMap<AccountCreateDto, Account>().ReverseMap();
            CreateMap<AccountReadDto, Account>().ReverseMap();
            
        }

    }
    
}