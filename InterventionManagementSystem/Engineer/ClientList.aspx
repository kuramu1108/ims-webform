<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientList.aspx.cs" Inherits="InterventionManagementSystem.Engineer.ClientList" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Client List - <%=getDetail().District.Name%></h3>
    <hr />
    <div class="main-body-content">
        <asp:ListView ID="ClientListView" runat="server">
            <LayoutTemplate>
                <table id="table-clients" class ="table table-striped table-bordered table-hover table-responsive" style ="background-color:white">
                    <thead>
                        <tr>
                            
                            <th style="width: 40%" >Name</th>
                            <th style="width: 60%" >Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                   
                    <td><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'/></td>
                    <td><asp:HyperLink ID="linkView" runat="server" Text="View" NavigateUrl='<%#"ClientDetails.aspx?id=" + Eval("Id") %>' /></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
