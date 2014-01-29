<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Validation.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validering</title>
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
                <p id="logo_text">
                    Validering
                </p>
            </div>
            <div id="menu_wrapper">
            </div>
        </div>
        <div id="main">
            <%-- Rättmeddelande --%>
            <asp:PlaceHolder ID="MessagePlaceHolder" runat="server" Visible="false">
                <p id="icon-ok">
                    <asp:Literal ID="MessageLiteral" runat="server" Text="E-postaddressen '{0}' har hanterats." />
                </p>
            </asp:PlaceHolder>
            <%-- Felmeddelande --%>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors  icon-error"
                HeaderText="Fel inträffade. Korrigera och försök igen." />
            <%-- E-post --%>
            <div class="editor-label">
                <asp:Label ID="Label1" runat="server" AssociatedControlID="EmailTextBox" Text="E-post:" />
            </div>
            <div class="editor-field">
                <asp:TextBox ID="EmailTextBox" runat="server" TextMode="Email" />
                <%-- Validering --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EmailTextBox"
                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="E-postaddress måste anges."
                    SetFocusOnError="True" Text="*" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox"
                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="E-postaddressen verkar inte vara korrekt."
                    SetFocusOnError="True" Text="*" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$" />
            </div>
            <%-- Kommandoknappar --%>
            <p>
                <asp:Button ID="SendButton" runat="server" Text="Skicka" OnClick="SendButton_Click" />
                <asp:Button ID="SendWithoutValidationButton" runat="server" Text="Posta utan validering"
                    CausesValidation="false" OnClick="SendWithoutValidationButton_Click" />
                <asp:Button ID="SendServerValidationButton" runat="server" Text="Posta med enbart servervalidering"
                    CausesValidation="false" OnClick="SendServerValidationButton_Click" />
            </p>
        </div>
    </div>
    <div id="footer">
        <a id="cc" href="http://creativecommons.org/licenses/by-nc-sa/2.5/se/">
            <img alt="Creative Commons Erkännande-IckeKommersiell-DelaLika 2.5 Sverige licens." src="~/Content/images/cc-by-nc-sa.png" runat="server" /></a>
        <span>Linnéuniversitetet | Fakulteten för teknik | Institutionen för datavetenskap</span>
    </div>
    </form>
</body>
</html>
