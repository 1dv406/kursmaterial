<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_ContactCreateReadUpdate.ascx.cs" Inherits="GeekCustomer.Pages.Shared._ContactCreateReadUpdate" ViewStateMode="Disabled" %>

<fieldset class="contact">
    <legend>Kontaktuppgifter</legend>

    <%-- ListView som presenterar en kunds kontaktuppgifter. --%>
    <asp:ListView ID="ContactListView" runat="server"
        ItemType="GeekCustomer.Model.Contact"
        DataKeyNames="ContactId, CustomerId, ContactTypeId"
        SelectMethod="ContactListView_GetData"
        InsertMethod="ContactListView_InsertItem"
        UpdateMethod="ContactListView_UpdateItem"
        OnItemCreated="ContactListView_ItemCreated"
        OnItemDataBound="ContactListView_ItemDataBound"
        OnPreRender="ContactListView_PreRender"
        InsertItemPosition="LastItem">
        <LayoutTemplate>
            <asp:ValidationSummary runat="server" HeaderText="<%$ Resources:Strings, Validation_Header %>"
                CssClass="validation-summary-errors" ShowModelStateErrors="False" />
            <asp:ValidationSummary runat="server" HeaderText="<%$ Resources:Strings, Validation_Header %>"
                CssClass="validation-summary-errors" ValidationGroup="vgContactInsert" ShowModelStateErrors="False" />
            <ul>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
        <EmptyDataTemplate>
            <p>
                Kontaktuppgifter saknas.
            </p>
        </EmptyDataTemplate>
        <ItemTemplate>
            <asp:MultiView ID="ContactMultiView" runat="server" ActiveViewIndex="0">
                <asp:View ID="ReadOnlyView" runat="server">
                    <%-- ListView som presenterar en kunds kontaktuppgifter. --%>
                    <li>
                        <%-- Label-kontrollen uppgift är att visa vilken typ kontaktinformationen är av. --%>
                        <asp:Label ID="ContactTypeNameLabel" runat="server" Text="{0}: " /><span><%#: Item.Value %></span>
                    </li>
                </asp:View>
                <asp:View ID="EditView" runat="server">
                    <li>
                        <asp:DropDownList ID="ContactTypeDropDownList" runat="server"
                            ItemType="GeekCustomer.Model.ContactType"
                            SelectMethod="ContactTypeDropDownList_GetData"
                            DataTextField="Name"
                            DataValueField="ContactTypeId"
                            SelectedValue='<%# Item.ContactTypeId %>'
                            Enabled="false" />
                        <asp:TextBox ID="ValueTextBox" runat="server" Text='<%# Item.Value %>' MaxLength="50" Enabled="false" />
                        <%-- "Kommandknappar" för att redigera och ta bort en kunduppgift . Kommandonamnen är VIKTIGA! --%>
                        <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                        <asp:HyperLink runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("ContactDelete", new { id = Item.ContactId }) %>' />
                    </li>
                </asp:View>
            </asp:MultiView>
        </ItemTemplate>
        <InsertItemTemplate>
            <li>
                <asp:DropDownList ID="ContactTypeDropDownList" runat="server"
                    ItemType="GeekCustomer.Model.ContactType"
                    SelectMethod="ContactTypeDropDownList_GetData"
                    DataTextField="Name"
                    DataValueField="ContactTypeId"
                    SelectedValue='<%# BindItem.ContactTypeId %>' />
                <asp:TextBox ID="ValueTextBox" runat="server" Text='<%# BindItem.Value %>' MaxLength="50" ValidationGroup="vgContactInsert" />
                <asp:RequiredFieldValidator runat="server" ErrorMessage="<%$ Resources:Strings, Contact_Value_Required %>"
                    ControlToValidate="ValueTextBox" CssClass="field-validation-error" ValidationGroup="vgContactInsert"
                    Display="Dynamic">*</asp:RequiredFieldValidator>
                <%-- "Kommandknappar" för att uppdatera en kontaktuppgift och avbryta. Kommandonamnen är VIKTIGA! --%>
                <asp:LinkButton runat="server" CommandName="Insert" Text="Spara" ValidationGroup="vgContactInsert" />
            </li>
        </InsertItemTemplate>
        <EditItemTemplate>
            <li>
                <asp:DropDownList ID="DropDownList1" runat="server"
                    ItemType="GeekCustomer.Model.ContactType"
                    SelectMethod="ContactTypeDropDownList_GetData"
                    DataTextField="Name"
                    DataValueField="ContactTypeId"
                    SelectedValue='<%# BindItem.ContactTypeId %>' />
                <asp:TextBox ID="ValueTextBox" runat="server" Text='<%# Bind("Value") %>' MaxLength="50" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="<%$ Resources:Strings, Contact_Value_Required %>"
                    ControlToValidate="ValueTextBox" CssClass="field-validation-error" Display="Dynamic">*</asp:RequiredFieldValidator>
                <%-- "Kommandknappar" för att uppdatera en kontaktuppgift och avbryta. Kommandonamnen är VIKTIGA! --%>
                <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
            </li>
        </EditItemTemplate>
    </asp:ListView>
</fieldset>
