using DotNet8_LINQ.Entities;
using DotNet8_LINQ.FiltrarDados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funcionario = DotNet8_LINQ.Entities.Funcionario;

namespace DotNet8_LINQ.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //define o provedor do BD e a string de conexão
        optionsBuilder.UseSqlServer("Server=localhost; Initial Catalog=Northwind; Integrated Security=True; Trusted_Connection=true; TrustServerCertificate=True");
        
        //exibe as consultas SQL no console
        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }

    //mapeia as entidades para as tabelas do BD
    public DbSet<Setor> Setores { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
}
