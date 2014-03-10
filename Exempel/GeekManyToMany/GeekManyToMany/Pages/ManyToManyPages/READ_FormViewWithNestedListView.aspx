<%@ Page Title="READ_FormViewWithNestedListView" Language="C#" AutoEventWireup="true" CodeBehind="READ_FormViewWithNestedListView.aspx.cs" Inherits="GeekManyToMany.Pages.ManyToManyPages.READ_FormViewWithNestedListView" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        FormView med nästlad ListView
    </h1>
    <asp:FormView ID="CourseDateFormView" runat="server"
        ItemType="GeekManyToMany.Model.CourseDate"
        DataKeyNames="Id"
        SelectMethod="CourseDateFormView_GetItem">
        <ItemTemplate>
            <h2>
                <%# Item.Name %>
            </h2>
            <asp:ListView ID="StudentsListView" runat="server"
                ItemType="GeekManyToMany.Model.Participant"
                DataKeyNames="Id, CourseDateId, StudentId"
                SelectMethod="StudentsListView_GetData"
                OnItemDataBound="StudentsListView_ItemDataBound">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li><asp:Literal ID="NameLiteral" runat="server" /></li>
                </ItemTemplate>
            </asp:ListView>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
