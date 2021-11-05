using System;
using System.Text;
using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.core
{
    public static class Extensions
    {
        /// <summary>
        ///     Check is a string is a Valid Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns>true if valid, false if not.</returns>
        public static bool IsValidUrl(this string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }

        /// <summary>
        ///     Check is a string is a valid Base64 string
        /// </summary>
        /// <param name="base64EncodedHtml">The base64 string to check.</param>
        /// <returns>true if valid, false if not.</returns>
        public static bool IsValidBase64String(this string base64EncodedHtml)
        {
            var buffer = new Span<byte>(new byte[base64EncodedHtml.Length]);
            return Convert.TryFromBase64String(base64EncodedHtml, buffer, out _);
        }

        /// <summary>
        ///     Convenience method to convert the Html to a base64 string.
        /// </summary>
        /// <param name="htmlOptions">The IHtmlOptions object</param>
        /// <param name="rawHtml">Raw HTML (not base64 encoded)</param>
        public static void SetHtml(this IHtmlOptions htmlOptions, string rawHtml)
        {
            var bytes = Encoding.Default.GetBytes(rawHtml);
            htmlOptions.Html = Convert.ToBase64String(bytes);
        }
    }
}