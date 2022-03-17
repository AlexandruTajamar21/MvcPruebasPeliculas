using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEjercicioPruebas.Models
{
    public class Pelicula
    {
        public int idPelicula { get; set; }
        public int idDistribuidor { get; set; }
        public int idGenero { get; set; }
        public string titulo { get; set; }
        public int idNacionalidad { get; set; }
        public string argumento { get; set; }
        public string foto { get; set; }
        public DateTime fechaEstreno { get; set; }
        public string actores { get; set; }
        public string duracion { get; set; }
    }
}
