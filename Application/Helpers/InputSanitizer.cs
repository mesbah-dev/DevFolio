using Ganss.Xss;

namespace Application.Helpers
{
    public static class InputSanitizer
    {
        public static string SanitizeBasic(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;
            var sanitizer = new HtmlSanitizer();

            return sanitizer.Sanitize(input);
        }

    }
}
