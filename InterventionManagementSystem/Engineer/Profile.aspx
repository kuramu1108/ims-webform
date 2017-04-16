<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="InterventionManagementSystem.Profile" MasterPageFile="~/Site.Master"%>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="LabelPage" runat="server" Font-Size="Medium" Text="Profile"></asp:Label>
                    </div>
                    <div>
                        <div class="col-md-12">
                            <asp:Label ID="LabelDistrict" runat="server" Text="District"></asp:Label>
                            <asp:Label ID="TextDistrict" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="LabelMAH" runat="server" Text="Maximum Approval Hours"></asp:Label>
                            <asp:Label ID="TextMAH" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="LabelMAC" runat="server" Text="Maximum Approval Cost of Materials"></asp:Label>
                            <asp:Label ID="TextMAC" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="LabelPassword" runat="server" Text="ChangePassword"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="LabelOldPassword" runat="server" Text="Old Password" Visible="false"></asp:Label>
                            <asp:TextBox ID="TextBoxOldPassword" runat="server" Visible="false"></asp:TextBox>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="LabelNewPassword" runat="server" Text="New Password" Visible="false"></asp:Label>
                            <asp:TextBox ID="TextBoxNewPassword" runat="server" Visible="false"></asp:TextBox>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="ButtonChangePassword" runat="server" Text="Change Password" OnClick="ButtonChangePassword_Click" />
                        </div>
                        
                    </div>
                </div>
            </div>


        </div>
        </asp:Content>
