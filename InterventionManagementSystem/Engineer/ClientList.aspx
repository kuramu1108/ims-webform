<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientList.aspx.cs" Inherits="InterventionManagementSystem.Engineer.ClientList" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Client List - <%=getDetail().District.Name%></h3>
    <hr />
    <asp:ListView ID="ClientListView" runat="server">
        <LayoutTemplate>
            <table runat="server" class ="table table-striped table-bordered table-hover table-responsive" style ="background-color:white">
                <tr runat="server">
                    <th runat="server" style="width: 50px" ></th>
                    <th runat="server" style="width: 40%" >Name</th>
                    <th runat="server" style="width: calc(60% -50px)" >Action</th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr runat="server">
                <td></td>
                <td><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'/></td>
                <td><asp:HyperLink ID="linkView" runat="server" Text="View" NavigateUrl='<%#"ClientDetails.aspx?id=" + Eval("Id") %>' /></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
