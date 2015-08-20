using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace SignatureCheck
{
    public class Dokument
    {
        public string Emri { get; set; }

        public string Madhesia { get; set; }

        public DateTime KohaVerifikimit { get; set; }

        public byte[] VleraHash { get; set; }

        public string VleraHashString
        {
            get
            {
                StringBuilder output = new StringBuilder(VleraHash.Length);
                for (int i = 0; i < VleraHash.Length; i++)
                {
                    output.Append(VleraHash[i].ToString("X2"));
                    output.Append(" ");
                }

                return output.ToString();
            }
        }

        public List<Nenshkrim> Nenshkrimet { get; set; }
    }
}
