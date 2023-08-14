using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenComercioElectronico.Models
{
    public class Departamentos
    {
        [Key]
        public int codigo { get; set; }
        [DisplayName("Departamento")]
        public string nombre { get; set; }
        public string ubicacion { get; set; }
    }
}