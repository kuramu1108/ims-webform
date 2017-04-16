<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WelcomeAccountant.aspx.cs" Inherits="InterventionManagementSystem.Accountant.WelcomeAccountant" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">

        <div class="row">
            <div class="row">
                <div class="col-md-2">
                    <h2>
                        <asp:Label ID="lblWelcome" runat="server" Text="Welcome: "></asp:Label>
                        <asp:Label ID="lbLoginUser" runat="server" Text="John Snow"></asp:Label>
                    </h2>
                </div>

                <div class="col-md-2">
                    <asp:Button ID="Logout" runat="server" Text="Logout" />
                </div>
                <div class="col-md-6"></div>
            </div>
            <div class="row">

                <div class="col-md-12">

                    <div class="row">
                        <div class="col-md-2">

                            <h3>
                                <asp:Label ID="ClientLabel" runat="server" Text="Report"></asp:Label>
                            </h3>
                        </div>


                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="dropdown">
                                <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                                    Report Type
                         <span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu">
                                    <li>Total Costs by Engineer</li>
                                    <li>Average Costs by Engineer</li>
                                    <li>Costs by District</li>
                                    <li>Monthly Costs for District</li>

                                </ul>
                            </div>

                            <asp:Button ID="ViewClient" runat="server" Text="View" />


                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-2">
                            <h3>
                                <asp:Label ID="InterventionLabel" runat="server" Text="Site Engineer/Manager List"></asp:Label>
                            </h3>


                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-2">

                            <asp:Button ID="ViewIntervention" runat="server" Text="View" />
                         

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
                   

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>














</asp:Content>
