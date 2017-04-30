<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterventionDetail.aspx.cs" Inherits="InterventionManagementSystem.Engineer.InterventionDetail" %>

<asp:Content ID="InterventionDetailPage" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Intervention Detail</h3>
    <hr />
    <div class="main-body-content">
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Intervention Type: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="type" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Client: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="client" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Created By: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="creator" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Approved By: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="approver" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>State: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="state" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Hour: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="hour" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Cost: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="cost" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Proposed Date: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="proposedDate" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Complete Date: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="completedDate" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Latest Visit Date: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="recentVisitDate" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Life Remaining: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lifeRemaining" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Comments: </label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="Comments" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
            </div>
            <div class="col-md-6">
                <asp:Button ID="Edit" runat="server" CssClass="btn btn-info" Text="Edit" OnClick="Edit_Click" />
                <asp:Button ID="changeState" runat="server" CssClass="btn btn-info" Text="Change State" OnClick="changeState_Click" />

            </div>
        </div>
    </div>
</asp:Content>
