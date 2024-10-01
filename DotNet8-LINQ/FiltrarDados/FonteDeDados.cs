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



}
