using AgendaMais.Domain.Entities;
using AgendaMais.Domain.Interfaces;
using AgendaMais.Infra.Context;

namespace AgendaMais.Infra.Repositories
{
    public class ConsultaRepository : RepositoryBase<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
