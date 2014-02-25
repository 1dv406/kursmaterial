<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GeekPaging.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="theForm" runat="server">
    <div>
        <%-- 
            ListView-kontroll med paginering och funktionalitet för att ta bort en bokstavering
            efter att bekräftelse på klientsidan gjorts.    
        --%>
        <asp:ListView ID="SpellingAlphabetListView" runat="server"
            ItemType="GeekPaging.Model.SpellingLetter"
            SelectMethod="SpellingAlphabetListView_GetData"
            DeleteMethod="SpellingAlphabetListView_DeleteItem"
            DataKeyNames="Letter">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                </ul>
                <asp:DataPager ID="DataPager" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="True" FirstPageText=" << "
                            ShowNextPageButton="False" ShowPreviousPageButton="False"  />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="True" LastPageText=" >> "
                            ShowNextPageButton="False" ShowPreviousPageButton="False"  />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <%#: Item.Swedish %>
                    <asp:LinkButton runat="server" CommandName="Delete" Text="Radera"
                        OnClientClick='<%# String.Format("return confirm(\"Ta bort namnet {0}?\")", Item.Swedish) %>' />
                </li>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
