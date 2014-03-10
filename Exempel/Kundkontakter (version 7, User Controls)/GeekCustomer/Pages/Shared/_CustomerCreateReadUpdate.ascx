<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_CustomerCreateReadUpdate.ascx.cs" Inherits="GeekCustomer.Pages.Shared._CustomerCreateReadUpdate" %>

<%@ Register Src="~/Pages/Shared/_ContactCreateReadUpdate.ascx" TagPrefix="uc" TagName="ContactCreateReadUpdate" %>

<asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
<asp:ValidationSummary runat="server" CssClass="validation-summary-errors" ValidationGroup="vgContactSave" ShowModelStateErrors="False" />
<asp:FormView ID="CustomerFormView" runat="server"
    ItemType="GeekCustomer.Model.Customer"
    DataKeyNames="CustomerId"
    DefaultMode="ReadOnly"
    RenderOuterTable="false"
    SelectMethod="CustomerFormView_GetItem"
    InsertMethod="CustomerFormView_InsertItem"
    UpdateMethod="CustomerFormView_UpdateItem"
    OnInit="CustomerFormView_Init"
    OnDataBound="CustomerFormView_DataBound">
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
        <uc:ContactCreateReadUpdate runat="server" CustomerId="<%$ RouteValue:id %>" />
        <div>
            <asp:HyperLink runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("CustomerEdit", new { id = Item.CustomerId }) %>' />
            <asp:HyperLink runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("CustomerDelete", new { id = Item.CustomerId }) %>' />
            <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Customers", null)%>' />
        </div>
    </ItemTemplate>
    <InsertItemTemplate>
        <%-- OBS! Använder även denna mall för UpdateItemTemplate. Se CustomerFormView_Init och CustomerFormView_DataBound
            hur det löses med ett fåtal rader kod. --%>
        <div class="editor-label">
            <label for="Name">Namn</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# BindItem.Name %>' MaxLength="30" />
            <asp:RequiredFieldValidator runat="server" ErrorMessage="<%$ Resources:Strings, Customer_Name_Required %>"
                Display="Dynamic" Text="*" ControlToValidate="NameTextBox" SetFocusOnError="True"
                CssClass="field-validation-error" ValidationGroup="vgContactInsert" />
        </div>
        <div class="editor-label">
            <label for="Address">Adress</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# BindItem.Address %>' MaxLength="30" />
            <asp:RequiredFieldValidator runat="server" ErrorMessage="<%$ Resources:Strings, Customer_Address_Required %>"
                Display="Dynamic" Text="*" ControlToValidate="AddressTextBox" SetFocusOnError="True"
                CssClass="field-validation-error" ValidationGroup="vgContactSave" />
        </div>
        <div class="editor-label">
            <label for="PostalCode">Postnummer</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# BindItem.PostalCode %>' MaxLength="6" />
            <asp:RequiredFieldValidator runat="server" ErrorMessage="<%$ Resources:Strings, Customer_PostalCode_Required %>"
                Display="Dynamic" Text="*" ControlToValidate="PostalCodeTextBox" SetFocusOnError="True"
                CssClass="field-validation-error" ValidationGroup="vgContactSave" />
            <asp:RegularExpressionValidator runat="server" ErrorMessage="<%$ Resources:Strings, Customer_PostalCode_Invalid_Format %>"
                Display="Dynamic" Text="*" ControlToValidate="PostalCodeTextBox" SetFocusOnError="True"
                ValidationExpression="<%$ Resources:Strings, Regular_Expression_PostalCode %>"
                CssClass="field-validation-error" ValidationGroup="vgContactSave" />
        </div>
        <div class="editor-label">
            <label for="City">Ort</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="CityTextBox" runat="server" Text='<%# BindItem.City %>' MaxLength="30" />
            <asp:RequiredFieldValidator runat="server" ErrorMessage="<%$ Resources:Strings, Customer_City_Required %>"
                Display="Dynamic" Text="*" ControlToValidate="CityTextBox" SetFocusOnError="True"
                CssClass="field-validation-error" ValidationGroup="vgContactSave" />
        </div>
        <div>
            <asp:LinkButton ID="SaveLinkButton" runat="server" Text="Spara" CommandName="Insert" ValidationGroup="vgContactSave" />
            <asp:HyperLink ID="CancelHyperLink" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Customers", null) %>' />
        </div>
    </InsertItemTemplate>
</asp:FormView>
