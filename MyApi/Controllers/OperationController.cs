using MyApi.Data.Repositories.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Controllers
{
    [RoutePrefix("api/operacoes")]
    public class OperationController : ApiController
    {
        private readonly IOperationRepository _operationRepository;

        public OperationController(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        [HttpGet]
        [Route("totais")]
        public HttpResponseMessage GetTotals([FromUri] string inicio, [FromUri] string fim)
        {
            try
            {
                var result = _operationRepository.GetTotalByDate(DateTime.Parse(inicio), DateTime.Parse(fim));

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Success = false,
                    Data = result
                });
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    Success = false,
                    Error = exception,
                    Data = new object[] { }
                });
            }
        }
    }
}
