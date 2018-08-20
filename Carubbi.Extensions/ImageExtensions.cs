using System;
using System.Drawing.Imaging;

namespace Carubbi.Extensions
{

    /// <summary>
    /// Extension Methods da classe Image
    /// </summary>
    public static class ImageExtensions
    {
        /// <summary>
        /// Recupera o ImageFormat a partir do RawFormat da imagem
        /// </summary>
        /// <param name="img">Image a ser verificado</param>
        /// <returns>Item do enum ImageFormat</returns>
        public static ImageFormat GetImageFormat(this System.Drawing.Image img)
        {
            if (img.RawFormat.Equals(ImageFormat.Jpeg))
                return ImageFormat.Jpeg;
            if (img.RawFormat.Equals(ImageFormat.Bmp))
                return ImageFormat.Bmp;
            if (img.RawFormat.Equals(ImageFormat.Png))
                return ImageFormat.Png;
            if (img.RawFormat.Equals(ImageFormat.Emf))
                return ImageFormat.Emf;
            if (img.RawFormat.Equals(ImageFormat.Exif))
                return ImageFormat.Exif;
            if (img.RawFormat.Equals(ImageFormat.Gif))
                return ImageFormat.Gif;
            if (img.RawFormat.Equals(ImageFormat.Icon))
                return ImageFormat.Icon;
            if (img.RawFormat.Equals(ImageFormat.MemoryBmp))
                return ImageFormat.MemoryBmp;

            return img.RawFormat.Equals(ImageFormat.Tiff) ? ImageFormat.Tiff : ImageFormat.Wmf;
        }

        /// <summary>
        /// Recupera a extensão padrão do arquivo a partir de seu image format
        /// </summary>
        /// <param name="imageFormat">Enum ImageFormat</param>
        /// <returns>extensão do arquivo</returns>
        public static string GetExtension(this ImageFormat imageFormat)
        {
            if (Equals(imageFormat, ImageFormat.Bmp))
            {
                return "bmp";
            }

            if (Equals(imageFormat, ImageFormat.Emf))
            {
                return "emf";
            }

            if (Equals(imageFormat, ImageFormat.Exif))
            {
                return "exif";
            }

            if (Equals(imageFormat, ImageFormat.Gif))
            {
                return "gif";
            }

            if (Equals(imageFormat, ImageFormat.Icon))
            {
                return "ico";
            }

            if (Equals(imageFormat, ImageFormat.Jpeg))
            {
                return "jpg";
            }

            if (Equals(imageFormat, ImageFormat.MemoryBmp))
            {
                return "bmp";
            }

            if (Equals(imageFormat, ImageFormat.Png))
            {
                return "png";
            }

            if (Equals(imageFormat, ImageFormat.Tiff))
            {
                return "tiff";
            }

            return Equals(imageFormat, ImageFormat.Wmf) ? "wmf" : string.Empty;
        }

        /// <summary>
        /// Recupera o formato da imagem a partir da extensão
        /// </summary>
        /// <param name="extension">extensão do arquivo</param>
        /// <returns>Objeto ImageFormat</returns>
        public static ImageFormat GetImageFormat(this string extension)
        {
            extension = extension.Trim().ToLower();

            switch (extension)
            {
                case "bmp":
                    return ImageFormat.Bmp;
                case "emf":
                    return ImageFormat.Emf;
                case "exif":
                    return ImageFormat.Exif;
                case "gif":
                    return ImageFormat.Gif;
                case "ico":
                    return ImageFormat.Icon;
                case "jpg":
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "png":
                    return ImageFormat.Png;
                case "tiff":
                case "tif":
                    return ImageFormat.Tiff;
                case "wmf":
                    return ImageFormat.Wmf;
                default:
                    throw new ArgumentException("extensão desconhecida");
            }
        }
    }
}
