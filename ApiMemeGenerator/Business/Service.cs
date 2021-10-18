using ApiMemeGenerator.Context;
using ApiMemeGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMemeGenerator.Business
{
    public interface IService
    {
        #region - Imagenes -
        Task<List<Imagen>> GetImagenes();
        Task<Imagen> GetImagenes(int id);
        Task<IActionResult> UpdateImagen(int id, Imagen imagen);
        Task<IActionResult> DeleteImagen(int id);

        void GenerateImagen(Imagen imagen);
        #endregion

        #region - Usuarios -
        Task<List<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuarios(int id);
        Task<IActionResult> UpdateUsuario(int id, Usuario usuario);
        Task<IActionResult> DeleteUsuario(int id);
        void GenerateUsuario(Usuario usuario);
        #endregion
    }
    public class Service : IService
    {

        private readonly AppDBContext _context;
        public Service(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DeleteImagen(int id)
        {
            var imagen = await _context.Imagen.FindAsync(id);
            if (imagen == null)
            {
                return new StatusCodeResult((int)System.Net.HttpStatusCode.NotFound);

            }

            _context.Imagen.Remove(imagen);
            await _context.SaveChangesAsync();

            return new StatusCodeResult((int)System.Net.HttpStatusCode.NoContent);

        }

        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var imagen = await _context.Usuario.FindAsync(id);
            if (imagen == null)
            {
                return new StatusCodeResult((int)System.Net.HttpStatusCode.NotFound);

            }

            _context.Usuario.Remove(imagen);
            await _context.SaveChangesAsync();

            return new StatusCodeResult((int)System.Net.HttpStatusCode.NoContent);
        }

        public async void GenerateImagen(Imagen imagen)
        {
            _context.Imagen.Add(imagen);
            await _context.SaveChangesAsync();
        }

        public async void GenerateUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public Task<List<Imagen>> GetImagenes()
        {
            return _context.Imagen.ToListAsync();
        }

        public async Task<Imagen> GetImagenes(int id)
        {
            var imagen = await _context.Imagen.FindAsync(id);

            return imagen;
        }

        public Task<List<Usuario>> GetUsuarios()
        {
            return _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetUsuarios(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            return usuario;
        }

        public async Task<IActionResult> UpdateImagen(int id, Imagen imagen)
        {
            if (id != imagen.Id)
            {
                return new StatusCodeResult((int)System.Net.HttpStatusCode.NotFound);
            }

            _context.Entry(imagen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagenExists(id))
                {
                    return new StatusCodeResult((int)System.Net.HttpStatusCode.NotFound);

                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult((int)System.Net.HttpStatusCode.NoContent);
        }

        public async Task<IActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return new StatusCodeResult((int)System.Net.HttpStatusCode.NotFound);
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return new StatusCodeResult((int)System.Net.HttpStatusCode.NotFound);

                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult((int)System.Net.HttpStatusCode.NoContent);
        }

        private bool ImagenExists(int id)
        {
            return _context.Imagen.Any(e => e.Id == id);
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
