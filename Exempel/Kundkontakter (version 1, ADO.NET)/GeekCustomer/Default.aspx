<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GeekCustomer.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Kundkontakter (version 1, ADO.NET)</title>
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
                    Kundkontakter <span id="small_logo_text">(version 1, ADO.NET)</span>
                </h1>
            </div>
            <menu />
        </header>
        <div id="main">
            <form id="theForm" runat="server">
            <h1>
                Kunder
            </h1>
            <%-- 
                    Visar alla kunder.
                    Hämtar alla kunduppgifter som finns i tabellen Customer i databasen via affärslogikklassen Service och 
                    metoden GetCustomers, som i sin tur använder klassen CustomerDAL och metoden GetCustomers, som skapar en
                    lista med referenser till Customer-objekt; ett Customer-objekt för varje post i tabellen. 
            --%>
            <asp:ListView ID="CustomerListView" runat="server"
                ItemType="GeekCustomer.Model.Customer"
                SelectMethod="CustomerListView_GetData"
                DataKeyNames="CustomerId">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>
                                Namn
                            </th>
                            <th>
                                Adress
                            </th>
                            <th>
                                Postnummer
                            </th>
                            <th>
                                Ort
                            </th>
                        </tr>
                        <%-- Platshållare för nya rader --%>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <%-- Mall för nya rader. --%>
                    <tr>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%#: Item.Name %>' />
                        </td>
                        <td>
                            <asp:Label ID="AddressLabel" runat="server" Text='<%#: Item.Address %>' />
                        </td>
                        <td>
                            <asp:Label ID="PostalCodeLabel" runat="server" Text='<%#: Item.PostalCode %>' />
                        </td>
                        <td>
                            <asp:Label ID="CityLabel" runat="server" Text='<%#: Item.City %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <%-- Detta visas då kunduppgifter saknas i databasen. --%>
                    <p>
                        Kunduppgifter saknas.
                    </p>
                </EmptyDataTemplate>
            </asp:ListView>
            </form>
        </div>
    </div>
    <footer>
        <a href="http://creativecommons.org/licenses/by-nc-sa/2.5/se/">
            <img alt="Creative Commons Erkännande-IckeKommersiell-DelaLika 2.5 Sverige licens." src="~/Content/images/cc-by-nc-sa.png" runat="server" /></a>
        <span>Linnéuniversitetet | Fakulteten för teknik | Institutionen för datavetenskap</span>
    </footer>
</body>
</html>
