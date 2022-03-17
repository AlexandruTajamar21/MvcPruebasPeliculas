using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEjercicioPruebas.Models
{
    public class Nacionalidad
    {
        public int idNacionalidad { get; set; }
        public string nombre { get; set; }
        public string bandera { get; set; }
    }
}
