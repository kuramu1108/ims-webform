<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportPage.aspx.cs" Inherits="InterventionManagementSystem.Accountant.ReportPage" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>Report</h2>
    <div class="form-vertical">
        <div class="container">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </div>
        </div>
        
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Back_Click" Text="Back" CssClass="btn btn-default" />
            </div>
        </div>
 
</asp:Content>
