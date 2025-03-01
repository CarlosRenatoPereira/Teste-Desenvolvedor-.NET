using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosRenatoPereiraTeste.Models
{
    public class Inscricao
    {
        public int Id { get; set; }
        public string NumeroInscricao { get; set; }
        public DateTime Data { get; set; }
        public int IdCandidato { get; set; }
        public int IdProcessoSeletivo { get; set; }
        public int IdCurso { get; set; }
    }
}