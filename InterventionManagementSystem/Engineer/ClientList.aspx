<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientList.aspx.cs" Inherits="InterventionManagementSystem.Engineer.ClientList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Client List</h3>
    <div class="container">
        <div>
            <asp:ListView ID="ClientListView" runat="server">
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <th runat="server">Client Name</th>
                            <th runat="server">Action</th>
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
        </div>
    </div>
</asp:Content>
