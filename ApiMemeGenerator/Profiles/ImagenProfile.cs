using ApiMemeGenerator.Entities;
using ApiMemeGenerator.Models;
using AutoMapper;

namespace ApiMemeGenerator.Profiles
{
    public class ImagenProfile : Profile
    {
        public ImagenProfile()
        {
            CreateMap<Imagen, Meme>();
        }
    }
}
