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
            new Aluno() { Nome = "Maria", Idade = 42, Nota = 7, Cursos = new List<string> { "VB.NET", "ASPNET" } },
            new Aluno() { Nome = "Manoel", Idade = 34, Nota = 8, Cursos = new List<string> { "C#", "SQL" } },
            new Aluno() { Nome = "Amanda", Idade = 21, Nota = 5, Cursos = new List<string> { "Java", "HTML" } },
            new Aluno() { Nome = "Carlos", Idade = 18, Nota = 10, Cursos = new List<string> { "Python", "CSS" } },
            new Aluno() { Nome = "Alicia", Idade = 15, Nota = 9, Cursos = new List<string> { "JavaScript", "PHP" } }
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
}
