using ApiMemeGenerator.Entities;
using ApiMemeGenerator.Enum;
using ApiMemeGenerator.Models;
using System.Collections.Generic;

namespace ApiMemeGenerator.Business
{
    public interface IMemeGenerator
    {
        Imagen GenerarMeme(int idImagen, Dictionary<UbicacionTexto, string> textos);
    }
}
