<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Edit" %>

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
                Redigera kund
            </h1>
            <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
            <asp:FormView ID="CustomerFormView" runat="server"
                ItemType="GeekCustomer.Model.Customer"
                DataKeyNames="CustomerId"
                DefaultMode="Edit"
                RenderOuterTable="false"
                SelectMethod="CustomerFormView_GetItem"
                UpdateMethod="CustomerFormView_UpdateItem">
                <EditItemTemplate>
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
                        <asp:LinkButton runat="server" Text="Spara" CommandName="Update" />
                        <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("CustomerDetails", new { id = Item.CustomerId }) %>' />
                    </div>
                </EditItemTemplate>
            </asp:FormView>
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
