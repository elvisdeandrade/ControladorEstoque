using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControladorDeEstoque.Controllers.Models;
using ControladorDeEstoque.Controllers.Models.InputModels;
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
               Id = 1,
               Nome = "Marcio",
               Cpf = "358.058.805-20"
           },
           new Cliente{
               Id = 2,
               Nome = "Elvis",
               Cpf = "646.112.489-68"
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

        [HttpPost]
        public IActionResult AddCliente([FromBody] ClienteInputModel cliente)
        {
            var clienteParaSalvar = new Cliente();

            try
            {
                clienteParaSalvar.Cpf = cliente.Cpf;
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //TODO: Salvar no banco

            return Ok(clienteParaSalvar);
        }
    }
}
