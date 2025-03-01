using CarlosRenatoPereiraTeste.Models;
using CarlosRenatoPereiraTeste.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarlosRenatoPereiraTeste.Controllers
{
    public class ProcessoSeletivoController : ApiController
    {
        private readonly ProcessoSeletivoService processoSeletivo = new Services.ProcessoSeletivoService();

        [Route("api/ProcessoSeletivo/get/{id}")]
        [HttpGet]
        public ProcessoSeletivo Pesquisar(int id)
        {
            return processoSeletivo.Pesquisar(id);
        }

        [Route("api/ProcessoSeletivo/post")]
        [HttpPost]
        public string Gravar([FromBody] ProcessoSeletivo payload)
        {
            return processoSeletivo.Gravar(payload);
        }

        [Route("api/ProcessoSeletivo/put")]
        [HttpPut]
        public string Atualizar([FromBody] ProcessoSeletivo payload)
        {
            return processoSeletivo.Atualizar(payload);
        }

        [Route("api/ProcessoSeletivo/delete/{id}")]
        [HttpDelete]
        public string Deletar(int id)
        {
            return processoSeletivo.Deletar(id);
        }


    }
}
