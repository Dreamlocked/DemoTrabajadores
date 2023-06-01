using DemoTrabajadores.Models;
using DemoTrabajadores.Models.ModelsDTO;
using System.Linq.Expressions;

namespace DemoTrabajadores.Services.Interfaces
{
    public interface ITrabajadorService
    {
        List<TrabajadorDTO> Listar();
        Task<List<TrabajadorDTO>> ListaFiltrada(Expression<Func<Trabajador, bool>> filtro);
        Task<bool> Eliminar(int idTrabajador);
        Task<TrabajadorDTO> Guardar(Trabajador trabajador);
        Trabajador Obtener(Expression<Func<Trabajador, bool>> filtro);
        TrabajadorDTO ObtenerporId(int idTrabajador);
        Task<bool> Editar(Trabajador trabajador);
    }
}
