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
                <asp:DropDownList ID="SeletedInterventionType" ValidationGroup="InterventionValidator" AppendDataBoundItems="true" AutoPostBack="true" runat="server" CssClass="form-control" Style="width: 280px"
                    ItemType="IMSLogicLayer.Models.InterventionType" SelectMethod="getInterventionTypes" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="SeletedInterventionType_SelectedIndexChanged">
                    <Items>
                        <asp:ListItem Text="" Value="" />
                    </Items>

                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="InterventionTypeValidator" runat="server" ErrorMessage="InterventionType Is Required" ControlToValidate="SeletedInterventionType" ValidationGroup="InterventionValidator">*</asp:RequiredFieldValidator>


            </div>
        </div>

        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Client: </label>
            </div>
            <div class="col-md-6">
                <%-- <asp:TextBox class="form-control" ID="InterventionClient" runat="server"></asp:TextBox>
                --%>
                <asp:DropDownList ID="SelectClient" ValidationGroup="InterventionValidator" AppendDataBoundItems="true" AutoPostBack="true" runat="server" CssClass="form-control" Style="width: 280px"
                    ItemType="IMSLogicLayer.Models.Client" SelectMethod="getClients" DataTextField="Name" DataValueField="Id">
                    <Items>
                        <asp:ListItem Text="" Value="" />
                    </Items>

                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="SelectClientValidator" runat="server" ErrorMessage="Client Is Required" ControlToValidate="SelectClient" ValidationGroup="InterventionValidator">*</asp:RequiredFieldValidator>


            </div>
        </div>

        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Hours: </label>
            </div>
            <div class="col-md-6">
                <asp:TextBox class="form-control" ValidationGroup="InterventionValidator" ID="InterventionHour" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="InterventionHourValidator" runat="server" ErrorMessage="Hour Is Required" ControlToValidate="InterventionHour" ValidationGroup="InterventionValidator">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="HourValidator" runat="server" ErrorMessage="Hour is not valid" ControlToValidate="InterventionHour" ForeColor="#FF6666"  ValidationGroup="InterventionValidator" ValidationExpression="(^(\+)(0|([1-9][0-9]*))(\.[0-9]{1,2})?$)|(^(0{0,1}|([1-9][0-9]*))(\.[0-9]{1,2})?$)">2 precison decimal or positive integer</asp:RegularExpressionValidator>

            </div>
        </div>

        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Cost: </label>
            </div>
            <div class="col-md-6">
                <asp:TextBox class="form-control" ValidationGroup="InterventionValidator" ID="InterventionCost" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="InterventionCostValidator" runat="server" ErrorMessage="Cost Is Required" ControlToValidate="InterventionCost" ValidationGroup="InterventionValidator">*</asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="CostValidator" runat="server" ErrorMessage="Cost is not valid" ControlToValidate="InterventionCost" ForeColor="#FF6666"  ValidationGroup="InterventionValidator" ValidationExpression="(^(\+)(0|([1-9][0-9]*))(\.[0-9]{1,2})?$)|(^(0{0,1}|([1-9][0-9]*))(\.[0-9]{1,2})?$)">2 precison decimal or positive integer</asp:RegularExpressionValidator>

            </div>
        </div>


        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Perform Date:</label>
            </div>
            <div class="col-md-6">


                <asp:TextBox class="form-control" ValidationGroup="InterventionValidator" ID="InterventionPerformDate" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="DateValidator" runat="server" ErrorMessage="Date is requried in the format of dd/mm/yyyy" ControlToValidate="InterventionPerformDate" ForeColor="#FF6666" ValidationGroup="InterventionValidator" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$">Date Format in dd/mm/yyyy or dd-mm-yyyy or dd.mm.yyyy</asp:RegularExpressionValidator>

            </div>


        </div>

        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
                <label>Comments: </label>
            </div>
            <div class="col-md-6">
                <asp:TextBox class="form-control" ID="InterventionComments" runat="server" TextMode="MultiLine" Style="width: 280px"></asp:TextBox>
            </div>
        </div>

        <div class="row form-group">
            <div class="col-md-4 col-lg-3 col-xl-2">
            </div>
            <div class="col-md-6">
                <asp:Button ID="Cancel_btn" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="Cancel_Click" />
                <asp:Button ID="Submit_btn" runat="server" CssClass="btn btn-success" Text="Submit" ValidationGroup="InterventionValidator" OnClick="Submit_Click" />

                <asp:ValidationSummary ID="InterventionValidationSummary" runat="server" ValidationGroup="InterventionValidator" DisplayMode="List" ForeColor="#FF6666" />
            </div>
        </div>
    </div>
</asp:Content>
