<%@ Page Title="Home_Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs"   %>




<asp:content id="BodyContent" contentplaceholderid="MainContent" runat="server">
    <asp:Login ID="Login1" OnAuthenticate= "Login1_Authenticate" CreateUserText="Register" HelpPageText="Additional Help" HelpPageUrl="~/Help.aspx"
InstructionText="Please enter your user name and password for login."  runat="server"></asp:Login>
</asp:content>
