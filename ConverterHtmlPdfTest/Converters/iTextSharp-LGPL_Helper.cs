using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using iTextSharp.text.xml;
using iTextSharp.text.html;

namespace ConverterHtmlPdfTest.Converters
{
    /// <summary>
    /// Бесплатная версия iText , до определённой версии он был на LGPL лицензии
    /// Нужно разбираться как тут конвертировать пока не реализовано
    /// взял от сюда https://social.msdn.microsoft.com/Forums/en-US/9aa813e6-d610-4f6f-b588-8b099d9bce46/convert-html-to-pdf-using-itextsharp?forum=aspservercontrols
    /// </summary>
    class ITextSharp_LGPL_Helper : HtmlToPdfConverterHelper
    {
        public override void ConvertToStream(string html, Stream outPdf)
        {
            Document document = new Document();
            try
            {
                PdfWriter.GetInstance(document, outPdf);
                document.Open();
                ArrayList htmlarraylist = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(html), null);
                for (int k = 0; k < htmlarraylist.Count; k++)
                {
                    try {
                        document.Add((IElement)htmlarraylist[k]);
                    }
                    catch (Exception) { }
                }

                document.Add(new Paragraph("And the same with indentation...."));
                Paragraph mypara = new Paragraph();//make an emtphy paragraph as "holder"
                mypara.IndentationLeft = 36;
                mypara.InsertRange(0, htmlarraylist);
                document.Add(mypara);
                document.Close();
            }
            catch (Exception exx)
            {
                Console.Error.WriteLine(exx.StackTrace);
                Console.Error.WriteLine(exx.Message);
            }
            throw new NotImplementedException();
        }
    }
}
