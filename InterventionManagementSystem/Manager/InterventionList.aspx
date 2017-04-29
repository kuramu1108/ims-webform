<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="InterventionList.aspx.cs" Inherits="InterventionManagementSystem.Manager.InterventionList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Interventions List</h3>
    <hr />
    <div class="main-body-content">
        <table id="table-clients" class="table table-striped table-bordered table-hover table-responsive" style="background-color: white">
            <thead>
                <tr>
                    <th class ="col-md-3 col-lg-4">Type</th>
                    <th class ="col-md-2 col-lg-2">Client</th>
                    <th class ="col-md-1 col-lg-1">Date</th>
                    <th class ="col-md-2 col-lg-2">
                        <asp:DropDownList ID="SeletedInterventionState" AutoPostBack="true" runat="server" style="width:100%" 
                            OnSelectedIndexChanged="SeletedInterventionState_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </th>
                    <th class ="col-md-4 col-lg-3">Action</th>
                </tr> 
            </thead>
            <asp:ListView ID="InterventionListView" runat="server">
                <LayoutTemplate>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder">
                        </tr>
                    </tbody>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr style="vertical-align: middle;">
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("InterventionType.Name") %>' /></td>
                        <td>
                            <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("Client.Name") %>' /></td>
                        <td>
                            <asp:Label ID="lblDistrictName" runat="server" Text='<%# string.Format("{0:dd/MM/yyyy}", Eval("DateFinish")) %>' /></td>
                        <td>
                            <asp:Label ID="State" runat="server" Text='<%#Eval("InterventionState") %>' /></td>
                        <td>
                            <asp:Button ID="btnView" Text="View" OnClick="ButtonView_Click" runat="server" CommandArgument='<%#Eval("Id")%>' CssClass="btn btn-default" style="width:68px; height:28px; text-align:center; font-size:11px;" />
                            <asp:HyperLink CssClass="btn btn-success" style="width:68px; height:28px; text-align:left; font-size:11px;" ID="linkApprove" runat="server" Text="Approve" NavigateUrl='<%#"ClientDetails.aspx?id=" + Eval("Id") %>' />
                            <asp:HyperLink CssClass="btn btn-danger" style="width:68px; height:28px; text-align:center; font-size:11px;" ID="linkCancel" runat="server" Text="Cancel" NavigateUrl='<%#"ClientDetails.aspx?id=" + Eval("Id") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

        </table>
    </div>
</asp:Content>
