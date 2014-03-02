<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Delete" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Kundkontakter (version 5, Flera sidor)</title>
    <%: Styles.Render("~/Content/css") %>
    <%: Scripts.Render("~/bundles/modernizr") %>
</head>
<body>
    <form id="theForm" runat="server">
    <div id="page">
        <header>
            <div id="header-group">
                <ul id="top">
                    <li>ASP.NET Web Forms (1DV406)</li>
                    <li>Föreläsning</li>
                    <li class="last">Exempel</li>
                </ul>
                <h1 id="logo-text">
                    Kundkontakter <span id="small-logo-text">(version 5, Flera sidor)</span>
                </h1>
            </div>
            <menu />
        </header>
        <div id="main">
            <h1>
                Ta bort kund
            </h1>
            <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
            <asp:PlaceHolder runat="server" ID="ConfirmationPlaceHolder">
                <p>
                    Är du säker på att du vill ta bort kunden <strong>
                        <asp:Literal runat="server" ID="CustomerName" ViewStateMode="Enabled" /></strong>?
                </p>
            </asp:PlaceHolder>
            <div>
                <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ja, ta bort kunden"
                    OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id %>' />
                <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Avbryt" />
            </div>
        </div>
    </div>
    <footer>
        <a href="http://creativecommons.org/licenses/by-nc-sa/2.5/se/">
            <img id="Img1" alt="Creative Commons Erkännande-IckeKommersiell-DelaLika 2.5 Sverige licens." src="~/Content/images/cc-by-nc-sa.png" runat="server" /></a>
        <span>Linnéuniversitetet | Fakulteten för teknik | Institutionen för datavetenskap</span>
    </footer>
    </form>
</body>
</html>
