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
    public class DogController : ControllerBase
    {
        private readonly IDogService _dogservice;

        public DogController(IDogService dogservice)
        {
            _dogservice = dogservice;
        }
        // GET: api/<DogController>
        [HttpGet]
        public async Task<IActionResult> GetDog()
        {
            List<Dog> Dogs = null;

            try
            {
                var taskDog = Task.Run(() => _dogservice.GetDog());
                await taskDog;
                Dogs = taskDog.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(Dogs);
        }

        // GET api/<DogController>/5
        [HttpGet("{code}")]
        public async Task<IActionResult> GetDog(int code)
        {
            Dog Dog = null;

            try
            {
                var taskDog = Task.Run(() => _dogservice.GetDog(code));
                await taskDog;
                Dog = taskDog.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(Dog);
        }

        // POST api/<DogController>
        [HttpPost]
        public async Task<IActionResult> InsertDog([FromBody] Dog Dog)
        {
            int code;

            try
            {
                var taskDog = Task.Run(() => _dogservice.InsertDog(Dog));
                await taskDog;
                code = taskDog.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(code);
        }

        // PUT api/<DogController>/5
        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateDog([FromBody] Dog Dog, int code)
        {
            bool result;

            try
            {
                var taskDog = Task.Run(() => _dogservice.UpdateDog(Dog, code));
                await taskDog;
                result = taskDog.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(result);
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteDog(int code)
        {
            bool result;

            try
            {
                var taskDog = Task.Run(() => _dogservice.DeleteDog(code));
                await taskDog;
                result = taskDog.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(result);
        }
    }
}
