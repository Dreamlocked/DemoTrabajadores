using AutoMapper;
using DemoTrabajadores.Models;
using DemoTrabajadores.Models.ModelsDTO;

namespace DemoTrabajadores.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Trabajador
            CreateMap<Trabajador, TrabajadorDTO>()
                .ForMember(destino =>
                    destino.Distrito,
                    option => option.MapFrom(origen => origen.IdDistritoNavigation.NombreDistrito))
                .ForMember(destino =>
                    destino.Provincia,
                    option => option.MapFrom(origen => origen.IdDistritoNavigation.IdProvinciaNavigation.NombreProvincia))
                .ForMember(destino =>
                    destino.Departamento,
                    option => option.MapFrom(origen => origen.IdDistritoNavigation.IdProvinciaNavigation.IdDepartamentoNavigation.NombreDepartamento));
            #endregion
        }
    }
}
