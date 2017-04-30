<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Welcome.aspx.cs" Inherits="InterventionManagementSystem.Manager.Welcome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Manager System</h3>
    <hr />
    <div class="main-body-content">
        <% IMSLogicLayer.Models.User manager = getDetail(); %>
        <div class="row form-group">
            <div class="col-md-4">
                Manager:
            </div>
            <div class="col-md-4">
                <%=manager.Name%>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4">
                District:
            </div>
            <div class="col-md-4">
                <%=manager.District.Name%>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-4">
                Costs:
            </div>
            <div class="col-md-4">
                <%=manager.AuthorisedCosts%>
            </div>
        </div>

        <div class="row form-group">
            <div class="col-md-4">
                Hours:
            </div>
            <div class="col-md-4">
                <%=manager.AuthorisedHours%>
            </div>
        </div>

    </div>
</asp:Content>
