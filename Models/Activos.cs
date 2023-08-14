using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenComercioElectronico.Models
{
    public class Activos
    {
        [Key]
        public int numeroPlaca { get; set; }

        public int idFuncionario { get; set; }
        public int codigo { get; set; }
        public string descripcion{ get; set; }
        public string marca { get; set; }

        [ForeignKey("idFuncionario")]
        public virtual Funcionarios Funcionarios { get; set; }

        [ForeignKey("codigo")]
        public virtual Departamentos Departamentos { get; set; }
    }
}