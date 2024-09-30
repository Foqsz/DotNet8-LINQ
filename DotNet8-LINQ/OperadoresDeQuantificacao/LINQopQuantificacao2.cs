using DotNet8_LINQ.Filtrar_Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.OperadoresDeQuantificacao;

public class LINQopQuantificacao2
{
    public static void Main(string[] args)
    {
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

        Console.WriteLine($" {existemCursos} {existemCursosMaiorQue2} ");

        List<Aluno> alunos = new List<Aluno>()
        {
            new Aluno() { Nome = "Maria", Pontos = 275 },
            new Aluno() { Nome = "Marta", Pontos = 375 },
            new Aluno() { Nome = "Pedro", Pontos = 299 }
        };

        AlunoComparer alunoComparer = new AlunoComparer();

        var aluno1 = new Aluno() { Nome = "Maria", Pontos = 275 };

        var resultado1 = alunos.Contains(aluno1);

        // Sintaxe de consulta
        var resultado2 = (from num in alunos
                          select num).Contains(aluno1);

        Console.WriteLine($"{resultado1} {resultado2}");

    }
}