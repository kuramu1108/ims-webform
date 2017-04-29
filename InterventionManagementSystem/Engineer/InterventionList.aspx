<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterventionList.aspx.cs" Inherits="InterventionManagementSystem.Engineer.InterventionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Intervention List</h3>

    <div class="main-body-content">

         <asp:ListView ID="ListofIntervention" runat="server">
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
                    <td><asp:Label ID="lblIntervention" runat="server" Text='<%#Eval("InterventionType.Name") %>'/></td>
                    <td><asp:Label ID="lblState" runat ="server" Text ='<%#Eval("State") %>' /></td>
                    <td><asp:HyperLink ID="linkView" runat="server" Text="Edit" NavigateUrl='<%#"EditIntervention.aspx?id=" + Eval("Id") %>' /></td>
                     <td><asp:HyperLink ID="HyperLink1" runat="server" Text="View" NavigateUrl='<%#"InterventionDetail.aspx?id=" + Eval("Id") %>' /></td>
                </tr>
            </ItemTemplate>

          
    </asp:ListView>
    </div>
</asp:Content>
