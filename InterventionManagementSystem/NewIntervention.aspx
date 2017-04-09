<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewIntervention.aspx.cs" Inherits="InterventionManagementSystem.NewIntervention" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>New Intervention</h1>
        <table>
            <tr><td>Intervention Type: </td><td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td></tr>
            <tr><td>Clients: </td><td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td></tr>
            <tr><td>Hours: </td><td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td></tr>
            <tr><td>Cost: </td><td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td></tr>
            <tr><td>Create By: </td><td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td></tr>
            <tr><td>Date: </td><td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td></tr>
            <tr><td>State: </td><td><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td></tr>
            <tr><td>Approved By: </td><td><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td></tr>
            <tr><td>Comments: </td><td><asp:TextBox ID="TextBox9" runat="server" Height="115px"></asp:TextBox></td></tr>
            <tr><td>Life Remaining: </td><td><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td></tr>
            <tr><td>Date of recent visit: </td><td><asp:TextBox ID="TextBox11" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:Button ID="Cancel" runat="server" Text="Cancel" /></td><td>
                <asp:Button ID="Submit" runat="server" Text="Submit" /></td></tr>
            </table>
    </form>
</body>
</html>
