<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientList.aspx.cs" Inherits="InterventionManagementSystem.Engineer.ClientList" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Client List</h3>
    <hr />
    <asp:ListView ID="ClientListView" runat="server">
        <LayoutTemplate>
            <table runat="server" class ="table table-striped table-bordered table-hover table-responsive" style ="background-color:white">
                <tr runat="server">
                    <th runat="server" class="col-md-6" >Client Name</th>
                    <th runat="server" class="col-md-6" >Action</th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr runat="server">
                <td><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'/></td>
                <td><asp:HyperLink ID="linkView" runat="server" Text="View" NavigateUrl='<%#"ClientDetails.aspx?id=" + Eval("Id") %>' /></td>
                <%-- <td><asp:HyperLink ID="HyperLink1" runat="server" Text="View" NavigateUrl='<%#"ClientDetails.aspx?Name=" + Eval("Name") %>' /></td>--%>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
