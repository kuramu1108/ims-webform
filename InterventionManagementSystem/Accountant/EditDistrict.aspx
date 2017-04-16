<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditDistrict.aspx.cs" Inherits="InterventionManagementSystem.Accountant.EditDistrict" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3>Edit District</h3>
        <div>
            User: 
            <asp:Label ID="lblUser" runat="server"></asp:Label>
        </div>
        <div>
            Current: 
            <asp:Label ID="lblCurrentDistrict" runat="server"></asp:Label>
        </div>
        <div>
            Change To:
            <asp:DropDownList ID="DropDownDistrict" runat="server">
                <asp:ListItem Text="Urban Indonesia" Value="0"></asp:ListItem>
                <asp:ListItem Text="Rural Indonesia" Value="1"></asp:ListItem>
                <asp:ListItem Text="Urban Papua New Guinea" Value="2"></asp:ListItem>
                <asp:ListItem Text="Rural Papua New Guinea" Value="3"></asp:ListItem>
                <asp:ListItem Text="Sydney" Value="4"></asp:ListItem>
                <asp:ListItem Text="Rural New South Wales " Value="5"></asp:ListItem>
            </asp:DropDownList> 
        </div>
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit"/>
        </div>
    </div>
</asp:Content>
