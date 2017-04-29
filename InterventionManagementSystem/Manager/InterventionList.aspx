<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="InterventionList.aspx.cs" Inherits="InterventionManagementSystem.Manager.InterventionList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Interventions List</h3>
    <hr />
    <div class="main-body-content">
        <table id="table-clients" class="table table-striped table-bordered table-hover table-responsive" style="background-color: white">
            <thead>
                <tr>
                    <th class ="col-md-3 col-lg-4">Type</th>
                    <th class ="col-md-2 col-lg-2">Client</th>
                    <th class ="col-md-3 col-lg-2">Perform Date</th>
                    <th class ="col-md-1 col-lg-2">Status</th>
                    <th class ="col-md-3 col-lg-2">Action</th>
                </tr>
            </thead>
            <asp:ListView ID="InterventionListView" runat="server">
                <LayoutTemplate>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder">
                        </tr>
                    </tbody>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("InterventionType.Name") %>' /></td>
                        <td>
                            <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("Client.Name") %>' /></td>
                        <td>
                            <asp:Label ID="lblDistrictName" runat="server" Text='<%#Eval("DateFinish") %>' /></td>
                        <td>
                            <asp:Label ID="State" runat="server" Text='<%#Eval("State") %>' /></td>
                        <td>
                            <asp:HyperLink ID="linkView" runat="server" Text="View" NavigateUrl='<%#"ClientDetails.aspx?id=" + Eval("Id") %>' /></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

        </table>
    </div>
</asp:Content>
