using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosRenatoPereiraTeste.Payloads
{
    public class InscricoesCPFPayload
    {
        public int Id { get; set; }
        public string NumeroInscricao { get; set; }
        public DateTime Data { get; set; }
        public string NomeCandidato { get; set; }
        public string Curso { get; set; }
        public string NomeProcessoSeletivo { get; set; }
    }
}