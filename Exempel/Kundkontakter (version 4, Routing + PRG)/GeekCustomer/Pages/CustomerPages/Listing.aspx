<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="GeekCustomer.Pages.CustomerPages.Listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Kundkontakter (version 4, Routing + PRG)</title>
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
                    Kundkontakter <span id="small-logo-text">(version 4, Routing + PRG)</span>
                </h1>
            </div>
            <menu />
        </header>
        <div id="main">
            <h1>
                Kunder
            </h1>
            <asp:Panel runat="server" ID="MessagePanel" Visible="false" CssClass="icon-ok">
                <asp:Literal runat="server" ID="MessageLiteral" />
            </asp:Panel>
            <div class="editor-field">
                <asp:HyperLink runat="server" NavigateUrl='<%$ RouteUrl:routename=CustomersCreate %>' Text="Lägg till ny kund" />
            </div>
            <asp:ValidationSummary runat="server" HeaderText="Fel inträffade. Korrigera det som är fel och försök igen."
                CssClass="validation-summary-errors" />
            <%-- 
                    Visar alla kunder. Innehåller även kommandoknappar för att uppdatera och ta bort kunder.
                    Hämtar alla kunduppgifter som finns i tabellen Customer i databasen via affärslogikklassen Service och 
                    metoden GetCustomers, som i sin tur använder klassen CustomerDAL och metoden GetCustomers, som skapar en
                    lista med referenser till Customer-objekt; ett Customer-objekt för varje post i tabellen. 
            --%>
            <asp:ListView ID="CustomerListView" runat="server"
                ItemType="GeekCustomer.Model.Customer"
                SelectMethod="CustomerListView_GetData"
                UpdateMethod="CustomerListView_UpdateItem"
                DeleteMethod="CustomerListView_DeleteItem"
                DataKeyNames="CustomerId">
                <LayoutTemplate>
                    <table class="grid">
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
                            <th>
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
                            <%#: Item.Name %>
                        </td>
                        <td>
                            <%#: Item.Address %>
                        </td>
                        <td>
                            <%#: Item.PostalCode %>
                        </td>
                        <td>
                            <%#: Item.City %>
                        </td>
                        <td class="command">
                            <%-- "Kommandknappar" för att ta bort och redigera kunduppgifter. Kommandonamnen är VIKTIGA! --%>
                            <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" />
                            <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <%-- Detta visas då kunduppgifter saknas i databasen. --%>
                    <table class="grid">
                        <tr>
                            <td>
                                Kunduppgifter saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EditItemTemplate>
                    <%-- Mall för rad i tabellen för att redigera kunduppgifter. --%>
                    <tr>
                        <td>
                            <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PostalCode" runat="server" Text='<%# BindItem.PostalCode %>' class="postal-code" />
                        </td>
                        <td>
                            <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' />
                        </td>
                        <td>
                            <%-- "Kommandknappar" för att uppdatera en kunduppgift och avbryta. Kommandonamnen är VIKTIGA! --%>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <footer>
        <a href="http://creativecommons.org/licenses/by-nc-sa/2.5/se/">
            <img id="Img1" alt="Creative Commons Erkännande-IckeKommersiell-DelaLika 2.5 Sverige licens." src="~/Content/images/cc-by-nc-sa.png" runat="server" /></a>
        <span>Linnéuniversitetet | Fakulteten för teknik | Institutionen för datavetenskap</span>
    </footer>
    </form>
</body>
</html>
