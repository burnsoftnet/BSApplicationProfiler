<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Project_list_all_sessions.aspx.vb" Inherits="BSAP_UI_WebForms.Project_list_all_sessions" %>
<%@ Register src="controls/Application_Sessions.ascx" tagname="Application_Sessions" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= Application_Sessions1.PageTitle %></h1>
    <hr />
    <br />
    <center>
    <uc1:Application_Sessions ID="Application_Sessions1" runat="server" />
        </center>
</asp:Content>
