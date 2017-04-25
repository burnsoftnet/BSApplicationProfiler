<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Edit_Application.aspx.vb" Inherits="BSAP_UI_WebForms.Edit_Application" %>
<%@ Register src="controls/AddEdit_Project.ascx" tagname="AddEdit_Project" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= AddEdit_Project1.PageTitle %></h1>
    <hr />
    <br />
    <uc1:AddEdit_Project ID="AddEdit_Project1" runat="server" EDITMODE="True" />
    <br />

</asp:Content>
