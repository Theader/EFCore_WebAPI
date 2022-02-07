using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly RHContext _context;

        public EFCoreRepository(RHContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Funcionario[]> GetAllFuncionarios()
        {
            IQueryable<Funcionario> query = _context.Funcionarios
                                            .Include(f => f.Setor)
                                            .Include(f=>f.Cargo)
                                            .OrderBy(f => f.Id)
                                            .AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Funcionario> GetFuncionarioById(int id)
        {
            IQueryable<Funcionario> query = _context.Funcionarios
                                            .Include(f => f.Setor)
                                            .Include(f => f.Cargo)
                                            .AsNoTracking();

            return await query.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Funcionario[]> GetFuncionarioByNome(string nome)
        {
            IQueryable<Funcionario> query = _context.Funcionarios
                                            .Include(f => f.Setor)
                                            .Include(f => f.Cargo)
                                            .Where(h => h.Nome.Contains(nome))
                                            .OrderBy(h => h.Id)
                                            .AsNoTracking();


            return await query.ToArrayAsync();
        }

        public async Task<Setor[]> GetAllSetores()
        {
            IQueryable<Setor> query = _context.Setores
                                      .Include(f => f.FuncionarioSetor)
                                      .OrderBy(h => h.Id)
                                      .AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Setor> GetSetorById(int Id)
        {
            IQueryable<Setor> query = _context.Setores
                                      .Where(s => s.Id == Id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Setor[]> GetSetorByNome(string nome)
        {
            IQueryable<Setor> query = from s in _context.Setores
                                      where s.Nome.Contains(nome)
                                      select s;

            return await query.ToArrayAsync();
        }
        public async Task<Cargo[]> GetAllCargos()
        {
            IQueryable<Cargo> query = _context.Cargos
                                      .OrderBy(h => h.Id)
                                      .AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Cargo> GetCargoById(int Id)
        {
            IQueryable<Cargo> query = _context.Cargos
                                      .Where(s => s.Id == Id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Cargo[]> GetCargoByNome(string nome)
        {
            IQueryable<Cargo> query = from s in _context.Cargos
                                      where s.Nome.Contains(nome)
                                      select s;

            return await query.ToArrayAsync();
        }
    }
}
