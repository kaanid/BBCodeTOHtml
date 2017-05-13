using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C.CodeFormatter
{
    public class FormatterContainer: ITextFormatter
    {
        /// <summary>
        /// Gets formatter collection.
        /// </summary>
        protected List<ITextFormatter> Formatters { get; private set; }
        public FormatterContainer()
        {
            Formatters = new List<ITextFormatter>();
        }
        public void AddFormat(Regex regex, string replacement, bool isExplicitly = false)
        {
            Formatters.Add(new CodeFormatter(regex, replacement, isExplicitly));
        }

        public string Format(string text)
        {
            var formattedText = text;
            foreach (var formatter in Formatters)
            {
                formattedText = formatter.Format(formattedText);
            }
            return formattedText;
        }
    }


}
