<%@ Page Title="READ_Repeater" Language="C#" AutoEventWireup="true" CodeBehind="READ_Repeater.aspx.cs" Inherits="GeekManyToMany.Pages.ManyToManyPages.READ_Repeater" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Enkelt webbformulär med Literal-och Repeater-kontroll
    </h1>
    <h2>
        <asp:Literal ID="CourseDateNameLiteral" runat="server" />
    </h2>
    <asp:Repeater ID="ParticipantRepeater" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><%# Eval("Name") %></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
