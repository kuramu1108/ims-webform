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
                <br>
                <div class="col-md-2">
                    <asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click" />
                </div>
                <div class="col-md-6"></div>
            </div>
            <div class="row">

                <div class="col-md-12">

                    <div class="row">
                        <div class="col-md-2">

                            <h3>
                                <asp:Label ID="ReportLabel" runat="server" Text="Report"></asp:Label>
                            </h3>
                        </div>


                    </div>
                    <div class="row">
                        <div class="col-md-8">
                            <div class="dropdown">
                            
                                <label for="sel1">Select list (select one):</label>
                                <select class="form-control" id="sel1" style="width: 25%">
                                    <option>Total Costs by Engineer</option>
                                    <option>Average Costs by Engineer</option>
                                    <option>Costs by District</option>
                                    <option>Monthly Costs for District</option>
                                </select>
                                <br>
                            </div>

                            <asp:Button ID="ViewReport" runat="server" Text="View" OnClick="ViewReport_Click"  />


                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-8">
                            <h3>
                                <asp:Label ID="InterventionLabel" runat="server" Text="Site Engineer/Manager List"></asp:Label>
                            </h3>


                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-8">

                            <asp:Button ID="ViewSiteEngineerManager" runat="server" Text="View" OnClick="ViewSiteEngineerManager_Click" />


                        </div>
                    </div>


                    <div class="row">

                        <div class="col-md-8">
                            <h3>
                                <asp:Label ID="ProfileLabel" runat="server" Text="Profile"></asp:Label>
                            </h3>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-8">

                            <asp:Button ID="ViewProfile" runat="server" Text="View" OnClick="ViewProfile_Click" />


                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
