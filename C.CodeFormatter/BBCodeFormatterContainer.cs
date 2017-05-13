using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C.CodeFormatter
{
    public class BBCodeFormatterContainer: ITextFormatter
    {
        #region Patterns
        private readonly Regex BoldRegex = new Regex(@"\[b\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Bold_Replacement = "<span style=\"font-weight:bold;\">|</span>";
        private readonly Regex ItalicRegex = new Regex(@"\[i\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Italic_Replacement = "<span style=\"font-style:italic;\">|</span>";
        private readonly Regex FontRegex = new Regex(@"\[font=(.+?)\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Font_Replacement = "<span style=\"font-family:$1;\">|</span>";
        private readonly Regex AlignRegex = new Regex(@"\[align=(.+?)\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Align_Replacement = "<span style=\"text-align:$1;\">|</span>";
        private readonly Regex UnderlineRegex = new Regex(@"\[u\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Underline_Replacement = "<span style=\"text-decoration:underline;\">|</span>";
        private readonly Regex StrikeThoughRegex = new Regex(@"\[s\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string StrikeThough_Replacement = "<span style=\"text-decoration:line-through;\">|</span>";
        private readonly Regex ColorRegex = new Regex(@"\[color=(.+?)\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Color_Replacement = "<span style=\"color:$1\">|</span>";
        private readonly Regex CenterRegex = new Regex(@"\[center\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Center_Replacement = "<span style=\"text-align:center;\">|</span>";
        private readonly Regex SizeRegex = new Regex(@"\[size=(.+?)\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Size_Replacement = "<span style=\"font-size:$1px;\">|</span>";
        private readonly Regex QuoteRegex = new Regex(@"\[quote\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Quote_Replacement = "<blockquote><p>|</p></blockquote>";
        private readonly Regex QuoteRegex2 = new Regex(@"\[quote=(.+?)\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Quote_Replacement2 = "<blockquote><p><b>$1</b></p><p>|</p></blockquote>";
        private readonly Regex MailRegex = new Regex(@"\[email\](.+?)\[\/email\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Mail_Replacement = "<a href=\"mailto:$1\" rel=\"nofollow\">mailto:$1</a>";
        private readonly Regex LinkRegex = new Regex(@"\[url\](.+?)\[\/url\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Link_Replacement = "<a href=\"$1\" rel=\"nofollow\">$1</a>";
        private readonly Regex Link2Regex = new Regex(@"\[url=(.+?)\](.+?)\[\/url\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Link2_Replacement = "<a href=\"$1\" rel=\"nofollow\">$2</a>";
        private readonly Regex ImgRegex = new Regex(@"\[img\](.+?)\[\/img\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Img_Replacement = "<img src=\"$1\" alt=\"\" />";
        private readonly Regex ImgRegex1 = new Regex(@"\[img width=(.+?) height=(.+?)\](.+?)\[\/img\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Img_Replacement1 = "<img src=\"$3\" alt=\"\" width=\"$1\" height=\"$2\" />";
        private readonly Regex ImgRegex2 = new Regex(@"\[img (.+?)x(.+?)\](.+?)\[\/img\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Img_Replacement2 = "<img src=\"$3\" alt=\"\" width=\"$1\" height=\"$2\" />";
        private readonly Regex OrderListRegex = new Regex(@"\[ol\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string OrderList_Replacement = "<ol>|</ol>";
        private readonly Regex UnOrderListRegex = new Regex(@"\[ul\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string UnOrderList_Replacement = "<ul>|</ul>";
        private readonly Regex ListItemRegex = new Regex(@"\[li\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string ListItem_Replacement = "<li>|</li>";
        private readonly Regex TableRegex = new Regex(@"\[table\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string Table_Replacement = "<table>|</table>";
        private readonly Regex TableRowRegex = new Regex(@"\[tr\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string TableRow_Replacement = "<tr>|</tr>";
        private readonly Regex TableCellRegex = new Regex(@"\[td\](.+?)\[\/td\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string TableCell_Replacement = "<td>|</td>";
        private readonly Regex TableHeaderCellRegex = new Regex(@"\[th\]", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly string TableHeaderCell_Replacement = "<th>|</th>";
        private readonly Regex H1Regex = new Regex(@"\[h1\]", RegexOptions.Compiled | RegexOptions.Multiline);
        private readonly string H1_Replacement = "<h1>|</h1>";
        private readonly Regex H2Regex = new Regex(@"\[h2\]", RegexOptions.Compiled | RegexOptions.Multiline);
        private readonly string H2_Replacement = "<h2>|</h2>";
        private readonly Regex H3Regex = new Regex(@"\[h3\]", RegexOptions.Compiled | RegexOptions.Multiline);
        private readonly string H3_Replacement = "<h3>|</h3>";
        private readonly Regex H4Regex = new Regex(@"\[h4\]", RegexOptions.Compiled | RegexOptions.Multiline);
        private readonly string H4_Replacement = "<h4>|</h4>";
        private readonly Regex H5Regex = new Regex(@"\[h5\](.+?)\[\/h5\]", RegexOptions.Compiled | RegexOptions.Multiline);
        private readonly string H5_Replacement = "<h5>|</h5>";
        private readonly Regex REGEX_BREAK = new Regex(@"(\r\n|\r|\n|\n\r)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        //"([\r\n])[\s]+"
        #endregion

        protected List<ITextFormatter> Formatters { get; private set; }

        public BBCodeFormatterContainer()
        {
            Formatters = new List<ITextFormatter>();

            AddFormat(BoldRegex, Bold_Replacement, true);
            AddFormat(ItalicRegex, Italic_Replacement, true);
            AddFormat(FontRegex, Font_Replacement, true);
            AddFormat(AlignRegex, Align_Replacement, true);
            AddFormat(UnderlineRegex, Underline_Replacement, true);
            AddFormat(StrikeThoughRegex, StrikeThough_Replacement, true);
            AddFormat(ColorRegex, Color_Replacement, true);
            AddFormat(CenterRegex, Center_Replacement, true);
            AddFormat(SizeRegex, Size_Replacement, true);
            AddFormat(MailRegex, Mail_Replacement, true);
            AddFormat(LinkRegex, Link_Replacement, true);
            AddFormat(Link2Regex, Link2_Replacement, true);
            AddFormat(QuoteRegex, Quote_Replacement, true);
            AddFormat(QuoteRegex2, Quote_Replacement2, true);
            AddFormat(ImgRegex, Img_Replacement, true);
            AddFormat(ImgRegex1, Img_Replacement1, true);
            AddFormat(ImgRegex2, Img_Replacement2, true);
            AddFormat(OrderListRegex, OrderList_Replacement, true);
            AddFormat(UnOrderListRegex, UnOrderList_Replacement, true);
            AddFormat(ListItemRegex, ListItem_Replacement, true);
            AddFormat(TableRegex, Table_Replacement, true);
            AddFormat(TableRowRegex, TableRow_Replacement, true);
            AddFormat(TableCellRegex, TableCell_Replacement, true);
            AddFormat(TableHeaderCellRegex, TableHeaderCell_Replacement, true);
            AddFormat(H5Regex, H5_Replacement, true);
            AddFormat(H4Regex, H4_Replacement, true);
            AddFormat(H3Regex, H3_Replacement, true);
            AddFormat(H2Regex, H2_Replacement, true);
            AddFormat(H1Regex, H1_Replacement, true);
            AddFormat(REGEX_BREAK, "<br/>", true);
        }

        public void AddFormat(Regex regex,string replacement,bool isFloag=false)
        {
            Formatters.Add(new BBCodeFormatter(regex, replacement, isFloag));
        }

        public string Format(string text)
        {
            var formattedText = text;
            foreach (var formatter in Formatters)
            {
                formattedText=formatter.Format(formattedText);
            }
            return formattedText;
        }
    }
}
