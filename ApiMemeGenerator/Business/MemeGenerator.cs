using ApiMemeGenerator.Context;
using ApiMemeGenerator.Entities;
using ApiMemeGenerator.Enum;
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
                throw new ArgumentException("No pasaste textos");

            var imagen = appDBContext.Imagen.Find(idImagen);

            if (imagen == null)
                throw new Exception("La imagen no fue encontrada");


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

                float height = 0f;
                switch (texto.Key)
                {
                    case UbicacionTexto.Arriba:
                        height = bitmap.Height / 4;
                        break;
                    case UbicacionTexto.Medio:
                        height = bitmap.Height / 2;
                        break;
                    case UbicacionTexto.UnTercio:
                        height = bitmap.Height / 3;
                        break;
                    case UbicacionTexto.TresCuarto:
                        height = (bitmap.Height / 4) * 3;
                        break;
                }

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
