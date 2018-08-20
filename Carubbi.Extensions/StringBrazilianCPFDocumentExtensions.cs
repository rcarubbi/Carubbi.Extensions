namespace Carubbi.Extensions
{
    public static class StringBrazilianCPFDocumentExtensions
    {
        /// <summary>
        /// Valida CPF
        /// Fonte: http://www.macoratti.net/11/09/c_val1.htm
        /// </summary>
        /// <param name="instance">CPF para ser validado</param>
        /// <returns>Retorna true caso seja um cpf válido e false caso não seja.</returns>
        public static bool IsCpf(this string instance)
        {
            instance = instance.PadLeft(11, '0');

            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            instance = instance.Trim();
            instance = instance.Replace(".", "").Replace("-", "");
            if (instance.Length != 11)
                return false;
            var tempCpf = instance.Substring(0, 9);

            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();

            tempCpf = tempCpf + digito;
            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto;

            return instance.EndsWith(digito);
        }
    }
}
