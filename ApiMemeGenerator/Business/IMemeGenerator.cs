using ApiMemeGenerator.Entities;
using ApiMemeGenerator.Enum;
using System.Collections.Generic;

namespace ApiMemeGenerator.Business
{
    public interface IMemeGenerator
    {
        Meme GenerarMeme(int idImagen, Dictionary<UbicacionTexto, string> textos);
    }
}
