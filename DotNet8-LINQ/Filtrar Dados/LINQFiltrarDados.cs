using DotNet8_LINQ;
using DotNet8_LINQ.Filtrar_Dados;

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
