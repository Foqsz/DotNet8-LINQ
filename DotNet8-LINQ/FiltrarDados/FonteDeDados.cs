using DotNet8_LINQ.FiltrarDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.Filtrar_Dados;

public class FonteDeDados
{
    public static List<int> GetNumeros()
    {
        List<int> numeros = new List<int>()
        {
            1, 2, 4, 8, 16, 32, 64, 128, 256, 512
        };
        return numeros;
    }

    public static int[] GetIdades()
    {
        var idades = new[] { 30, 33, 35, 36, 40, 30, 33, 36, 30, 40 };
        return idades;
    }

    public static string[] GetNomes()
    {
        var nomes = new[] { "Paulo", "MARIA", "paulo", "Amanda", "maria", "amannda" };
        return nomes;
    }

    public static List<int> GetListaNegra()
    {

        List<int> numeros = new List<int>()
        {
            16, 128, 512
        };
        return numeros;
    }

    public static List<Aluno> GetAlunos()
    {
        List<Aluno> alunos = new()
        {
            new Aluno() { AlunoId = 1, Curso = "Fisica", Nome = "Vitor", Sexo = 'M', Idade = 18 },
            new Aluno() { AlunoId = 2, Curso = "Quimica", Nome = "Jorge", Sexo = 'M', Idade = 21 },
            new Aluno() { AlunoId = 3, Curso = "Engenharia", Nome = "Bernardo", Sexo = 'M', Idade = 18 },
            new Aluno() { AlunoId = 4, Curso = "Moda", Nome = "Danusa", Sexo = 'F', Idade = 19 },
            new Aluno() { AlunoId = 5, Curso = "Moda", Nome = "Carla", Sexo = 'F', Idade = 20 },
            new Aluno() { AlunoId = 6, Curso = "Fisica", Nome = "Helio", Sexo = 'M', Idade = 21 },
            new Aluno() { AlunoId = 7, Curso = "Engenharia", Nome = "Bianca", Sexo = 'F', Idade = 19 },
            new Aluno() { AlunoId = 8, Curso = "Quimica", Nome = "Vilma", Sexo = 'F', Idade = 20 },
            new Aluno() { AlunoId = 9, Curso = "Engenharia", Nome = "Amanda", Sexo = 'F', Idade = 18 },
            new Aluno() { AlunoId = 10, Curso = "Quimica", Nome = "Silvia", Sexo = 'F', Idade = 21 }
        };
        return alunos;
    }

    public static List<Funcionario> GetFuncionarios()
    {
        List<Funcionario> funcionarios = new()
        {
            new Funcionario() { Nome = "Maria", Idade = 22, Salario = 3290.55m },
            new Funcionario() { Nome = "Manoel", Idade = 24, Salario = 4125.45m },
            new Funcionario() { Nome = "Amanda", Idade = 21, Salario = 5123.99m },
            new Funcionario() { Nome = "Carlos", Idade = 18, Salario = 6200.50m },
            new Funcionario() { Nome = "Alicia", Idade = 17, Salario = 4099.11m },
        };
        return funcionarios;
    }

    public static List<Aluno> GetTurmaA()
    {
        List<Aluno> alunos = new()
        {
            new Aluno() { Nome = "Maria",   Idade = 36, Nascimento = new DateTime(2001, 6, 11)},
            new Aluno() { Nome = "Manoel",  Idade = 33, Nascimento = new DateTime(2000, 2, 10)},
            new Aluno() { Nome = "Amanda",  Idade = 21, Nascimento = new DateTime(1986, 9, 30)},
            new Aluno() { Nome = "Carlos",  Idade = 18, Nascimento = new DateTime(1999, 10, 11)},
            new Aluno() { Nome = "Jaime",   Idade = 36, Nascimento = new DateTime(1988, 9, 15)}
        };
        return alunos;
    }

    public static List<Aluno> GetTurmaB()
    {
        List<Aluno> alunos = new()
        {
            new Aluno() { Nome = "Homero",  Idade = 26, Nascimento = new DateTime(1988, 9, 15)},
            new Aluno() { Nome = "Silvia",  Idade = 31, Nascimento = new DateTime(2001, 9, 30)},
            new Aluno() { Nome = "Felicio", Idade = 21, Nascimento = new DateTime(1986, 9, 30)},
            new Aluno() { Nome = "Carlos",  Idade = 18, Nascimento = new DateTime(2002, 8, 15)},
            new Aluno() { Nome = "Alfredo", Idade = 33, Nascimento = new DateTime(1999, 10, 11)},
            new Aluno() { Nome = "Denize",  Idade = 30, Nascimento = new DateTime(2004, 11, 5)}
        };
        return alunos;
    }

    public static List<Aluno> GetAlunosAtt()
    {
        List<Aluno> alunos = new()
        {
        new Aluno() { Id=1, Nome="Maria", EnderecoId=1, CursoId=10 },
        new Aluno() { Id=2, Nome="Manoel", EnderecoId=2, CursoId=20 },
        new Aluno() { Id=3, Nome="Amanda", EnderecoId=3, CursoId=30 },
        new Aluno() { Id=4, Nome="Carlos", EnderecoId=4, CursoId=10 },
        new Aluno() { Id=5, Nome="Jaime", EnderecoId=5, CursoId=00 },
        new Aluno() { Id=6, Nome="Debora", EnderecoId=6, CursoId=40 },
        new Aluno() { Id=7, Nome="Alicia", EnderecoId=7, CursoId=10 },
        new Aluno() { Id=8, Nome="Sandra", EnderecoId=8, CursoId=00 },
        new Aluno() { Id=9, Nome="Marta", EnderecoId=3, CursoId=00 },
        new Aluno() { Id=10, Nome="Sueli", EnderecoId=2, CursoId=30 }
        };
        return alunos;
    }

    public static List<Endereco> GetEnderecos()
    {
        List<Endereco> enderecos = new()
        {
        new Endereco() { Id=1, Local="R. México 1004" },
        new Endereco() { Id=2, Local="Pça Miranda 12" },
        new Endereco() { Id=3, Local="Av. da Luz 290" },
        new Endereco() { Id=4, Local="R. Projetada 33" },
        new Endereco() { Id=5, Local="R. Mirassol 11" },
        new Endereco() { Id=6, Local="Av. da Saudade 43" },
        new Endereco() { Id=7, Local="Av. Felicidade 77" },
        new Endereco() { Id=8, Local="R. Equador 90" }
        };
        return enderecos;
    }

    public static List<Curso> GetCursos()
    {
        List<Curso> cursos = new()
    {
        new Curso() { Id=10, Nome="CSharp" },
        new Curso() { Id=20, Nome="Node" },
        new Curso() { Id=30, Nome="Java" },
        new Curso() { Id=40, Nome="Phyton" }
    };
        return cursos;
    }



    public static List<Pessoa> GetPessoas()
    {
        List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Maria",
                Cachorros = new Cachorro[] {
                    new Cachorro { Nome="Bilu", Idade=10 },
                    new Cachorro { Nome="Pipoca", Idade=14 },
                    new Cachorro { Nome="Negão", Idade=6 }}},

            new Pessoa { Nome = "Fernando",
                Cachorros = new Cachorro[] {
                    new Cachorro { Nome = "Canelinha", Idade = 1 }}},

            new Pessoa { Nome = "Amanda",
                Cachorros = new Cachorro[] {
                    new Cachorro { Nome = "Bisteca", Idade = 8 }}},

            new Pessoa { Nome = "Patricia",
                Cachorros = new Cachorro[] {
                    new Cachorro { Nome = "Acerola", Idade = 2 },
                    new Cachorro { Nome = "Mel", Idade = 13 }}}
        };
        return pessoas;
    }

    public static List<Aluno> GetAlunosNew()
    {
        return new List<Aluno>()
        {
            new Aluno() { Id = 1, Nome = "Pedro", Curso = "Java" },
            new Aluno() { Id = 2, Nome = "Amélia", Curso = "Node" },
            new Aluno() { Id = 3, Nome = "Marta", Curso = "C#" },
            new Aluno() { Id = 4, Nome = "Samara", Curso = "SQL" },
            new Aluno() { Id = 5, Nome = "Silvio", Curso = "Java" },
            new Aluno() { Id = 6, Nome = "Carlos", Curso = "SQL" },
            new Aluno() { Id = 7, Nome = "Helena", Curso = "C#" },
            new Aluno() { Id = 8, Nome = "Renato", Curso = "Phyton" },
            new Aluno() { Id = 9, Nome = "Tânia", Curso = "Node" },
            new Aluno() { Id = 10, Nome = "Bia", Curso = "Python" },
            new Aluno() { Id = 11, Nome = "José", Curso = "Java" },
            new Aluno() { Id = 12, Nome = "Ana", Curso = "C#" },
            new Aluno() { Id = 13, Nome = "Debora", Curso = "PHP" },
            new Aluno() { Id = 14, Nome = "Marcos", Curso = "Phyton" },
            new Aluno() { Id = 15, Nome = "Luis", Curso = "PHP" },
            new Aluno() { Id = 16, Nome = "Dina", Curso = "C#" }
        }; 
    }

}
