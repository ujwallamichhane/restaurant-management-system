<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            margin:5px;
          
        }
        .auto-style2 {
            width: 93px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" class="auto-style1">
        <tr>
            <td colspan="2"><h3> Create the New Menu</h3></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblFoodName" runat="server" Text="Food Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlfoodname" runat="server" DataSourceID="SqlDataSource1" DataTextField="foodname" DataValueField="FOODID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT * FROM [food] ORDER BY [foodname]"></asp:SqlDataSource>
&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="LblFoodCategory" runat="server" Text="FoodCategory"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlfoodcategory" runat="server" DataSourceID="SqlDataSource2" DataTextField="Type" DataValueField="FCID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT * FROM [foodcategory] ORDER BY [Type]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtprice" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="Delete" />
            </td>
        </tr>
    </table>
</asp:Content>

