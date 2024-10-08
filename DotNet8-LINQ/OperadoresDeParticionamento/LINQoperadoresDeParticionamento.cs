using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.OperadoresDeParticionamento;

public class LINQoperadoresDeParticionamento
{
    static void Main(string[] args)
    {
        Console.WriteLine("LINQ");
        Console.WriteLine("Operadores de Particionamento");

        List<int> numerosTake = new List<int>() { 1, 3, 7, 10, 5, 8, 6, 9, 4, 2 };

        var resultadoTake = numerosTake.OrderBy(n => n).Where(n => n > 3).Take(4).ToList();

        foreach (var num in resultadoTake)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();

        List<int> numerosTakeWhile = new List<int>() { 1, 2, 3, 6, 7, 8, 9, 10, 4, 5 };

        List<int> Resultado1 = numerosTakeWhile.TakeWhile(num => num < 6).ToList();

        Console.Write("Resultado com TakeWhile: ");
        foreach (var num in Resultado1)
        {
            Console.Write($"{num} "); // 1 2 3  //takeWhile fica ativo até retornar false
        }

        Console.WriteLine();

        List<int> Resultado2 = numerosTakeWhile.Where(num => num < 6).ToList();

        Console.Write("Resultado com where: ");

        foreach (var num in Resultado2)
        {
            Console.Write($"{num} "); // 1 2 3 4 5 
        }

        List<string> nomesTakeWhile = new List<string>() { "Sara", "Raul", "José", "Ana", "Pedro" };
        List<string> resultadoTakeWhile = nomesTakeWhile.TakeWhile((nome, index) => nome.Length > index).ToList(); //aqui vai parar em ana, pq ela tem 3 letras e seu indice é 3, entao nao é maior que seu indice(3)
        foreach (var nome in resultadoTakeWhile)
        {
            Console.Write($"\n{nome}");
        }

        List<int> numerosSkip = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 2, 3 };
        List<int> resultadoSkip = numerosSkip.Where(n => n > 3).Skip(4).ToList();
        foreach (var num in resultadoSkip)
        {
            Console.Write($"\n{num} Skip");
        }

        List<int> resultadoSkipWhile = numerosSkip.SkipWhile(num => num < 5).ToList();
        foreach (var num in resultadoSkipWhile)
        {
            Console.Write($"\n{num} SkipWhile");
        }

        List<string> resultadoSkipWhileName = nomesTakeWhile.SkipWhile((nome, index) => nome.Length > index).ToList();
        foreach (var nome in resultadoSkipWhileName)
        {
            Console.Write($"\n{nome} SkipWhile Name");
        }



    }
}
