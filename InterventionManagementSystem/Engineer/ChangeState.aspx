<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeState.aspx.cs" Inherits="InterventionManagementSystem.Engineer.ChangeState" %>
<asp:Content ID="ChangeStatePage" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Change State -Intervention</h3>
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
                <label>State: </label>
            </div>
            <asp:DropDownList AutoPostBack="false" ID="State" AppendDataBoundItems="true" runat="server" CssClass="form-control" Style="width: 280px">

             

            </asp:DropDownList>

             <asp:Label ID="errorMessage" runat="server" CssClass="label" ForeColor="Red"></asp:Label>
            <div class="col-md-6">
               
            </div>
        </div>

     </div>
     <div class="row form-group">
                <div class="col-md-4 col-lg-3 col-xl-2">
                </div>
                <div class="col-md-6">
                    <asp:Button ID="Cancel_btn" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="Cancel_btn_Click" />
                    <asp:Button ID="Submit_btn" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="Submit_btn_Click"  />
                
                  </div>
            </div>


</asp:Content>
