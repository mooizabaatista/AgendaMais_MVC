using AgendaMais.Application.Interfaces;
using AgendaMais.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendaMais.WebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConsultaService _service;
        private readonly IProfissionalService _profissionaisService;

        public HomeController(IConsultaService service, IProfissionalService profissionaisService)
        {
            _service = service;
            _profissionaisService = profissionaisService;
        }


        //Pagina inicial com o Fullcalendar
        public async Task<IActionResult> Index()
        {
            ViewBag.Profissionais = new SelectList(await _profissionaisService.GetAllAsync(), "Id", "Nome");

            ViewBag.ConsultasDeHoje = _service.GetAllAsync().Result.Where(x => x.Start.Day == DateTime.Now.Day).Where(x => x.Finished == false);

            return View();
        }


        //Relatório Geral
        public async Task<IActionResult> RelatorioGeral()
        {
            var consultas = await _service.GetAllAsync();
            return View(consultas);
        }


        // Todas as consultas convertidas para JSON para consumo do FullCalendar
        [HttpGet]
        public IActionResult TodasAsConsultasJson()
        {
            IEnumerable<Consulta> events = _service.GetAllAsync().Result.Where(x => x.Finished == false);
            return Json(events);
        }
    }
}