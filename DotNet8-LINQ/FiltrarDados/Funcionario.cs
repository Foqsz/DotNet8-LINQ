using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.FiltrarDados
{
    public class Funcionario
    {
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public decimal Salario { get; set; }
        public string? Cargo { get; set; }
        public string? Cidade { get; set; }
    }
}
