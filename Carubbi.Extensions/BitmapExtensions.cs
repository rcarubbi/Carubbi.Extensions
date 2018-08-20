﻿using System;
using System.Drawing;

namespace Carubbi.Extensions
{

    /// <summary>
    /// Extension Methods para a classe Bitmap
    /// </summary>
    public static class BitmapExtensions
    {
        /// <summary>
        /// Converte um array de bytes em um bitmap
        /// </summary>
        /// <param name="instance">Objeto a ser convertido</param>
        /// <returns>Bitmap convertido</returns>
        public static Bitmap ToBitmap(this byte[] instance)
        {
            var ic = new ImageConverter();
            var img = (Image)ic.ConvertFrom(instance);
            var bitmap = new Bitmap(img ?? throw new InvalidOperationException());
            return bitmap;
        }


        /// <summary>
        /// Converte um Bitmap em byte array
        /// </summary>
        /// <param name="instance">Bitmap a ser convertido</param>
        /// <returns>byte array convertido</returns>
        public static byte[] ToByteArray(this Bitmap instance)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(instance, typeof(byte[]));
        }

        /// <summary>
        /// Recorta uma imagem a partir das coordenadas do retangulo informado
        /// </summary>
        /// <param name="source">Bitmap a ser recortado</param>
        /// <param name="section">Retangulo com as coordenadas do recorte</param>
        /// <returns>byte arrah da imagem recortada</returns>
        public static byte[] Crop(this Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            var bmp = new Bitmap(section.Width, section.Height);

            var g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp.ToByteArray();
        }

        


    }
}
