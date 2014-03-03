<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="GeekCustomer.Pages.ContactPages.Delete" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Ta bort kunds kontaktuppgift
    </h1>
    <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
    <asp:PlaceHolder runat="server" ID="ConfirmationPlaceHolder">
        <p>
            Är du säker på att du vill ta bort kontaktuppgiften  <strong>
                <asp:Literal runat="server" ID="ContactValue" ViewStateMode="Enabled" /></strong> för <strong>
                    <asp:Literal runat="server" ID="CustomerName" ViewStateMode="Enabled" /></strong>?
        </p>
    </asp:PlaceHolder>
    <div>
        <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ja, ta bort kontaktuppgiften"
            OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id %>' />
        <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Avbryt" />
    </div>
</asp:Content>
