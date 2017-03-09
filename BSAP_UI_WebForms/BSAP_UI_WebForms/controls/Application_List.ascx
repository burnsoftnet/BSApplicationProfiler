<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Application_List.ascx.vb" Inherits="BSAP_UI_WebForms.Application_List" %>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bsap %>" ProviderName="<%$ ConnectionStrings:bsap.ProviderName %>" SelectCommand="SELECT * FROM web_view_app_project_name ORDER BY name asc"></asp:SqlDataSource>

<asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
        <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" Visible="False" />
        <asp:BoundField DataField="web_name" HeaderText="Project Name" SortExpression="name" HtmlEncode="false" />
        <asp:BoundField DataField="appdesc" HeaderText="Description" SortExpression="appdesc" />
        <asp:BoundField DataField="byagent" HeaderText="By Agents" SortExpression="byagent" HtmlEncode="false" />
        <asp:BoundField DataField="TotalSessions" HeaderText="Total Sessions" SortExpression="TotalSessions" >
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
