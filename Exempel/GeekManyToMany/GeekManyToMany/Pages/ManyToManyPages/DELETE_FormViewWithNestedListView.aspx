<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="DELETE_FormViewWithNestedListView.aspx.cs" Inherits="GeekManyToMany.Pages.ManyToManyPages.DELETE_FormViewWithNestedListView" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        FormView med nästlad ListView - CREATE DELETE
    </h1>
    <asp:FormView ID="CourseDateFormView" runat="server"
        ItemType="GeekManyToMany.Model.CourseDate"
        DataKeyNames="Id"
        SelectMethod="CourseDateFormView_GetItem">
        <ItemTemplate>
            <h2>
                <%# Item.Name %>
            </h2>
            <asp:ListView ID="ParticipantListView" runat="server"
                ItemType="GeekManyToMany.Model.Participant"
                DataKeyNames="Id, CourseDateId, StudentId"
                SelectMethod="ParticipantListView_GetData"
                OnItemDataBound="ParticipantListView_ItemDataBound">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li>
                        <asp:Literal ID="NameLiteral" runat="server" />
                    </li>
                </ItemTemplate>
            </asp:ListView>
            <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" />
        </ItemTemplate>
        <EditItemTemplate>
            <h2>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.Name %>' />
            </h2>
            <asp:ListView ID="ParticipantListView" runat="server"
                ItemType="GeekManyToMany.Model.Participant"
                DataKeyNames="Id, CourseDateId, StudentId"
                SelectMethod="ParticipantListView_GetData"
                DeleteMethod="ParticipantListView_DeleteItem"
                OnItemDataBound="ParticipantListView_ItemDataBound"
                InsertItemPosition="LastItem">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li>
                        <asp:Literal ID="NameLiteral" runat="server" />
                        <asp:LinkButton runat="server" Text="Ta bort" />
                    </li>
                </ItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="StudentDropDownList" runat="server"
                        ItemType="GeekManyToMany.Model.Student"
                        DataValueField="Id"
                        DataTextField="FullName"
                        SelectMethod="StudentDropDownList_GetData"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="0" Text="[Välj deltagare]" />
                    </asp:DropDownList>
                </InsertItemTemplate>
            </asp:ListView>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
