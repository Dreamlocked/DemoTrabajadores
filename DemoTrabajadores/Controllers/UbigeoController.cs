using DemoTrabajadores.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoTrabajadores.Controllers
{
    public class UbigeoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUbigeoService _departamentoService;

        public UbigeoController(ILogger<HomeController> logger, IUbigeoService departamentoService)
        {
            _logger = logger;
            _departamentoService = departamentoService;
        }
        public IActionResult Departamento()
        {
            try
            {
                var departamentos = _departamentoService.ListarDepartamentos();
                return Ok(departamentos);
            }
            catch(Exception)
            {

                throw;
            }
        }
        public IActionResult Provincia(int idDepartamento)
        {
            try
            {
                var provincias = _departamentoService.ListarProvincias(idDepartamento);
                return Ok(provincias);
            }
            catch(Exception)
            {

                throw;
            }
        }
        public IActionResult Distrito(int idProvincia)
        {
            try
            {
                var distritos = _departamentoService.ListarDistritos(idProvincia);
                return Ok(distritos);
            }
            catch(Exception)
            {

                throw;
            }
        }
    }
}
