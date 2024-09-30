﻿using DotNet8_LINQ;
using DotNet8_LINQ.Filtrar_Dados;
using DotNet8_LINQ.FiltrarDados;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("LINQ");
Console.WriteLine("Filtrar Dados");
Console.WriteLine("");

//numeros = 1, 2, 4, 8, 16, 32, 64, 128, 256, 512
var numeros = FonteDeDados.GetNumeros();

var resultado1 = numeros.Where(n => n < 10);

var resultado2 = numeros.Where(n => n > 1 && n != 4 && n < 20);

// 16, 128, 512
var listaNegra = FonteDeDados.GetListaNegra();

var resultado3 = numeros.Where(n => !listaNegra.Contains(n)); // não(!) quero que os numeros da lista negra sejam incluidos

var resultado4 = numeros.Where(n => n > 1)
                        .Where(n => n != 4)
                        .Where(n => n > 20);

Console.WriteLine(String.Join(", ", resultado1));
Console.WriteLine(String.Join(", ", resultado2));
Console.WriteLine(String.Join(", ", resultado3));
Console.WriteLine(String.Join(", ", resultado4));

//trabalhar com objetos complexos

var alunos = FonteDeDados.GetAlunos();

var resultado5 = alunos.Where(a => a.Nome.StartsWith('A') && a.Idade < 18); //nome tem que começar com A e a idade tem q ser menor 18

//sintaxe de consulta
var filtro = from a in alunos
             where a.Nome.StartsWith('A') && a.Idade < 18
             select a;

foreach (var aluno in resultado5)
{
    Console.WriteLine(aluno.Nome + " : " + aluno.Idade);
}

Console.WriteLine("LINQ");
Console.WriteLine("Operadores de Projeção");

//Sintaxe de método
IEnumerable<Aluno> alunoss = FonteDeDados.GetAlunos().ToList();

Console.WriteLine("Alunos Notas\n");

foreach (var aluno in alunoss)
{
    Console.WriteLine($"{aluno.Nome} : {aluno.Nota}");
}

IEnumerable<string> nomes = FonteDeDados.GetAlunos().Select(n => n.Nome);

Console.WriteLine("Alunos Notas\n");

foreach (var nome in nomes)
{
    Console.WriteLine($"{nome}");
}

//tipo anonimo
var AlunosTipoAnonimo = FonteDeDados.GetAlunos().Select(a => new
{
    NomeAluno = a.Nome,
    IdadeAluno = a.Idade,
    NotaAluno = a.Nota
}).ToList();

Console.WriteLine("Alunos Idade\n");

foreach (var aluno in AlunosTipoAnonimo)
{
    Console.WriteLine($"{aluno.IdadeAluno} : {aluno.NomeAluno}");
}

var alunosTipoAnonimo2 = FonteDeDados.GetFuncionarios().Select(f => new
{
    NomeAluno = f.Nome,
    IdadeAluno = f.Idade,
    SalarioAnual = f.Salario * 12
}).ToList();

foreach (var aluno in alunosTipoAnonimo2)
    Console.WriteLine($"{aluno.NomeAluno} : {aluno.IdadeAluno} {aluno.SalarioAnual.ToString("c")}");

List<List<int>> listas = new List<List<int>>
                                            {
                                            new List<int> {1, 2, 3},
                                            new List<int> {12},
                                            new List<int> {5, 6, 5, 7},
                                            new List<int> { 10, 12, 12, 13 }
                                            };

IEnumerable<int> resultado = listas.SelectMany(lista => lista.Distinct());
// retornará { 1, 2, 3, 12, 5, 6, 5, 7, 10, 11, 12, 13 }
foreach (var i in resultado)
    Console.Write(" " + i);

// usando Select
IEnumerable<List<String>> retornoSelect = FonteDeDados.GetAlunos().Select(c => c.Cursos);

Console.WriteLine("Usando Select\n");

foreach (List<String> listasCursos in retornoSelect)
{
    foreach (string curso in listasCursos)
    {
        Console.Write($"{curso} ");
    }
    Console.WriteLine();
}
// usando SelectMany()

Console.WriteLine("\nUsando SelectMany\n");
IEnumerable<string> retornoSelectMany = FonteDeDados.GetAlunos().SelectMany(c => c.Cursos);
foreach (string curso in retornoSelectMany)
{
    Console.Write($"{curso} ");
}


Console.WriteLine("LINQ");
Console.WriteLine("Operações com CONJUNTOS");

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

List<int> fonte1aula2 = new List<int>() { 1, 2, 3, 4, 5, 6 };
List<int> fonte2aula2 = new List<int>() { 1, 3, 5, 8, 9, 10 };

//var resultado fonte1. Intersect(fonte2).ToList();
var resultadxo = (from num in fonte1
                  select num).Intersect(fonte2).ToList();
foreach (var item in resultadxo)
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

List<string> nomesOrderBy = new List<string>() { "Paulo", "Tarcisio", "Amaral", "Pedro", "Debora", "Helena", "Percival", "Manoel", "Rute", "Jose" };

var lista = nomesOrderBy.OrderBy(x => x).ToList();

foreach (var item in lista)
{
    Console.WriteLine(item + " ");
}

Console.WriteLine("");
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


Console.WriteLine("LINQ");
Console.WriteLine("Operadores de Agregação");

string[] cursos = { "C#", "Java", "Phyton", "PHP", "JavaScript", "Go" };

string resultadoAG = cursos.Aggregate((s1, s2) => s1 + "," + s2);
Console.WriteLine(resultadoAG);

var resultadosCount = cursos.Count();
var resultadosCount2 = cursos.Where(c => c.Contains('P')).Count();
var resultadosCount3 = cursos.Count(c => c.Contains('P'));

Console.WriteLine(resultadosCount);
Console.WriteLine(resultadosCount2);
Console.WriteLine(resultadosCount3); 

int[] numerosAg = { 3, 5, 7, 9 };

int resultadoAgN = numerosAg.Aggregate((n1, n2) => n1 * n2);

Console.WriteLine(resultadoAgN);

var alunosN = FonteDeDados.GetAlunos();

string listaAlunos = alunosN.Aggregate<Aluno, string>("Nomes : ", (semente, aluno) => semente += aluno.Nome + ", ");

int indice = listaAlunos.LastIndexOf(", ");
listaAlunos = listaAlunos.Remove(indice);

Console.WriteLine("Lista 1:" + listaAlunos);

string listaAlunos2 = alunosN.Aggregate<Aluno, string, string>("Nomes : ",  //semente
                                                              (semente, aluno) => semente += aluno.Nome + ", ",
                                                              resultado => resultado.Substring(0, resultado.Length - 2));

Console.WriteLine("Lista 2: " + listaAlunos2);

var mediaIdades = alunosN.Average(aluno => aluno.Idade);

Console.WriteLine(mediaIdades);

int[] numerosSum = { 3, 5, 7, 9 };

int resultadoSum = numerosSum.Where(n => n > 3).Sum();
int resultadoSum2 = numerosSum.Sum(n =>
{
    if (n > 5)
        return n;
    else
        return 0;
});

Console.WriteLine(resultadoSum);
Console.WriteLine(resultadoSum2);

var funcionarios = FonteDeDados.GetFuncionarios();

var maiorIdade = funcionarios.Max(f => f.Idade);
var maiorSalario = funcionarios.Max(f => f.Salario);

var menorIdade = funcionarios.Min(f => f.Idade);
var menorSalario = funcionarios.Min(f => f.Salario);

var maxSalario = funcionarios.Max(s =>
{
    if (s.Idade > 20)
        return s.Salario;
    else
        return 0;
});

var menorSalarioFiltrado = funcionarios.Where(f => f.Idade < 20).Min(f => f.Salario);

Console.WriteLine($"Maior idade {maiorIdade} Maior salario - {maiorSalario}");
Console.WriteLine($"Menor idade {menorIdade} Menor salario - {menorSalario}");
Console.WriteLine($"Maior salario filtrado entre idades: {maxSalario}");
Console.WriteLine($"Salario filtrado menor: {menorSalarioFiltrado}");