using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SimplePhotoGallery
{
   public static class StringExtension
    {
        private static readonly Regex WebUrlExpression = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex EmailExpression = new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex ImageFileExpression = new Regex(@".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex VideoFileExpression = new Regex(@".*(\.[Mm][Pp][4]|\.[Vv][Oo][Bb]|\.[Ww][Mm][Vv]|\.[Mm][Pp][Gg]|\.[3][Gg][Pp]|\.[Aa][Vv][Ii]|\.[Ff][Ll][Vv]|\.[Ss][Ww][Ff])", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex AudioFileExpression = new Regex(@".*(\.[Ww][mm][Aa]|\.[Ww][Aa][Vv]|\.[Mm][Pp][3]|\.[Mm][Pp][Aa]|\.[Mm][Ii][Dd]|\.[Aa][Ii][Ff]|\.[Aa][Aa][Cc])", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex TextDocumentFileExpression = new Regex(@".*(\.[Pp][Dd][Ff]|\.[Dd][Oo][Cc]|\.[Dd][Oo][Cc][Xx]|\.[Tt][Xx][Tt]|\.[Xx][Ll][Ss]|\.[Xx][Ll][Ss][Xx]|\.[Pp][Pp][Tt]|\.[Pp][Pp][Tt][Xx]|\.[Cc][Ss][Vv])", RegexOptions.Singleline | RegexOptions.Compiled);

        public static bool IsWebUrl(this string target)
        {
            return !string.IsNullOrEmpty(target) && WebUrlExpression.IsMatch(target);
        }

        public static bool IsEmail(this string target)
        {
            return !string.IsNullOrEmpty(target) && EmailExpression.IsMatch(target);
        }

        public static bool IsPhoto(this string target)
        {
            return !string.IsNullOrEmpty(target) && ImageFileExpression.IsMatch(target);
        }

        public static bool IsVideo(this string target)
        {
            return !string.IsNullOrEmpty(target) && VideoFileExpression.IsMatch(target);
        }

        public static bool IsAudio(this string target)
        {
            return !string.IsNullOrEmpty(target) && AudioFileExpression.IsMatch(target);
        }

        public static bool IsTextDocument(this string target)
        {
            return !string.IsNullOrEmpty(target) && TextDocumentFileExpression.IsMatch(target);
        }

        public static Guid ToGuid(this string target)
        {
            Guid result = Guid.Empty;

            try
            {
                result = new Guid(target);
            }
            catch (FormatException)
            {
            }

            return result;
        }

    }
}
