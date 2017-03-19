<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Project_List.aspx.vb" Inherits="BSAP_UI_WebForms.Project_List" %>
<%@ Register src="controls/Application_List.ascx" tagname="Application_List" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Project Lists</h1>
    <hr />
     <br />
    <center>
        <a href="Add_Application.aspx">
            <asp:Image ID="Image2" runat="server" BorderStyle="None" Height="32px" ImageUrl="~/images/add-button_318-32466.jpg" Width="32px" ToolTip="Add new Project to List" />
        </a>
     </center>
     <br />
    <br />
    <uc1:Application_List ID="Application_List1" runat="server" />
</asp:Content>
