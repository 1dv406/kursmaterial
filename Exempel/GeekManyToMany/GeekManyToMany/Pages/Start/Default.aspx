<%@ Page Title="ASP.NET Web Forms (1DV406)" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GeekManyToMany.Pages.Start._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Hämta inspiration till ditt individuella arbete.</h2>
            </hgroup>
            <p>
                För att få en orientering om hur en "många-till-många"-relation kan lösas 
                genom att titta på exemplen nedan.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Exempel - CREATE</h3>
    <ol class="round">
        <li>-</li>
    </ol>
    <h3>Exempel - READ</h3>
    <ol class="round">
        <li class="one">
            <h5>Enkelt webbformulär med enbart två Literal-kontroller</h5>
            I webbformuläret
            <asp:HyperLink runat="server" NavigateUrl="~/Pages/ManyToManyPages/READ_Simple.aspx">READ_Simple.aspx</asp:HyperLink>
            sköts allt från Page_Load.
        </li>
        <li class="two">
            <h5>Literal- och Repeater-kontroller</h5>
            I webbformuläret
            <asp:HyperLink runat="server" NavigateUrl="~/Pages/ManyToManyPages/READ_Repeater.aspx">READ_Repeater.aspx</asp:HyperLink> används händelsen ItemDataBound för att slå
            upp information och populera en kontroll i den nästlade ListView-kontrollen.
        </li>
        <li class="three">
            <h5>FormView-kontroll med nästlad ListView-kontroll</h5>
            I webbformuläret
            <asp:HyperLink runat="server" NavigateUrl='<%$ RouteUrl:routename=CourseDateDetails, id=1 %>'>READ_FormViewWithNestedListView.aspx</asp:HyperLink>
            används händelsen ItemDataBound för att slå
            upp information och populera en kontroll i den nästlade ListView-kontrollen.
        </li>
    </ol>
    <h3>Exempel - UPDATE</h3>
    <ol class="round">
        <li>-</li>
    </ol>
    <h3>Exempel - DELETE</h3>
    <ol class="round">
        <li class="two">
            <h5>Literal- och Repeater-kontroller</h5>
            I webbformuläret
            <asp:HyperLink runat="server" NavigateUrl="~/Pages/ManyToManyPages/DELETE_Repeater.aspx">DELETE_Repeater.aspx</asp:HyperLink> används händelsen ItemDataBound för att slå
            upp information och populera en kontroll i den nästlade ListView-kontrollen.
        </li>
        <li class="three">
            <h5>FormView-kontroll med nästlad ListView-kontroll</h5>
            I webbformuläret
            <asp:HyperLink runat="server" NavigateUrl='<%$ RouteUrl:routename=CourseDateDetails, id=1 %>'>READ_FormViewWithNestedListView.aspx</asp:HyperLink>
            används händelsen ItemDataBound för att slå
            upp information och populera en kontroll i den nästlade ListView-kontrollen.
        </li>
    </ol>
</asp:Content>
