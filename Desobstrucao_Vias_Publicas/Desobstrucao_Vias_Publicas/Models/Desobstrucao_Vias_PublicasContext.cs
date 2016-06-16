using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Desobstrucao_Vias_Publicas.Models
{
    public class Desobstrucao_Vias_PublicasContext : DbContext
    {
        public Desobstrucao_Vias_PublicasContext() 
                : base("name=Desobstrucao_Vias_PublicasContext")
        {
        }

        public DbSet<DesobstrucaoViasPublicas> Vias { get; set; }
  
    }
}