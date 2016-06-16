using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Construcao_Meio_Fio.Models
{
    public class ConstrucaoMeioFio
    {
        public int Id { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public DateTime Data { get; set; }
    }
}