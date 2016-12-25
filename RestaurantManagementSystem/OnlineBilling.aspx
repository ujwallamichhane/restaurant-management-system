<%@ Page Title="" Language="C#" MasterPageFile="~/Receptionmaster.master" AutoEventWireup="true" CodeFile="OnlineBilling.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 139px;
        }
        .auto-style4 {
            width: 42px;
        }
        .auto-style5 {
            width: 107px;
        }
        .auto-style6 {
            width: 230px;
        }
        .auto-style7 {
            width: 198px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Name" runat="server" Text="Name"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:DropDownList ID="ddlcustomername" runat="server" DataSourceID="customername" DataTextField="Cust_FName" DataValueField="Cust_FName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="customername" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT DISTINCT [Cust_FName] FROM [customerorder]"></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btngetbill" runat="server" OnClick="btngetbill_Click" Text="Get Bill" />
            </td>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Ordered Date :"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtordereddate" runat="server"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Data/images/calender.jpg" OnClick="ImageButton1_Click" />
                <br />
                <asp:Calendar ID="Calendar" runat="server" OnDayRender="Calendar_DayRender" OnSelectionChanged="Calendar_SelectionChanged"></asp:Calendar>
            </td>
            <td class="auto-style7">
                Phone Number :<asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
                <asp:Button ID="btnprintbill" runat="server" OnClick="btnprintbill_Click" Text="Print Bill" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
            </td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" Width="563px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="MenuId" HeaderText="Menu Id" />
                        <asp:BoundField DataField="foodname" HeaderText="Food Name" />
                        <asp:BoundField DataField="Type" HeaderText="Food Category" />
                        <asp:BoundField DataField="price" HeaderText="Unit Price" />
                        <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="totalamount" HeaderText=" Total Amount" />
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
            </td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
    </table>
&nbsp;
</asp:Content>

