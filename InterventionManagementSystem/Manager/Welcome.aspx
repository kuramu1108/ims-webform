<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Welcome.aspx.cs" Inherits="InterventionManagementSystem.Manager.Welcome" %>

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
                                <asp:Label ID="Interventions" runat="server" Text="Proposed Interventions"></asp:Label>
                            </h3>
                        </div>


                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Button ID="ViewIntervention" runat="server" Text="View" style="height: 26px"  />
                            

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-2">
                            <h3>
                                <asp:Label ID="Profile" runat="server" Text="Profile"></asp:Label>
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