using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePratico.Services.Interfaces.Services;
using TestePratico.Services.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestePratico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // GET: api/<OwnerController>
        [HttpGet]
        public async Task<IActionResult> GetFila()
        {
            List<Owner> owners = null;

            try
            {
                var taskOwner = Task.Run(() => _ownerService.GetOwner());
                await taskOwner;
                owners = taskOwner.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(owners);
        }

        // GET api/<OwnerController>/5
        [HttpGet("{code}")]
        public async Task<IActionResult> GetFila(int code)
        {
            Owner owner = null;

            try
            {
                var taskOwner = Task.Run(() => _ownerService.GetOwner(code));
                await taskOwner;
                owner = taskOwner.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(owner);
        }

        
    }
}
