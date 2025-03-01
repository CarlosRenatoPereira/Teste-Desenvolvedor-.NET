using CarlosRenatoPereiraTeste.Models;
using CarlosRenatoPereiraTeste.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarlosRenatoPereiraTeste.Controllers
{
    public class InscricaoController : ApiController
    {
        private readonly Services.InscricaoService inscricao = new Services.InscricaoService();

        [Route("api/Inscricao/get/{id}")]
        [HttpGet]
        public Inscricao Pesquisar(int id)
        {
            return inscricao.Pesquisar(id);
        }

        [Route("api/Inscricao/post")]
        [HttpPost]
        public string Gravar([FromBody] Inscricao payload)
        {
            return inscricao.Gravar(payload);
        }

        [Route("api/Inscricao/put")]
        [HttpPut]
        public string Atualizar([FromBody] Inscricao payload)
        {
            return inscricao.Atualizar(payload);
        }

        [Route("api/Inscricao/delete/{id}")]
        [HttpDelete]
        public string Deletar(int id)
        {
            return inscricao.Deletar(id);
        }

        /// <summary>
        /// Busca inscrições por CPF.
        /// </summary>
        /// <param name="cpf">CPF do candidato.</param>
        /// <returns>Lista de inscrições.</returns>
        [Route("api/Inscricao/pesquisarporCPF/{cpf}")]
        [HttpGet]
        public List<InscricoesCPFPayload> RetornarListaInscricoes(string cpf)
        {
            return inscricao.RetornarListaInscricoes(cpf);
        }

        /// <summary>
        /// Busca inscrições por Id do Curso.
        /// </summary>
        /// <param name="idCurso">Id do Curso.</param>
        /// <returns>Lista de inscrições.</returns>
        [Route("api/Inscricao/pesquisarpoidcurso/{idCurso}")]
        [HttpGet]
        public List<InscricoesCPFPayload> RetornarListaInscricoes(int idCurso)
        {
            return inscricao.RetornarListaInscricoes(idCurso);
        }
    }
}
