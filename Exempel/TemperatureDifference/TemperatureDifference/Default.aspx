<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TemperatureDifference.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Temperaturskillnad</title>
    <%: Styles.Render("~/Content/css") %>
    <%: Scripts.Render("~/bundles/modernizr") %>
</head>
<body>
    <form id="form1" runat="server">
    <div id="page">
        <header>
            <div id="header-group">
                <ul id="top">
                    <li>ASP.NET Web Forms (1DV406)</li>
                    <li>Föreläsning</li>
                    <li class="last">Exempel</li>
                </ul>
                <h1 id="logo-text">
                    Temperaturskillnad
                </h1>
            </div>
            <menu />
        </header>
        <div id="main">
            <%-- Felmeddelanden --%>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors"
                HeaderText="Fel inträffade. Korrigera och försök igen." />
            <%-- Mintemperatur --%>
            <div class="editor-label">
                <asp:Label ID="Label1" runat="server" AssociatedControlID="Min" Text="Mintemperatur:" />
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Min" runat="server" TextMode="Number" />
                <%-- Validering --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="Min"
                    Text="*" ErrorMessage="Mintemperatur måste anges."
                    CssClass="field-validation-error" Display="Dynamic" SetFocusOnError="True" />
                <asp:CompareValidator ID="CompareValidator1" runat="server"
                    ControlToValidate="Min" Type="Integer" Operator="DataTypeCheck"
                    Text="*" ErrorMessage="Mintemperaturen måste anges i hela grader."
                    CssClass="field-validation-error" Display="Dynamic" SetFocusOnError="True"></asp:CompareValidator>
            </div>
            <%-- Maxtemperatur --%>
            <div class="editor-label">
                <asp:Label ID="Label2" runat="server" AssociatedControlID="Max" Text="Maxtemperatur:" />
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Max" runat="server" TextMode="Number" />
                <%-- Validering --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="Max"
                    Text="*" ErrorMessage="Maxtemperatur måste anges."
                    CssClass="field-validation-error" Display="Dynamic" SetFocusOnError="True" />
                <asp:CompareValidator ID="CompareValidator2" runat="server"
                    ControlToValidate="Max" ControlToCompare="Min" Operator="GreaterThanEqual" Type="Integer"
                    Text="*" ErrorMessage="Maxtemperaturen måste vara högre än mintemperaturen."
                    CssClass="field-validation-error" Display="Dynamic" SetFocusOnError="True"></asp:CompareValidator>
            </div>
            <%-- Kommandoknapp --%>
            <div>
                <asp:Button ID="SendButton" runat="server" Text="Skicka" OnClick="SendButton_Click" />
            </div>
            <%-- Resultat --%>
            <asp:PlaceHolder ID="OuputPlaceHolder" runat="server" Visible="false">
                <p>
                    <asp:Literal ID="OutputLiteral" runat="server">Temperaturdifferensen är {0} &deg;C.</asp:Literal>
                </p>
            </asp:PlaceHolder>
        </div>
    </div>
    <footer>
        <a id="cc" href="http://creativecommons.org/licenses/by-nc-sa/2.5/se/">
            <img alt="Creative Commons Erkännande-IckeKommersiell-DelaLika 2.5 Sverige licens." src="~/Content/images/cc-by-nc-sa.png" runat="server" /></a>
        <span>Linnéuniversitetet | Fakulteten för teknik | Institutionen för datavetenskap</span>
    </footer>
    </form>
</body>
</html>
