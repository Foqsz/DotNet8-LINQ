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

            int resultadoLast = numerosNew.Last();
            Console.WriteLine(resultadoLast);

            int resultadoLast2 = numerosNew.Last(num => num < 50);
            Console.WriteLine(resultadoLast2);

            List<int> numerosLast = new List<int>() { };
            int resultadoLast3 = numerosNew.Last();
            Console.WriteLine(resultadoLast3);

            int resultadoLast5 = numerosNew.LastOrDefault(num => num > 90);
            Console.WriteLine(resultadoLast5);

            int resultadoLast4 = numerosNew.Last(num => num > 90);
            Console.WriteLine(resultadoLast4);

            int resultadoLast6 = numerosNew.Last(num => num < 90);
            Console.WriteLine(resultadoLast6);

            int resultadoSingle = numerosNew.SingleOrDefault(n => n > 90);
            Console.WriteLine(resultadoSingle);

        }
    }
}
