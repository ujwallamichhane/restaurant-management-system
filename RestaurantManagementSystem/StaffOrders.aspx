<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffOrders.aspx.cs" Inherits="StaffOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 118px;
        }
        .auto-style5 {
            width: 235px;
        }
        .auto-style6 {
            width: 92%;
            height: 280px;
        }
        .auto-style7 {
            width: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style6">
        <tr>
            <td colspan="2"><h3>Staff Orders</h3></td>
            <td class="auto-style7">&nbsp;</td>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Today's Date :"></asp:Label>
                <asp:Label ID="Lbldate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Table Number"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddltablename" runat="server" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="TableId">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT * FROM [tables] ORDER BY [name]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Breakfast"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:RadioButtonList ID="rblbreakfast" runat="server" DataSourceID="SqlDataSource1" DataTextField="foodname" DataValueField="price">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'breakfast')"></asp:SqlDataSource>
&nbsp; </td>
            <td class="auto-style7">
                <asp:Label ID="Label13" runat="server" Text="Qty : "></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rblqty" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Button ID="btnorder" runat="server" Text="order" OnClick="btnorder_Click" />
&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="Appetizer"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:RadioButtonList ID="rblappetizer" runat="server" DataSourceID="SqlDataSource3" DataTextField="foodname" DataValueField="price">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'appetizer')"></asp:SqlDataSource>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td>
                <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label3" runat="server" Text="Main Dish"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:RadioButtonList ID="rblmaindish" runat="server" DataSourceID="SqlDataSource4" DataTextField="foodname" DataValueField="price">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'main dish')"></asp:SqlDataSource>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label4" runat="server" Text="Khajaset"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:RadioButtonList ID="rblkhajaset" runat="server" DataSourceID="SqlDataSource5" DataTextField="foodname" DataValueField="price">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'Khaja set')"></asp:SqlDataSource>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label5" runat="server" Text="Salads"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:RadioButtonList ID="rblsalads" runat="server" DataSourceID="SqlDataSource6" DataTextField="foodname" DataValueField="price">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'salad')"></asp:SqlDataSource>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label15" runat="server" Text="Beverages"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:RadioButtonList ID="rblbeverage" runat="server" DataSourceID="SqlDataSource8" DataTextField="foodname" DataValueField="price">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'Beverage')"></asp:SqlDataSource>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label12" runat="server" Text="Desserts"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:RadioButtonList ID="rbldesserts" runat="server" DataSourceID="SqlDataSource7" DataTextField="foodname" DataValueField="price">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'desserts')"></asp:SqlDataSource>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    
          
   
</asp:Content>

