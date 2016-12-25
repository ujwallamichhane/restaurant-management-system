<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
            width: 80px;
        }
        .auto-style4 {
            width: 80px;
        }
        .auto-style5 {
            width: 32%;
            margin-top:40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style5">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblusername" runat="server" Text="Username"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblpassword" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password">*</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Button ID="btnlogin" runat="server" Text="Login" Width="71px" OnClick="btnlogin_Click" />
            </td>
            <td>
                <asp:Button ID="btncancel" runat="server" Text="Cancel" Width="71px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>

