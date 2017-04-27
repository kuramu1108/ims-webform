<%@ Page Title="New Client" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewClient.aspx.cs" Inherits="InterventionManagementSystem.NewClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2">
                <h2>
                    <asp:Label ID="lblWelcome" runat="server" Text="New Client"></asp:Label>
                </h2>
            </div>

            <div class="col-md-6"></div>
        </div>
        <div class="row">

            <div class="col-md-12">

                <div class="row">
                    <div class="col-md-2">

                        <h3>
                            <asp:Label ID="ClientLabel" runat="server" Text="Client name: 　"></asp:Label>
                            <asp:TextBox ID="ClientName" runat="server"></asp:TextBox>
                        </h3>
                    </div>


                </div>
                <div class="row">
                    <div class="col-md-4">
                        <h3> <asp:Label ID="Label1" runat="server" Text="Client location:　"></asp:Label>
                            <asp:TextBox ID="Clientlocation" runat="server"></asp:TextBox></h3>
                    </div>
                </div>
                    <div class="row">
                    <div class="col-md-4">
                        <h3> <asp:Label ID="Label2" runat="server" Text="Client District:　"></asp:Label>
                            <asp:TextBox ID="ClientDistrict" runat="server"></asp:TextBox></h3>
                    </div>
                </div>

                        <div class="row">

                    <div class="col-md-4">
                                   
                        <asp:Button ID="Cancel_btn" runat="server" Text="Cancel" OnClick="Cancel_btn_Click" />
                           
                        <asp:Button ID="Submit_btn" runat="server" Text="Submit" OnClick="Submit_btn_Click" />
                    </div>
                </div>
                    </div>
            </div>
        </div>
</asp:Content>

