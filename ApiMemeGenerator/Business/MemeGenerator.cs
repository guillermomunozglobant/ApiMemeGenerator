using ApiMemeGenerator.Context;
using ApiMemeGenerator.Entities;
using ApiMemeGenerator.Enum;
using ApiMemeGenerator.ExceptionFilter;
using ApiMemeGenerator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ApiMemeGenerator.Business
{
    public class MemeGenerator : IMemeGenerator
    {
        private readonly AppDBContext appDBContext;
        private string guid;

        public MemeGenerator(AppDBContext dbContext)
        {
            appDBContext = dbContext;
        }

        public Meme GenerarMeme(int idImagen, Dictionary<UbicacionTexto, string> textos)
        {
            if (textos.Count == 0)
                throw new HttpResponseException("No pasaste textos");

            var imagen = appDBContext.Imagen.Find(idImagen);

            if (imagen == null)
                throw new HttpResponseException("La imagen no fue encontrada");


            EscribirTexto(imagen, textos);

            return new Meme()
            {
                Notificacion = "El meme se ha creado con exito"
            ,
            };
        }

        private void EscribirTexto(Imagen imagen,
            Dictionary<UbicacionTexto, string> textos)
        {
            var imageFilePath = imagen.URL;
            var bitmap = (Bitmap)Image.FromFile(imageFilePath);
            foreach (var texto in textos)
            {

                float height = texto.Key switch
                {
                    UbicacionTexto.Arriba => bitmap.Height / 4,
                    UbicacionTexto.Medio => bitmap.Height / 2,
                    UbicacionTexto.UnTercio => bitmap.Height / 3,
                    UbicacionTexto.TresCuarto => (bitmap.Height / 4) * 3,
                    _ => 0f
                };

                PointF firstLocation = new(bitmap.Width / 3, height);

                using Graphics graphics = Graphics.FromImage(bitmap);
                using Font arialFont = new("Arial", 60);
                graphics.DrawString(texto.Value, arialFont, Brushes.White,
                    firstLocation);
            }
            guid = Guid.NewGuid().ToString();
            bitmap.Save(Path.GetFullPath(@"\meme") +
                guid + bitmap.GetType());
        }
    }
}
