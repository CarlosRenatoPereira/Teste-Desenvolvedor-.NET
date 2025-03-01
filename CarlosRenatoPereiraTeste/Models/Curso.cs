using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosRenatoPereiraTeste.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int VagasDisponiveis { get; set; }
    }
}