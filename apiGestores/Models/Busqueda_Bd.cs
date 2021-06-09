using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Busqueda_Bd
    {
        [Key]
        public int id { get; set; }

        public string ciudad { get; set; }
        public string fecha { get; set; }
    }
}
