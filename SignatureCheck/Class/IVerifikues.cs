using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;

namespace SignatureCheck
{
    public interface IVerifikues
    {
        IEnumerable<Nenshkrim> MerrNenshkrimet(Stream fajlli);
    }
}
