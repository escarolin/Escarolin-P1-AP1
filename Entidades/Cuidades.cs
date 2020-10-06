using System;
using System.ComponentModel.DataAnnotations;

namespace Escarolin_P1_AP1.Entidades{
    public class Cuidades{
        [Key]
        public int CuidadId { get; set; }

        public string Nombre { get; set; }

    }
}