using System.Globalization;
using System.Text;

namespace Libs.System.Extensions
{
    public static class StringExtension
    {
        public static string ToTitleCase(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }
        /// <summary>
        ///     Verify if value is null, empty or white space
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNull(this string text)
        {
           return string.IsNullOrWhiteSpace(text);
        }

        public static string RemoveAccents(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            char[] arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }
}
