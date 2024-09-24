using DotNet8_LINQ.Filtrar_Dados;
using System;

namespace DotNet8_LINQ.Operadores_De_Projecao
{
    class LINQprojecao
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ");
            Console.WriteLine("Operadores de Projeção");

            //Sintaxe de método
            IEnumerable<Aluno> alunos = FonteDeDados.GetAlunos().ToList();

            Console.WriteLine("Alunos Notas\n");

            foreach (var aluno in alunos)
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

            //calculo com select

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
        }
    }
}
