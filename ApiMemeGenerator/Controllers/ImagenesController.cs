using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMemeGenerator.Context;
using ApiMemeGenerator.Models;
using ApiMemeGenerator.Auth;
using Microsoft.AspNetCore.Authorization;
using ApiMemeGenerator.Business;

namespace ApiMemeGenerator.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenesController : ControllerBase
    {
        private readonly IService _service;

        public ImagenesController(IService service)
        {
            _service = service;
        }

        // GET: api/Imagenes
        [HttpGet]
        public async Task<IEnumerable<Imagen>> GetImagen()
        {
            return await _service.GetImagenes();
        }

        // GET: api/Imagenes/5
        [HttpGet("{id}")]
        public async Task<Imagen> GetImagen(int id)
        {
            return await _service.GetImagenes(id);
        }

        // PUT: api/Imagenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImagen(int id, Imagen imagen)
        {
            await _service.UpdateImagen(id, imagen);

            return NoContent();
        }

        // POST: api/Imagenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Imagen>> PostImagen(Imagen imagen)
        {
            _service.GenerateImagen(imagen);

            return CreatedAtAction("GetImagen", new { id = imagen.Id }, imagen);
        }

        // DELETE: api/Imagenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagen(int id)
        {
            await _service.DeleteImagen(id);
            return NoContent();
        }

    }
}
