<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Details" %>

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
                Kunddetaljer
            </h1>
            <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
                <asp:Literal runat="server" ID="SuccessMessageLiteral" />
            </asp:Panel>
            <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
            <asp:FormView ID="CustomerFormView" runat="server"
                ItemType="GeekCustomer.Model.Customer"
                SelectMethod="CustomerFormView_GetItem"
                RenderOuterTable="false">
                <ItemTemplate>
                    <div class="editor-label">
                        <label for="Name">Namn</label>
                    </div>
                    <div class="editor-field">
                        <%#: Item.Name %>
                    </div>
                    <div class="editor-label">
                        <label for="Address">Adress</label>
                    </div>
                    <div class="editor-field">
                        <%#: Item.Address %>
                    </div>
                    <div class="editor-label">
                        <label for="PostalCode">Postnummer</label>
                    </div>
                    <div class="editor-field">
                        <%#: Item.PostalCode %>
                    </div>
                    <div class="editor-label">
                        <label for="City">Ort</label>
                    </div>
                    <div class="editor-field">
                        <%#: Item.City %>
                    </div>
                    <div>
                        <asp:HyperLink runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("CustomerEdit", new { id = Item.CustomerId }) %>' />
                        <asp:HyperLink runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("CustomerDelete", new { id = Item.CustomerId }) %>' />
                        <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Customers", null)%>' />
                    </div>
                </ItemTemplate>
            </asp:FormView>
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
