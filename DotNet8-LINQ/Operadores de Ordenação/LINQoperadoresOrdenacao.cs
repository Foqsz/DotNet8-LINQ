using DotNet8_LINQ.Filtrar_Dados;
using System;

internal class LINQoperadorDeOrdenacao
{
    public static void Main(string[] args)
    {
        Console.WriteLine("LINQ");
        Console.WriteLine("Operadores de Ordenação");

        List<string> nomes = new List<string>() { "Paulo", "Tarcisio", "Amaral", "Pedro", "Debora", "Helena", "Percival", "Manoel", "Rute", "Jose" };

        var lista = nomes.OrderBy(x => x).ToList();

        foreach (var item in lista) Console.WriteLine(item + " ");

        Console.WriteLine("");

        var alunosOrderBy = FonteDeDados.GetAlunos();


        var lista1Aln = alunosOrderBy.OrderBy(p => p.Nome);

        var lista2Aln = alunosOrderBy.Where(p => p.Nome.Contains("a")).OrderBy(p => p.Nome);

        var lista3Aln = alunosOrderBy.Where(p => p.Nome.Contains("a")).OrderBy(p => p.Nome).ThenBy(p => p.Idade);

        var lista4Aln = alunosOrderBy.Where(p => p.Nome.Contains("a")).OrderByDescending(p => p.Nome).ThenByDescending(p => p.Idade);

        foreach (var item in lista4Aln)
        {
            Console.WriteLine($"{item.Nome} {item.Idade}");
        }

        Console.WriteLine("");

        List<string> nomesRervese = new List<string>() { "Pedro", "Tania", "Amaral", "Penita", "Debora" };

        //var lista nomes. Reverse();

        IEnumerable<string> listal = nomes.AsEnumerable().Reverse();
        IQueryable<string> lista2 = nomes.AsQueryable().Reverse();

        foreach (var nome in listal)
        {
            Console.Write($"{nome} ");
        }

    }
}