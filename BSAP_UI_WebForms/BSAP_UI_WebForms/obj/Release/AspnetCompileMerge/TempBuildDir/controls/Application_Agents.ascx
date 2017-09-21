<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Application_Agents.ascx.vb" Inherits="BSAP_UI_WebForms.Application_Agents" %>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bsap %>" ProviderName="<%$ ConnectionStrings:bsap.ProviderName %>" SelectCommand="SELECT * FROM web_view_agents ORDER BY dtreported desc"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
        <asp:BoundField DataField="computername" HeaderText="Computer Name" SortExpression="computername" Visible="true" />
        <asp:BoundField DataField="operatingsystem" HeaderText="OS" SortExpression="operatingsystem" HtmlEncode="false" >
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="maxmem" HeaderText="Memory" SortExpression="maxmem" HtmlEncode="false" >
        <HeaderStyle HorizontalAlign="Center" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="cpuspeed" HeaderText="CPU Speed (GHz)" SortExpression="cpuspeed" >
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="cpuname" HeaderText="CPU Info" SortExpression="cpuname" HtmlEncode="false" >
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="dtcreated" HeaderText="Date Created" SortExpression="dtcreated" HtmlEncode="false" >
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="dtreported" HeaderText="Last Report In" SortExpression="dtreported" HtmlEncode="false" >
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Web_SessionCount" HeaderText="Total Sessions" SortExpression="SessionCount" HtmlEncode="false" >
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