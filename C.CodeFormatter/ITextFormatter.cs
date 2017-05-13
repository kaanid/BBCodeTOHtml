using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.CodeFormatter
{
    /// <summary>
    /// Defines the methods that use in a text formater.
    /// </summary>
    public interface ITextFormatter
    {
        /// <summary>
        /// Format the text and returns the formatted result.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string Format(string text);
    }
}
