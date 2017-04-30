<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InternalErrors.aspx.cs" Inherits="InterventionManagementSystem.Errors.InternalErrors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Error!</h3>
    <h4>You have encounter an error in the application. It can be the following reasons:</h4>
    <div class="main-body-content">
        <div class="row">
            <label>You are trying to access webpages where you are not suppose to</label></div>
        <div class="row">
            <label>You have a wrong query string when access specific pages</label>
        </div>
        <div class="row">
            <label>An invalid operation is performed and been rejected</label></div>
        <div class="row">
            <label>An error occured within the database</label></div>
        <div class="row">
            <label>An error related to the network</label></div>
        <div class="row">

            <div class="row">
            <label>A server related error</label></div>
        <div class="row">
            <asp:HyperLink ID="GoHome" runat="server" Text="Click here to go back to the homepage" NavigateUrl="~/Default.aspx" /></div>

    </div>





</asp:Content>
