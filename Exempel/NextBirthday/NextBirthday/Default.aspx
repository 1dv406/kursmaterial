<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NextBirthday.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exempel - Nästa födelsedag</title>
    <link href="~/Content/site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="page">
        <div id="header">
            <div id="header_wrapper">
                <ul id="top">
                    <li>ASP.NET Web Forms (1DV406)</li>
                    <li>Föreläsning</li>
                    <li class="last">Exempel</li>
                </ul>
                <h1 id="logo_text">
                    Nästa födelsedag
                </h1>
            </div>
            <div id="menu_wrapper">
            </div>
        </div>
        <div id="main">
            <div class="editor-label">
                <asp:Label ID="Label1" runat="server" Text="Födelsedatum:" AssociatedControlID="Birthdate" />
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Birthdate" runat="server" autofocus="autofocus" TextMode="Date" />
            </div>
            <p>
                <asp:Button ID="SendButton" runat="server" Text="Skicka" OnClick="SendButton_Click" />
            </p>
            <asp:PlaceHolder ID="OutputPlaceHolder" runat="server" Visible="false">
                <p>
                    Födelsedagen infaller på en
                    <asp:Label ID="DayOfWeekLabel" runat="server" CssClass="bold" />
                    om
                    <asp:Label ID="DaysUntilBirthdayLabel" runat="server" CssClass="bold" />
                    dagar och jubilaren kommer då att fylla
                    <asp:Label ID="AgeOnLabel" runat="server" CssClass="bold" />
                    år.
                </p>
            </asp:PlaceHolder>
        </div>
        <div id="footer">
            <a id="cc" style="float: left;" href="http://creativecommons.org/licenses/by-nc-sa/2.5/se/">
                <img alt="Creative Commons Erkännande-IckeKommersiell-DelaLika 2.5 Sverige licens." src="~/Content/images/cc-by-nc-sa.png" runat="server" /></a>
            <span>Linnéuniversitetet | Fakulteten för teknik | Institutionen för datavetenskap</span>
        </div>
    </div>
    </form>
</body>
</html>
