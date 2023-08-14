using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenComercioElectronico.Models
{
    public class Funcionarios
    {
        [Key]
        public int idFuncionario { get; set; }

        public int codigo { get; set; }

        [DisplayName("Nombre Funcionario")]
        public string nombre { get; set; }

        public DateTime fechaRegistro { get; set; }

        public string rol { get; set; }

        [ForeignKey("codigo")]
        public virtual Departamentos Departamentos { get; set; }
    }
}