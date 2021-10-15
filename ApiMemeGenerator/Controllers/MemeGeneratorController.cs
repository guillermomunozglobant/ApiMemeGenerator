using ApiMemeGenerator.Business;
using ApiMemeGenerator.Context;
using ApiMemeGenerator.Entities;
using ApiMemeGenerator.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMemeGenerator.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MemeGeneratorController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IMemeGenerator _memeGenerator;

        public MemeGeneratorController(AppDBContext context, IMemeGenerator memeGenerator)
        {
            _context = context;
            _memeGenerator = memeGenerator;
        }

        [HttpPost]
        public Meme Post(int idImagen, [FromBody] Dictionary<UbicacionTexto, string> textos)
        {
           if(idImagen==0 || textos.Count == 0)
            {
                throw new System.Exception("No pasaste datos");
            }
            return _memeGenerator.GenerarMeme(idImagen,textos);
        }
    }
}
