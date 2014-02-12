<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GeekTallStory.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista med skrönor</title>
    <%: Styles.Render("~/Content/css") %>
    <%: Scripts.Render("~/bundles/modernizr") %>
</head>
<body>
    <form id="theForm" runat="server">
    <div id="page">
        <header>
            <div id="header-group">
                <ul id="top">
                    <li>ASP.NET Web Forms (1DV406)</li>
                    <li>Föreläsning</li>
                    <li class="last">Exempel</li>
                </ul>
                <h1 id="logo-text">
                    Lista med skrönor
                </h1>
            </div>
            <menu />
        </header>
        <div id="main">
            <%-- 
                Repeater-kontrollen är i princip en deklarativ "for"-sats. För varje skröna som SelectMethod
                tillhandahåller kommer innehållet i "ItemTemplate" att tjäna som en mall och rubriken (Header) 
                och själva skrönan (Phrase) kommer att rendaras ut.
                (För säkerhets skull använder jag Server.HtmlEncode (:) för att "sterilisera" eventuellt elaka taggar.)
            --%>
            <asp:Repeater ID="TallStoryRepeater" runat="server"
                ItemType="GeekTallStory.Model.TallStory"
                SelectMethod="TallStoryRepeater_GetData">
                <ItemTemplate>
                    <h1>
                        <%#: Item.Header %>
                    </h1>
                    <p>
                        <%#: Item.Phrase %>
                    </p>
                </ItemTemplate>
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
