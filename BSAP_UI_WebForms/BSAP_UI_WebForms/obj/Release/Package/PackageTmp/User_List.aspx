<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="User_List.aspx.vb" Inherits="BSAP_UI_WebForms.User_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>User List</h1>
    <hr />
    <br />
    <center>
    <div class="centerme">
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="web_displayname" HeaderText="Display Name" HtmlEncode="False" SortExpression="displayname" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="usr_name" HeaderText="User Name" SortExpression="usr_name" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="usr_email" HeaderText="eMail" SortExpression="usr_email" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="dtcreated" HeaderText="Date Created" SortExpression="dtcreated" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="last_login" HeaderText="Last Login" SortExpression="last_login" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="web_enabled" HeaderText="Enabled?" SortExpression="web_enabled" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bsap %>" ProviderName="<%$ ConnectionStrings:bsap.ProviderName %>" SelectCommand="SELECT web_displayname,usr_name, usr_pwd, usr_email, dtcreated, last_login, web_enabled FROM web_view_user_list ORDER BY displayname ASC"></asp:SqlDataSource>
    </div>
        </center>
        <br />

</asp:Content>
