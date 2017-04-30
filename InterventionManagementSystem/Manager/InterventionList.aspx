<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="InterventionList.aspx.cs" Inherits="InterventionManagementSystem.Manager.InterventionList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Interventions List - <%=getDetail().District.Name%></h3>
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
                            <div class="modal fade" id="view-<%#Eval("Id")%>" role="dialog"><div class="modal-dialog"><div class="modal-content">
                                    <div class="modal-header">
                                      <button type="button" class="close" data-dismiss="modal">&times;</button>
                                      <h4 class="modal-title"><%#Eval("InterventionType.Name") %></h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class ="row">
                                            <div class="col-md-4">Client: </div>
                                            <div class="col-md-8"><%#Eval("Client.Name") %></div>
                                        </div>
                                        <div class ="row">
                                            <div class="col-md-4">District</div>
                                            <div class="col-md-8"><%#Eval("District.Name") %></div>
                                        </div>
                                        <hr />
                                        <div class ="row">
                                            <div class="col-md-4">Costs</div>
                                            <div class="col-md-8"><%#Eval("Costs") %></div>
                                        </div>
                                        <div class ="row">
                                            <div class="col-md-4">Hours</div>
                                            <div class="col-md-8"><%#Eval("Hours") %></div>
                                        </div>
                                        <div class ="row">
                                            <div class="col-md-4">Perform Date</div>
                                            <div class="col-md-8"><%#Eval("DateFinish") %></div>
                                        </div>
                                        <hr />
                                        <div class ="row">
                                            <div class="col-md-4">State: </div>
                                            <div class="col-md-8"><%#Eval("InterventionState") %></div>
                                        </div>
                                        <div class ="row">
                                            <div class="col-md-4">Comments: </div>
                                            <div class="col-md-8"><%#Eval("Comments") %></div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                      <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>
                            </div></div></div>
                            <a class="btn btn-default btn-listview" data-toggle="modal" data-target="#view-<%#Eval("Id")%>">View</a>
                            <asp:Button ID="btnApprove" Text="Approve" OnClick="btnApprove_Click" CommandArgument='<%#Eval("Id")%>' Visible='<%#canApprove(Eval("Id"))%>'  CssClass="btn btn-success btn-listview" runat="server"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
</asp:Content>
