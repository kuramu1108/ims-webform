<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountList.aspx.cs" Inherits="InterventionManagementSystem.Accountant.AccountList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Account List</h3>
    <div class="container">
        <h4>Site Engineer</h4>
        <div>
           <asp:ListView ID="EngineerListView" runat="server">
            <LayoutTemplate>
                <table id="table-clients" class ="table table-striped table-bordered table-hover table-responsive" style ="background-color:white">
                    <thead>
                        <tr>
                            <th style="width: 50px" ></th>
                            <th style="width: 40%" >Name</th>
                            <th style="width: calc(60% -50px)" >Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td></td>
                    <td><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'/></td>
                    <td><asp:HyperLink ID="linkView" runat="server" Text="Edit" NavigateUrl='<%#"EditDistrict.aspx?id=" + Eval("Id") %>' /></td>

                              
                </tr>
            </ItemTemplate>
        </asp:ListView>
        </div>
    </div>
    <div class="container">
        <h4>Manager</h4>
        <div>
            <asp:ListView ID="ManagerListView" runat="server">
            <LayoutTemplate>
                <table id="table-clients" class ="table table-striped table-bordered table-hover table-responsive" style ="background-color:white">
                    <thead>
                        <tr>
                            <th style="width: 50px" ></th>
                            <th style="width: 40%" >Name</th>
                            <th style="width: calc(60% -50px)" >Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td></td>
                    <td><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'/></td>
                    <td><asp:HyperLink ID="linkView" runat="server" Text="Edit" NavigateUrl='<%#"EditDistrict.aspx?id=" + Eval("Id") %>' /></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        </div>
    </div>
</asp:Content>
