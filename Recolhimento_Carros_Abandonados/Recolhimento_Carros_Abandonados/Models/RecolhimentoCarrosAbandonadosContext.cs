using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Recolhimento_Carros_Abandonados.Models
{
    public class Recolhimento_Carros_AbandonadosContext : DbContext
    {
        public Recolhimento_Carros_AbandonadosContext() 
                : base("name=Recolhimento_Carros_AbandonadosContext")
        {
        }

        public DbSet<RecolhimentoCarrosAbandonados> Carros { get; set; }
        
    }
}