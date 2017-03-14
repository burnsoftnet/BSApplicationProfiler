<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Agents.aspx.vb" Inherits="BSAP_UI_WebForms.Agents" %>
<%@ Register src="controls/Application_Agents.ascx" tagname="Application_Agents" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agent Lists</h1>
    <hr />
    <br />
        <br />
    <center>
    <uc1:Application_Agents ID="Application_Agents1" runat="server" />
        </center>
</asp:Content>
