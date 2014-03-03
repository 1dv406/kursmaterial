<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_CustomerCreateReadUpdate.ascx.cs" Inherits="GeekCustomer.Pages.Shared._CustomerCreateReadUpdate" %>
<%@ Register Src="~/Pages/Shared/_ContactCreateReadUpdate.ascx" TagPrefix="uc1" TagName="_ContactCreateReadUpdate" %>

<asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
<asp:FormView ID="CustomerFormView" runat="server"
    ItemType="GeekCustomer.Model.Customer"
    DataKeyNames="CustomerId"
    DefaultMode="ReadOnly"
    RenderOuterTable="false"
    SelectMethod="CustomerFormView_GetItem"
    InsertMethod="CustomerFormView_InsertItem"
    UpdateMethod="CustomerFormView_UpdateItem">
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
        <uc1:_ContactCreateReadUpdate runat="server" ID="_ContactCreateReadUpdate" CustomerId="<%$ RouteValue:id %>" />
        <div>
            <asp:HyperLink runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("CustomerEdit", new { id = Item.CustomerId }) %>' />
            <asp:HyperLink runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("CustomerDelete", new { id = Item.CustomerId }) %>' />
            <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Customers", null)%>' />
        </div>
    </ItemTemplate>
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
            <asp:LinkButton runat="server" Text="Spara" CommandName="Insert" />
            <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Customers", null) %>' />
        </div>
    </InsertItemTemplate>
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
        <uc1:_ContactCreateReadUpdate runat="server" CustomerId="<%$ RouteValue:id %>" ReadOnly="false" />
        <div>
            <asp:LinkButton runat="server" Text="Spara" CommandName="Update" />
            <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("CustomerDetails", new { id = Item.CustomerId }) %>' />
        </div>
    </EditItemTemplate>
</asp:FormView>
