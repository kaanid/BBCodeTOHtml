using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C.CodeFormatter
{
    public class ReplacementTexFormatter:CodeFormatter
    {
        public ReplacementTexFormatter(Regex _regex,string _replacement, bool _isExplicitly = false):base(_regex,_replacement,_isExplicitly)
        {

        }

        protected string FormatBlock(string text)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(replacement))
            {
                if (regex.Match(text).Success)
                    return regex.Replace(text, this.replacement);
            }
            return text;
        }

        public override string Format(string text)
        {
            if (isExplicitly)
                return base.Format(text);  //return FormatExplicitly(text);
            else
                return FormatBlock(text);
        }
    }
}
