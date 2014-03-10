<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_ContactEdit.ascx.cs" Inherits="GeekCustomer.Pages.Shared._ContactEdit" %>

<div class="editor-label">
    <label for="Name">Namn</label>
</div>
<div class="editor-field">
    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# BindItem.Name %>' MaxLength="30" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:Strings, Customer_Name_Required %>"
        Display="Dynamic" Text="*" ControlToValidate="NameTextBox" SetFocusOnError="True"
        CssClass="field-validation-error" ValidationGroup="vgContactInsert" />
</div>
<div class="editor-label">
    <label for="Address">Adress</label>
</div>
<div class="editor-field">
    <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# BindItem.Address %>' MaxLength="30" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:Strings, Customer_Address_Required %>"
        Display="Dynamic" Text="*" ControlToValidate="AddressTextBox" SetFocusOnError="True"
        CssClass="field-validation-error" ValidationGroup="vgContactInsert" />
</div>
<div class="editor-label">
    <label for="PostalCode">Postnummer</label>
</div>
<div class="editor-field">
    <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# BindItem.PostalCode %>' MaxLength="6" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$ Resources:Strings, Customer_PostalCode_Required %>"
        Display="Dynamic" Text="*" ControlToValidate="PostalCodeTextBox" SetFocusOnError="True"
        CssClass="field-validation-error" ValidationGroup="vgContactInsert" />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="<%$ Resources:Strings, Customer_PostalCode_Invalid_Format %>"
        Display="Dynamic" Text="*" ControlToValidate="PostalCodeTextBox" SetFocusOnError="True"
        ValidationExpression="<%$ Resources:Strings, Regular_Expression_PostalCode %>"
        CssClass="field-validation-error" ValidationGroup="vgContactInsert" />
</div>
<div class="editor-label">
    <label for="City">Ort</label>
</div>
<div class="editor-field">
    <asp:TextBox ID="CityTextBox" runat="server" Text='<%# BindItem.City %>' MaxLength="30" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="<%$ Resources:Strings, Customer_City_Required %>"
        Display="Dynamic" Text="*" ControlToValidate="CityTextBox" SetFocusOnError="True"
        CssClass="field-validation-error" ValidationGroup="vgContactInsert" />
</div>

