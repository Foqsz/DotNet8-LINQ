using DotNet8_LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8_LINQ.Context;

public class SeedDatabase
{
    public static void PopulaDB(AppDbContext contexto)
    {
        contexto.Database.EnsureCreated();

        if (!contexto.Funcionarios.Any())
        {
            var setor1 = new Setor
            {
                SetorNome = "Recursos Humanos",
            };
            contexto.Setores.Add(setor1);

            var funcionarios1 = new List<Funcionario>
            {
               new Funcionario { FuncionarioNome="Marisa Monte",
                                 FuncionarioCargo="Gerente", SetorId= 1},
               new Funcionario { FuncionarioNome="Janice Ribeiro",
                                 FuncionarioCargo="Administrativo", SetorId= 1},
               new Funcionario { FuncionarioNome="Fernando Alves",
                                 FuncionarioCargo="Recrutador", SetorId= 1},
               new Funcionario { FuncionarioNome="Sara Souza",
                                 FuncionarioCargo="Assistente de RH", SetorId= 1}
            };

            contexto.Funcionarios.AddRange(funcionarios1);

            var setor2 = new Setor
            {
                SetorNome = "Contabilidade",
            };
            contexto.Setores.Add(setor2);
            var funcionarios2 = new List<Funcionario>
            {
                 new Funcionario { FuncionarioNome="Pedro Toledo",
                                   FuncionarioCargo="Gerente", SetorId=2},
                 new Funcionario { FuncionarioNome="Andre Sanches",
                                   FuncionarioCargo="Contador", SetorId=2},
                 new Funcionario { FuncionarioNome="Hilda Hinst",
                                   FuncionarioCargo="Diretora", SetorId=2},
                 new Funcionario { FuncionarioNome="Bruna Xavier",
                                   FuncionarioCargo="Analista Financeiro", SetorId=2}
            };
            contexto.Funcionarios.AddRange(funcionarios2);

            var setor3 = new Setor
            {
                SetorNome = "Marketing",
            };
            contexto.Setores.Add(setor3);
            var funcionarios3 = new List<Funcionario>
            {
                    new Funcionario { FuncionarioNome="Ana Maria Lima",
                                      FuncionarioCargo="Gerente", SetorId=3},
                    new Funcionario { FuncionarioNome="Carlos Ribeiro",
                                      FuncionarioCargo="Designer", SetorId=3},
                    new Funcionario { FuncionarioNome="Jaime Lacuste",
                                      FuncionarioCargo="CEO", SetorId=3},
                    new Funcionario { FuncionarioNome="Beatriz Garcia",
                                      FuncionarioCargo="Analista de Marketing", SetorId=3},
                    new Funcionario { FuncionarioNome="Lucas Silva",
                                      FuncionarioCargo="Estagiário de Marketing", SetorId=3}
            };

            contexto.Funcionarios.AddRange(funcionarios3);

            var setor4 = new Setor
            {
                SetorNome = "Tecnologia",
            };
            contexto.Setores.Add(setor4);
            var funcionarios4 = new List<Funcionario>
            {
                new Funcionario { FuncionarioNome="Ricardo Borges",
                                  FuncionarioCargo="Desenvolvedor Full Stack", SetorId=4},
                new Funcionario { FuncionarioNome="Gabriela Costa",
                                  FuncionarioCargo="Desenvolvedora Mobile", SetorId=4},
                new Funcionario { FuncionarioNome="Maurício Lima",
                                  FuncionarioCargo="Gerente de TI", SetorId=4},
                new Funcionario { FuncionarioNome="Marina Oliveira",
                                  FuncionarioCargo="Suporte Técnico", SetorId=4}
            };

            contexto.Funcionarios.AddRange(funcionarios4);

            var setor5 = new Setor
            {
                SetorNome = "Logística",
            };
            contexto.Setores.Add(setor5);
            var funcionarios5 = new List<Funcionario>
            {
                new Funcionario { FuncionarioNome="Julio Fernandes",
                                  FuncionarioCargo="Supervisor de Logística", SetorId=5},
                new Funcionario { FuncionarioNome="Isabela Santos",
                                  FuncionarioCargo="Motorista", SetorId=5},
                new Funcionario { FuncionarioNome="Thiago Pereira",
                                  FuncionarioCargo="Auxiliar de Expedição", SetorId=5}
            };

            contexto.Funcionarios.AddRange(funcionarios5);

            contexto.SaveChanges();
        }
    }
}