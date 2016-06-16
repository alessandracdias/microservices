using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IPTU.Models
{
    public class Iptu
    {
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}