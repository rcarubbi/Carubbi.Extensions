using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carubbi.Extensions
{
    /// <summary>
    ///  Classe com métodos para tratamento de Códigos CNAE
    /// </summary>
    public static class StringBrazilianCNAEDocumentExtensions
    {
        /// <summary>
        /// Separa a porção númerica da porção alfabética de um código CNAE
        /// <example>
        ///     <code>
        ///        var par = CNAEHelper.LerCnae("A1234")
        ///        par.Key // "1234"
        ///        par.Value // "A"
        ///     </code>
        /// </example>
        /// </summary>
        /// <param name="instance">Código CNAE a ser analisado</param>
        /// <returns>Par Chave-Valor onde a chave é a porção numérica e o valor a porção alfabética</returns>
        public static KeyValuePair<long, string> LerCnae(this string instance)
        {
            instance = (instance ?? string.Empty).Replace("-", string.Empty).Replace(".", string.Empty).Replace(" ", string.Empty);
            var letra = string.Empty;
            long codigo;
            if (char.IsLetter(instance[0]))
            {
                letra = instance[0].ToString();
                codigo = instance.Substring(1, instance.Length - 1).To<long>(0);
            }
            else
            {
                codigo = instance.To<long>(0);
            }

            return new KeyValuePair<long, string>(codigo, letra);
        }
    }
}
