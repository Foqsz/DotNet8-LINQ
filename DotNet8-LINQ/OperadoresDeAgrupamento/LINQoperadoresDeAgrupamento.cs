using DotNet8_LINQ.Filtrar_Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.OperadoresDeAgrupamento;

public class LINQoperadoresDeAgrupamento
{
    static void Main(string[] args)
    {
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
        var gruposGroup = alunosGroup.GroupBy(s => s.Curso)
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
        var gruposA = alunosGroup.GroupBy(x => new { x.Curso, x.Sexo })
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


    }
}
