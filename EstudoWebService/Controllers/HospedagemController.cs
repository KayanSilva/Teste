using EstudoWebService.DAO;
using EstudoWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EstudoWebService.Controllers
{
    public class HospedagemController : ApiController
    {
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var dao = new HospedagemDAO();
                var carrinho = dao.Busca(id);
                return Request.CreateResponse(HttpStatusCode.OK, carrinho);
            }
            catch (KeyNotFoundException)
            {
                var mensagem = string.Format("A hospedagem {0} não foi encontrado", id);
                var error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        public HttpResponseMessage Post([FromBody] Hospedagem hospedagem)
        {
            HospedagemDAO dao = new HospedagemDAO();
            dao.Adiciona(hospedagem);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { controller = "hospedagem", id = hospedagem.Id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        [Route("api/hospedagem/{idHospedagem}/cliente/{idCliente}")]
        public HttpResponseMessage Delete([FromUri] int idHospedagem, [FromUri] int idCliente)
        {
            var dao = new HospedagemDAO();
            var hospedagem = dao.Busca(idHospedagem);
            hospedagem.Remove(idCliente);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/hospedagem/{idHospedagem}/cliente/{idCliente}/quantidade")]
        public HttpResponseMessage Put([FromBody]Cliente cliente, [FromUri] int idHospedagem, [FromUri] int idCliente)
        {
            var dao = new HospedagemDAO();
            var hospedagem = dao.Busca(idHospedagem);

            hospedagem.TrocaQuantidade(cliente);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
