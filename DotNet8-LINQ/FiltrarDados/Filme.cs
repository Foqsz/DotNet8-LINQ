using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.FiltrarDados
{
    public class Filme
    {
        public string? Titulo { get; set; }
        public int Avaliacao { get; set; }
        public Filme(string? titulo, int avaliacao)
        {
            Titulo = titulo;
            Avaliacao = avaliacao;
        }
        public Filme()
        {

        }
    }
}
