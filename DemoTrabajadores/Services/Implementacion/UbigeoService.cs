using AutoMapper;
using DemoTrabajadores.Models;
using DemoTrabajadores.Models.ModelsDTO;
using DemoTrabajadores.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoTrabajadores.Services.Implementacion
{
    public class UbigeoService : IUbigeoService
    {
        private readonly IMapper _mapper;
        private readonly DemoTrabajadoresContext _dbContext;

        public UbigeoService(IMapper mapper, DemoTrabajadoresContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public List<Departamento> ListarDepartamentos()
        {
            try
            {
                return _dbContext.Set<Departamento>().ToList();
            }
            catch(Exception)
            {

                throw;
            }
        }

        public List<Distrito> ListarDistritos(int idProvincia)
        {
            try
            {
                return _dbContext.Set<Distrito>().Where(e => e.IdProvincia == idProvincia).ToList();
            }
            catch(Exception)
            {

                throw;
            }
        }

        public List<Provincia> ListarProvincias(int idDepartamento)
        {
            try
            {
                return _dbContext.Set<Provincia>().Where(e => e.IdDepartamento == idDepartamento).ToList();
            }
            catch(Exception)
            {

                throw;
            }
        }
    }
}
