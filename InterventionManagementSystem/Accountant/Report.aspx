<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="InterventionManagementSystem.Accountant.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ReportListView" runat="server">
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
                    <td><asp:Label ID="lblName" runat="server" Text='<%# Eval("FirstProperty") %>'/></td>
                    <td><asp:Label ID="lblCost" runat="server" Text='<%# Eval("Costs") %>' /></td>
                    <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("Hours") %>' /></td>

                              
                </tr>
            </ItemTemplate>
        </asp:ListView>

</asp:Content>
