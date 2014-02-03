<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleTallStory.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:1dv406.AnecdoteConnectionString %>" 
            SelectCommand="SELECT TallStoryId, Header, Context FROM TallStory">
        </asp:SqlDataSource>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="TallStoryId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Header" HeaderText="Header" SortExpression="Header" />
                <asp:BoundField DataField="Context" HeaderText="Context" SortExpression="Context" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
