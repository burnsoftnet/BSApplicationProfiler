<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Session_Details.aspx.vb" Inherits="BSAP_UI_WebForms.Session_Details" %>
<%@ Register src="controls/Session_Details.ascx" tagname="Session_Details" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1>Session Details</h1>
<hr />
<br />
    <uc1:Session_Details ID="Session_Details1" runat="server" />
<br />
</asp:Content>

