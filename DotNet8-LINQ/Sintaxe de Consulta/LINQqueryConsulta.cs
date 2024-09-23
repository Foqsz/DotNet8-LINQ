using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.Sintaxe_de_Consulta;

class LINQqueryConsulta
{
    static void Main(string[] args)
    {

        Console.WriteLine("LINQ");
        Console.WriteLine("Query Sintax ou Sintaxe de Consulta");
        Console.WriteLine("");
        IList<string> frutas = new List<string>() { "Banana", "Maça", "Pera", "Laranja", "Uva" };

        //query sintax

        var resultado = from f in frutas
                        where f.Contains('r')
                        select f;

        Console.WriteLine(string.Join(", ", resultado));

        //method syntax 

        var resultado2 = frutas.Where(f => f.Contains('r')); // Leitura lambda: eu quero toda as frutas que contem a letra r

        Console.WriteLine(string.Join(", ", resultado2));
    }
}
