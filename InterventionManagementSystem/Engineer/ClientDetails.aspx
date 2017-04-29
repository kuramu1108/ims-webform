<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientDetails.aspx.cs" Inherits="InterventionManagementSystem.ClientDetails" %>

<asp:Content ID="ClientDetailPage" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblClientName" runat="server" Text="Client Name: " Font-Size="Large"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblName" runat="server" Font-Size="Medium"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblClientLocation" runat="server" Text="Client Location: " Font-Size="Large"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblLocation" runat="server" Font-Size="Medium"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblClientDistricts" runat="server" Text="Client District: " Font-Size="Large"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblDistrict" runat="server" Font-Size="Medium"></asp:Label>
                </div>
            </div>
            <div class="row">
                <asp:Label ID="lblInterventionList" runat="server" Text="Intervention List: " Font-Size="Large"></asp:Label>

            </div>
        </div>


    </div>
    <asp:ListView ID="InterventionList" runat="server">
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
                    <td><asp:Label ID="lblState" runat ="server" Text ='<%#Eval("State") %>' /></td>
                    <td><asp:HyperLink ID="linkView" runat="server" Text="Edit" NavigateUrl='<%#"EditIntervention.aspx?id=" + Eval("Id") %>' /></td>
                     <td><asp:HyperLink ID="HyperLink1" runat="server" Text="View" NavigateUrl='<%#"InterventionDetail.aspx?id=" + Eval("Id") %>' /></td>
                </tr>
            </ItemTemplate>

          
    </asp:ListView>
</asp:Content>
