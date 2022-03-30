using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Intereface.Services.Municipio;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class MunicipioService : IMunicipioservice
    {
        private readonly IMunicipioRepository _repository;
        private readonly IMapper _mapper;

        public MunicipioService(IMunicipioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<MunicipioDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<MunicipioDto>(entity);
        }

        public async Task<IEnumerable<MunicipioDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<MunicipioDto>>(listEntity);
        }

        public async Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIBGE)
        {
            var entity = await _repository.GetCompleteByIBGE(codIBGE);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<MunicipioDtoCompleto> GetCompleteById(Guid Id)
        {
            var entity = await _repository.GetCompleteById(Id);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio)
        {
            //DTOCREATE => MODEL
            var municipioModel = _mapper.Map<MunicipioModel>(municipio);
            //MODEL => ENTITY
            var municipioEntity = _mapper.Map<MunicipioEntity>(municipioModel);

            var result = await _repository.InsertAsync(municipioEntity);
            return _mapper.Map<MunicipioDtoCreateResult>(result);
        }

        public async Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio)
        {
            //DTOUPDATE => MODEL
            var municipioModel = _mapper.Map<MunicipioModel>(municipio);
            //MODEL => ENTITY
            var municipioEntity = _mapper.Map<MunicipioEntity>(municipioModel);

            var result = await _repository.UpdateAsync(municipioEntity);
            return _mapper.Map<MunicipioDtoUpdateResult>(result);
        }
    }
}
