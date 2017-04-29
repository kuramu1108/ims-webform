<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MonthlyReport.aspx.cs" Inherits="InterventionManagementSystem.Accountant.MonthlyReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Monthly Cost By District Report</h3>
    <hr />
    <asp:DropDownList ID="DropDownDistrict" AppendDataBoundItems="true" runat="server" ItemType="IMSLogicLayer.Models.District" SelectMethod="getDistricts" DataTextField="Name" DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="DropDownDistrict_SelectedIndexChanged" >
                   
                        
                    </asp:DropDownList>

    <asp:ListView ID="ReportListView" runat="server">
            <LayoutTemplate>
                <table id="table-clients" class ="table table-striped table-bordered table-hover table-responsive" style ="background-color:white">
                    <thead>
                        <tr>
                            <th style="width: 50px" ></th>
                            <th style="width: 40%" >Name</th>
                            <th style="width: calc(60% -50px)" >Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td></td>
                    <td><asp:Label ID="lblName" runat="server" Text='<%# Eval("FirstProperty") %>'/></td>
                    <td><asp:Label ID="lblCost" runat="server" Text='<%# Eval("Costs") %>' /></td>
                    <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("Hours") %>' /></td>

                              
                </tr>
            </ItemTemplate>
        </asp:ListView>

</asp:Content>
