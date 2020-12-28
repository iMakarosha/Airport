using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Pdf.IO;
using Airport.ViewModels;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace Airport.Handlers
{
    public class TicketHandler
    {
        //public void PrintTicketPdf(TicketInfo ticket)
        public string PrintTicketPdf()
        {
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = "Билет №";// + ticket.Ticket.Id;
            int startPointX = 80;
            int startPointY = 50;
            int step = 24;
            int bigStep = 40;
            PdfPage page = doc.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XBrush brush = XBrushes.Black;
            XBrush brushGray = XBrushes.Gray;
            XPen pen = new XPen(XColors.Gray, 1);
            XFont fontHeader = new XFont("Calibri", 20, XFontStyle.Bold);
            XFont fontSubHeader = new XFont("Calibri", 16, XFontStyle.Bold);
            XFont fontText = new XFont("Calibri", 13, XFontStyle.Regular);
            XFont fontBText = new XFont("Calibri", 13, XFontStyle.Bold);
            gfx.DrawString("Маршрутная квитанция №...", fontHeader, brush,
                new XRect(0, startPointY, page.Width, startPointY += step),
                XStringFormat.Center);
            gfx.DrawString("Electronic ticket/Itinerary receipt", fontText, brushGray,
                new XPoint(startPointX, startPointY += bigStep),
                XStringFormat.TopLeft);
            gfx.DrawString("Данные полёта", fontSubHeader, brush,
                new XPoint(startPointX, startPointY += bigStep),
                XStringFormat.TopLeft);
            gfx.DrawLine(pen, new XPoint(startPointX, startPointY - 10), new XPoint(page.Width - startPointX, startPointY - 10));
            gfx.DrawString("ПАСПОРТ", fontText, brush, new XPoint(startPointX, startPointY += step), XStringFormat.TopLeft);
            gfx.DrawString("ПАССАЖИР", fontText, brush, new XPoint(startPointX + 140, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("8878 487954", fontBText, brushGray, new XPoint(startPointX, startPointY += 20), XStringFormat.TopLeft);
            gfx.DrawString("Абрамов Иван Геннадьевич", fontText, brushGray, new XPoint(startPointX + 140, startPointY), XStringFormat.TopLeft);

            gfx.DrawString("Информация о маршруте", fontSubHeader, brush,
                new XPoint(startPointX, startPointY += bigStep),
                XStringFormat.TopLeft);
            gfx.DrawLine(pen, new XPoint(startPointX, startPointY - 10), new XPoint(page.Width - startPointX, startPointY - 10));

            gfx.DrawString("РЕЙСЫ", fontText, brush, new XPoint(startPointX, startPointY += step), XStringFormat.TopLeft);
            gfx.DrawString("ВЫЛЕТ", fontText, brush, new XPoint(startPointX + 140, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("В ПУТИ", fontText, brush, new XPoint(startPointX + 260, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("ПРИБЫТИЕ", fontText, brush, new XPoint(startPointX + 320, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("Рейс .,..", fontBText, brush, new XPoint(startPointX, startPointY += 20), XStringFormat.TopLeft);
            gfx.DrawString("Москва", fontBText, brush, new XPoint(startPointX + 120, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("....", fontText, brush, new XPoint(startPointX + 240, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("Минск", fontBText, brush, new XPoint(startPointX + 300, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("ыаыавфываф ываф ываф ", fontText, brushGray, new XPoint(startPointX, startPointY += 20), XStringFormat.TopLeft);
            gfx.DrawString("фыва фыа ыва ", fontText, brushGray, new XPoint(startPointX + 120, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("....", fontText, brushGray, new XPoint(startPointX + 240, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("ыва фыва фыав фыа ", fontText, brushGray, new XPoint(startPointX + 300, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("ыаыавфываф ываф ываф ", fontText, brushGray, new XPoint(startPointX, startPointY += 20), XStringFormat.TopLeft);
            gfx.DrawString("фыва фыа ыва ", fontText, brushGray, new XPoint(startPointX + 120, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("....", fontText, brushGray, new XPoint(startPointX + 240, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("ыва фыва фыав фыа ", fontText, brushGray, new XPoint(startPointX + 300, startPointY), XStringFormat.TopLeft);


            string filename = Directory.GetCurrentDirectory() + "/Tickets/" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour + "." + DateTime.Now.Minute + ".pdf";
            doc.Save(filename);
            return filename;
            //Process.Start(filename);

            // Create a PDF text annotation
            //PdfTextAnnotation textAnnot = new PdfTextAnnotation();
            //textAnnot.Title = "This is the title";
            //textAnnot.Subject = "This is the subject";
            //textAnnot.Contents = "This is the contents of the annotation.\rThis is the 2nd line.";
            //textAnnot.Icon = PdfTextAnnotationIcon.Note;

            //gfx.DrawString("The first text annotation", font, XBrushes.Black, 30, 50, XStringFormats.Default);

            //// Convert rectangle from world space to page space. This is necessary because the annotation is
            //// placed relative to the bottom left corner of the page with units measured in point.
            //XRect rect = gfx.Transformer.WorldToDefaultPage(new XRect(new XPoint(30, 60), new XSize(30, 30)));
            //textAnnot.Rectangle = new PdfRectangle(rect);

            //// Add the annotation to the page
            //page.Annotations.Add(textAnnot);
        }
       
        //public void SentTicket(TicketInfo ticket)
        public string SentTicket()
        {
            string code = "";

            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 25);
            smtpClient.Credentials = new NetworkCredential("rosavtodorcza@mail.ru", "tararaKota1235");

            //MailAddress to = new MailAddress("email");
            MailAddress to = new MailAddress("prince-zuko27@yandex.ru");
            MailAddress from = new MailAddress("rosavtodorcza@mail.ru", "Авиаперевозки Airport");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Бронь билета на самолет - Airport";
            message.IsBodyHtml = true;
            message.Body = "<html><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'></head><body><h2>Скачать билет на самолет - аэропорт Airport</h2>" +
                "<p>Спасибо что воспользовались услугами нашей компании</p><br/><p>Возникли вопросы? Напишите нам: rosavtodorcza@mail.ru</p><p style='text-align:right'>" + DateTime.Now + "</p></body></html>";
            message.Attachments.Add(new Attachment(PrintTicketPdf()));
            smtpClient.EnableSsl = true;

            smtpClient.Send(message);
            return code;
        }

        public string SentTicketCancel()
        {
            string code = "";

            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 25);
            smtpClient.Credentials = new NetworkCredential("rosavtodorcza@mail.ru", "tararaKota1235");

            //MailAddress to = new MailAddress("email");
            MailAddress to = new MailAddress("prince-zuko27@yandex.ru");
            MailAddress from = new MailAddress("rosavtodorcza@mail.ru", "Авиаперевозки Airport");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Отмена брони билета на самолет - Airport";
            message.IsBodyHtml = true;
            message.Body = "<html><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'></head><body><h2>Ваша бронь отменена</h2>" +
                "<p>Это могло произойти из-за истечения времени оплаты. В случае, если вы готовы оплатить билет, оформите его еще раз.</p><br/><p>Возникли вопросы? Напишите нам: rosavtodorcza@mail.ru</p><p style='text-align:right'>" + DateTime.Now + "</p></body></html>";
            message.Attachments.Add(new Attachment(PrintTicketPdf()));
            smtpClient.EnableSsl = true;

            smtpClient.Send(message);
            return code;
        }
    }
}
