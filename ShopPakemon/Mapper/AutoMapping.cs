using DTO;
using EntityForDatabase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ShopPakemon.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
