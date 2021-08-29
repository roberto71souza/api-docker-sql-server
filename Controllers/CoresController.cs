using System;
using System.Collections;
using System.Linq;
using DockerCores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DockerCores.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoresController : ControllerBase
    {
        private readonly ILogger<CoresController> _logger;
        private readonly CoresContext _Contexto;

        public CoresController(ILogger<CoresController> logger,CoresContext contexto)
        {
            _Contexto = contexto;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Cores[]> Get()
        {
            var lista = _Contexto.Cores.ToList();
            return Ok(lista.Select(x => x.Nome));
        }
    }
}
