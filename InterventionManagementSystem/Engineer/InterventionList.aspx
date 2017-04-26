<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterventionList.aspx.cs" Inherits="InterventionManagementSystem.Engineer.InterventionList" %>
<asp:Content runat="server" ID="InterventionLists" ContentPlaceHolderID="MainContent">
    <div class="container">
        <asp:DataList runat="server" ID="ListIntervention">
             <ItemTemplate>
                Client Name:
                <asp:Label ID="lblClientName" runat="server" 
                   Text='<%# Eval("ClientName") %>'>
                </asp:Label>
                <br />
                District Name:
                <asp:Label ID="lblDistrictName" runat="server" 
                   Text='<%# Eval("DistrictName") %>'>
                </asp:Label>
                <br />
                State:
                <asp:Label ID="lblState" runat="server" 
                   Text='<%# Eval("State") %>'>
                </asp:Label>
                <br />
                 <br />
            </ItemTemplate>

        </asp:DataList>

    </div>


</asp:Content>