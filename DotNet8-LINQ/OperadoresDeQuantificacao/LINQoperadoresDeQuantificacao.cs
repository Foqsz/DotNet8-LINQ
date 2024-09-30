using DotNet8_LINQ.Filtrar_Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.OperadoresDeQuantificacao;

internal class LINQoperadoresDeQuantificacao
{
    public static void Main(string[] args)
    {
        int[] numerosQuant = { 10, 22, 32, 44, 56, 64, 78 };

        var resultadoQuant = numerosQuant.All(n => n % 2 == 0);

        var resultadoQuant2 = (from n in numerosQuant select n).All(n => n % 2 == 0);

        Console.WriteLine(resultadoQuant);
        Console.WriteLine(resultadoQuant2);

        var funcionarioAll = FonteDeDados.GetFuncionarios();

        var todosSalariosAcima2500 = funcionarioAll.All(f => f.Salario > 2500.00m);

        var todosIdadeMaiorQ21 = funcionarioAll.All(f => f.Idade > 21);

        var todosNomesTemLetraA = funcionarioAll.All(f => f.Nome.Contains('a'));

        Console.WriteLine($"{todosSalariosAcima2500} - {todosIdadeMaiorQ21} - {todosNomesTemLetraA}");

        var resultadoConsulta = (from n in funcionarioAll select n).All(n => n.Salario > 250);

        Console.WriteLine($"{(resultadoConsulta ? "Todos os salários são maior que 2500" : "Nem todos são maiores que 2500")}");
    }

}
