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
using System.Threading;
using Airport.Services;
using Airport.Data;

namespace Airport.Handlers
{
    public class TicketHandler
    {
        ApplicationDbContext db;
        string additionlPath = Directory.GetCurrentDirectory() + "/wwwroot";

        public TicketHandler(ApplicationDbContext context)
        {
            db = context;
        }
        public string PrintTicketPdf(TicketFull ticket)
        {
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = "Билет №" + ticket.Id;
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
            gfx.DrawString("Маршрутная квитанция №" + ticket.Id, fontHeader, brush,
                new XRect(0, startPointY, page.Width, startPointY += step),
                XStringFormat.Center);
            gfx.DrawString("Electronic ticket/Itinerary receipt", fontText, brushGray,
                new XPoint(startPointX, startPointY += bigStep),
                XStringFormat.TopLeft);
            gfx.DrawString("Данные полёта", fontSubHeader, brush,
                new XPoint(startPointX, startPointY += bigStep),
                XStringFormat.TopLeft);
            gfx.DrawLine(pen, new XPoint(startPointX, startPointY - 10), new XPoint(page.Width - startPointX, startPointY - 10));
            gfx.DrawString(ticket.Passenger.Documents[0].DocumentType.ToString().ToUpper(), fontText, brush, new XPoint(startPointX, startPointY += step), XStringFormat.TopLeft);
            gfx.DrawString("ПАССАЖИР", fontText, brush, new XPoint(startPointX + 140, startPointY), XStringFormat.TopLeft);
            gfx.DrawString(ticket.Passenger.Documents[0].Value.ToString(), fontBText, brushGray, new XPoint(startPointX, startPointY += 20), XStringFormat.TopLeft);
            gfx.DrawString(ticket.Passenger.Surname + " " + ticket.Passenger.Name + " " + ticket.Passenger.Patronumic, fontText, brushGray, new XPoint(startPointX + 140, startPointY), XStringFormat.TopLeft);

            gfx.DrawString("Информация о маршруте", fontSubHeader, brush,
                new XPoint(startPointX, startPointY += bigStep),
                XStringFormat.TopLeft);
            gfx.DrawLine(pen, new XPoint(startPointX, startPointY - 10), new XPoint(page.Width - startPointX, startPointY - 10));

            gfx.DrawString("РЕЙСЫ", fontText, brush, new XPoint(startPointX, startPointY += step), XStringFormat.TopLeft);
            gfx.DrawString("ВЫЛЕТ", fontText, brush, new XPoint(startPointX + 120, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("В ПУТИ", fontText, brush, new XPoint(startPointX + 240, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("ПРИБЫТИЕ", fontText, brush, new XPoint(startPointX + 300, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("Рейс №" + ticket.Flight.Id, fontBText, brush, new XPoint(startPointX, startPointY += 20), XStringFormat.TopLeft);
            gfx.DrawString(ticket.Flight.StartingPoint.City, fontBText, brush, new XPoint(startPointX + 120, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("....", fontText, brush, new XPoint(startPointX + 240, startPointY), XStringFormat.TopLeft);
            gfx.DrawString(ticket.Flight.TermitationPoint.City, fontBText, brush, new XPoint(startPointX + 300, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("Страна", fontText, brushGray, new XPoint(startPointX, startPointY += 20), XStringFormat.TopLeft);
            gfx.DrawString(ticket.Flight.StartingPoint.Country, fontText, brushGray, new XPoint(startPointX + 120, startPointY), XStringFormat.TopLeft);
            gfx.DrawString(ticket.Flight.TermitationPoint.Country, fontText, brushGray, new XPoint(startPointX + 300, startPointY), XStringFormat.TopLeft);
            gfx.DrawString("Время", fontText, brushGray, new XPoint(startPointX, startPointY += 20), XStringFormat.TopLeft);
            gfx.DrawString(ticket.Flight.StartingPoint.DateTime.ToString(), fontText, brushGray, new XPoint(startPointX + 120, startPointY), XStringFormat.TopLeft);
            gfx.DrawString(ticket.Flight.TermitationPoint.DateTime.ToString(), fontText, brushGray, new XPoint(startPointX + 300, startPointY), XStringFormat.TopLeft);


            string filename;
            if (!string.IsNullOrEmpty(ticket.PdfFilePath)) {
                filename = ticket.PdfFilePath;
            }
            else { 
                filename =  "/content/Tickets/" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour + "." + DateTime.Now.Minute + ".pdf";
            }
            doc.Save(additionlPath + filename);
            return filename;
        }
       
        public string SendTicket(string email, string pdfPath)
        {
            string code = "";

            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 25);
            smtpClient.Credentials = new NetworkCredential("rosavtodorcza@mail.ru", "tararaKota1235");

            MailAddress to = new MailAddress(email);
            MailAddress from = new MailAddress("rosavtodorcza@mail.ru", "Авиаперевозки Airport");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Бронь билета на самолет - Airport";
            message.IsBodyHtml = true;
            message.Body = "<html><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'></head><body><h2>Скачать билет на самолет - аэропорт Airport</h2>" +
                "<p>Спасибо что воспользовались услугами нашей компании</p><br/><p>Возникли вопросы? Напишите нам: rosavtodorcza@mail.ru</p><p style='text-align:right'>" + DateTime.Now + "</p></body></html>";
            smtpClient.EnableSsl = true;
            message.Attachments.Add(new Attachment(additionlPath + pdfPath));

            smtpClient.Send(message);
            return code;
        }

        public string SendTicketCancel(string passengerEmail)
        {
            string code = "";

            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 25);
            smtpClient.Credentials = new NetworkCredential("rosavtodorcza@mail.ru", "tararaKota1235");

            //MailAddress to = new MailAddress("email");
            MailAddress to = new MailAddress(passengerEmail);
            MailAddress from = new MailAddress("rosavtodorcza@mail.ru", "Авиаперевозки Airport");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Отмена брони билета на самолет - Airport";
            message.IsBodyHtml = true;
            message.Body = "<html><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'></head><body><h2>Ваша бронь отменена</h2>" +
                "<p>Это могло произойти из-за истечения времени оплаты. В случае, если вы готовы оплатить билет, оформите его еще раз.</p><br/><p>Возникли вопросы? Напишите нам: rosavtodorcza@mail.ru</p><p style='text-align:right'>" + DateTime.Now + "</p></body></html>";
            //message.Attachments.Add(new Attachment(PrintTicketPdf()));
            smtpClient.EnableSsl = true;

            smtpClient.Send(message);
            return code;
        }

        public async Task WaitPaymentAsync(int ticketId)
        {
            await Task.Run(() => Thread.Sleep(1000 * 60 * 3));
            string result = new TicketService(db).TryRemoveTicket(ticketId, true);
            if (result.IndexOf("Ok") != -1)
            {
                SendTicketCancel(result.Substring(3));
            }
        }

        public void UpdateTicket(int ticketId)
        {
            TicketFull result = new TicketService(db).UpdateTicket(ticketId);
            if (result != null)
            {
                string pdfName = PrintTicketPdf(result);
                SendTicket(result.Passenger.Email, pdfName);
                new TicketService(db).UpdateTicketPdfName(result.Id, pdfName);
            }
        }
        public void RemoveTicket(int ticketId, bool triggerRemove = false)
        {
            string result = new TicketService(db).TryRemoveTicket(ticketId, triggerRemove);
            if (result.IndexOf("Ok")!=-1)
            {
                SendTicketCancel(result.Substring(3));
            }
        }
    }
}
