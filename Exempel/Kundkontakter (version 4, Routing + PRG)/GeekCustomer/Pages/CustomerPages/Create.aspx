<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Create" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kundkontakter (version 4, Routing + PRG)</title>
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
                    Kundkontakter <span id="small-logo-text">(version 4, Routing + PRG)</span>
                </h1>
            </div>
            <menu />
        </header>
        <div id="main">
            <h1>
                Ny kund
            </h1>
            <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
            <asp:FormView ID="CustomerFormView" runat="server"
                ItemType="GeekCustomer.Model.Customer"
                DefaultMode="Insert"
                RenderOuterTable="false"
                InsertMethod="CustomerFormView_InsertItem"
                OnItemCommand="CustomerFormView_ItemCommand">
                <InsertItemTemplate>
                    <div class="editor-label">
                        <label for="Name">Namn</label>
                    </div>
                    <div class="editor-field">
                        <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' />
                    </div>
                    <div class="editor-label">
                        <label for="Address">Adress</label>
                    </div>
                    <div class="editor-field">
                        <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' />
                    </div>
                    <div class="editor-label">
                        <label for="PostalCode">Postnummer</label>
                    </div>
                    <div class="editor-field">
                        <asp:TextBox ID="PostalCode" runat="server" Text='<%# BindItem.PostalCode %>' />
                    </div>
                    <div class="editor-label">
                        <label for="City">Ort</label>
                    </div>
                    <div class="editor-field">
                        <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' />
                    </div>
                    <div>
                        <asp:Button runat="server" Text="Spara" CommandName="Insert" />
                        <asp:Button runat="server" Text="Avbryt" CommandName="Cancel" />
                    </div>
                </InsertItemTemplate>
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
