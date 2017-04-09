<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditIntervention.aspx.cs" Inherits="InterventionManagementSystem2.EditIntervention" %>

<asp:Content runat="server" ID="EditInterventionPage" ContentPlaceHolderID="MainContent">
    <div class="container">

        <div class="row">
            <h1>

                <asp:Label ID="lblEditIntervention" runat="server" Text="Edit Intervention"></asp:Label>

            </h1>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblInterventionType" runat="server" Text="Intervention Type: "></asp:Label>
              
                </div> 
                 <div class="col-md-4">
                                    <asp:TextBox ID="txtInterventionType" runat="server"></asp:TextBox>

                </div>


            </div>

            <div class="row">
                 <div class="col-md-2">
                     <asp:Label ID="lblClients" runat="server" Text="Clients: "></asp:Label>

                </div>
               <div class="col-md-4">
                    <asp:TextBox ID="txtClients" runat="server"></asp:TextBox>
  
                </div>
               
            </div>
            <div class="row">
                 <div class="col-md-2">
                     <asp:Label ID="lblHours" runat="server" Text="Hours: "></asp:Label>

                </div>
               
                <div class="col-md-4">
                      <asp:TextBox ID="txtHours" runat="server"></asp:TextBox>

                </div>
               
            </div>
            <div class="row">
                 <div class="col-md-2">
                   <asp:Label ID="lblCost" runat="server" Text="Cost: "></asp:Label>
 
                </div>
                <div class="col-md-4">
                     <asp:TextBox ID="txtCost" runat="server"></asp:TextBox>

                </div>
                
            </div>
            <div class="row">
                 <div class="col-md-2">
                    <asp:Label ID="lblCreateBy" runat="server" Text="CreateBy: "></asp:Label>

                </div>
                <div class="col-md-4">
                     <asp:TextBox ID="txtCreateBy" runat="server"></asp:TextBox>

                </div>
                
            </div>
            <div class="row">
                 <div class="col-md-2">
                     <asp:Label ID="lblDate" runat="server" Text="Date: "></asp:Label>

                </div>
               <div class="col-md-4">
                                     <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>

                </div>

            </div>
            <div class="row">
                 <div class="col-md-2">
                     <asp:Label ID="lblState" runat="server" Text="Stat: "></asp:Label>

                </div>
               <div class="col-md-4">
                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
 
                </div>
                
            </div>
            <div class="row">
                 <div class="col-md-2">
                    <asp:Label ID="lblApprovedBy" runat="server" Text="Approved By: "></asp:Label>
 
                </div>
               <div class="col-md-4">
                    <asp:TextBox ID="txtApprovedBy" runat="server"></asp:TextBox>
 
                </div>
                
            </div>
            <div class="row">
                <div class="col-md-2">
 <asp:Label ID="lblComments" runat="server" Text="Comments: "></asp:Label>
                </div>
               
<div class="col-md-4">
                   <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
  
                </div>
                
            </div>

            <div class="row">
                 <div class="col-md-2">
                     <asp:Label ID="lblLifeRemaining" runat="server" Text="Life Remaining: "></asp:Label>

                </div>
               <div class="col-md-4">
                    <asp:TextBox ID="txtLifeRemaining" runat="server"></asp:TextBox>
  
                </div>
               
            </div>

            <div class="row">
                 <div class="col-md-2">
                     <asp:Label ID="lblDateOfRecentVisit" runat="server" Text="Date of Recent Visit: "></asp:Label>

                </div>
               <div class="col-md-4">
                     <asp:TextBox ID="txtDateOfRecentVisit" runat="server"></asp:TextBox>

                </div>
                
            </div>


        </div>
        <div class="row">

            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            <asp:Button ID="btnSave" runat="server" Text="Save" />
        </div>

    </div>
</asp:Content>
