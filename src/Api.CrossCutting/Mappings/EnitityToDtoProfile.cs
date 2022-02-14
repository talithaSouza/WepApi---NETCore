using Api.Domain.Dtos.User;
using Api.Domain.Intereface;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EnitityToDtoProfile : Profile
    {
        public EnitityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();


        }
    }
}
