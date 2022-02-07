using System;
using System.Collections.Generic;

namespace EFCore.Dominio
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Setor Setor { get; set; }
    }
}