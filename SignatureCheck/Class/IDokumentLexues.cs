using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;

namespace SignatureCheck
{
    public interface IDokumentLexues
    {
        Dokument MerrDokumentInfo(string emriFajllit, Stream stream, IVerifikues verifikuesi);
    }
}
