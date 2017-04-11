<%@ Page Language="C#"  AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientDetails.aspx.cs" Inherits="InterventionManagementSystem2.ClientDetails" %>

<asp:Content ID="ClientDetailPage" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblClientName"  CssClass="label-default" runat="server" Text="Client Name: " Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-md-4">
                    <asp:Label ID="lblName" runat="server" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblClientLocation" Cssclass="label-default" runat="server" Text="Client Location: " Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-md-4">
                    <asp:Label ID="lblLocation" runat="server" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div class ="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblClientDistricts" Cssclass="label-default" runat="server" Text="Client District: " Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-md-4">
                    <asp:Label ID="lblDistrict" runat="server" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <asp:Label ID="lblInterventionList" Cssclass="label-default" runat="server" Text="Intervention List: " Font-Size="Large"></asp:Label>
                    
                </div>
            </div>


        </div>
        <asp:ListView ID="InterventionList" runat="server" OnSelectedIndexChanged="InterventionList_SelectedIndexChanged" >
            <ItemTemplate>
                <div>

                    <asp:Label Text="<%#Container.DataItem %>" runat="server" />
                </div>
            </ItemTemplate>
        </asp:ListView>
   </asp:Content>