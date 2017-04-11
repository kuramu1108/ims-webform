<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="InterventionManagementSystem2.Profile" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="LabelPage" runat="server" Font-Size="Medium" Text="Profile"></asp:Label>
                    </div>
                    <div>
                        <div>
                            <asp:Label ID="LabelDistrict" runat="server" Text="District"></asp:Label>
                            <asp:Label ID="TextDistrict" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelMAH" runat="server" Text="Maximum Approval Hours"></asp:Label>
                            <asp:Label ID="TextMAH" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelMAC" runat="server" Text="Maximum Approval Cost of Materials"></asp:Label>
                            <asp:Label ID="TextMAC" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelPassword" runat="server" Text="ChangePassword"></asp:Label>
                            <asp:Button ID="ButtonChangePassword" runat="server" Text="Change Password" />
                        </div>
                    </div>
                </div>
            </div>


        </div>
        </asp:Content>
