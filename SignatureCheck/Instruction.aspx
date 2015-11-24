<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="instruction.aspx.cs" Inherits="SignatureCheck.Instruction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><asp:Literal ID="Literal3" runat="server" Text="<%$Resources:db.lang,mnuInstruction%>"/></title>
    <link rel="shortcut icon" type="image/x-icon" href="~/img/icon.ico" />
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link href='https://fonts.googleapis.com/css?family=Raleway' rel='stylesheet' type='text/css' />
    <style>
        body {
            font-family: 'Raleway', sans-serif;
        }
    </style>
</head>
<body>
    <div class="row">
        <div class="col-sm-1 col-sm-offset-2 col-xs-1 col-xs-offset-2">
            <img src="img/logo.png" style="height:100px; width:100px;" />
        </div>
        <div class="col-sm-3 col-xs-3">
            <h3><asp:Literal ID="header" runat="server" Text="<%$Resources:db.lang,header%>"/></h3>
        </div>  
        <div class="col-sm-2 col-sm-offset-2 col-xs-2 col-xs-offset-2">
            <br />
            <a href="?lang=en" runat="server" id="en"><img src="img/us.png" style="height: 21px; width: 40px;" /> English</a> |
            <a href="?lang=sq" runat="server" id="sq"><img src="img/al.jpg" style="height: 21px; width: 40px;" /> Shqip</a>
        </div>
    </div>
    <nav class="navbar navbar-default" style="height:60px; margin-bottom: 0px;">
        <div class="col-sm-6 col-sm-offset-2" style="padding-top: 10px;">
            <ul class="nav nav-pills">
                <li role="presentation"><a href="Default.aspx"><asp:Literal ID="mnuVerify" runat="server" Text="<%$Resources:db.lang,mnuVerify%>"/></a></li>
                <li role="presentation" class="active"><a href="instruction.aspx"><asp:Literal ID="mnuInstruction" runat="server" Text="<%$Resources:db.lang,mnuInstruction%>"/></a></li>
                <li role="presentation"><a href="kontakti.aspx"><asp:Literal ID="Literal1" runat="server" Text="<%$Resources:db.lang,mnuContact%>"/></a></li>
                <li role="presentation"><a href="test.aspx"><asp:Literal ID="Literal2" runat="server" Text="<%$Resources:db.lang,mnuTest%>"/></a></li>
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
        <div class="col-md-8 col-md-offset-2">
            <h3><asp:Literal ID="Literal4" runat="server" Text="<%$Resources:db.lang,mnuInstruction%>"/></h3>
            <b><asp:Literal ID="Literal7" runat="server" Text="<%$Resources:db.lang,InstrcHowToUse%>"/></b>
        </div>
    </div>
    <hr class="col-md-8 col-md-offset-2" />
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <p>
                <b><asp:Literal ID="Literal5" runat="server" Text="<%$Resources:db.lang,InstrcReceivingTitle%>"/></b><br />
                <asp:Literal ID="Literal6" runat="server" Text="<%$Resources:db.lang,InstrcReceivingText%>"/>
            </p>
        </div>
        <div class="col-md-8 col-md-offset-2">
            <p>
                <b><asp:Literal ID="Literal8" runat="server" Text="<%$Resources:db.lang,InstrcProcessingSig%>"/></b><br />
                <asp:Literal ID="Literal9" runat="server" Text="<%$Resources:db.lang,InstrcProcessingSigText%>"/>
            </p>
            <p style=" text-align:center;">
                <img runat="server" src="<%$Resources:db.lang,InstrcImage1%>" style="width:600px;" />
            </p>
        </div>
        <div class="col-md-8 col-md-offset-2">
            <p>
                <b><asp:Literal ID="Literal10" runat="server" Text="<%$Resources:db.lang,InstrcDisplayingRes%>"/></b><br />
                <asp:Literal ID="Literal11" runat="server" Text="<%$Resources:db.lang,InstrcDisplayingResText%>"/>
            </p>
            <p style=" text-align:center;">
                <img runat="server" src="<%$Resources:db.lang,InstrcImage2%>" style="width:600px;" />
            </p>
        </div>
    </div>

    <div class="row">
        <nav class="navbar navbar-default" style="background-color: #444; margin-bottom: 0px;">
            <p style="color: white; text-align: center; padding-top: 10px;">
                &copy; Copyright <%= DateTime.Now.ToString("yyyy") %> Ditjon Berisha
            </p>
        </nav>
    </div>
</body>
</html>
