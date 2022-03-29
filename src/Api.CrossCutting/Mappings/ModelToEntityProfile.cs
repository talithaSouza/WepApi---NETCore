using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>()
                .ReverseMap();

            CreateMap<UfEntity, UfModel>()
                .ReverseMap();

            CreateMap<MunicipioEntity, MunicipioModel>()
                .ReverseMap();

            CreateMap<CEPEntity, CepModel>()
                .ReverseMap();
        }
    }
}
