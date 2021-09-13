using AutoMapper;
using PruebaTecnicaDeloimBackend.Domain.Dtos;
using PruebaTecnicaDeloimBackend.Domain.Interfaces;
using PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.Entities;
using PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaDeloimBackend.Domain.Services
{
    public class AfiliadoService : IAfiliadoService
    {
        private readonly IRepository<Afiliado> _repository;

        public AfiliadoService(IRepository<Afiliado> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<AfiliadoDto> GetByIdAsync(int id)
        {
            var result = await _repository.FirstOrDefaultAsync(x => x.AfiliadoID == id).ConfigureAwait(false);
            return Mapper.Map<AfiliadoDto>(result);
        }

        public async Task<IEnumerable<AfiliadoDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true)
        {
            var result = await _repository.GetAllAsync(page, limit, orderBy, ascending).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<AfiliadoDto>>(result);
        }

        public (bool status, int id) Post(AfiliadoDto entity)
        {
            var obj = Mapper.Map<Afiliado>(entity);
            var result = _repository.Insert(obj);
            return (result, obj.AfiliadoID);
        }

        public async Task<bool> PutAsync(int id, AfiliadoDto entity)
        {
            var existingEntity = await _repository.FirstOrDefaultAsync(x => x.AfiliadoID == id).ConfigureAwait(false);
            if (existingEntity is null) return false;

            Mapper.Map(entity, existingEntity);
            return _repository.Update(existingEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingEntity = await _repository.FirstOrDefaultAsync(x => x.AfiliadoID == id).ConfigureAwait(false);
            if (existingEntity is null) return false;
            return _repository.Delete(existingEntity);
        }
    }
}
