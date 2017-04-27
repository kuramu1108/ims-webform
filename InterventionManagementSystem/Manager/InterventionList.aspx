<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterventionList.aspx.cs" Inherits="InterventionManagementSystem.Manager.InterventionList" %>

<asp:Content runat="server" ID="InterventionLists" ContentPlaceHolderID="MainContent">
    <div class="container">
        <asp:DataList runat="server" ID="ListIntervention">
             <ItemTemplate>
                Client Name:
                <asp:Label ID="lblClientId" runat="server" 
                   Text='<%# Eval("ClientId") %>'>
                </asp:Label>
                <br />
                District Name:
                <asp:Label ID="lblHour" runat="server" 
                   Text='<%# Eval("Hours") %>'>
                </asp:Label>
                <br />
                State:
                <asp:Label ID="lblCost" runat="server" 
                   Text='<%# Eval("Costs") %>'>
                </asp:Label>
                <br />
                   <asp:Label ID="lblDateCreate" runat="server" 
                   Text='<%# Eval("DateCreate") %>'>
                </asp:Label>
                <br />
                   <asp:Label ID="lblDateFinish" runat="server" 
                   Text='<%# Eval("DateFinish") %>'>
                </asp:Label>
                <br />
                   <asp:Label ID="lblDateRecentVisit" runat="server" 
                   Text='<%# Eval("DateRecentVisit") %>'>
                </asp:Label>
                <br />
                   <asp:Label ID="lblCreatedBy" runat="server" 
                   Text='<%# Eval("CreatedBy") %>'>
                </asp:Label>
                <br />
                   <asp:Label ID="lblApprovedBy" runat="server" 
                   Text='<%# Eval("ApprovedBy") %>'>
                </asp:Label>
                <br />
                   <asp:Label ID="lblInterventionTypeId" runat="server" 
                   Text='<%# Eval("InterventionTypeId") %>'>
                </asp:Label>
                <br />
                   <asp:Label ID="lblLifeRemaining" runat="server" 
                   Text='<%# Eval("LifeRemaining") %>'>
                </asp:Label>
                <br />
                   <asp:Label ID="lblComments" runat="server" 
                   Text='<%# Eval("Comments") %>'>
                </asp:Label>
                <br />
                   <asp:Label ID="lblState" runat="server" 
                   Text='<%# Eval("State") %>'>
                </asp:Label>
                <br />
                 <br />
            </ItemTemplate>

        </asp:DataList>

    </div>


</asp:Content>


