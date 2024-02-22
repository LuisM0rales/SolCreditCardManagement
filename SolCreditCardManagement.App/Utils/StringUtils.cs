namespace SolCreditCardManagement.App.Utils
{
    public static class StringUtils
    {
        public static string ToCardFormat(this string cardNumber)
        {
            // Ofuscar los 8 caracteres intermedios
            string obscuredNumber = string.Concat(cardNumber.Substring(0, 4),"********",cardNumber.Substring(12, 4));

            return string.IsNullOrEmpty(obscuredNumber)
                ? string.Empty
                : string.Join(" ", Enumerable.Range(0, obscuredNumber.Length / 4)
                                             .Select(i => obscuredNumber.Substring(i * 4, 4)));
        }
    }
}
