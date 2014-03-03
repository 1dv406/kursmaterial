<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Create" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <p>
        Vi är beklagar att ett fel inträffade och vi inte kunde hantera din förfrågan.
    </p>
    <p>
        <a href='<%$ RouteUrl:routename=Customers %>' runat="server">Tillbaka till listan med kunder</a>
    </p>
</asp:Content>
