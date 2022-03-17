using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEjercicioPruebas.Models
{
    public class Genero
    {
        public int idGenero { get; set; }
        public string nombre { get; set; }
    }
}
