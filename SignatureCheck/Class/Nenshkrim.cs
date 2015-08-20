using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SignatureCheck
{
    public class Nenshkrim
    {
        public bool Valid { get; set; }
        public string Nenshkruesi { get; set; }

        public string Emri { get; set; }

        public string Mbiemri { get; set; }

        public DateTime DataNenshkrimit { get; set; }

        public string AlgoritmiHash { get; set; }

        public string AlgoritmiEnkriptimit { get; set; }

        public string CertifikataValidePrej { get; set; }

        public string CertifikataValideDeri { get; set; }

        public string SerialNumber { get; set; }

        public string IssuerCN { get; set; }

        public string IssuerOU { get; set; }

        public string IssuerO { get; set; }

        public string IssuerC { get; set; }
    }
}
