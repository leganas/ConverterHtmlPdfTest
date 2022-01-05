using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
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
            ConverterProperties properties = new ConverterProperties();
            var pdfWriter = new PdfWriter(outPdf);
            var pdfDocument = new PdfDocument(pdfWriter);
            pdfDocument.SetDefaultPageSize(PageSize.A4.Rotate());
            HtmlConverter.ConvertToPdf(html, pdfDocument, properties);
        }
    }
}
