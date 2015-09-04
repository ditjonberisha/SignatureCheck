<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SignatureCheck.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><asp:Literal ID="Literal9" runat="server" Text="<%$Resources:db.lang,header%>"/></title>
    <link rel="shortcut icon" type="image/x-icon" href="~/img/icon.ico" />
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
    <style>
        p {
            font-family: Georgia, serif;
        }
        h3 {
            font-family: Georgia, serif;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
    <div class="row">
        <div class="col-sm-1 col-sm-offset-2 col-xs-1 col-xs-offset-2">
            <img src="img/logo.png" style="height: 100px; width: 100px;" />
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

    <nav class="navbar navbar-default" style="height: 60px; margin-bottom: 0px;">
        <div class="col-sm-6 col-sm-offset-2" style="padding-top: 10px;">
            <ul class="nav nav-pills">
                <li role="presentation" class="active"><a href="Default.aspx"><asp:Literal ID="mnuVerify" runat="server" Text="<%$Resources:db.lang,mnuVerify%>"/></a></li>
                <li role="presentation"><a href="instruction.aspx"><asp:Literal ID="mnuInstruction" runat="server" Text="<%$Resources:db.lang,mnuInstruction%>"/></a></li>
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
        <div class="col-sm-8 col-sm-offset-2">
            <h3><asp:Literal ID="Literal4" runat="server" Text="<%$Resources:db.lang,mnuVerify%>"/></h3>
            <p align="justify">
                <asp:Literal ID="Literal3" runat="server" Text="<%$Resources:db.lang,welcomeParagraph%>"/>
            </p>
        </div>
    </div>
    <br />
    <div class="row">
        <div id="uploadFile" runat="server" class="col-sm-6 col-sm-offset-3">
            <div class="panel panel-primary">
                <div class="panel-heading"><asp:Literal ID="Literal5" runat="server" Text="<%$Resources:db.lang,uploadHeader%>"/></div>
                <div class="panel-body">
                    <p style="color: red;"><b><%=GetMessage() %></b></p>
                   
                        <label><asp:Literal ID="Literal7" runat="server" Text="<%$Resources:db.lang,uploadDoc%>"/></label>
                        <input type="file" id="fileUpload" runat="server" class="btn btn-info" />
                        <br />
                        <button type="submit" id="verifiko" class="btn btn-primary" aria-label="Left Align" runat="server">
                            <span class="glyphicon glyphicon-search" aria-hidden="true"></span> <asp:Literal ID="Literal6" runat="server" Text="<%$Resources:db.lang,btnVerify%>"/>
                        </button>
                      
                    <br />
                </div>
            </div>
        </div>
        <div id="Rezultati" runat="server">
            <div class="col-sm-8 col-sm-offset-2">
                <div class="panel panel-primary" style="margin-left: 30px; margin-right: 30px;">
                    <div class="panel-body" style="margin-left: 15px; margin-right: 15px;">
                        <h3><asp:Literal ID="Literal10" runat="server" Text="<%$Resources:db.lang,Report%>"/></h3>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th colspan="3" style="background-color:rgb(66, 139, 202); color:white;"><asp:Literal ID="Literal11" runat="server" Text="<%$Resources:db.lang,docReport%>"/></th>
                                </tr>
                            </thead>
                            <tr>
                                <th><asp:Literal ID="Literal12" runat="server" Text="<%$Resources:db.lang,infoReport%>"/></th>
                                <td style="width: 40px">
                                    <%=img %></td>
                                <td>
                                    <%=rezultatiVerifikimit %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal13" runat="server" Text="<%$Resources:db.lang,TimeReport%>"/></th>
                                <td colspan="2"><%=dokumenti.KohaVerifikimit %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal14" runat="server" Text="<%$Resources:db.lang,filenameReport%>"/></th>
                                <td colspan="2"><%=dokumenti.Emri %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal15" runat="server" Text="<%$Resources:db.lang,HashReport%>"/></th>
                                <td colspan="2"><%=dokumenti.VleraHashString %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal16" runat="server" Text="<%$Resources:db.lang,sizeReport%>"/></th>
                                <td colspan="2"><%=dokumenti.Madhesia %></td>
                            </tr>
                        </table>
                        <% foreach (var nenshkrimi in dokumenti.Nenshkrimet)
                           { %>
                        <table class="table table-bordered table-hover" style="table-layout: fixed;">
                            <thead>
                                <tr>
                                    <th colspan="2" style="background-color:rgb(66, 139, 202); color:white;"><asp:Literal ID="Literal30" runat="server" Text="<%$Resources:db.lang,signerInfo%>"/></th>
                                </tr>
                            </thead>
                            <tr>
                                <th><asp:Literal ID="Literal17" runat="server" Text="<%$Resources:db.lang,signerReport%>"/></th>
                                <td>
                                    <%=nenshkrimi.Nenshkruesi %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal18" runat="server" Text="<%$Resources:db.lang,firstnameReport%>"/></th>
                                <td>
                                    <%=nenshkrimi.Emri %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal19" runat="server" Text="<%$Resources:db.lang,lastnameReport%>"/></th>
                                <td>
                                    <%=nenshkrimi.Mbiemri %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal20" runat="server" Text="<%$Resources:db.lang,signingtime%>"/></th>
                                <td>
                                    <%=nenshkrimi.DataNenshkrimit %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal21" runat="server" Text="<%$Resources:db.lang,hashalg%>"/></th>
                                <td>
                                    <%=nenshkrimi.AlgoritmiHash %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal22" runat="server" Text="<%$Resources:db.lang,enkriptalg%>"/></th>
                                <td>
                                    <%=nenshkrimi.AlgoritmiEnkriptimit %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal23" runat="server" Text="<%$Resources:db.lang,validfrom%>"/></th>
                                <td>
                                    <%=nenshkrimi.CertifikataValidePrej %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal24" runat="server" Text="<%$Resources:db.lang,validto%>"/></th>
                                <td>
                                    <%=nenshkrimi.CertifikataValideDeri %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal25" runat="server" Text="<%$Resources:db.lang,serialnumber%>"/></th>
                                <td>
                                    <%=nenshkrimi.SerialNumber %></td>
                            </tr>
                        </table>
                        <table class="table table-bordered table-hover" style="table-layout: fixed;">
                            <thead>
                                <tr>
                                    <th colspan="2" style="background-color:rgb(66, 139, 202); color:white;"><asp:Literal ID="Literal31" runat="server" Text="<%$Resources:db.lang,issuerinfo%>"/></th>
                                </tr>
                            </thead>
                            <tr>
                                <th><asp:Literal ID="Literal26" runat="server" Text="<%$Resources:db.lang,issuercn%>"/></th>
                                <td>
                                    <%=nenshkrimi.IssuerCN %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal27" runat="server" Text="<%$Resources:db.lang,issuerou%>"/></th>
                                <td>
                                    <%=nenshkrimi.IssuerOU %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal28" runat="server" Text="<%$Resources:db.lang,issuero%>"/></th>
                                <td>
                                    <%=nenshkrimi.IssuerO %></td>
                            </tr>
                            <tr>
                                <th><asp:Literal ID="Literal29" runat="server" Text="<%$Resources:db.lang,issuerc%>"/></th>
                                <td>
                                    <%=nenshkrimi.IssuerC %></td>
                            </tr>
                        </table>
                        <%} %>
                        
                            <asp:Button class="btn btn-primary" ID="BtnShkarkoRaportin" Text="<%$Resources:db.lang,btnReportdownload%>" OnClick="ShkarkoButton_Click" runat="server" />
                            <asp:Button class="btn btn-primary" ID="BtnVerfikoDocTjeter" Text="<%$Resources:db.lang,btnVerifyanother%>" OnClick="VerifikoDocTjeter_Click" runat="server" />
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-8 col-sm-offset-2">
            <hr style="margin-bottom: 5px; border-color: #2f2f2f" />
            <p align="justify">
                <small class="text-warning">
                    <asp:Literal ID="Literal8" runat="server" Text="<%$Resources:db.lang,Note%>"/>
                </small>
            </p>
        </div>
    </div>

    <br />
    <div class="row">
        <nav class="navbar navbar-default" style="background-color: #444; margin-bottom: 0px;">
            <p style="color: white; text-align: center; padding-top: 10px;">
                &copy; Copyright <%= DateTime.Now.ToString("yyyy") %> Ditjon Berisha
            </p>
        </nav>
    </div>
    </form>
</body>
</html>
