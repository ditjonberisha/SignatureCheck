<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SignatureCheck.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verifikimi i nenshkrimit digjital</title>
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
</head>
<body>
    <div class="row">
        <div class="col-sm-1 col-sm-offset-2">
            <img src="img/logo.png" style="height: 100px; width: 100px;" />
        </div>
        <div class="col-sm-3">
            <h3>VERIFIKIMI I N&Euml;NSHKRIMIT DIGJITAL</h3>
        </div>
    </div>

    <nav class="navbar navbar-default" style="height: 60px; margin-bottom: 0px;">
        <div class="col-sm-4 col-sm-offset-2" style="padding-top: 10px;">
            <ul class="nav nav-pills">
                <li role="presentation" class="active"><a href="index.aspx">Verifikimi</a></li>
                <li role="presentation"><a href="instruction.aspx">Instruksionet</a></li>
                <li role="presentation"><a href="kontakti.aspx">Kontakti</a></li>
                <li role="presentation"><a href="test.aspx">Test Data</a></li>
            </ul>
        </div>
    </nav>
    
    <div class="row">
        <div class="col-sm-8 col-sm-offset-2">
            <div style="box-shadow: 0px 10px 20px #888888;">
                <img src="img/header.jpg" style="height: 100%; width: 100%;" />
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-8 col-sm-offset-2">
            <p align="justify">
                Web site per verfikimi i nenshkrimit digjital, ju mundeson verifikimin e nenshkrimit digjital te dokumenteve PDF per autenticitetin e tyre ne vetem disa sekonda.
                Si rezultat ju do te keni nje raport me te dhenat e nenshkruesit, te cilin raport mund edhe ta shkarkoni.
            </p>
        </div>
    </div>
    <br />
    <div class="row">
        <div id="uploadFile" runat="server" class="col-sm-6 col-sm-offset-3">
            <div class="panel panel-primary">
                <div class="panel-heading">Verifiko nenshkrimin digjital te dokumentit</div>
                <div class="panel-body">
                    <p style="color: red;"><b><%=GetMessage() %></b></p>
                    <form id="form1" method="post" enctype="multipart/form-data" runat="server">
                        <label>Dokumenti: </label>
                        <input type="file" id="fileUpload" runat="server" class="btn btn-info" />
                        <br />
                        <button type="submit" id="verifiko" class="btn btn-primary" aria-label="Left Align" runat="server">
                            <span class="glyphicon glyphicon-search" aria-hidden="true"></span> Verifiko
                        </button>
                    </form>  
                    <br />
                </div>
            </div>
        </div>
        <div id="Rezultati" runat="server">
            <div class="col-sm-8 col-sm-offset-2">
                <div class="panel panel-primary" style="margin-left: 30px; margin-right: 30px;">
                    <div class="panel-body" style="margin-left: 15px; margin-right: 15px;">
                        <h3>Raporti i verifikimit</h3>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th colspan="3" style="background-color:rgb(66, 139, 202); color:white;">Dokumenti</th>
                                </tr>
                            </thead>
                            <tr>
                                <th>Nenshkrimi digjital</th>
                                <td style="width: 40px">
                                    <%=img %></td>
                                <td>
                                    <%=rezultatiVerifikimit %></td>
                            </tr>
                            <tr>
                                <th>Koha e verifikimit</th>
                                <td colspan="2"><%=dokumenti.KohaVerifikimit %></td>
                            </tr>
                            <tr>
                                <th>Emri i dokumentit</th>
                                <td colspan="2"><%=dokumenti.Emri %></td>
                            </tr>
                            <tr>
                                <th>Vlera hash e dokumentit (SHA256) </th>
                                <td colspan="2"><%=dokumenti.VleraHashString %></td>
                            </tr>
                            <tr>
                                <th>Madhesia e dokumentit</th>
                                <td colspan="2"><%=dokumenti.Madhesia %></td>
                            </tr>
                        </table>
                        <% foreach (var nenshkrimi in dokumenti.Nenshkrimet)
                           { %>
                        <table class="table table-bordered table-hover" style="table-layout: fixed;">
                            <thead>
                                <tr>
                                    <th colspan="2" style="background-color:rgb(66, 139, 202); color:white;">Te dhenat e nenshkruesit</th>
                                </tr>
                            </thead>
                            <tr>
                                <th>Nenshkruesi</th>
                                <td>
                                    <%=nenshkrimi.Nenshkruesi %></td>
                            </tr>
                            <tr>
                                <th>Emri</th>
                                <td>
                                    <%=nenshkrimi.Emri %></td>
                            </tr>
                            <tr>
                                <th>Mbiemri</th>
                                <td>
                                    <%=nenshkrimi.Mbiemri %></td>
                            </tr>
                            <tr>
                                <th>Data e nenshkrimit</th>
                                <td>
                                    <%=nenshkrimi.DataNenshkrimit %></td>
                            </tr>
                            <tr>
                                <th>Algoritmi i Hashit</th>
                                <td>
                                    <%=nenshkrimi.AlgoritmiHash %></td>
                            </tr>
                            <tr>
                                <th>Algoritmi i Enkriptimit</th>
                                <td>
                                    <%=nenshkrimi.AlgoritmiEnkriptimit %></td>
                            </tr>
                            <tr>
                                <th>Certifikata valide prej</th>
                                <td>
                                    <%=nenshkrimi.CertifikataValidePrej %></td>
                            </tr>
                            <tr>
                                <th>Certifikata valide deri</th>
                                <td>
                                    <%=nenshkrimi.CertifikataValideDeri %></td>
                            </tr>
                            <tr>
                                <th>Numri serik i certifikates</th>
                                <td>
                                    <%=nenshkrimi.SerialNumber %></td>
                            </tr>
                        </table>
                        <table class="table table-bordered table-hover" style="table-layout: fixed;">
                            <thead>
                                <tr>
                                    <th colspan="2" style="background-color:rgb(66, 139, 202); color:white;">Te dhenat e leshuesit te qerifikates</th>
                                </tr>
                            </thead>
                            <tr>
                                <th>Emri(CN)</th>
                                <td>
                                    <%=nenshkrimi.IssuerCN %></td>
                            </tr>
                            <tr>
                                <th>Njesia organizative(OU)</th>
                                <td>
                                    <%=nenshkrimi.IssuerOU %></td>
                            </tr>
                            <tr>
                                <th>Organizata(O)</th>
                                <td>
                                    <%=nenshkrimi.IssuerO %></td>
                            </tr>
                            <tr>
                                <th>Shteti(C)</th>
                                <td>
                                    <%=nenshkrimi.IssuerC %></td>
                            </tr>
                        </table>
                        <%} %>
                        <form id="formabutton" runat="server">
                            <asp:Button class="btn btn-primary" ID="BtnShkarkoRaportin" Text="Shkarko raportin" OnClick="ShkarkoButton_Click" runat="server" />
                            <asp:Button class="btn btn-primary" ID="BtnShkarkoCert" Text="Shkarko certifikaten" OnClick="ShkarkoCertifikaten_Click" runat="server" />
                            <asp:Button class="btn btn-primary" ID="BtnVerfikoDocTjeter" Text="Verifo dokument tjeter" OnClick="VerifikoDocTjeter_Click" runat="server" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-8 col-sm-offset-2">
            <hr style="margin-bottom: 5px; border-color: #2f2f2f" />
            <p align="justify">
                <small class="text-warning">Shenim: Bazuar ne Ligjin Per Sherbimet e Shoqerise Informatike, Neni 1 - Përcakton
                    dokumentacionin në formë elektronike juridikisht të barabartë me dokumentacionin 
                    tradicional të paraqitur në format të letrës.
                </small>
            </p>
        </div>
    </div>

    <br />
    <div class="row">
        <nav class="navbar navbar-default" style="background-color: #444; margin-bottom: 0px;">
            <p style="color: white; text-align: center;">
                &copy; Copyright <%= DateTime.Now.ToString("yyyy") %> Ditjon Berisha
            </p>
        </nav>
    </div>
</body>
</html>
