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
    public class CatController : ControllerBase
    {
        private readonly ICatService _catservice;

        public CatController(ICatService catservice)
        {
            _catservice = catservice;
        }
        // GET: api/<CatController>
        [HttpGet]
        public async Task<IActionResult> GetCat()
        {
            List<Cat> cats = null;

            try
            {
                var taskCat = Task.Run(() => _catservice.GetCat());
                await taskCat;
                cats = taskCat.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(cats);
        }

        // GET api/<CatController>/5
        [HttpGet("{code}")]
        public async Task<IActionResult> GetCat(int code)
        {
            Cat cat = null;

            try
            {
                var taskCat = Task.Run(() => _catservice.GetCat(code));
                await taskCat;
                cat = taskCat.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(cat);
        }

        // POST api/<CatController>
        [HttpPost]
        public async Task<IActionResult> InsertCat([FromBody] Cat cat)
        {
            int code;

            try
            {
                var taskCat = Task.Run(() => _catservice.InsertCat(cat));
                await taskCat;
                code = taskCat.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(code);
        }

        // PUT api/<CatController>/5
        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateCat([FromBody] Cat cat, int code)
        {
            bool result;

            try
            {
                var taskCat = Task.Run(() => _catservice.UpdateCat(cat, code));
                await taskCat;
                result = taskCat.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(result);
        }

        // DELETE api/<CatController>/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteCat(int code)
        {
            bool result;

            try
            {
                var taskCat = Task.Run(() => _catservice.DeleteCat(code));
                await taskCat;
                result = taskCat.Result;
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
            return Ok(result);
        }
    }
}
