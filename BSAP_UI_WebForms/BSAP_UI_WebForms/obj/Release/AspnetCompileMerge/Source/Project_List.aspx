<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Project_List.aspx.vb" Inherits="BSAP_UI_WebForms.Project_List" %>
<%@ Register src="controls/Application_List.ascx" tagname="Application_List" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Project Lists</h1>
    <hr />
    <br />
    <uc1:Application_List ID="Application_List1" runat="server" />
</asp:Content>
