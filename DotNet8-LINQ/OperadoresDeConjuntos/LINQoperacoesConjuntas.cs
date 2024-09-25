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

        Console.WriteLine("## LINQ Operações com conjuntos 2 ### \n");

        List<int> fonte1aula2 = new List<int>() { 1, 2, 3, 4, 5, 6 };
        List<int> fonte2aula2 = new List<int>() { 1, 3, 5, 8, 9, 10 };

        //var resultado fonte1. Intersect(fonte2).ToList();
        var resultado = (from num in fonte1
                         select num).Intersect(fonte2).ToList();
        foreach (var item in resultado)
        {
            Console.WriteLine(item);
        }


        string[] paises1 = { "Brasil", "USA", "UK", "Argentina", "China" };
        string[] paises2 = { "Brasil", "uk", "Argentina", "França", "Japão" };

        var resultadoPaises = paises1.Intersect(paises2, StringComparer.OrdinalIgnoreCase).ToList();

        foreach (var pais in resultadoPaises)
        {
            Console.WriteLine(pais);
        }

        var turmaA = FonteDeDados.GetTurmaA();
        var turmaB = FonteDeDados.GetTurmaB();

        var consulta2 = turmaA.Select(p => p.Nascimento.Year).Intersect(turmaB.Select(p => p.Nascimento.Year));

        var alunosTurmaAComMesmoAnoNascimento = turmaA.IntersectBy(turmaB.Select(p => p.Nascimento.Year),
                                                p => p.Nascimento.Year);

        Console.WriteLine("Turma A - Alunos com mesma ano de nascimento da turma B");

        foreach (var aluno in alunosTurmaAComMesmoAnoNascimento)
        {
            Console.WriteLine(aluno.Nome + " ");
        }
        Console.WriteLine("Total de Alunos : " + alunosTurmaAComMesmoAnoNascimento.Count());

        List<int> fonte1Union = new List<int>() { 1, 2, 3, 4, 5, 6 };
        List<int> fonte2Union = new List<int>() { 1, 3, 5, 8, 9, 10 };

        var resultadoUnion = fonte1Union.Union(fonte2Union).ToList();

        foreach (var item in resultadoUnion)
        {
            Console.Write(" " + item);
        }

        string[] fonte1Paises = { "Brasil", "USA", "UK", "Argentina", "China" };
        string[] fonte2Paises = { "Brasil", "uk", "Argentina", "França", "Japão" };

        var resultadoPaisesUnion = fonte1Paises.Union(fonte2Paises, StringComparer.OrdinalIgnoreCase).ToList();

        Console.WriteLine("");

        foreach (var pais in resultadoPaisesUnion)
        {
            Console.Write($"{pais} ");
        }

        var turmaAUnion = FonteDeDados.GetTurmaA();
        var turmaBUnion = FonteDeDados.GetTurmaB();

        var consultaUnion = turmaAUnion.Select(p => p.Nome).Union(turmaBUnion.Select(p => p.Nome));

        var turmasUnionBy = turmaAUnion.UnionBy(turmaBUnion, p => p.Nome);

        Console.WriteLine("");
        Console.WriteLine("Alunos nomes distintos\n");

        foreach (var aluno in turmasUnionBy)
        {
            Console.WriteLine($"{aluno.Nome} {aluno.Nascimento.Year} {aluno.Idade}");
        }
    }
}

