<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="GeekNames.GridView" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ObjectDataSource ID="BabyGirlNamesObjectDataSource" runat="server" SelectMethod="GetPopularBabyGirlNames"
        TypeName="GeekNames.Model.Service" />
    <asp:GridView ID="BabyGirlNamesGridView" runat="server"
        AutoGenerateColumns="False" CssClass="grid"
        DataSourceID="BabyGirlNamesObjectDataSource" GridLines="None">
        <RowStyle CssClass="row" />
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Number" HeaderText="Number"
                SortExpression="Number" />
        </Columns>
        <HeaderStyle CssClass="header" />
        <AlternatingRowStyle CssClass="alternating" />
    </asp:GridView>
    <hr />
    <asp:ObjectDataSource ID="BabyNamesObjectDataSource" runat="server" SelectMethod="GetPopularBabyNames"
        TypeName="GeekNames.Model.Service" />
    <asp:GridView ID="BabyNamesGridView" runat="server" AutoGenerateColumns="False" CssClass="name-grid"
        DataSourceID="BabyNamesObjectDataSource" OnRowDataBound="BabyNamesGridView_RowDataBound"
        GridLines="None">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Number" HeaderText="Number" SortExpression="Number" />
        </Columns>
        <HeaderStyle CssClass="header" />
    </asp:GridView>
</asp:Content>
