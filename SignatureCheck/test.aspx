<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="SignatureCheck.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test data</title>
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
        <div class="col-sm-4 col-sm-offset-2" style="padding-top: 10px;">
            <ul class="nav nav-pills">
                <li role="presentation"><a href="index.aspx">Verifikimi</a></li>
                <li role="presentation"><a href="instruction.aspx">Instruksionet</a></li>
                <li role="presentation"><a href="kontakti.aspx">Kontakti</a></li>
                <li role="presentation" class="active"><a href="test.aspx">Test Data</a></li>
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
            <div class="panel panel-primary">
                <div class="panel-heading">Verifiko nenshkrimin digjital te dokumentit</div>
                <div class="panel-body">
                    <form runat="server">
                    <table class="table-bordered table-hover">
                        <tr>
                            <td>Dokumenti i nenshkruar </td>
                            <td><asp:Button OnClick="ShkarkoTestData_Click" Text="dokumenti i nenshkruar" runat="server" /></td>
                        </tr>
                    </table>
                    </form>
                </div>
            </div>
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
