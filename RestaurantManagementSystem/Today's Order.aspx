<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Today's Order.aspx.cs" Inherits="Today_s_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
    <h3>Online Orders</h3><br />
    <asp:GridView ID="gvonlineorder" runat="server">
    </asp:GridView><br />
    <h3>Restaurant in place order</h3><br />
    <asp:GridView ID="gvrestaurantorders" runat="server">
    </asp:GridView><br />
</asp:Content>

