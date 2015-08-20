using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace SignatureCheck
{
    public class DokumentLexues : IDokumentLexues
    {
        private static SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();

        public Dokument MerrDokumentInfo(string emriFajllit, Stream stream, IVerifikues verifikuesi)
        {
            Dokument dokumenti = new Dokument
            {
                Emri = emriFajllit,
                KohaVerifikimit = DateTime.Now,
                Madhesia = (int)stream.Length / 1024 + " KB",
                VleraHash = sha256.ComputeHash(stream)
            };

            dokumenti.Nenshkrimet = verifikuesi.MerrNenshkrimet(stream).ToList();
            return dokumenti;
        }
    }
}
