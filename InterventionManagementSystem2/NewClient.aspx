<%@ Page Title="New Client" Language="C#" AutoEventWireup="true" CodeBehind="NewClient.aspx.cs" Inherits="InterventionManagementSystem.NewClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"></head>
<h1>New Client</h1>
<table>
    <tr>
        <td>Client name: </td>
        <td>
            <asp:TextBox ID="ClientName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Client location: </td>
        <td>
            <asp:TextBox ID="ClientLocation" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>District: </td>
        <td>
            <asp:TextBox ID="ClientDistrict" runat="server"></asp:TextBox></td>
    </tr>

    <tr>
        <td>
            <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
        </td>
        <td>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="submit_click" /></td>
    </tr>
</table>

</html>
