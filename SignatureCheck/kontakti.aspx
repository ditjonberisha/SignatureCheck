<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kontakti.aspx.cs" Inherits="SignatureCheck.kontakti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kontakti</title>
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
</head>
<body>
    <div class="row">
        <div class="col-sm-1 col-sm-offset-2">
            <img src="img/logo.png" style="height:100px; width:100px;" />
        </div>
        <div class="col-sm-3">
            <h3>VERIFIKIMI I N&Euml;NSHKRIMIT DIGJITAL</h3>
        </div>  
    </div>
    <nav class="navbar navbar-default" style="height:60px; margin-bottom: 0px;">
        <div class="col-sm-4 col-sm-offset-2" style="padding-top:10px;">
            <ul class="nav nav-pills">
                <li role="presentation"><a href="index.aspx">Verifikimi</a></li>
                <li role="presentation"><a href="instruction.aspx">Instruksionet</a></li>
                <li role="presentation" class="active"><a href="kontakti.aspx">Kontakti</a></li>
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
        <div class="col-sm-6 col-sm-offset-3">
            <h3>Kontakti</h3>
            <br />
            <p align="justify">
                Me posht mundeni te na kontaktoni per qdo pytje, sygjerim apo shqetesim tuajin.
                Ju lutemi sigurohuni qe te plotesoni te gjitha fushat te shenuara me *.
            </p>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-5 col-sm-offset-3">
            <form id="form" runat="server">
                <table class="table">
                    <tr><td><label style="font-weight:bold">Emri*</label></td><td><input type="text" class="form-control" id="Emri" runat="server" /></td></tr>
                    <tr><td><label>Mbiemri*</label></td><td><input type="text" class="form-control" id="Mbiemri" runat="server" /></td></tr>
                    <tr><td><label>Tel</label></td><td><input type="tel" class="form-control" id="Tel" runat="server" /></td></tr>
                    <tr><td><label>E-mail adresa*</label></td><td><input type="email" class="form-control" id="Email" runat="server" /></td></tr>
                    <tr><td><label>Subject</label></td><td><input type="text" class="form-control" id="Subject" runat="server" /></td></tr>
                    <tr><td><label>Pytja*</label></td><td><textarea class="form-control" id="Pytja" rows="5" style="resize:vertical;" runat="server"></textarea></td></tr>
                    <tr><td></td><td><asp:Button class="btn btn-primary" text="Dergo" OnClick="DergoEmail_Click" runat="server" style="width:120px;" /></td></tr>
                </table>
            </form>
        </div>
    </div>

    <div class="row">
        <nav class="navbar navbar-default" style="background-color: #444; margin-bottom: 0px;">
            <p style="color: white; text-align: center;">
                &copy; Copyright <%= DateTime.Now.ToString("yyyy") %> Ditjon Berisha
            </p>
        </nav>
    </div>
</body>
</html>
