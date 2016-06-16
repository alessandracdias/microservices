using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Desobstrucao_Corregos.Models
{
    public class Desobstrucao_CorregosContext : DbContext
    {
        public Desobstrucao_CorregosContext() 
                : base("name=Desobstrucao_CorregosContext")
        {
        }
   
        public DbSet<DesobstrucaoCorregos> Corrregos { get; set; }
      
    }
}