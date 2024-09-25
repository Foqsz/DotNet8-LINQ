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

        }
    } 
}