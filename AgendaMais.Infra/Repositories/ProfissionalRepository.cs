using AgendaMais.Domain.Entities;
using AgendaMais.Domain.Interfaces;
using AgendaMais.Infra.Context;

namespace AgendaMais.Infra.Repositories
{
    public class ProfissionalRepository : RepositoryBase<Profissional>, IProfissionalRepository
    {
        public ProfissionalRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
