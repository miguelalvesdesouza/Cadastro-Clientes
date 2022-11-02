using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CadastroClientes.Application;
using CadastroClientes.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CadastroClientes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ClienteService clienteService;

        public ClienteController(IDbConnection dbConnection, IConfiguration configuration)
        {
            this.configuration = configuration;
            clienteService = new ClienteService(dbConnection);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var clientes = clienteService.GetAll();
                if(clientes == null)
                    return NoContent();

                
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar clientes. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var clientes = clienteService.GetById(id);
                if(clientes == null)
                    return NoContent();

                
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar clientes. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        { 
            try
            {
                var clientes = clienteService.Create(cliente);
                if(clientes == null)
                    return NoContent();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar clientes. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Cliente cliente)
        {
            try
            {
                var clientes = clienteService.Update(cliente);
                if(clientes == null)
                    return NoContent();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar clientes. Erro: {ex.Message}");
            }
        }


    }
}