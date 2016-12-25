<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="FoodCategory.aspx.cs" Inherits="FoodCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-collapse: collapse;
            border-style: solid;
            border-width: 1px;
            align-self:center;
            margin-top:14px;
        }
        .auto-style2 {
        width: 126px;
    }
        .auto-style3 {
            width: 126px;
            height: 21px;
        }
        .auto-style4 {
            height: 21px;
        }
    </style>
     <table  class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text=" Food Category ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label3" runat="server" Text="Food Category"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtcategory" runat="server"></asp:TextBox>
                <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="BtnSave" runat="server" Text="Save" Width="65px" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

