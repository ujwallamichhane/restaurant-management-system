<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TableName.aspx.cs" Inherits="TableName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 145px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" cellpadding="2" cellspacing="3" class="auto-style1">
        <tr>
            <td colspan="2">
                <asp:Literal ID="ltrmsg2" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Table ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
                <asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" Text="Search" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="Table Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txttablename" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" Text="Update" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btndelete" runat="server" Text="Delete" />
            </td>
        </tr>
    </table>
</asp:Content>

