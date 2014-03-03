<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Create" %>

<%@ Register src="../Shared/_CustomerCreateReadUpdate.ascx" tagname="CustomerCreateReadUpdate" tagprefix="uc" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Ny kund
    </h1>
    <uc:CustomerCreateReadUpdate runat="server" ViewMode="Insert" />
</asp:Content>
