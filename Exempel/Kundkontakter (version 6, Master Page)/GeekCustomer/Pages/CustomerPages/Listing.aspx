<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Listing" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
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
            <%-- Detta visas då kunder saknas i databasen. --%>
            <p>
                Kunder saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
