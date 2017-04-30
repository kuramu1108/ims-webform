<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportList.aspx.cs" Inherits="InterventionManagementSystem.Accountant.ReportList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Report List</h3>
      <asp:ListView ID="ReportListView" runat="server">
            <LayoutTemplate>
                <table id="table-clients" class ="table table-striped table-bordered table-hover table-responsive" style ="background-color:white">
                    <thead>
                        <tr>
                        
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
                   
                    <td><asp:Label ID="lblName" runat="server" Text='<%# Container.DataItem %>'/></td>
                    <td><asp:HyperLink ID="linkView" runat="server" Text="Print" NavigateUrl='<%#"Report.aspx?Name=" + Container.DataItem%>' /></td>

                              
                </tr>
            </ItemTemplate>
        </asp:ListView>

</asp:Content>
