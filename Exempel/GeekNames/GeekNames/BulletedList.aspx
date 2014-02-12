<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BulletedList.aspx.cs" Inherits="GeekNames.BulletedList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Osorterad lista - BulletedList
    </h1>
    <asp:BulletedList ID="GirlsNamesBulletedList" runat="server" 
        ItemType="System.String" SelectMethod="GirlsNamesBulletedList_Get" />

</asp:Content>
