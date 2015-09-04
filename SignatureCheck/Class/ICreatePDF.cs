﻿using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;

namespace SignatureCheck
{
    public interface ICreatePDF
    {
        MemoryStream KrijoRaportin(Dokument dokumenti);
        MemoryStream CreateReport(Dokument dokumenti);
    }
}
