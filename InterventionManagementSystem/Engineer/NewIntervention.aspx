<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="NewIntervention.aspx.cs" Inherits="InterventionManagementSystem.NewIntervention" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>New Intervention</h3>
    <hr />
    <div class="main-body-content">
            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                    <label>Intervention Type: </label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox class="form-control" ID="InterventionType" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                    <label>Client: </label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox class="form-control" ID="InterventionClient" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                    <label>Hours: </label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox class="form-control" ID="TextBox12" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                    <label>Cost: </label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox class="form-control" ID="TextBox13" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                    <label>Hours: </label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox class="form-control" ID="TextBox14" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                    <label>Perform Date:</label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox class="form-control" ID="TextBox16" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                    <label>Comments: </label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox class="form-control" ID="TextBox15" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                </div>
                <div class="col-md-6">
                    <asp:Button ID="Cancel_btn" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="Cancel_Click" />
                    <asp:Button ID="Submit_btn" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="Submit_Click" />
                </div>
            </div>
    </div>
</asp:Content>