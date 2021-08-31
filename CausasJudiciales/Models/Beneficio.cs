using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CausasJudiciales.Models
{
    public class Beneficio
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Numero de Expediente")]
        public int NumeroExpediente { get; set; }
       
        [Display(Name = "Representado")]
        public string Representado { get; set; }
        
        [Display(Name = "Caratula de la Causa")]
        public  string Caratula { get; set; }

        [Display(Name = "Testigos")]
        public string Testigos { get; set; }

        [Display(Name = "Inicio de Demanda")]
        public string InicioDemanda { get; set; }

        [Display(Name = "Traslado")]
        public string Traslado { get; set; }

        [Display(Name = "Se Dicte Sentencia")]
        public string SeDicteSentencia { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Sentencia")]
        public DateTime? Sentencia { get; set; }
        
        [Display(Name = "Regulacion")]
        public string Regulacion { get; set; }

        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

    }
}
