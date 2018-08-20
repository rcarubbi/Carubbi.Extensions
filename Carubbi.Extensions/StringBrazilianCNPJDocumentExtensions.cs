using System.Text.RegularExpressions;

namespace Carubbi.Extensions
{
    public static class StringBrazilianCNPJDocumentExtensions
    {
        /// <summary>
        /// Retorna um CNPJ completo, com os digitos verificadores
        /// </summary>
        /// <param name="instance">CNPJ sem digitos Verificadores</param>
        /// <returns>CNPJ Completo</returns>
        public static string CompletarDigitos(this string instance)
        {
            if (instance.Length > 12)  instance = instance.Substring(0, 12);

            var qDig = instance.Length;

            //Gravar posição dos caracteres
            int dig1 = instance.Substring(qDig - 12, 1).To<short>(0);
            int dig2 = instance.Substring(qDig - 11, 1).To<short>(0);
            int dig3 = instance.Substring(qDig - 10, 1).To<short>(0);
            int dig4 = instance.Substring(qDig - 9, 1).To<short>(0);
            int dig5 = instance.Substring(qDig - 8, 1).To<short>(0);
            int dig6 = instance.Substring(qDig - 7, 1).To<short>(0);
            int dig7 = instance.Substring(qDig - 6, 1).To<short>(0);
            int dig8 = instance.Substring(qDig - 5, 1).To<short>(0);
            int dig9 = instance.Substring(qDig - 4, 1).To<short>(0);
            int dig10 = instance.Substring(qDig - 3, 1).To<short>(0);
            int dig11 = instance.Substring(qDig - 2, 1).To<short>(0);
            int dig12 = instance.Substring(qDig - 1, 1).To<short>(0);
            //dig13 = Convert.ToInt16(strCNPJ.Substring(qDig - 2, 1));
            //dig14 = Convert.ToInt16(strCNPJ.Substring(qDig - 1, 1));

            //Cálculo para o primeiro dígito validador
            var dv1 = (dig1 * 6) + (dig2 * 7) + (dig3 * 8) + (dig4 * 9) + (dig5 * 2) + (dig6 * 3) + (dig7 * 4) + (dig8 * 5) + (dig9 * 6) + (dig10 * 7) + (dig11 * 8) + (dig12 * 9);
            dv1 = dv1 % 11;

            if (dv1 == 10)
            {
                dv1 = 0; //Se o resto for igual a 10, dv1 igual a zero
            }
            var dig13 = dv1;

            //Cálculo para o segundo dígito validador
            var dv2 = (dig1 * 5) + (dig2 * 6) + (dig3 * 7) + (dig4 * 8) + (dig5 * 9) + (dig6 * 2) + (dig7 * 3) + (dig8 * 4) + (dig9 * 5) + (dig10 * 6) + (dig11 * 7) + (dig12 * 8) + (dv1 * 9);
            dv2 = dv2 % 11;

            if (dv2 == 10)
            {
                dv2 = 0; //Se o resto for igual a 10, dv1 igual a zero

            }
            var dig14 = dv2;

            //Validação dos dígitos validadores, após o cálculo realizado
            return $"{dig1}{dig2}{dig3}{dig4}{dig5}{dig6}{dig7}{dig8}{dig9}{dig10}{dig11}{dig12}{dig13}{dig14}";
        }

        /// <summary>
        /// Pega a Raiz do CNPJ informado e resolve os digitos verificadores para o sufixo 0001
        /// </summary>
        /// <param name="instance">CNPJ a ser resolvido</param>
        /// <returns>Raiz do original + Sufixo 0001 e seu DV</returns>
        public static string GetMilContra(this string instance)
        {
            instance = instance.ToCnpjString();
            var cnpjMatriz = $"{instance.Substring(0, instance.Length - 6)}0001";
            cnpjMatriz = cnpjMatriz.CompletarDigitos();
            return cnpjMatriz;
        }

        /// <summary>
        /// Verifica se o sufixo de um CNPJ é 0001
        /// </summary>
        /// <param name="instance">CNPJ a ser analisado</param>
        /// <returns>indicador se possui sufixo igual à 0001</returns>
        public static bool IsMilContra(this string instance)
        {
            return instance.GetSufixo() == "0001";
        }

        /// <summary>
        /// Verifica se o sufixo de um CNPJ é 0001
        /// </summary>
        /// <param name="instance">CNPJ a ser analisado</param>
        /// <returns>indicador se possui sufixo igual à 0001</returns>
        public static bool IsMilContra(this long instance)
        {
            return instance.ToCnpjString().IsMilContra();
        }

        /// <summary>
        /// Retorna o sufixo de um CNPJ
        /// </summary>
        /// <param name="instance">CNPJ a ser analisado</param>
        /// <returns>Sufixo do CNPJ</returns>
        public static string GetSufixo(this string instance)
        {
            return instance.ToCnpjString().Substring(8, 4);
        }

        /// <summary>
        /// Converte o cnpj numérico para string completando com 0s à esquerda
        /// </summary>
        /// <param name="instance">CNPJ</param>
        /// <returns>CNPJ Convertido</returns>
        public static string ToCnpjString(this long instance)
        {
            return instance.ToString().PadLeft(14, '0');
        }

        /// <summary>
        /// Converte um texto que contem um cnpj em apenas o CNPJ
        /// </summary>
        /// <param name="instance">CNPJ</param>
        /// <returns>CNPJ Convertido</returns>
        public static string ToCnpjString(this string instance)
        {
            instance = Regex.Replace(instance ?? string.Empty, @"[^\d]", string.Empty);
            return instance.Trim().PadLeft(14, '0');
        }

        /// <summary>
        ///  Converte um cnpj em texto para número
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static long ToLong(this string instance)
        {
            instance = Regex.Replace(instance ?? string.Empty, @"[^\d]", string.Empty);
            return instance.PadLeft(14, '0').To<long>(0);
        }

        /// <summary>
        /// Recupera a Raiz de um CNPJ
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string GetRaiz(this string instance)
        {
            return instance.ToCnpjString().Substring(0, 8);
        }

        /// <summary>
        /// Recupera os digitos verificadores
        /// </summary>
        /// <param name="instance">CNPJ</param>
        /// <returns>Digitos Verificadores</returns>
        public static string GetDigitos(this string instance)
        {
            return instance.ToCnpjString().Substring(12, 2);
        }

        /// <summary>
        /// Verifica se a string é um CNPJ válido
        /// </summary>
        /// <param name="cnpj">string chamadora</param>
        /// <returns>Resultado da validação</returns>
        public static bool IsCnpj(this string cnpj)
        {
            cnpj = cnpj.PadLeft(14, '0');

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
