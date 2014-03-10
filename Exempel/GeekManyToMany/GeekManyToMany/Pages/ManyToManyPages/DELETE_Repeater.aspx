<%@ Page Title="DELETE_Repeater" Language="C#" AutoEventWireup="true" CodeBehind="DELETE_Repeater.aspx.cs" Inherits="GeekManyToMany.Pages.ManyToManyPages.DELETE_Repeater" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Enkelt webbformulär med Literal-och Repeater-kontroll för DELETET
    </h1>
    <h2>
        <asp:Literal ID="CourseDateNameLiteral" runat="server" />
    </h2>
    <asp:Repeater ID="ParticipantRepeater" runat="server" OnItemCommand="ParticipantRepeater_ItemCommand">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><%# Eval("Name") %>
                <asp:LinkButton ID="DeleteLinkButton" runat="server" Text="Ta bort" 
                    CommandName="Delete" CommandArgument='<%# Eval("ParticipantId") %>' /></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
