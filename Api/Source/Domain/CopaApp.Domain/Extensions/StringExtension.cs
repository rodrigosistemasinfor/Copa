using System.Text.RegularExpressions;

namespace CopaApp.Domain.Extensions
{
    public static class StringExtension
    {
        private const int posicaoPalavra = 1;
        private const int posicaoNumeros = 2;
        private const string expressaoRegular = (@"([a-zA-Z]+|[a-zA-Z]+\s)(\d+)");

        //retorna a parte textual da string para ordenação inteligente
        public static string ValueKeyString(this string value)
        {
            var result = GetStringProcessed(value);

            if (string.IsNullOrEmpty(result.Groups[posicaoNumeros].Value))
               return value;
            else
               return result.Groups[posicaoPalavra].Value;
        }

        //retorna a parte numérica da string para ordenação inteligente
        public static int ValueKeyInt(this string value)
        {
            int valorSemParteNumerica = 0;
            var result = GetStringProcessed(value);

            if (string.IsNullOrEmpty(result.Groups[posicaoNumeros].Value))
                return valorSemParteNumerica;
            else
                return int.Parse(result.Groups[posicaoNumeros].Value);
        }

        private static Match GetStringProcessed(string value)
        {
            var objRegex = new Regex(expressaoRegular);
            return objRegex.Match(value);
        }
    }
}
