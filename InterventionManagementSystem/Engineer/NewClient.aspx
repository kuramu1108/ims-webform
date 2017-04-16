<%@ Page Title="New Client" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewClient.aspx.cs" Inherits="InterventionManagementSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>New Client</h1>
    <%--<form method="POST" action="NewClient.aspx">--%>
         <table>
        <tr><td>Client name: </td><td><input id="ClientName" name="client_name" type="Text" /></td></tr>
        <tr><td>Client location: </td><td><input id="ClientLocation" name="client_location" type="Text" /></td></tr>
       <tr><td>District: </td><td><input id="ClientDistrict" name="client_district" type="Text" /></td></tr>
           <tr><td><input value="Cancel" type="Submit" /></td><td><input value="Submit" type="Submit" /></td></tr>
             </table>

<%--</form>--%>
   

</asp:Content>
