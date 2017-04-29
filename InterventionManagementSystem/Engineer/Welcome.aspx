<%@ Page Title="WelcomePage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="InterventionManagementSystem.Welcome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row form-group">
            <h3><%:Context.User.Identity.GetUserName()%></h3>
            <hr />

            <div class="row">

                <div class="col-md-12">

                    <div class="row">
                        <div class="col-md-2">

                            <h3>
                                <asp:Label ID="ClientLabel" runat="server" Text="Client"></asp:Label>
                            </h3>
                        </div>


                    </div>
                  
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Button ID="ViewClient" runat="server" CssClass="btn" Text="View"  OnClick="ViewClient_Click" />
                            <asp:Button ID="CreateClient" runat="server" CssClass="btn" Text="Create" OnClick="CreateClientButton_Click"/>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-2">
                            <h3>
                                <asp:Label ID="InterventionLabel" runat="server" Text="Intervention"></asp:Label>
                            </h3>


                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-2">

                            <asp:Button ID="ViewIntervention" runat="server"  CssClass="btn" Text="View" OnClick="ViewIntervention_Click" />
                            <asp:Button ID="CreateIntervention" runat="server"  CssClass="btn" Text="Create" OnClick="CreateIntervention_Click" />

                        </div>
                    </div>


                    
                </div>
            </div>
        </div>
</asp:Content>
