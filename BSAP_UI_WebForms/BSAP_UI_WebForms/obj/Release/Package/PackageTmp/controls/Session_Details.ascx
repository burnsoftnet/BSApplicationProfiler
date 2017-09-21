<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Session_Details.ascx.vb" Inherits="BSAP_UI_WebForms.Session_Details1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 100px;
    }
    .auto-style3 {
        width: 149px;
    }
    .auto-style4 {
        width: 144px;
    }
    .auto-style5 {
        width: 197px;
    }
    .auto-style6 {
        width: 75%;
    }
    .auto-style7 {
        text-align: center;
    }
    .auto-style8 {
        width: 196px;
    }
    .auto-style9 {
        width: 144px;
        height: 23px;
    }
    .auto-style10 {
        width: 197px;
        height: 23px;
    }
    .auto-style11 {
        width: 149px;
        height: 23px;
    }
    .auto-style12 {
        width: 100px;
        height: 23px;
    }
</style>
<p>
    <br />
    <center>
    <table class="auto-style6">
        <tr>
            <td class="auto-style4"><strong>Session Start:</strong></td>
            <td class="auto-style5">
                <asp:Label ID="lblStart" runat="server"></asp:Label>
            </td>
            <td class="auto-style3" colspan="2"><strong>Session End:</strong></td>
            <td class="auto-style2">
                <asp:Label ID="lblEnd" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"><strong>Main Process Name:</strong></td>
            <td class="auto-style5">
                <asp:Label ID="lblProcessName" runat="server"></asp:Label>
            </td>
            <td class="auto-style3" colspan="2"><strong>User Name:</strong></td>
            <td class="auto-style2">
                <asp:Label ID="lblUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"><strong>Session Total Time:</strong></td>
            <td class="auto-style5">
                <asp:Label ID="lblSessionTotal" runat="server"></asp:Label>
&nbsp;minutes</td>
            <td class="auto-style3" colspan="2"><strong>Application Version:</strong></td>
            <td class="auto-style2">
                <asp:Label ID="lblVersion" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style9"><strong>Application Creator:</strong></td>
            <td class="auto-style10">
                <asp:Label ID="lblAppCreator" runat="server"></asp:Label>
            </td>
            <td class="auto-style11" colspan="2"><strong>App. Last Access:</strong></td>
            <td class="auto-style12">
                <asp:Label ID="lblAppLastAccess" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"><strong>App. Last Write:</strong></td>
            <td class="auto-style5">
                <asp:Label ID="lblAppLastWrite" runat="server"></asp:Label>
            </td>
            <td class="auto-style3" colspan="2"><strong>App. Create Date:</strong></td>
            <td class="auto-style2">
                <asp:Label ID="lblAppCreateDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"><strong>Command Line:</strong></td>
            <td colspan="4">
                <asp:Label ID="lblCommandLine" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"><strong>Average CPU:</strong></td>
            <td>
                <asp:Label ID="lblAvgCPU" runat="server"></asp:Label>
            </td>
            <td class="auto-style8">
                <strong>Average Memory:</strong></td>
            <td colspan="2">
                <asp:Label ID="lblAvgMem" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"><strong>Average Handles:</strong></td>
            <td>
                <asp:Label ID="lblAvgHandles" runat="server"></asp:Label>
            </td>
            <td class="auto-style8">
                <strong>Average Threads:</strong></td>
            <td colspan="2">
                <asp:Label ID="lblAvgThreads" runat="server"></asp:Label>
            </td>
        </tr>
    </table></center>
</p>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bsap %>" ProviderName="<%$ ConnectionStrings:bsap.ProviderName %>"></asp:SqlDataSource>


<br />
<table align="center" class="auto-style1">
    <tr>
        <td class="auto-style7">
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1">
                <series>
                    <asp:Series ChartType="SplineArea" Name="Series1" XValueMember="dt_time" YValueMembers="cpu">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
        </td>
        <td class="auto-style7">
            <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource1">
                <series>
                    <asp:Series Name="Series1" XValueMember="dt_time" YValueMembers="memoryused">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
        </td>
    </tr>
    <tr>
        <td class="auto-style7">
            <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource1">
                <series>
                    <asp:Series ChartType="Area" Name="Series1" XValueMember="dt_time" YValueMembers="handles">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
        </td>
        <td class="auto-style7">
            <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource1">
                <series>
                    <asp:Series ChartType="Area" Name="Series1" XValueMember="dt_time" YValueMembers="threads">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7" colspan="2">


<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
        <asp:BoundField DataField="filename" HeaderText="File Name" SortExpression="filename">
        <HeaderStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="logdetails" HeaderText="Log Details" SortExpression="logdetails">
        <HeaderStyle HorizontalAlign="Center" />
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



        </td>
    </tr>
</table>
<br />

<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:bsap %>" ProviderName="<%$ ConnectionStrings:bsap.ProviderName %>"></asp:SqlDataSource>






