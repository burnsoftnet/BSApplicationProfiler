<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AddEdit_Project.ascx.vb" Inherits="BSAP_UI_WebForms.AddEdit_Project" %>
<style type="text/css">
    .auto-style1 {
        width: 75%;
    }
    .auto-style2 {
        width: 18px;
    }
    .auto-style3 {
        width: 174px;
    }
    .auto-style4 {
        width: 367px;
    }
    .auto-style5 {
        text-align: center;
    }
</style>

<table align="center" class="auto-style1">
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Project Name:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtName" runat="server" Width="360px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Description:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtDesc" runat="server" Width="360px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Enabled?</td>
        <td class="auto-style4">
            <asp:CheckBox ID="chkEnabled" runat="server" Text="Yes" Checked="True" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Has Sub Processes?</td>
        <td class="auto-style4">
            <asp:CheckBox ID="chkHasSub" runat="server" Text="Yes" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Process Display Name:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtProcessName" runat="server" Width="360px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Executable Name:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtEXEName" runat="server" Width="360px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Match Parameter?</td>
        <td class="auto-style4">
            <asp:CheckBox ID="chkMatchParam" runat="server" Text="Yes" AutoPostBack="True" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <% If chkMatchParam.Checked Then %>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Parameter:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtParameter" runat="server" Width="360px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <%End if %>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Interval:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtInterval" runat="server" Width="360px">0</asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Has Logs?</td>
        <td class="auto-style4">
            <asp:CheckBox ID="chkHasLogs" runat="server" Text="Yes" AutoPostBack="True" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <% If chkHasLogs.Checked Then %>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Log Name:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtLogName" runat="server" Width="360px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Log Path Location:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtLogPath" runat="server" Width="360px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Clear Logs on Exit?</td>
        <td class="auto-style4">
            <asp:CheckBox ID="chkClearLogs" runat="server" Text="Yes" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <%End if %>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">Uses Windows Event Log?</td>
        <td class="auto-style4">
            <asp:CheckBox ID="chkUseEventLog" runat="server" Text="Yes" AutoPostBack="True" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <% If chkUseEventLog.Checked Then %>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">NT Source:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtNTSource" runat="server" Width="360px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">NT Event ID:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtNTEventID" runat="server" Width="360px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <%End if %>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td class="auto-style4">
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5" colspan="4">
            <asp:Button ID="btnSave" runat="server" Text="Save" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" />
        </td>
    </tr>
    </table>

