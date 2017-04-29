<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="InterventionList.aspx.cs" Inherits="InterventionManagementSystem.Manager.InterventionList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Interventions List</h3>
    <hr />
    <div class="main-body-content">
        <asp:ListView ID="InterventionListView" runat="server">
            <LayoutTemplate>
                <table id="table-clients" class ="table table-striped table-bordered table-hover table-responsive" style ="background-color:white">
                    <table class="table">
                    <thead>
                        <th>Intervention Name</th>
                        <th>Client Name</th>
                        <th>Date Perform</th>
                        <th>Status</th>
                        <th>Action</th>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder">
                        </tr>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td></td>
                    <td><asp:Label ID="lblName" runat="server" Text='<%#Eval("InterventionType.Name") %>'/></td>
                    <td><asp:Label ID="lblClientName" runat="server" Text='<%#Eval("Client.Name") %>'/></td>
                    <td><asp:Label ID="lblDistrictName" runat="server" Text='<%#Eval("DateFinish") %>'/></td>
                    <td><asp:Label ID="State" runat="server" Text='<%#Eval("State") %>'/></td>
                    <td><asp:HyperLink ID="linkView" runat="server" Text="View" NavigateUrl='<%#"ClientDetails.aspx?id=" + Eval("Id") %>' /></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
