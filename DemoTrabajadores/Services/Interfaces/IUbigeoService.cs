using DemoTrabajadores.Models;
using DemoTrabajadores.Models.ModelsDTO;

namespace DemoTrabajadores.Services.Interfaces
{
    public interface IUbigeoService
    {
        List<Departamento> ListarDepartamentos();
        List<Provincia> ListarProvincias(int idDepartamento);
        List<Distrito> ListarDistritos(int idProvincia);
    }
}
