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
        private readonly Regex regex;
        
        private readonly string[] arrReplacement;
        private readonly bool isFlag;

        public BBCodeFormatter(Regex _regex,string _replacement, bool _isFlag=false)
        {
            regex = _regex;
            arrReplacement = _replacement.Split('|');
            isFlag = _isFlag;
        }

        public string GetReplaceResult(Match match)
        {
            return match.Result(arrReplacement[0]);
        }

        /// <summary>
        /// Explicitly match the text and replace the match result.
        /// </summary>
        /// <param name="text">The format target text.</param>
        /// <returns>Returns the formatted text.</returns>
        public string Format(string text)
        {
            string formatted = string.Empty;
            
            //<span>|</span>
            formatted=regex.Replace(text, GetReplaceResult);

            if (arrReplacement.Length > 1)
            {
                string pattern = regex.ToString().Replace("\\","");
                int end= pattern.IndexOf("=", 1)>=0? pattern.IndexOf("=", 1)-1:pattern.Length-2;
                string old= "[/" + pattern.Substring(1,end)+"]";
                formatted = formatted.Replace(old, arrReplacement[1]);
            }

            return formatted;
        }
    }
}
