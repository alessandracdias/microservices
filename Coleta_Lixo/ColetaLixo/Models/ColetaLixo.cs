using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ColetaLixo.Models
{
    public class ColetaLixo
    {
        public int Id { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public DateTime Data { get; set; }
    }
}