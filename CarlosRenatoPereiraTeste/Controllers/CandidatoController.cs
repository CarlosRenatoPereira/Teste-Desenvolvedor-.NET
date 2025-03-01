using CarlosRenatoPereiraTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarlosRenatoPereiraTeste.Controllers
{
    public class CandidatoController : ApiController
    {
        private readonly Services.CandidatoService candidato = new Services.CandidatoService();

        [Route("api/Candidato/get/{id}")]
        [HttpGet]
        public Candidato Pesquisar(int id)
        {
            return candidato.Pesquisar(id);       
        }

        [Route("api/Candidato/post")]
        [HttpPost]
        public string Gravar([FromBody] Candidato payload)
        {
            return candidato.Gravar(payload);
        }

        [Route("api/Candidato/put")]
        [HttpPut]
        public string Atualizar([FromBody] Candidato payload)
        {
            return candidato.Atualizar(payload);
        }

        [Route("api/Candidato/delete/{id}")]
        [HttpDelete]
        public string Deletar(int id)
        {
            return candidato.Deletar(id);
        }


    }
}
