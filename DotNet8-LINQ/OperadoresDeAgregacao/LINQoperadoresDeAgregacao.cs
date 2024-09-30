using DotNet8_LINQ.Filtrar_Dados;
using DotNet8_LINQ.FiltrarDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.OperadoresDeAgregacao;

internal class LINQoperadoresDeAgregacao
{
    public static void Main(string[] args)
    {

        Console.WriteLine("LINQ");
        Console.WriteLine("Operadores de Agregação");

        string[] cursos = { "C#", "Java", "Phyton", "PHP", "JavaScript", "Go" };

        string resultadoAG = cursos.Aggregate((s1, s2) => s1 + "," + s2);

        var resultadosCount = cursos.Count();
        var resultadosCount2 = cursos.Where(c => c.Contains('P')).Count();
        var resultadosCount3 = cursos.Count(c => c.Contains('P'));

        Console.WriteLine(resultadosCount);
        Console.WriteLine(resultadosCount2);
        Console.WriteLine(resultadosCount3);
        Console.WriteLine(resultadoAG);

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

        int resultadoSum = numerosSum.Where(n => n > 5).Sum();
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

        Console.WriteLine($"{maiorIdade} - {maiorSalario}");
        Console.WriteLine($"Menor idade {menorIdade} Menor salario - {menorSalario}");
        Console.WriteLine($"Maior salario filtrado entre idades: {maxSalario}");
        Console.WriteLine($"Salario filtrado menor: {menorSalarioFiltrado}");
    }
}
