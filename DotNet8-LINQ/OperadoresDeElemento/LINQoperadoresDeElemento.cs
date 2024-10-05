using DotNet8_LINQ.Filtrar_Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.OperadoresDeElemento
{
    public class LINQoperadoresDeElemento
    {
        static void Main2(string[] args)
        {
            Console.WriteLine("LIN");
            Console.WriteLine("Operadores de Elemento");

            List<int> numerosNew = new List<int>() { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            int resultadoNew = numerosNew.ElementAtOrDefault(5);
            Console.WriteLine(resultadoNew);

            var alunoNew = FonteDeDados.GetAlunosAtt().ElementAtOrDefault(5);
            Console.WriteLine($"\n{alunoNew.Id} {alunoNew.Nome} {alunoNew.CursoId}");

            var nomeAluno = FonteDeDados.GetAlunosAtt().Select(a => a.Nome).ElementAtOrDefault(5);
            Console.WriteLine($"\n{nomeAluno}");
        }
    }
}
