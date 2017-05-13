using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C.CodeFormatter
{
    public class BBCodeFormatter:ITextFormatter
    {
        private readonly Regex regex = new Regex("\\[code=(.+?)\\]((.|\\n|\\r)+?)\\[\\/code\\]", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
        
        public BBCodeFormatter()
        {

        }

        public string GetReplaceResult(Match match)
        {
            string lang = match.Result("$1");
            string body = match.Result("$2");
            return body;
        }

        /// <summary>
        /// Explicitly match the text and replace the match result.
        /// </summary>
        /// <param name="text">The format target text.</param>
        /// <returns>Returns the formatted text.</returns>
        public virtual string Format(string text)
        {
            var match = regex.Match(text);
            int startIndex = 0;
            int len = text.Length;
            string formatted = "";

            while (match.Success)
            {
                if (match.Index > 0)
                {
                    int length = match.Index - startIndex;
                    formatted += text.Substring(startIndex, length);
                }

                var target = text.Substring(match.Index, match.Length);

                formatted += regex.Replace(target, GetReplaceResult);
                startIndex = (match.Index + match.Length);
                match = match.NextMatch();
            }

            if (startIndex != (len - 1))
                formatted += text.Substring(startIndex);

            if (!string.IsNullOrEmpty(formatted))
                return formatted;
            return text;
        }
    }
}
