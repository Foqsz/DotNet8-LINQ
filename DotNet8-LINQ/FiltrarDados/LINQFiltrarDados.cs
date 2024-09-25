using DotNet8_LINQ;
using DotNet8_LINQ.Filtrar_Dados;
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
