            using AgendaMais.Application.Interfaces;
using AgendaMais.Domain.Entities;
using AgendaMais.Domain.Interfaces;

namespace AgendaMais.Application.Services
{
    public class ConsultaService : ServiceBase<Consulta>, IConsultaService
    {
        public ConsultaService(IConsultaRepository repository) : base(repository)
        {
        }
    }
}
