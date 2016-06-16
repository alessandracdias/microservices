using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IPTU.Models
{
    public class IPTUContext : DbContext
    {
        public IPTUContext() 
                : base("name=IPTUContext")
        {
        }

        public DbSet<Iptu> IPTU { get; set; }
       
        
    }
}