using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ColetaLixo.Models
{
    public class ColetaLixoContext : DbContext
    {
        public ColetaLixoContext() 
                : base("name=ColetaLixoContext")
        {
        }
        public DbSet<ColetaLixo> Coletas { get; set; }

        
    }
}