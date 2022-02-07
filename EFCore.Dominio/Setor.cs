using System;
using System.Collections.Generic;

namespace EFCore.Dominio
{
    public class Setor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdGestor { get; set; }
        public int QtdeFuncionarios { get; set; }
        public List<Funcionario> FuncionarioSetor { get; set; }
    }
}