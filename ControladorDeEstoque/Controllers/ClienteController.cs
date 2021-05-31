using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControladorDeEstoque.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ControladorDeEstoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private static readonly Cliente[] Clientes = new[]
        {
           new Cliente{
               Id=1,
               Nome="Marcio",
               Cpf="35805880520"
           }
        };

        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return Clientes;
        }
    }
}
