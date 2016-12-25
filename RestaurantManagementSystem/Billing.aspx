<%@ Page Title="" Language="C#" MasterPageFile="~/Receptionmaster.master" AutoEventWireup="true" CodeFile="Billing.aspx.cs" Inherits="Billing" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 293px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Table Name :"></asp:Label>
                <asp:DropDownList ID="ddltable" runat="server" DataSourceID="tabledata" DataTextField="name" DataValueField="TableId">
                </asp:DropDownList>
                <asp:SqlDataSource ID="tabledata" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT * FROM [tables]"></asp:SqlDataSource>
                <asp:Button ID="Button1" runat="server" Text="Get Bill" OnClick="Button1_Click" />
            </td>
            <td>
                <asp:Button ID="btnPrint" runat="server" Text="Print" Width="79px" OnClick="btnPrint_Click" />
                <asp:Label ID="Label48" runat="server" Text="Date :"></asp:Label>
                <asp:Label ID="lbldate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
                <br />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" AutoGenerateColumns="False" Width="765px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField  DataField="MenuID" HeaderText="Menu ID" SortExpression="Eval(&quot;MenuId&quot;)" />
            <asp:BoundField DataField="foodname" HeaderText="Food Name " />
            <asp:BoundField DataField="type" HeaderText="Food Category" />
            <asp:BoundField  DataField="Price"  HeaderText="Unitprice"/>
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:BoundField  DataField="TotalAmount" HeaderText="Total Amount" />
        </Columns>
        <EditRowStyle BackColor="#999999" />       
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

    <br />
    
</asp:Content>

