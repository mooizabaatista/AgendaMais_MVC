using AgendaMais.Application.Interfaces;
using AgendaMais.Domain.Entities;
using AgendaMais.Domain.Interfaces;

namespace AgendaMais.Application.Services
{
    public class ProfissionalService : ServiceBase<Profissional>, IProfissionalService
    {
        public ProfissionalService(IProfissionalRepository repository) : base(repository)
        {
        }
    }
}
