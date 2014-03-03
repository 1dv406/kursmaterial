<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Delete" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Ta bort kund
    </h1>
    <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
    <asp:PlaceHolder runat="server" ID="ConfirmationPlaceHolder">
        <p>
            Är du säker på att du vill ta bort kunden <strong>
                <asp:Literal runat="server" ID="CustomerName" ViewStateMode="Enabled" /></strong>?
        </p>
    </asp:PlaceHolder>
    <div>
        <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ja, ta bort kunden"
            OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id %>' />
        <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Avbryt" />
    </div>
</asp:Content>
