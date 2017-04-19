<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountList.aspx.cs" Inherits="InterventionManagementSystem.Accountant.AccountList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Account List</h3>
    <div class="container">
        <h4>Site Engineer</h4>
        <div>
            <asp:ListView ID="ListViewEngineer" runat="server">
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <th runat="server">Name</th>
                            <th runat="server">District</th>
                            <th runat="server">Action</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'/></td>
                        <td><asp:Label ID="lblDistrict" runat="server" Text='<%#Eval("DistrictId") %>'/></td>
                        <%--<td><asp:HyperLink ID="linkEdit" runat="server" Text="Edit District" NavigateUrl='<%#"EditDistrict.aspx?id=" + Eval("Id") %>' /></td>--%>
                        <td><asp:HyperLink ID="linkEdit" runat="server" Text="Edit District" NavigateUrl='<%#"EditDistrict.aspx?Name=" + Eval("Name") %>' /></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <div class="container">
        <h4>Manager</h4>
        <div>
            <asp:ListView ID="ListViewManager" runat="server">
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <th runat="server">Name</th>
                            <th runat="server">District</th>
                            <th runat="server">Action</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'/></td>
                        <td><asp:Label ID="lblDistrict" runat="server" Text='<%#Eval("DistrictId") %>'/></td>
   <%--                     <td><asp:HyperLink ID="linkEdit" runat="server" Text="Edit District" NavigateUrl='<%#"EditDistrict.aspx?id=" + Eval("Id") %>' /></td>--%>
                         <td><asp:HyperLink ID="HyperLink1" runat="server" Text="Edit District" NavigateUrl='<%#"EditDistrict.aspx?Name=" + Eval("Name") %>' /></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
