<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="InterventionManagementSystem.Accountant.Welcome" %>
<asp:Content ID="WelcomeAccountant" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row form-group">
            <h3><%:Context.User.Identity.GetUserName()%></h3>
            <hr />

         
            <div class="row">

                <div class="col-md-12">

                    <div class="row">
                        <div class="col-md-2">

                            <h3>
                                <asp:Label ID="AccountLabel" runat="server" Text="Accounts"></asp:Label>
                            </h3>
                        </div>


                    </div>
                  
                    <div class="row">
                        <div class="col-md-2">
                           <asp:Button ID="ViewAccountList" runat="server"  CssClass="btn" Text="View" OnClick="ViewAccountList_Click" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-2">
                            <h3>
                                <asp:Label ID="ReportLabel" runat="server" Text="Report"></asp:Label>
                            </h3>


                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Button ID="ViewReportList" runat="server"  CssClass="btn" Text="View" OnClick="ViewReportList_Click" />
                        
                        </div>
                    </div>


                    
                </div>
            </div>

      </div>
</asp:Content>
