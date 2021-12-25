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
    /// </summary>
    class ITextSharp_LGPL_Helper : HtmlToPdfConverterHelper
    {
        public override void ConvertToStream(string html, Stream outPdf)
        {
            Document document = new Document();
            try
            {
                //writer - have our own path!!! and see you have write permissions...
                PdfWriter.GetInstance(document, outPdf);
                document.Open();


                //make an arraylist ....with STRINGREADER since its no IO reading file...
                ArrayList htmlarraylist = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(html), null);
                //add the collection to the document
                for (int k = 0; k < htmlarraylist.Count; k++)
                {
                    document.Add((IElement)htmlarraylist[k]);
                }

                document.Add(new Paragraph("And the same with indentation...."));

                // or add the collection to an paragraph
                // if you add it to an existing non emtpy paragraph it will insert it from
                //the point youwrite -
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
