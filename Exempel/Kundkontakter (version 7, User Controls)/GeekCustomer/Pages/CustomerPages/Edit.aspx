<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Edit" %>

<%@ Register src="../Shared/_CustomerCreateReadUpdate.ascx" tagname="CustomerCreateReadUpdate" tagprefix="uc" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Redigera kund
    </h1>
    <uc:CustomerCreateReadUpdate runat="server" ViewMode="Edit" />
</asp:Content>
