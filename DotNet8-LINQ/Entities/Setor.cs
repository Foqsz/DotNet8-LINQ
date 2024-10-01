using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//op juncao (filha)
namespace DotNet8_LINQ.Entities;

public class Setor
{
    public int SetorId { get; set; }
    [MaxLength(80)]
    public string SetorNome { get; set; } = null!;
}
