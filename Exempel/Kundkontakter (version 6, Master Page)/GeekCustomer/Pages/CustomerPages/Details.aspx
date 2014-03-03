<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Details" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Kund
    </h1>
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
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
</asp:Content>
