<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditIntervention.aspx.cs" Inherits="InterventionManagementSystem.EditIntervention" %>

<asp:Content runat="server" ID="EditInterventionPage" ContentPlaceHolderID="MainContent">
    <h3>
        <asp:Label ID="lblEditIntervention" runat="server" Text="Edit Intervention"></asp:Label>
    </h3>

    <hr />
    <div class="main-body-content">
        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Intervention Type:</label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtInterventionType" runat="server" Enabled="false"></asp:TextBox>
            </div>
        </div>

        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Client Name:</label>
            </div>
            <div class="col-md-6">
                <asp:TextBox class="form-control" ID="ClientName" runat="server"
                    Enabled="false"></asp:TextBox>
            </div>
        </div>

        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Comments:</label>
            </div>
            <div class="col-md-6">
                <asp:TextBox class="form-control" ID="InterventionComments" runat="server" TextMode="MultiLine" Style="width: 280px"></asp:TextBox>
            </div>
        </div>

        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Remaining Life:</label>

            </div>
            <div class="col-md-6">

                <asp:TextBox class="form-control" ID="LifeRemaining" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RemaingLifeValidator" runat="server" ErrorMessage="Remaing Life is invalid" ControlToValidate="LifeRemaining" ForeColor="#FF6666" ValidationExpression="^[1-9][0-9]?$|^100$" ValidationGroup="EditInterventionValidator">1-100</asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Date of Recent Visit:</label>
            </div>
            <div class="col-md-6">
                <asp:TextBox class="form-control" ValidationGroup="EditInterventionValidator" ID="InterventionVisitDate" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="DateValidator" runat="server" ErrorMessage="Date is requried in the format of dd/mm/yyyy" ControlToValidate="InterventionVisitDate" ForeColor="#FF6666" ValidationGroup="EditInterventionValidator" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$">Date Format in dd/mm/yyyy or dd-mm-yyyy or dd.mm.yyyy</asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row">

            <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" Text="Save" ValidationGroup="EditInterventionValidator" OnClick="btnSave_Click" />
        </div>
    </div>

</asp:Content>
