using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using System.Security.Cryptography.X509Certificates;

namespace SignatureCheck
{
    public class Verifikues : IVerifikues
    {
        public IEnumerable<Nenshkrim> MerrNenshkrimet(Stream fajlli)
        {
            fajlli.Position = 0;
            PdfReader pdfReader = new PdfReader(fajlli);
            AcroFields af =  pdfReader.AcroFields;

            List<string> names = af.GetSignatureNames();

            foreach (string name in names)
            {
                yield return MerrNenshkrimInfo(af, name);
            }
            
            pdfReader.Close();
        }

        private Nenshkrim MerrNenshkrimInfo(AcroFields af, string name)
        {
            PdfPKCS7 pkcs7 = af.VerifySignature(name);

            var certificate = new X509Certificate2();

            var cert = (Org.BouncyCastle.X509.X509Certificate)pkcs7.Certificates[0];

            certificate.Import(cert.GetEncoded());
            Nenshkrim nenshkruesi = new Nenshkrim();

            nenshkruesi.Nenshkruesi = CertificateInfo.GetSubjectFields(cert).GetField("CN");

            string issuer = certificate.Issuer;
            nenshkruesi.IssuerCN = GetIssuer(issuer, "CN=");
            nenshkruesi.IssuerOU = GetIssuer(issuer, "OU=");
            nenshkruesi.IssuerO = GetIssuer(issuer, "O=");
            nenshkruesi.IssuerC = GetIssuer(issuer, "C=");

            if (nenshkruesi.IssuerC == "KS")
            {
                //largimi i [EMAIL] prej cn
                nenshkruesi.Nenshkruesi = nenshkruesi.Nenshkruesi.Substring(8);
            }

            nenshkruesi.Emri = CertificateInfo.GetSubjectFields(cert).GetField("GIVENNAME");
            nenshkruesi.Mbiemri = CertificateInfo.GetSubjectFields(cert).GetField("SURNAME");
            //algoritmi hash
            nenshkruesi.AlgoritmiHash = pkcs7.GetHashAlgorithm();
            //algoritmi hash
            nenshkruesi.AlgoritmiEnkriptimit = pkcs7.GetEncryptionAlgorithm();
            //data e nenshrimit
            nenshkruesi.DataNenshkrimit = pkcs7.SignDate;
            //certifikata valide prej, deri
            nenshkruesi.CertifikataValidePrej = certificate.GetEffectiveDateString();
            nenshkruesi.CertifikataValideDeri = certificate.GetExpirationDateString();
            nenshkruesi.SerialNumber = certificate.SerialNumber;

            

            //verifikimi
            if (pkcs7.Verify())
            {
                nenshkruesi.Valid = true;
            }
            else
            {
                nenshkruesi.Valid = false;
            }

            return nenshkruesi;
        }

        private string GetIssuer(string issuer, string find)
        {
            string[] str;
            string s = "";
            str = issuer.Split(',');
            foreach (string st in str)
            {
                int index = st.IndexOf(find);
                if (index != -1)
                {
                    s = st.Substring(index + find.Length);
                }
            }

            return s;
        }
    }
}
