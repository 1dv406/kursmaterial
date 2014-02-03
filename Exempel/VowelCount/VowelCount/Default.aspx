<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VowelCount.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Hur många vokaler?</title>
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
                    Hur många vokaler?
                </h1>
            </div>
            <menu />
        </header>
        <div id="main">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade. Korrigera felet och försök igen."
                CssClass="validation-summary-errors icon-error" />
            <div class="textarea-wrapper">
                <asp:TextBox ID="InputTextBox" runat="server" TextMode="MultiLine" Rows="10" />
                <asp:RequiredFieldValidator ID="InputRequiredFieldValidator" runat="server" ErrorMessage="Fältet får inte vara tomt."
                    ControlToValidate="InputTextBox" CssClass="field-validation-error" Display="None" />
            </div>
            <asp:PlaceHolder ID="ResultPlaceHolder" runat="server" Visible="false">
                <p>
                    <asp:Literal ID="CountLiteral" runat="server">Texten innehåller {0} vokal(er).</asp:Literal>
                    <asp:Literal ID="DifferenceLiteral" runat="server" Visible="false"> Det är {0}{1} jämfört med föregående text.</asp:Literal>
                </p>
            </asp:PlaceHolder>
            <p>
                <asp:Button ID="SendButton" runat="server" OnClick="SendButton_Click" Text="Bestäm antalet vokaler" />
            </p>
        </div>
    </div>
    <footer>
        <a href="http://creativecommons.org/licenses/by-nc-sa/2.5/se/">
            <img alt="Creative Commons Erkännande-IckeKommersiell-DelaLika 2.5 Sverige licens." src="~/Content/images/cc-by-nc-sa.png" runat="server" /></a>
        <span>Linnéuniversitetet | Fakulteten för teknik | Institutionen för datavetenskap</span>
    </footer>
    </form>
</body>
</html>
