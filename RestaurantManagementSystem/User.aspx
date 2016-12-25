<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
            width: 92px;
        }
        .auto-style3 {
            width: 92px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lbluid" runat="server" Text="UID"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtuid" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lblusername" runat="server" Text="Username"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="lblpassword" runat="server" Text="Password"></asp:Label>
        </td>
        <td class="auto-style4">
            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lblrole" runat="server" Text="Role"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlrole" runat="server" DataSourceID="ddl" DataTextField="rolename" DataValueField="rolename">
            </asp:DropDownList>
            <asp:SqlDataSource ID="ddl" runat="server" ConnectionString="Data Source=.;Initial Catalog=rms;User ID=sa;Password=root123" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [rolename] FROM [role]"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btndelete" runat="server" Text="Delete" />
        </td>
    </tr>
</table>
</asp:Content>

