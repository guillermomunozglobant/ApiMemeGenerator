using ApiMemeGenerator.Business;
using ApiMemeGenerator.Context;
using ApiMemeGenerator.Entities;
using ApiMemeGenerator.Enum;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public MemeGeneratorController(AppDBContext context, 
            IMemeGenerator memeGenerator, IMapper mapper)
        {
            _context = context;
            _memeGenerator = memeGenerator;
            _mapper = mapper;
        }

        [HttpPost]
        public Meme Post(int idImagen, [FromBody] Dictionary<UbicacionTexto, string> textos)
        {
           if(idImagen==0 || textos.Count == 0)
            {
                throw new System.Exception("No pasaste datos");
            }
            return _mapper.Map<Meme>(_memeGenerator.GenerarMeme(idImagen,textos));
        }
    }
}
