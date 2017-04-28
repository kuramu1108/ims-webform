<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="NewIntervention.aspx.cs" Inherits="InterventionManagementSystem.NewIntervention" %>

<asp:Content ID="NewIntervention" runat="server" ContentPlaceHolderID="MainContent">
        <h1>New Intervention</h1>
        <table>
            <tr><td>Intervention Type: </td><td>
                <asp:DropDownList ID="interventionTypes" runat="server" Width="175px" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Name" >
            </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Name] FROM [InterventionTypes]"></asp:SqlDataSource>
                </td></tr>
            <tr><td>Clients: </td><td> <asp:DropDownList ID="Clients" runat="server" Width="175px" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name">
           
            </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Name] FROM [Clients]"></asp:SqlDataSource>
                </td></tr>
            <tr><td>Hours: </td><td><asp:TextBox ID="Hours" runat="server"></asp:TextBox></td></tr>
            <tr><td>Cost: </td><td><asp:TextBox ID="Cost" runat="server"></asp:TextBox></td></tr>
            <tr><td>Create By: </td><td>
                <asp:Label ID="Creator" runat="server"></asp:Label>
               </td></tr>
            <tr><td>Date: </td><td><asp:TextBox ID="Date" Text='<%# Eval("Date", "{0:d MMM yyyy HH:mm}") %>' runat="server"></asp:TextBox></td></tr>
            <tr><td>State: </td><td><asp:TextBox ID="State" runat="server"></asp:TextBox></td></tr>
            <tr><td>Approved: </td><td>  <asp:CheckBox ID="Approval_check" runat="server" /></td></tr>
            <tr><td>Comments: </td><td><asp:TextBox ID="Comments" runat="server" Height="115px"></asp:TextBox></td></tr>
            <tr><td>Life Remaining: </td><td><asp:TextBox ID="LifeRemaining" runat="server" Text="100"></asp:TextBox></td></tr>
            <tr><td>Date of recent visit: </td><td> <asp:Label ID="Date_reccent_visit" Text='<%# Eval("Date", "{0:d MMM yyyy HH:mm}") %>' runat="server"></asp:Label></td></tr>
            <tr><td><asp:Button ID="Cancel" runat="server" Text="Cancel" /></td><td>
                <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" /></td></tr>
            </table>
   </asp:Content>
