using iText.Html2pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterHtmlPdfTest.Converters
{
    class iText7ConverterHelper : HtmlToPdfConverterHelper
    {
        public override void ConvertToStream(string html, Stream outPdf)
        {
            HtmlConverter.ConvertToPdf(html, outPdf);
        }
    }
}
