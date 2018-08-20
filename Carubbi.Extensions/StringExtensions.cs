using System;
using System.Text.RegularExpressions;

namespace Carubbi.Extensions
{
    /// <summary>
    /// Extension Methods para a classe String
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Retorna N caracteres a esquerda de um determinado texto
        /// </summary>
        /// <param name="value">Texto</param>
        /// <param name="maxLength">Quantidade de Caracteres a Esquerda</param>
        /// <returns>Trecho do texto selecionado</returns>
        public static string Left(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }

        /// <summary>
        /// Converte uma string em um array de linhas quebrando pelo escape \n
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string[] ToLineArray(this string value)
        {
            return value.Split(new string[] { "\n" }, StringSplitOptions.None);
        }

        /// <summary>
        /// Valida E-mail a partir do padrão RFC 2822
        /// Fonte: http://www.regular-expressions.info/email.html
        /// </summary>
        /// <param name="email">Endereço de e-mail para ser validado</param>
        /// <returns>Resultado da validação</returns>
        public static bool IsValidEmail(this string email)
        {
            if (email == null)
                return false;

            if (email.Trim() == string.Empty)
                return false;

            email = email.Trim().ToLower();

            // E-mail válido perante a especificação
            const string rfc2822 = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";

            // E-mail com domínio válido
            const string custom = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{3}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum|eco|emp|agr|am|art|b|coop|esp|far|fm|g12|imb|ind|inf|jus|leg|psi|mp|radio|rec|srv|tmp|tur|tv|etc|adm|adv|arq|ato|bio|bmd|cim|cng|cnt|ecn|eng|eti|fnd|fot|fst|ggf|jor|lel|mat|med|mus|not|ntr|odo|ppg|pro|psc|qsl|slg|taxi|teo|trd|vet|zlg|blog|flog|nom|vlog|wiki)\b";

            var regex1 = new Regex(rfc2822);

            var regex2 = new Regex(custom);

            return regex1.Match(email).Success && regex2.Match(email).Success;
        }
    }
}
