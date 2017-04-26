<%@ Page Title="WelcomePage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="InterventionManagementSystem.Welcome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">

        <div class="row">
            <div class="row">
                <div class="col-md-2">
                    <h2>
                        <asp:Label ID="lblWelcome" runat="server" Text="Welcome: "></asp:Label>
                        <%: Context.User.Identity.GetUserName()%>
                       </h2>
                </div>

                <div class="col-md-2">
                    <h3>
                    <asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click" />
                </h3>
                </div>
                <div class="col-md-6"></div>
            </div>
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
                            <asp:Button ID="ViewClient" runat="server" Text="View" style="height: 26px" OnClick="ViewClient_Click" />
                            <asp:Button ID="CreateClient" runat="server" Text="Create" OnClick="CreateClientButton_Click"/>

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

                            <asp:Button ID="ViewIntervention" runat="server" Text="View" />
                            <asp:Button ID="CreateIntervention" runat="server" Text="Create" />

                        </div>
                    </div>


                    <div class="row">

                        <div class="col-md-2">
                            <h3>
                                <asp:Label ID="ProfileLabel" runat="server" Text="Profile"></asp:Label>
                            </h3>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-2">

                            <asp:Button ID="ViewProfile" runat="server" Text="View" />
                            <asp:Button ID="CreateProfile" runat="server" Text="Create" />

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>














</asp:Content>
