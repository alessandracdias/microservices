using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Construcao_Meio_Fio.Models
{
    public class Construcao_Meio_FioContext : DbContext
    {
        public Construcao_Meio_FioContext() 
                : base("name=Construcao_Meio_FioContext")
        {
        }
       
        public DbSet<ConstrucaoMeioFio> Construcoes { get; set; }
        
    }
}