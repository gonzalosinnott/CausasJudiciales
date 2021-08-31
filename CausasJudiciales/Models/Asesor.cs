using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CausasJudiciales.Models
{
    public class Asesor
    {
        [Key]
        public int Id { get; set; }
        
        public int NumeroExpediente { get; set; }
       
        [Display(Name = "Representado")]
        public string Representado { get; set; }
        
        [Display(Name = "Caratula de la Causa")]
        public  string Caratula { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de aceptacion de Cargo")]
        public DateTime? AceptaCargo { get; set; }
        
        [Display(Name = "Actuacion")]
        public string Actuacion { get; set; }

        [Display(Name = "Regulacion")]
        public string Regulacion { get; set; }

        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

    }
}
