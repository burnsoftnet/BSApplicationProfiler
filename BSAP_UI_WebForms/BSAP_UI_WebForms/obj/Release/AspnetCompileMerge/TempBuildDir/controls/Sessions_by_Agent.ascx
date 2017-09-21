<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Sessions_by_Agent.ascx.vb" Inherits="BSAP_UI_WebForms.Sessions_by_Agent" %>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bsap %>" ProviderName="<%$ ConnectionStrings:bsap.ProviderName %>"></asp:SqlDataSource>
<div class=".centerme">
<asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CssClass=".centerme">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
        <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" Visible="False" />
        <asp:BoundField DataField="web_ProjectName" HeaderText="Project Name" SortExpression="ProjectName" HtmlEncode="false" >
        <HeaderStyle HorizontalAlign="Center" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="web_sessiondt" HeaderText="Session Date Time" SortExpression="sessiondt" HtmlEncode="false" >
        <HeaderStyle HorizontalAlign="Center" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="sessionend" HeaderText="Session End" SortExpression="sessionend" HtmlEncode="false" >
        <HeaderStyle HorizontalAlign="Center" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="haslogs" HeaderText="Has Log Files" SortExpression="haslogs" HtmlEncode="false" >
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
    </div>