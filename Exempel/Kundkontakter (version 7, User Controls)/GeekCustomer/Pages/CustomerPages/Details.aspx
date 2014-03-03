<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Details" %>

<%@ Register src="../Shared/_CustomerCreateReadUpdate.ascx" tagname="CustomerCreateReadUpdate" tagprefix="uc" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Kund
    </h1>
        <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
    </asp:Panel>
    <uc:CustomerCreateReadUpdate runat="server" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
    <%: Scripts.Render("~/bundles/app") %>
</asp:Content>
