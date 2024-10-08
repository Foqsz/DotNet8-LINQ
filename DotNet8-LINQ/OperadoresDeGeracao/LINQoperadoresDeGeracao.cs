using DotNet8_LINQ.Filtrar_Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.OperadoresDeGeracao
{
    public class LINQoperadoresDeGeracao
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ");
            Console.WriteLine("Operadores de Agregação");

            var numerosRange = Enumerable.Range(1, 10).Reverse();
            var numerosPares = Enumerable.Range(10, 30).Where(n => n % 2 == 0);
            var numerosAoQuadrado = Enumerable.Range(1, 10).Select(n => n * n);

            foreach (var numero in numerosRange)
            {
                Console.Write(" " + numero);
            }
            Console.WriteLine();
            foreach (var numeroPar in numerosPares)
            {
                Console.Write(" " + numeroPar);
            }
            Console.WriteLine();
            foreach (var numerosQuadrado in numerosAoQuadrado)
            {
                Console.Write(" " + numerosQuadrado);
            }
            Console.WriteLine();

            var textos = Enumerable.Repeat("Deus é Fiel", 5);
            var numerosRpt = Enumerable.Repeat(2024, 5);

            foreach (string texto in textos)
            {
                Console.WriteLine(texto);
            }

            foreach (var num in numerosRpt)
            {
                Console.WriteLine(num);
            }

            var colecaoVazia1 = Enumerable.Empty<string>();
            var colecaoVazia2 = Enumerable.Empty<Aluno>();

            Console.WriteLine("\nColeção de strings\n");
            Console.WriteLine("Count: {0} ", colecaoVazia1.Count());
            Console.WriteLine("Tipo : {0}", colecaoVazia1.GetType().Name);

            Console.WriteLine("\nColeção de objetos Aluno\n");
            Console.WriteLine("Count: {0} ", colecaoVazia2.Count());
            Console.WriteLine("Tipo: {0} ", colecaoVazia2.GetType().Name);

            IEnumerable<int> result = GetData() ?? Enumerable.Empty<int>();

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Concluído");

            static IEnumerable<int> GetData()
            {
                return null;
            }
        }
    }
}
