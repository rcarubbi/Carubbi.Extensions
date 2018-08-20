using System;

namespace Carubbi.Extensions
{
    /// <summary>
    /// Biblioteca de Funções Matemáticas
    /// </summary>
    public static class MathExtensions
    {
        public static double CeilingWithPlaces(this double instance, int places)
        {
            var scale = Math.Pow(10, places);
            var multiplied = instance * scale;
            var ceiling = Math.Ceiling(multiplied);
            return ceiling / scale;
        }
    }
}
