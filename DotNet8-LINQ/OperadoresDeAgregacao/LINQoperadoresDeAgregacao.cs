using DotNet8_LINQ.Filtrar_Dados;
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
    }
}
