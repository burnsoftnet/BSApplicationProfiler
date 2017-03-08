<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Project_List.aspx.vb" Inherits="Project_List" %>

<%@ Register src="controls/Application_List.ascx" tagname="Application_List" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Project Lists</h1>
    <hr />
    <br />
    <center>
    <uc1:Application_List ID="Application_List1" runat="server" />
        </center>
</asp:Content>

