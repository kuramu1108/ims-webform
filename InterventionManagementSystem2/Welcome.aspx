<%@ Page Title="WelcomePage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs"  Inherits="InterventionManagementSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

         <table style="margin-bottom: 224px">
        <tr><td style="width: 169px">Welcome: </td><td> </td><td style="width: 199px">
            <asp:Button ID="Logout" runat="server" Text="Logout" /></td></tr>
      <tr><td></td></tr>

                 <tr><td><asp:Label ID="ClientLabel" runat="server" Text="Client" ></asp:Label></td></tr>
              <tr><td>&nbsp;</td></tr>
                   <tr><td>
                     <asp:Button ID="ViewClient" runat="server" Text="View" /> </td><td>
                     <asp:Button ID="CreateClient" runat="server" Text="Create" /> </td></tr>
              
             
                 
                 <tr><td><asp:Label ID="InterventionLabel" runat="server" Text="Intervention" ></asp:Label></td></tr>
              <tr><td></td></tr>     
             <tr><td>
                     <asp:Button ID="ViewIntervention" runat="server" Text="View" /></td><td>
                     <asp:Button ID="CreateIntervention" runat="server" Text="Create" /> </td></tr>
               

              
                 <tr><td><asp:Label ID="ProfileLabel" runat="server" Text="Profile" ></asp:Label></td></tr>
              <tr><td></td></tr>     
             <tr><td>
                     <asp:Button ID="ViewProfile" runat="server" Text="View" /> </td><td>
                     <asp:Button ID="CreateProfile" runat="server" Text="Create" /> </td></tr>
              
            
             </table>
  
</asp:Content>
