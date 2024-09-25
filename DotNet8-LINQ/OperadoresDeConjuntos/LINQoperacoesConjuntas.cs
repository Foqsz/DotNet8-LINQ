using DotNet8_LINQ.Filtrar_Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.OperadoresDeConjuntos;

class LINQoperacoesConjuntas
{
    static void Main2(string[] args)
    {
        Console.WriteLine("LINQ");
        Console.WriteLine("Operações com CONJUNTOS");

        Console.WriteLine("Idades ->30,33,35,36,40,30,33,36,30,40");

        var idadesDistintas = FonteDeDados.GetIdades().Distinct();

        foreach (var idades in idadesDistintas)
        {
            Console.WriteLine($"{idades}");
        }

        Console.WriteLine("Paulo, Maria, paulo, Amanda, maria,amanda\n");

        var nomesDistintos = FonteDeDados.GetNomes().Distinct(StringComparer.OrdinalIgnoreCase);

        foreach (var nome in nomesDistintos)
        {
            Console.Write(nome + " ");
        }

        var alunoS = FonteDeDados.GetAlunos().ToList();

        var AlunosIdadesDistintas = alunoS.DistinctBy(a => a.Idade);

        foreach (var aln in AlunosIdadesDistintas)
        {
            Console.WriteLine($" Aluno: {aln.Nome} tem {aln.Idade} anos");
        }

        List<int> fonte1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
        List<int> fonte2 = new List<int>() { 1, 3, 5, 8, 9, 10 };

        var resultadoFonte = fonte1.Except(fonte2).ToList();

        foreach (var item in resultadoFonte)
        {
            Console.WriteLine(item);
        }

        string[] fonte1br = { "Brasil", "USA", "UK", "Argentina", "China" };
        string[] fonte2br = { "Brasil", "uk", "Argentina", "França", "Japão" };

        var resultadofonte1 = fonte1br.Except(fonte2br, StringComparer.OrdinalIgnoreCase);

        foreach (var pais in resultadofonte1)
        {
            Console.Write($"{pais} ");
        }

        var alunoos = FonteDeDados.GetAlunos();

        var alunosReprovados = new List<string>() { "Amanda", "Alicia", "Jaime" };

        var alunosAprovados = alunoos.ExceptBy(alunosReprovados, n => n.Nome);

        Console.WriteLine("Alunos Aprovados\n");
        foreach (var aluno in alunosAprovados)
        {
            Console.WriteLine(aluno.Nome);
        }

    }
}

