using AgendaMais.Application.Interfaces;
using AgendaMais.Domain.Interfaces;

namespace AgendaMais.Application.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        //Repository Injection
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _repository.CreateAsync(entity);
        }

        public async Task DeleteASync(TEntity entity)
        {
            await _repository.DeleteASync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
           return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
