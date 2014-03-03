<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_MainNavigation.ascx.cs" Inherits="GeekCustomer.Pages.Shared._MainNavigation" %>

<ul>
    <li id="HomeLi" runat="server">
        <asp:HyperLink ID="HomeHyperLink" runat="server" NavigateUrl='<%$ RouteUrl:routename=Default %>'>Kunder</asp:HyperLink></li>
    <li id="CreateLi" runat="server">
        <asp:HyperLink ID="CreateHyperLink" runat="server" NavigateUrl='<%$ RouteUrl:routename=CustomerCreate %>'>Ny kund</asp:HyperLink></li>
    <li></li>
</ul>
