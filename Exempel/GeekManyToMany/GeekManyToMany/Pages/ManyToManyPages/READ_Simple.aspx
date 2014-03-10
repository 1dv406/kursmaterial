<%@ Page Title="READ_Simple" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="READ_Simple.aspx.cs" Inherits="GeekManyToMany.Pages.ManyToManyPages.READ_Simple" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Enkelt webbformulär med enbart två Literal-kontroller
    </h1>
    <h2>
        <asp:Literal ID="CourseDateNameLiteral" runat="server" />
    </h2>
    <p>
        <asp:Literal ID="ParticipantLiteral" runat="server" />
    </p>
</asp:Content>
