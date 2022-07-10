using AgendaMais.Application.Interfaces;
using AgendaMais.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendaMais.WebUi.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly IConsultaService _service;
        private readonly IProfissionalService _profissionaisService;

        public ConsultasController(IProfissionalService profissionaisService, IConsultaService service)
        {
            _profissionaisService = profissionaisService;
            _service = service;
        }


        //Detalhes de uma consulta
        [HttpGet]
        public async Task<IActionResult> DetalheConsulta(int id)
        {
            var xConsulta = await _service.GetByIdAsync(id);
            ViewBag.Profissionais = new SelectList(await _profissionaisService.GetAllAsync(), "Id", "Nome");
            ViewBag.Consulta = xConsulta;
            ViewBag.ProfissionalId = xConsulta.ProfissionalId;
            return View(xConsulta);
        }

        //Cadastrar consulta
        [HttpPost]
        public async Task<IActionResult> CadastroConsulta(string title, string description, string email, DateTime dtInicio, int profissionalId)
        {
            Consulta consulta = new()
            {
                Title = title,
                Description = description,
                Email = email,
                Start = dtInicio,
                ProfissionalId = profissionalId
            };

            await _service.CreateAsync(consulta);

            //Send Email
            

            return RedirectToAction("Index", "Home", consulta);
        }

        //Editar Consulta
        [HttpPost]
        public async Task<IActionResult> EditarConsulta(int id, string title, string description, string email, DateTime dtInicio, int profissionalId)
        {
            var consultaOld = _service.GetByIdAsync(id).Result;

            consultaOld.Title = title;
            consultaOld.Description = description;
            consultaOld.Email = email;
            consultaOld.Start = dtInicio;
            consultaOld.ProfissionalId = profissionalId;

            await _service.UpdateAsync(consultaOld);

            return RedirectToAction("Index", "Home");
        }


        //Cancelar Consulta
        [HttpGet]
        public IActionResult CancelarConsulta(string id)
        {
            var consulta = _service.GetByIdAsync(Convert.ToInt32(id)).Result;

            _service.DeleteASync(consulta);

            return RedirectToAction("Index", "Home");
        }

        //Finalizar Consulta
        [HttpGet]
        public IActionResult FinalizarConsulta(string id)
        {
            var consulta = _service.GetByIdAsync(Convert.ToInt32(id)).Result;

            consulta.Finished = true;

            _service.UpdateAsync(consulta);

            return RedirectToAction("Index", "Home");
        }
    }
}
