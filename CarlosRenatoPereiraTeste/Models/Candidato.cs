using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosRenatoPereiraTeste.Models
{
    public class Candidato
    {       
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
    }
}