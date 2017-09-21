<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="All_Sessions_By_Agent.aspx.vb" Inherits="BSAP_UI_WebForms.All_Sessions_By_Agent" %>
<%@ Register src="controls/Sessions_by_Agent.ascx" tagname="Sessions_by_Agent" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%=Sessions_by_Agent1.PageTitle %></h1>
    <hr />
    <br />
    <br />
    <uc1:Sessions_by_Agent ID="Sessions_by_Agent1" runat="server" />

</asp:Content>
