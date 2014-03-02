<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Listing" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                Kunder
            </h1>
            <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
                <asp:Literal runat="server" ID="SuccessMessageLiteral" />
            </asp:Panel>
            <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
            <div class="editor-field">
                <asp:HyperLink runat="server" NavigateUrl='<%$ RouteUrl:routename=CustomerCreate %>' Text="Lägg till ny kund" />
            </div>
            <asp:ListView ID="CustomerListView" runat="server"
                ItemType="GeekCustomer.Model.Customer"
                SelectMethod="CustomerListView_GetData"
                DataKeyNames="CustomerId">
                <LayoutTemplate>
                    <%-- Platshållare för kunder --%>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </LayoutTemplate>
                <ItemTemplate>
                    <dl class="customer-card">
                        <dt>
                            <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("CustomerDetails", new { id = Item.CustomerId })  %>' Text='<%# Item.Name %>' /></dt>
                        <dd>
                            <%#: Item.Address %>
                        </dd>
                        <dd>
                            <%#: Item.PostalCode %> <%#: Item.City %>
                        </dd>
                    </dl>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <%-- Detta visas då kunduppgifter saknas i databasen. --%>
                    <p>
                        Kunduppgifter saknas.
                    </p>
                </EmptyDataTemplate>
            </asp:ListView>
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
