<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Agents.aspx.vb" Inherits="BSAP_UI_WebForms.Agents" %>
<%@ Register src="controls/Application_Agents.ascx" tagname="Application_Agents" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agent Lists</h1>
    <hr />
    <br />
    <center>
        <a href="install/BSAP_Installer.msi">
        <asp:Image ID="Image1" runat="server" Height="32px" ImageUrl="~/images/download_48x38.png" Width="32px" BorderStyle="None" BorderWidth="0px" ToolTip="Download Agent Installer" />
        </a>
        <br />
        <br />
    <uc1:Application_Agents ID="Application_Agents1" runat="server" />
        </center>
</asp:Content>
