<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataboundFiles.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Databundna filer</title>
    <%: Styles.Render("~/Content/css") %>
    <%: Scripts.Render("~/bundles/modernizr") %>
</head>
<body>
    <div id="page">
        <header>
            <div id="header-group">
                <ul id="top">
                    <li>ASP.NET Web Forms (1DV406)</li>
                    <li>Föreläsning</li>
                    <li class="last">Exempel</li>
                </ul>
                <h1 id="logo-text">
                    Databundna filer
                </h1>
            </div>
            <menu />
        </header>
        <div id="main">
            <form id="Form1" runat="server">
            <asp:Button runat="server" Text="Posta tomt formulär!" />
            <%-- Old School --%>
            <h1>&lt; ASP.NET 4.5 ("Old School")</h1>
            <asp:Repeater ID="OldSchoolFileRepeater" runat="server" OnItemDataBound="OldSchoolFileRepeater_ItemDataBound">
                <HeaderTemplate>
                    <ul class="files">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="FileHyperLink" runat="server"
                            Text='<%# Eval("Name") %>'
                            NavigateUrl='<%# Eval("Name", "~/Content/files/{0}") %>' />
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
            <%-- New School --%>
            <h1>&gt;=ASP.NET 4.5</h1>
            <asp:Repeater ID="Repeater" runat="server" 
                ItemType="DataboundFiles.Model.FileData" 
                SelectMethod="Repeater_GetData">
                <HeaderTemplate>
                    <ul class="files">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="FileHyperLink" runat="server"
                            Text='<%#: Item.Name %>'
                            NavigateUrl='<%# "~/Content/files/" + Item.Name %>'
                            CssClass='<%#: Item.CssClass %>' />
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <footer>
        <a href="http://creativecommons.org/licenses/by-nc-sa/2.5/se/">
            <img alt="Creative Commons Erkännande-IckeKommersiell-DelaLika 2.5 Sverige licens." src="~/Content/images/cc-by-nc-sa.png" runat="server" /></a>
        <span>Linnéuniversitetet | Fakulteten för teknik | Institutionen för datavetenskap</span>
    </footer>
    </form>
</body>
</html>
