<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterventionList.aspx.cs" Inherits="InterventionManagementSystem.Engineer.InterventionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Intervention List -<%=getDetail().District.Name %></h3>

    <div class="main-body-content">

         <asp:ListView ID="ListofIntervention" runat="server">
         <LayoutTemplate>
                <table id="table-clients" class ="table table-striped table-bordered table-hover table-responsive" style ="background-color:white">
                    <thead>
                        <tr>
                          
                            <th style="width: 40%" >Intervention Name</th>
                            <th style="width: 40%" >State</th>
                            <th style="width: 10%">Edit</th>
                            <th style="width: 10%">View</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </tbody>
                </table>
            </LayoutTemplate>

      

             <ItemTemplate>
                <tr>
                   
                    <td><asp:Label ID="lblIntervention" runat="server" Text='<%#Eval("InterventionType.Name") %>'/></td>
                    <td><asp:Label ID="lblState" runat ="server" Text ='<%#Eval("InterventionState") %>' /></td>
                    <td><asp:HyperLink ID="linkView" runat="server" Text="Edit" NavigateUrl='<%#"EditIntervention.aspx?id=" + Eval("Id") %>' /></td>
                     <td><asp:HyperLink ID="HyperLink1" runat="server" Text="View" NavigateUrl='<%#"InterventionDetail.aspx?id=" + Eval("Id") %>' /></td>
                </tr>
            </ItemTemplate>

          
    </asp:ListView>
    </div>
</asp:Content>
