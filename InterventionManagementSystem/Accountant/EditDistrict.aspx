<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditDistrict.aspx.cs" Inherits="InterventionManagementSystem.Accountant.EditDistrict" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3>

            <asp:Label ID="lblEditDistrict" runat="server" Text="Edit District"></asp:Label>

        </h3>
        <div class="main-body-content">
            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">

                    <label>User:</label>
                </div>
                <div class="col-md-6">

                    <asp:TextBox ID="txtUser" runat="server" Enabled="false"></asp:TextBox>
                    

                </div>


            </div>
            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">

                    <label>District:</label>
                </div>
                <div class="col-md-6">

                    <asp:TextBox ID="txtDistrict" runat="server" Enabled="false"></asp:TextBox>
                    

                </div>


            </div>

            <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">

                    <label>District :</label>
                </div>
                <div class="col-md-6">

                   <asp:DropDownList ID="DropDownDistrict" AppendDataBoundItems="true" runat="server" ItemType="IMSLogicLayer.Models.District" SelectMethod="getDistricts" DataTextField="Name" DataValueField="Id" >
                   
                        
                    </asp:DropDownList>
                </div>


            </div>
            <div class="row">

                <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" Text="Save" ValidationGroup="EditInterventionValidator" OnClick="btnSave_Click" />
            </div>
        </div>


    </div>
</asp:Content>
