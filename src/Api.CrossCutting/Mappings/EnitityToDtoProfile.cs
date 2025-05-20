using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EnitityToDtoProfile : Profile
    {
        public EnitityToDtoProfile()
        {
            #region  USER
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();
            #endregion

            #region UF
            CreateMap<UfDto, UfEntity>()
               .ReverseMap();
            #endregion

            #region MUNICIPIO
            CreateMap<MunicipioDto, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDtoCompleto, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDtoCreateResult, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDtoUpdateResult, MunicipioEntity>()
                .ReverseMap();

            //COMPLETO
            #endregion

            #region CEP
            CreateMap<CepDto, CEPEntity>()
                .ReverseMap();

            CreateMap<CepDtoCreateResult, CEPEntity>()
                .ReverseMap();

            CreateMap<CepDtoUpdateResult, CEPEntity>()
                .ReverseMap();
            #endregion

        }
    }
}
