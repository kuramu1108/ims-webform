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
                            <asp:Button ID="btnView" Text="View" OnClick="btnView_Click" CommandArgument='<%#Eval("Id")%>' CssClass="btn btn-default btn-listview"  runat="server"/>
                            <asp:Button ID="btnApprove" Text="Approve" OnClick="btnApprove_Click" CommandArgument='<%#Eval("Id")%>' CssClass="btn btn-success btn-listview" runat="server"/>
                            <asp:Button ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" CommandArgument='<%#Eval("Id")%>' CssClass="btn btn-danger btn-listview" runat="server"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

        </table>
    </div>
</asp:Content>
