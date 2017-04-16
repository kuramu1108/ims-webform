<%@ Page Title="New Client" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewClient.aspx.cs" Inherits="InterventionManagementSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>New Client</h3>
    <asp:ValidationSummary runat="server" CssClass="text-danger" />

    <div class="row form-group">
        <%--<asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>--%>
        <div class="col-md-2" ><label>Client Name</label></div>
        <div class="col-md-6">
            <asp:TextBox runat="server" ID="ClientName" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ClientName"
                CssClass="text-danger" ErrorMessage="The email field is required." />
        </div>
    </div>

    <div class="row form-group">
        <div class="col-md-2"><label>Client Location</label></div>
        <div class="col-md-6">
            <asp:TextBox runat="server" ID="ClientLocation" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ClientLocation"
                CssClass="text-danger" ErrorMessage="The password field is required." />
        </div>
    </div>
    
    <div class="row form-group">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button runat="server" Text="Create" CssClass="btn btn-default" />
        </div>
    </div>
</asp:Content>
