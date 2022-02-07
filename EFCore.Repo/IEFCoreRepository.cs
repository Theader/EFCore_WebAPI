using EFCore.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        //Funcionario
        Task<bool> SaveChangeAsync();
        Task<Funcionario[]> GetAllFuncionarios();
        Task<Funcionario> GetFuncionarioById(int id);
        Task<Funcionario[]> GetFuncionarioByNome(string nome);
        //Setor
        Task<Setor[]> GetAllSetores();
        Task<Setor> GetSetorById(int id);
        Task<Setor[]> GetSetorByNome(string nome);
        //Cargo
        Task<Cargo[]> GetAllCargos();
        Task<Cargo> GetCargoById(int id);
        Task<Cargo[]> GetCargoByNome(string nome);
    }
}
