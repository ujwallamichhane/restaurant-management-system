<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
    <asp:Button ID="btnlogout" runat="server" OnClick="btnlogout_Click" Text="Logout" />
  
</asp:Content>

