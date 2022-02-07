using System;

namespace EFCore.Dominio
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public Cargo Cargo { get; set; }
        public Setor Setor { get; set; }
        public float Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDesligamento { get; set; }
  
    }
}