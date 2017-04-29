<%@ Page Title="New Client" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewClient.aspx.cs" Inherits="InterventionManagementSystem.NewClient" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>New Client - <%=getDetail().District.Name%></h3>
    <hr />
    <div class="main-body-content">
            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                    <label>Client Name:</label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox class="form-control" ID="ClientName" runat="server" ValidationGroup="ClientValidator"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="ClientNameValidator" runat="server" ErrorMessage="Client Name Is Required" ControlToValidate="ClientName" ValidationGroup="ClientValidator">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                    <label>Client Location:</label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox class="form-control" ID="Clientlocation" runat="server" ValidationGroup="ClientValidator"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="ClientLocationValidator" runat="server" ErrorMessage="Client Location Is Required" ControlToValidate="ClientLocation" ValidationGroup="ClientValidator">*</asp:RequiredFieldValidator>
               
                
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                    <label>Client District:</label>
                </div>
                <div class="col-md-6">
                    <input type="text" class="form-control" disabled value="<%=getDetail().District.Name%>" />
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                </div>
                <div class="col-md-6">
                    <asp:Button ID="Cancel_btn" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="Cancel_btn_Click" />
                    <asp:Button ID="Submit_btn" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="Submit_btn_Click"  ValidationGroup="ClientValidator" />
                
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ClientValidator" DisplayMode="List" ForeColor="#FF6666" />
                </div>
            </div>
    </div>
</asp:Content>

