using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMemeGenerator.Context;
using ApiMemeGenerator.Models;
using Microsoft.AspNetCore.Authorization;
using ApiMemeGenerator.Business;

namespace ApiMemeGenerator.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IService _service;

        public UsuariosController(IService service)
        {
            _service = service;
        }


        // GET: api/Usuarios
        [HttpGet]
        public async Task<IEnumerable<Usuario>> GetUsuario()
        {
            return await _service.GetUsuarios();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<Usuario> GetUsuario(int id)
        {
            return await _service.GetUsuarios(id);
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario Usuario)
        {
            await _service.UpdateUsuario(id, Usuario);

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Usuario> PostUsuario(Usuario Usuario)
        {
            _service.GenerateUsuario(Usuario);

            return CreatedAtAction("GetUsuario", new { id = Usuario.Id }, Usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _service.DeleteUsuario(id);
            return NoContent();
        }

       
    }
}
