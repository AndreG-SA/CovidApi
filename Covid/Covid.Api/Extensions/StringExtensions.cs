namespace System
{
    public static class StringExtensions
    {
        public static string CleanCountryNames(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return input.Replace("&ccedil;", "ç")
                        .Replace("&eacute;", "é")
                        .TrimEnd('-');
        }
    }
}
