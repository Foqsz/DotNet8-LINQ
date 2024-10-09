using DotNet8_LINQ;
using DotNet8_LINQ.Context;
using DotNet8_LINQ.Filtrar_Dados;
using DotNet8_LINQ.FiltrarDados;
using DotNet8_LINQ.OperadoresDeQuantificacao;
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

Console.WriteLine("");

Console.WriteLine("LINQ");
Console.WriteLine("Operadores de quantificacao");

int[] numerosQuant = { 10, 22, 32, 44, 56, 64, 78 };

var resultadoQuant = numerosQuant.All(n => n % 2 == 0);

var resultadoQuant2 = (from n in numerosQuant select n).All(n => n % 2 == 0);

Console.WriteLine($"{(resultadoQuant ? "Todos são pares" : "Nem todos são pares")}");
Console.WriteLine(resultadoQuant2);

var funcionarioAll = FonteDeDados.GetFuncionarios();

var todosSalariosAcima2500 = funcionarioAll.All(f => f.Salario > 2500.00m);

var todosIdadeMaiorQ21 = funcionarioAll.All(f => f.Idade > 21);

var todosNomesTemLetraA = funcionarioAll.All(f => f.Nome.Contains('a'));

Console.WriteLine($"{todosSalariosAcima2500} - {todosIdadeMaiorQ21} - {todosNomesTemLetraA}");

var resultadoConsulta = (from n in funcionarioAll select n).All(n => n.Salario > 3500);

Console.WriteLine($"{(resultadoConsulta ? "Todos os salários são maior que 3500" : "Nem todos são maiores que 3500")}");

Console.WriteLine("LINQ - OP DE QUANTIFICACAO 2");

var pessoasQt = FonteDeDados.GetPessoas();

var nomesDog = from pessoa in pessoasQt
               where pessoa.Cachorros.All(pet => pet.Idade > 5)
               select pessoa.Nome;

foreach (string nome in nomesDog)
{
    Console.WriteLine(nome);
}

string[] cursosAny = { "C#", "Java", "Phyton", "PHP", "ASP.NET", "Node" };

var existemCursos = cursosAny.Any();

var existemCursosMaiorQue2 = cursosAny.Any(c => c.Length > 2);

var resultadoP = (from c in cursosAny select c).Any(c => c.Contains('P'));

Console.WriteLine($" {existemCursos}- {existemCursosMaiorQue2} -{resultadoP}");

List<Cachorro> cachorros = new()
{
new Cachorro() { Nome = "Bilu", Idade = 6, Vacinado = true},
new Cachorro() { Nome = "Canelinha", Idade = 3, Vacinado = false},
new Cachorro() { Nome = "Pipoca", Idade = 8, Vacinado = true},
};

// Verifica se existem cachorros com mais de 2 anos e não vacinados bool naoVacinados cachorros. Any (p => p. Idade > 2 && p. Vacinado == false);
bool naoVacinados = cachorros.Any(p => p.Idade > 2 && p.Vacinado == false);


var resultadoDog = (from c in cachorros
                    select c).Any(p => p.Idade > 3 && p.Vacinado == false);

Console.WriteLine($"{(naoVacinados ? "Existem" : "Não existem")} cães com mais de 2 anos não vacinados");

List<Aluno> alunosComparer = new List<Aluno>()
        {
            new Aluno() { Nome = "Maria", Pontos = 275 },
            new Aluno() { Nome = "Marta", Pontos = 375 },
            new Aluno() { Nome = "Pedro", Pontos = 299 }
        };

AlunoComparer alunoComparer = new AlunoComparer();

var aluno1 = new Aluno() { Nome = "Maria", Pontos = 275 };

var resultadoAl1 = alunosComparer.Contains(aluno1, alunoComparer);

// Sintaxe de consulta
var resultadoAl2 = (from num in alunos
                    select num).Contains(aluno1, alunoComparer);

Console.WriteLine($"{resultadoAl1} {resultadoAl2}");

Console.WriteLine("LINQ");
Console.WriteLine("Operadores de Agrupamento");

var alunosGroup = FonteDeDados.GetAlunos();

//sintaxe de método
var grupos = alunosGroup.GroupBy(a => a.Sexo);

//sintaxe de consulta
var grupos2 = from a in alunosGroup
              group a by a.Sexo;

//itera em cada grupo
foreach (var grupo in grupos)
{
    Console.WriteLine($"\nSexo: {grupo.Key} - Alunos: {grupo.Count()}");

    //itera através de cada aluno no grupo
    foreach (var aluno in grupo)
    {
        Console.WriteLine($"\t{aluno.Nome} {aluno.Curso} {aluno.Idade}");
    }
}

// Sintaxe de método
var gruposGroup = alunos.GroupBy(s => s.Curso)
    // Primeiro ordena os dados baseado na chave: curso
    .OrderBy(c => c.Key)
    .Select(std => new
    {
        Key = std.Key,
        // Ordena os dados baseado no nome
        Alunos = std.OrderBy(x => x.Nome)
    });

foreach (var grupo in gruposGroup)
{
    Console.WriteLine($"{grupo.Key} (alunos: {grupo.Alunos.Count()})");
    // Itera cada grupo de alunos
    foreach (var aluno in grupo.Alunos)
    {
        Console.WriteLine($"\t{aluno.Nome} {aluno.Idade} {aluno.Sexo}");
    }
}


// Sintaxe de método
var gruposA = alunos.GroupBy(x => new { x.Curso, x.Sexo })
    .OrderBy(g => g.Key.Curso)
    .ThenBy(g => g.Key.Sexo)
    .Select(g => new
    {
        Curso = g.Key.Curso,
        Sexo = g.Key.Sexo,
        Alunos = g.OrderBy(x => x.Nome)
    });

foreach (var grupo in gruposA)
{
    Console.WriteLine($"\n{grupo.Curso} {grupo.Sexo} (alunos: {grupo.Alunos.Count()})");
    // Itera cada grupo de alunos
    foreach (var aluno in grupo.Alunos)
    {
        Console.WriteLine($"\t{aluno.Nome} {aluno.Idade} {aluno.Sexo}");
    }
}


var alunosToLoopup = FonteDeDados.GetAlunos();

var gruposTo = alunosToLoopup.ToLookup(a => a.Curso);

var gruposTo2 = (from a in alunosToLoopup
                 select a).ToLookup(c => c.Curso);

foreach (var grupo in gruposTo)
{
    Console.WriteLine($"\n{grupo.Key} ({grupo.Count()})");
    foreach (var aluno in grupo)
    {
        Console.WriteLine($"\t{aluno.Nome} {aluno.Idade} {aluno.Sexo}");
    }
}


Console.WriteLine("New");

var consulta = from aluno in FonteDeDados.GetAlunosAtt()
               join endereco in FonteDeDados.GetEnderecos()
               on aluno.EnderecoId equals endereco.Id
               join curso in FonteDeDados.GetCursos()
               on aluno.CursoId equals curso.Id
               select new
               {
                   ID = aluno.Id,
                   AlunoNome = aluno.Nome,
                   CursoNome = curso.Nome,
                   EnderecoLocal = endereco.Local,
               };

foreach (var aluno in consulta)
{
    Console.WriteLine($"ID = {aluno.ID}\t Nome = {aluno.AlunoNome} " +
                      $"\tEndereco = {aluno.EnderecoLocal}\t Curso = {aluno.CursoNome}");
}

Console.WriteLine("LIN");
Console.WriteLine("Operadores de Elemento");

List<int> numerosNew = new List<int>() { 10, 20, 30, 40, 50, 60, 70, 80, 90, 90 };

int resultadoNew = numerosNew.ElementAtOrDefault(5);
Console.WriteLine(resultadoNew);

var alunoNew = FonteDeDados.GetAlunosAtt().ElementAtOrDefault(5);
Console.WriteLine($"\n{alunoNew.Id} {alunoNew.Nome} {alunoNew.CursoId}");

var nomeAluno = FonteDeDados.GetAlunosAtt().Select(a => a.Nome).ElementAtOrDefault(5);
Console.WriteLine($"\n{nomeAluno}");

Console.WriteLine("First e FirstOrDefault");
int resultadoFirst = numerosNew.FirstOrDefault();
int resultadoFirst2 = numerosNew.FirstOrDefault(n => n > 20);

Console.WriteLine(resultadoFirst); // 10
Console.WriteLine(resultadoFirst2); // 30

//InvalidOperationException
int resultadoFirst3 = numerosNew.FirstOrDefault(n => n > 90);
Console.WriteLine(resultadoFirst3);

//Tipo Complexo
var alunoFirst = FonteDeDados.GetAlunosAtt().FirstOrDefault();
var alunoFirst1 = FonteDeDados.GetAlunosAtt().FirstOrDefault(a => a.CursoId == 30);
Console.WriteLine($"{alunoFirst.Id} {alunoFirst.Nome} {alunoFirst.CursoId}");
Console.WriteLine($"{alunoFirst1.Id} {alunoFirst1.Nome} {alunoFirst1.CursoId}");

int resultadoLast = numerosNew.Last();
Console.WriteLine(resultadoLast);

int resultadoLast2 = numerosNew.Last(num => num < 50);
Console.WriteLine(resultadoLast2);

List<int> numerosLast = new List<int>() { };
int resultadoLast3 = numerosNew.Last();
Console.WriteLine(resultadoLast3);

//int resultadoLast4 = numerosNew.Last(num => num > 90); invalid exception por n ter numero maior q 90
//Console.WriteLine(resultadoLast4);

int resultadoLast5 = numerosNew.LastOrDefault(num => num > 90);
Console.WriteLine(resultadoLast5);

int resultadoLast6 = numerosNew.LastOrDefault(num => num < 90);
Console.WriteLine(resultadoLast6);

//int resultadoSingle = numerosNew.SingleOrDefault();
//Console.WriteLine(resultadoSingle);

IEnumerable<int> resultadoDefault = numerosNew.DefaultIfEmpty(); // se a coleção estiver vazia, vai retornar 0, ou se eu definir o valor padrao e estiver vazia, retorna o valor que eu defini
foreach (int num in resultadoDefault)
{
    Console.Write(" , " + num);
}

var filmes = new List<Filme>
{
    new Filme("Titanic", 7),
    new Filme("De volta para o futuro", 8),
    new Filme("Mulher Maravilha", 6)
};

var filmeFavorito = new Filme("O quinto elemento", 10);

var filmeAAssistir = filmes.Where(f => f.Avaliacao >= 8).DefaultIfEmpty(filmeFavorito).First();
Console.WriteLine("");
Console.WriteLine(filmeAAssistir.Titulo);

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

//int RegistrosPorPagina = 4;
//int NumeroPagina;

//do
//{
//    Console.WriteLine("\nInforme o no. de página entre 1 e 4: ");
//    if (int.TryParse(Console.ReadLine(), out NumeroPagina))
//    {
//        if (NumeroPagina > 0 && NumeroPagina < 5)
//        {
//            var alunosBd = FonteDeDados.GetAlunosNew()
//                                       .Skip((NumeroPagina - 1) * RegistrosPorPagina)
//                                       .Take(RegistrosPorPagina).ToList();

//            Console.WriteLine("\nPag. : " + NumeroPagina);

//            foreach (var aluno in alunosBd)
//            {
//                Console.WriteLine($"Id: {aluno.Id} - Nome: {aluno.Nome} - Curso: {aluno.Curso}");
//            }
//        }
//    }
//    else
//    {
//        Console.WriteLine("Informe o no. de página válido");
//    }

//} while (true);

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

Console.WriteLine("LINQ - APPEND, PREPEND E ZIP");

List<int> NumerosGlobal = new List<int> { 1, 2, 3, 4, 5 };

var resultAppend = NumerosGlobal.Append(6).ToList();
var resultadPrepend = NumerosGlobal.Prepend(0).ToList();

Console.WriteLine(string.Join(", ", resultAppend));
Console.WriteLine(string.Join(", ", resultadPrepend));

string[] palavras = { "Um", "Dois", "Três", "Quatro" };

var resultadoZip = NumerosGlobal.Zip(palavras, (prim, seg) => seg + " - " + prim);

foreach (var item in resultadoZip)
{
    Console.WriteLine(item);
}

var seq1 = new[] { 1, 2, 3 };
var seq2 = new[] { 10, 20, 30 };

var resultadosq = seq1.Zip(seq2, (m, n) => m * n);

foreach (var item in resultadosq)
{
    Console.WriteLine(item);
}

var estados = new[] { "São Paulo", "Rio de Janeiro", "Belo Horizonte" };
var siglas = new[] { "SP", "RJ", "MG" };

var resultadoes = estados.Zip(siglas, (x, y) => x + "-" + y);

foreach (var item in resultadoes)
{
    Console.WriteLine(item);
}

string[] paises = { "US", "UK", "India", "Russia", "China", "Brasil", "Peru" };

var resultadoPs = paises.ToList();

foreach (string pais in resultadoPs)
{
    Console.WriteLine(pais);
}

var alunosUp = FonteDeDados.GetAlunosUp();

var listaAluno = alunosUp.Where(a => a.Nome.Contains('M')).ToList();

Console.WriteLine("-----------ToList()--------------");
foreach (var aluno in listaAluno)
{
    Console.WriteLine(aluno.Nome);
}

var listaAlunoArray = alunosUp.Where(a => a.Nome.Contains('a')).ToArray();

Console.WriteLine("-------------ToArray()--------------");
foreach (var aluno in listaAlunoArray)
{
    Console.WriteLine(aluno.Nome);
}

IEnumerable<Pacote> pacotes = new List<Pacote>
{
    new Pacote { Empresa = "VV Tech", Peso = 25.2},
    new Pacote { Empresa = "VP LTDA", Peso = 18.7},
    new Pacote { Empresa = "TMP SP", Peso = 33.8}
}.AsEnumerable();

var empresas = pacotes.Select(pct => pct.Empresa).ToArray();

foreach (var empres in empresas)
{
    Console.WriteLine(empres);
}

var alunosDic = FonteDeDados.GetAlunosUp(); //IEnumerable

var listaDic = alunosDic.ToDictionary<Aluno, int>(a => a.Id);

foreach (var chave in listaDic.Keys)
{
    Console.WriteLine($"Chave: {chave}, Valor: {(listaDic[chave] as Aluno).Nome}");
} 

//ExemploInnerJoin();
//ExemploLeftJoin();
//ExemploRightJoin();
//ExemploFullJoin();
//ExemploCrossJoin();
//ExemploGroupJoin();
static void ExemploInnerJoin()
{
    using (var contexto = new AppDbContext())
    {
        var innerJoin = contexto.Funcionarios              //Outer Data Source
        .Join(
              contexto.Setores,                            //Inner Data Source
                       funcionario => funcionario.SetorId, //Inner Key Selector
                       setor => setor.SetorId,             //Outer Key selector
                       (funcionario, setor) => new         //Projetando os dados em um conjunto
                       {
                           NomeFuncionario = funcionario.FuncionarioNome,
                           NomeSetor = setor.SetorNome,
                           CargoFuncionario = funcionario.FuncionarioCargo
                       }).ToList();

        //var innerJoin2 = (from f in contexto.Funcionarios
        //                  join s in contexto.Setores on f.SetorId equals s.SetorId
        //                  select new
        //                  {
        //                      NomeFuncionario = f.FuncionarioNome,
        //                      CargoFuncionario = f.FuncionarioCargo,
        //                      NomeSetor = s.SetorNome
        //                  }).ToList();

        Console.WriteLine("Funcionario\t\tCargo\t\t\tSetor");

        foreach (var funcionario in innerJoin)
        {
            Console.WriteLine($"{funcionario.NomeFuncionario}" +
                              $"\t\t{funcionario.CargoFuncionario}" +
                              $"\t\t{funcionario.NomeSetor}");
        }
        Console.ReadLine();
    }
}

static void ExemploLeftJoin()
{
    using (var contexto = new AppDbContext())
    {
        var leftJoin = (from f in contexto.Funcionarios
                        join s in contexto.Setores
                        on f.SetorId equals s.SetorId
                        into funciSetorGrupo
                        from setor in funciSetorGrupo.DefaultIfEmpty()
                        select new
                        {
                            NomeFuncionario = f.FuncionarioNome,
                            CargoFuncionario = f.FuncionarioCargo,
                            NomeSetor = setor.SetorNome
                        }).ToList();

        Console.WriteLine("Funcionario\t\tCargo\t\t\tSetor");
        foreach (var funcionario in leftJoin)
        {
            Console.WriteLine($"{funcionario.NomeFuncionario}" +
                              $"\t\t{funcionario.CargoFuncionario}" +
                              $"\t\t{funcionario.NomeSetor}");
        }
        Console.ReadLine();
    }
}

static void ExemploRightJoin()
{
    using (var contexto = new AppDbContext())
    {
        var rightJoin = (from s in contexto.Setores
                         join f in contexto.Funcionarios
                         on s.SetorId equals f.SetorId
                         into SetorFunciGrupo
                         from funcionario in SetorFunciGrupo.DefaultIfEmpty()
                         select new
                         {
                             NomeFuncionario = funcionario.FuncionarioNome,
                             CargoFuncionario = funcionario.FuncionarioCargo,
                             NomeSetor = s.SetorNome
                         }).ToList();

        Console.WriteLine("Funcionario\t\tCargo\t\t\tSetor");

        foreach (var funcionario in rightJoin)
        {
            Console.WriteLine($"{funcionario.NomeFuncionario}" +
                              $"\t\t {funcionario.CargoFuncionario}" +
                              $"\t\t {funcionario.NomeSetor}");
        }
        Console.ReadLine();
    }
}

static void ExemploFullJoin()
{
    using (var contexto = new AppDbContext())
    {
        var leftJoin = from f in contexto.Funcionarios
                       join s in contexto.Setores on f.SetorId equals s.SetorId
                       into set
                       from setor in set.DefaultIfEmpty()
                       select new
                       {
                           Nome = f.FuncionarioNome,
                           Cargo = f.FuncionarioCargo,
                           Setor = setor.SetorNome
                       };

        var rightJoin = from s in contexto.Setores
                        join f in contexto.Funcionarios on s.SetorId equals f.SetorId
                        into funci
                        from funcionario in funci.DefaultIfEmpty()
                        select new
                        {
                            Nome = funcionario.FuncionarioNome,
                            Cargo = funcionario.FuncionarioCargo,
                            Setor = s.SetorNome
                        };

        var fullJoin = leftJoin.Union(rightJoin);

        Console.WriteLine("Funcionario\t\tCargo\t\tSetor");

        foreach (var resultado in fullJoin)
        {
            Console.WriteLine(resultado.Nome + "\t\t" +
                              resultado.Cargo + "\t\t" +
                              resultado.Setor);
        }

    }
}

static void ExemploCrossJoin()
{
    using (var contexto = new AppDbContext())
    {
        var crossJoin = from f in contexto.Funcionarios
                        from s in contexto.Setores
                        select new
                        {
                            Nome = f.FuncionarioNome,
                            Cargo = f.FuncionarioCargo,
                            Setor = s.SetorNome
                        };

        Console.WriteLine("Funcionario\t\tCargo\t\t\tSetor");

        foreach (var resultado in crossJoin)
        {
            Console.WriteLine(resultado.Nome + "\t\t" + resultado.Cargo + "\t\t\t" + resultado.Setor);
        }
    }
}

static void ExemploGroupJoin()
{
    using (var contexto = new AppDbContext())
    {
        var groupJoin = contexto.Setores
                        .GroupJoin(contexto.Funcionarios,
                        s => s.SetorId, f => f.SetorId,
                        (f, funcionariosGrupo) => new
                        {
                            Funcionarios = funcionariosGrupo,
                            NomeSetor = f.SetorNome
                        }).ToList();

        foreach (var item in groupJoin)
        {
            Console.WriteLine(item.NomeSetor);
            foreach (var func in item.Funcionarios)
            {
                Console.WriteLine($"\t {func.FuncionarioNome}");
            }
        }
        Console.ReadLine();
    }

}