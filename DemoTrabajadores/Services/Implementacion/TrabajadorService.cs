using AutoMapper;
using DemoTrabajadores.Models;
using DemoTrabajadores.Models.ModelsDTO;
using DemoTrabajadores.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DemoTrabajadores.Services.Implementacion
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly IMapper _mapper;
        private readonly DemoTrabajadoresContext _dbContext;

        public TrabajadorService(IMapper mapper, DemoTrabajadoresContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<List<TrabajadorDTO>> ListaFiltrada(Expression<Func<Trabajador, bool>> filtro)
        {
            try
            {
                var listarTrabajadores = await _dbContext.Set<Trabajador>().Include(d => d.IdDistritoNavigation)
                                                                           .ThenInclude(p => p.IdProvinciaNavigation)
                                                                           .ThenInclude(o => o.IdDepartamentoNavigation).Where(filtro).ToListAsync();

                return _mapper.Map<List<TrabajadorDTO>>(listarTrabajadores);

            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<TrabajadorDTO> Listar()
        {
            try
            {
                var listarTrabajadores = _dbContext.Set<TrabajadorDTO>().ToList();
                return listarTrabajadores;
            }
            catch(Exception)
            {

                throw;
            }
        }

        public async Task<bool> Eliminar(int idTrabajador)
        {
            try
            {
                var obtenerTrabajador = await _dbContext.Trabajadors.FirstOrDefaultAsync(e => e.IdTrabajador == idTrabajador);
                if(obtenerTrabajador == null) throw new TaskCanceledException("Trabajador no existe");
                _dbContext.Remove(obtenerTrabajador);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<TrabajadorDTO> Guardar(Trabajador trabajador)
        {
            try
            {
                _dbContext.Set<Trabajador>().Add(trabajador);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<TrabajadorDTO>(trabajador);
            }
            catch(Exception)
            {

                throw;
            }
        }

        public Trabajador Obtener(Expression<Func<Trabajador, bool>> filtro)
        {
            try
            {
                var trabajador = _dbContext.Set<Trabajador>().Include(d => d.IdDistritoNavigation)
                                                                           .ThenInclude(p => p.IdProvinciaNavigation)
                                                                           .ThenInclude(o => o.IdDepartamentoNavigation).FirstOrDefault(filtro);
                return trabajador;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> Editar(Trabajador trabajador)
        {
            try
            {

                var usuarioEncontrado = Obtener(u => u.IdTrabajador == trabajador.IdTrabajador);

                usuarioEncontrado = trabajador;

                if(usuarioEncontrado == null) throw new TaskCanceledException("El usuario no existe");

                _dbContext.Set<Trabajador>().Update(usuarioEncontrado);

                await _dbContext.SaveChangesAsync();

                return true;

            }
            catch(Exception)
            {
                throw;
            }
        }

        public TrabajadorDTO ObtenerporId(int idTrabajador)
        {
            try
            {
                var trabajador = Obtener(trabajador => trabajador.IdTrabajador == idTrabajador);
                return _mapper.Map<TrabajadorDTO>(trabajador); ;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
