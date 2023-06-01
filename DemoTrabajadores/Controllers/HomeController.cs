using DemoTrabajadores.Models;
using DemoTrabajadores.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoTrabajadores.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITrabajadorService _trabajadorService;
        private readonly IUbigeoService _ubigeoService;

        public HomeController(ILogger<HomeController> logger, ITrabajadorService trabajadorService, IUbigeoService ubigeoService)
        {
            _logger = logger;
            _trabajadorService = trabajadorService;
            _ubigeoService = ubigeoService;
        }

        public IActionResult Index()
        {
            // Listar trabajadores por SP
            var listarTrabajadoresDTO = _trabajadorService.Listar();
            var departamentos = _ubigeoService.ListarDepartamentos();
            var model = new { listarTrabajadoresDTO, departamentos };
            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int idTrabajador)
        {
            try
            {
                var response = await _trabajadorService.Eliminar(idTrabajador);
                return Ok(response);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Obtener(int idTrabajador)
        {
            try
            {
                var response = _trabajadorService.ObtenerporId(idTrabajador);
                return Ok(response);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Trabajador trabajador)
        {
            try
            {
                var response = await _trabajadorService.Guardar(trabajador);
                return Ok(response);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Trabajador trabajador)
        {
            try
            {
                var response = await _trabajadorService.Editar(trabajador);
                return Ok(response);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}