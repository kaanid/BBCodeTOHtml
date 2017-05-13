using C.CodeFormatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBBCode
{
    class Program
    {
        static void Main(string[] args)
        {
            ITextFormatter container = new BBFormatterContainer();
            string str = "123sadfsdf[b]ASDAsd[/b]12[h1]4444[/h1]3123s[b]00[/b]dfsdfs";
            Console.WriteLine(str);
            string str2=container.Format(str);
            Console.WriteLine(str2);
            Console.Read();
        }
    }
}
