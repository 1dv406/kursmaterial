<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="RadioButtonList.aspx.cs" Inherits="GeekNames.RadioButtonList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Sorterad lista med alternativknappar - RadioButtonListList
    </h1>
    <p>
        (Sortering av datat görs i affärslogiklagret med hjälp av LINQ to Objects.)
    </p>
    <p>
        Alternativknappar i en kolumn (använder table-tagg!)
    </p>
    <asp:RadioButtonList ID="GirlsNamesRadioButtonList" runat="server" />
    <hr />
    <p>
        Alternativknappar i tre kolumner (använder table-tagg!)
    </p>
    <asp:ObjectDataSource ID="SimpleDataObjectDataSource" runat="server" SelectMethod="GetPopularGirlNamesOrderedByName"
        TypeName="GeekNames.Model.Service" />
    <asp:CheckBoxList ID="GirlsNamesCheckBoxList2" runat="server" DataSourceID="SimpleDataObjectDataSource"
        RepeatColumns="3" RepeatDirection="Horizontal">
    </asp:CheckBoxList>
    <hr />
    <p>
        Tre alternativknappar på varje rad (rader bryts med br-tagg)
    </p>
    <asp:CheckBoxList ID="GirlsNamesCheckBoxList3" runat="server" DataSourceID="SimpleDataObjectDataSource"
        RepeatColumns="3" RepeatDirection="Horizontal" RepeatLayout="Flow" />
</asp:Content>
