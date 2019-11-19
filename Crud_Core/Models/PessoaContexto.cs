using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Core.Models
{
    public class PessoaContexto : DbContext
    {
        public PessoaContexto(DbContextOptions<PessoaContexto> options) : base(options)
        {

        }
        public DbSet<PessoaDominio> Pessoas { get; set; }
    }
}
