using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Linq;

namespace SignatureCheck
{
    public class CreatePDF : ICreatePDF
    {
        public iTextSharp.text.Image ImgOK { get; set; }
        public iTextSharp.text.Image ImgNot { get; set; }
        public iTextSharp.text.Image ImgLogo { get; set; }

        public CreatePDF(string imgOK, string imgNot, string imgLogo)
        {
            this.ImgOK = iTextSharp.text.Image.GetInstance(imgOK);
            this.ImgNot = iTextSharp.text.Image.GetInstance(imgNot);
            this.ImgLogo = iTextSharp.text.Image.GetInstance(imgLogo);
        }

        private void CreateCell(PdfPTable tbl, string str, int colspan, int HorizontalAlignment, bool bold, BaseColor bgcolor, BaseColor txtcolor = null, iTextSharp.text.Image img = null)
        {
            PdfPCell cell;
            Font fonti;
            if (txtcolor == null)
            {
                //ngjyra e zeze e tekstit
                BaseColor textColor = new BaseColor(0, 0, 0);
            }
            else
            {
                //ngjyra e caktuar e tekstit
                BaseColor textColor = txtcolor;
            }

            if (bold)
            {
                fonti = new Font(Font.FontFamily.UNDEFINED, 11, Font.BOLD, txtcolor);
            }
            else
            {
                fonti = new Font(Font.FontFamily.UNDEFINED, 11, Font.NORMAL, txtcolor);
            }

            if (img == null)
            {
                cell = new PdfPCell(new Phrase(str, fonti));
            }
            else
            {
                cell = new PdfPCell(img);
            }

            tbl.WidthPercentage = 100f;
            cell.BorderColor = new BaseColor(66, 139, 202);
            cell.BorderWidth = 1;
            cell.HorizontalAlignment = HorizontalAlignment; //0=Left, 1=Centre, 2=Right
            cell.Padding = 7;
            cell.Colspan = colspan;
            cell.BackgroundColor = bgcolor;
            tbl.AddCell(cell);
        }

        public MemoryStream KrijoPdf(Dokument dokumenti)
        {
            var doc = new Document();
            doc.SetMargins(50f, 50f, 10f, 50f);

            var ms = new MemoryStream();
            PdfWriter.GetInstance(doc, ms);

            doc.Open();

            Paragraph webpage = new Paragraph("http://eid.uni-pr.edu/signaturecheck/", new Font(Font.FontFamily.UNDEFINED, 10, Font.NORMAL));
            webpage.SpacingAfter = 20f;
            webpage.Alignment = 2;
            doc.Add(webpage);

            Paragraph header = new Paragraph("Raporti i verifikimit", new Font(Font.FontFamily.UNDEFINED, 16, Font.BOLD));
            header.SpacingAfter = 30f;
            header.Alignment = 1;
            doc.Add(header);

            PdfPTable tblDokumenti = new PdfPTable(3);
            float[] widths = new float[] { 40f, 10f, 50f };
            tblDokumenti.SetWidths(widths);
            tblDokumenti.SpacingAfter = 20;

            CreateCell(tblDokumenti, "Dokumenti", 3, 0, true, new BaseColor(66, 139, 202), new BaseColor(255, 255, 255));

            CreateCell(tblDokumenti, "Nenshkrimi digjital", 1, 0, true, new BaseColor(255, 255, 255));

            string rezultatiVerifikimit;
            iTextSharp.text.Image img;
            if(dokumenti.Nenshkrimet.Count() == 0)
            {
                rezultatiVerifikimit = "Nuk ekziston nenshkrim digjital ne kete dokument.";
                img = ImgNot;
            }
            else if(dokumenti.Nenshkrimet.All(nenshkrim => nenshkrim.Valid))
            {
                rezultatiVerifikimit = "Nenshkrimi u verifikua me sukses.";
                img = ImgOK;
            }
            else
            {
                rezultatiVerifikimit = "Nuk u verifikua nenshkrimi digjital.";
                img = ImgNot;
            }

            img.ScaleAbsolute(25, 25);

            CreateCell(tblDokumenti, "", 1, 0, false, new BaseColor(255, 255, 255), null, img);
            CreateCell(tblDokumenti, rezultatiVerifikimit, 1, 0, false, new BaseColor(255, 255, 255));

            CreateCell(tblDokumenti, "Koha e verifikimit", 1, 0, true, new BaseColor(255, 255, 255));
            CreateCell(tblDokumenti, dokumenti.KohaVerifikimit.ToString(), 2, 0, false, new BaseColor(255, 255, 255));

            CreateCell(tblDokumenti, "Emri i dokumentit", 1, 0, true, new BaseColor(255, 255, 255));
            CreateCell(tblDokumenti, dokumenti.Emri, 2, 0, false, new BaseColor(255, 255, 255));

            CreateCell(tblDokumenti, "Vlera hash e dokumentit (SHA256)", 1, 0, true, new BaseColor(255, 255, 255));
            CreateCell(tblDokumenti, dokumenti.VleraHashString, 2, 0, false, new BaseColor(255, 255, 255));

            CreateCell(tblDokumenti, "Madhesia e dokumentit", 1, 0, true, new BaseColor(255, 255, 255));
            CreateCell(tblDokumenti, dokumenti.Madhesia, 2, 0, false, new BaseColor(255, 255, 255));

            doc.Add(tblDokumenti);

            foreach(Nenshkrim nenshkrimi in dokumenti.Nenshkrimet)
            {
                PdfPTable tblNenshkruesi = new PdfPTable(2);
                tblNenshkruesi.SpacingAfter = 20;

                CreateCell(tblNenshkruesi, "Te dhenat e nenshkruesit", 2, 0, true, new BaseColor(66, 139, 202), new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Nenshkruesi", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.Nenshkruesi, 1, 0, false, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Emri", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.Emri, 1, 0, false, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Mbiemri", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.Mbiemri, 1, 0, false, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Data e nenshkrimit", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.DataNenshkrimit.ToString(), 1, 0, false, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Algoritmi i Hashit", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.AlgoritmiHash, 1, 0, false, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Algoritmi i Enkriptimit", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.AlgoritmiEnkriptimit, 1, 0, false, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Certifikata valide prej", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.CertifikataValidePrej, 1, 0, false, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Certifikata valide deri", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.CertifikataValideDeri, 1, 0, false, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Numri serik i certifikates", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.SerialNumber, 1, 0, false, new BaseColor(255, 255, 255));

                doc.Add(tblNenshkruesi);

                PdfPTable tblIssuer = new PdfPTable(2);

                CreateCell(tblIssuer, "Te dhenat e leshuesit te certifikates", 2, 0, true, new BaseColor(66, 139, 202), new BaseColor(255, 255, 255));

                CreateCell(tblIssuer, "Emri(CN)", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblIssuer, nenshkrimi.IssuerCN, 1, 0, false, new BaseColor(255, 255, 255));

                CreateCell(tblIssuer, "Njesia organizative(OU)", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblIssuer, nenshkrimi.IssuerOU, 1, 0, false, new BaseColor(255, 255, 255));

                CreateCell(tblIssuer, "Organizata(O)", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblIssuer, nenshkrimi.IssuerO, 1, 0, false, new BaseColor(255, 255, 255));

                CreateCell(tblIssuer, "Shteti(C)", 1, 0, true, new BaseColor(255, 255, 255));
                CreateCell(tblIssuer, nenshkrimi.IssuerC, 1, 0, false, new BaseColor(255, 255, 255));

                tblIssuer.SpacingAfter = 20;
                doc.Add(tblIssuer);
            }

            //vije horizontale
            Paragraph line = new Paragraph(doc.Bottom, new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            line.SpacingAfter = 0f;
            doc.Add(line);

            //footer
            string shenim = "Shenim: Bazuar ne Ligjin Per Sherbimet e Shoqerise Informatike, Neni 1 - Përcakton dokumentacionin në formë elektronike juridikisht të barabartë me dokumentacionin tradicional të paraqitur në format të letrës.";
            Paragraph footer = new Paragraph(shenim, new Font(Font.FontFamily.UNDEFINED, 8, Font.NORMAL, new BaseColor(32, 32, 32)));
            footer.SetLeading(12f, 0);
            footer.SpacingBefore = 0f;
            doc.Add(footer);

            doc.Close();

            return ms;
        }
    }
}
