using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Poda_Arvore.Models
{
    public class Poda_ArvoreContext : DbContext
    {
        public Poda_ArvoreContext() 
                : base("name=Poda_ArvoreContext")
        {
        }
        public DbSet<PodaArvore> Arvores { get; set; }
        
        
    }
}