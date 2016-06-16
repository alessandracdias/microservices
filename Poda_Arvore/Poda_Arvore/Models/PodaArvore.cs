using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Poda_Arvore.Models
{
    public class PodaArvore
    {
        public int Id { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public DateTime Data { get; set; }
    }
}