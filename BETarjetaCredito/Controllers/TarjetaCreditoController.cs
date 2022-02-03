using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BETarjetaCredito.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BETarjetaCredito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaCreditoController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public TarjetaCreditoController(AplicacionDbContext context)
        {
            _context = context;
        }

        // GET: api/<TarjetaCreditoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try {
                var listTarjetas = await _context.TarjetaCredito.ToListAsync();
                return Ok(listTarjetas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<TarjetaCreditoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TarjetaCreditoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                _context.Add(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(tarjeta);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TarjetaCreditoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TarjetaCredito tarjeta)
        {
            try {
                if(id != tarjeta.id)
                {
                    return NotFound();
                }

                _context.Update(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La Tarjeta fue actualizada con exito !!!" });
            
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TarjetaCreditoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarjeta = await _context.TarjetaCredito.FindAsync(id);
                if(tarjeta == null)
                {
                    return NotFound();
                }

                _context.TarjetaCredito.Remove(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarjeta fue eliminada con exito"});
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
