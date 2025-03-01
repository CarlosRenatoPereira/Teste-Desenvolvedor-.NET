using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarlosRenatoPereiraTeste.Models;

namespace CarlosRenatoPereiraTeste.Controllers
{
    public class CursoController : ApiController
    {
        private readonly Services.CursoService curso = new Services.CursoService();

        [Route("api/Curso/get/{id}")]
        [HttpGet]
        public Curso Pesquisar(int id)
        {
            return curso.Pesquisar(id);       
        }

        [Route("api/Curso/post")]
        [HttpPost]
        public string Gravar([FromBody] Curso payload)
        {
            return curso.Gravar(payload);
        }

        [Route("api/Curso/put")]
        [HttpPut]
        public string Atualizar([FromBody] Curso payload)
        {
            return curso.Atualizar(payload);
        }

        [Route("api/Curso/delete/{id}")]
        [HttpDelete]
        public string Deletar(int id)
        {
            return curso.Deletar(id);
        }


    }
}
