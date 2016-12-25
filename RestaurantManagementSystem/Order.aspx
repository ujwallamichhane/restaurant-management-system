<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            align-items:center;
            border:2px;
            
        }
        .auto-style2 {
            width: 89px;
        }
        .auto-style4 {
            width: 78px;
        }
        .auto-style5 {
            width: 315px;
        }
        .auto-style8 {
            width: 52px;
        }
        .auto-style9 {
            width: 79px;
        }
        .auto-style10 {
            width: 100%;
        }
        .auto-style11 {
            text-align: center;
            text-decoration: underline;
            font-size: x-large;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="Breakfast" runat="server">
            <br />
            <table class="auto-style10">
                <tr>
                    <td class="auto-style11"><strong>Breakfast</strong></td>
                </tr>
            </table>
            <asp:CheckBoxList ID="cblbreakfast" runat="server" DataSourceID="SqlDataSource1" DataTextField="foodname" DataValueField="price">
            </asp:CheckBoxList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price, foodcategory.Type FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'breakfast')"></asp:SqlDataSource>
            <asp:Label ID="Label2" runat="server" Text="QTY"></asp:Label>
            <asp:DropDownList ID="ddlbreakfast" runat="server">
                <asp:ListItem Value="1">1pcs</asp:ListItem>
                <asp:ListItem Value="2">2pcs</asp:ListItem>
                <asp:ListItem Value="3">3pcs</asp:ListItem>
                <asp:ListItem Value="4">4pcs</asp:ListItem>
                <asp:ListItem Value="5">5pcs</asp:ListItem>
                <asp:ListItem Value="6">6pcs</asp:ListItem>
                <asp:ListItem Value="7">7pcs</asp:ListItem>
                <asp:ListItem Value="8">8pcs</asp:ListItem>
                <asp:ListItem Value="9">9pcs</asp:ListItem>
                <asp:ListItem Value="10">10pcs</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="gotoappetiser" runat="server" Text="Go to Appetizer Section" OnClick="gotoappetiser_Click" />
            <br />
            
        </asp:View>
        <asp:View ID="appetizer" runat="server">
            <br />
            <table class="auto-style10">
                <tr>
                    <td class="auto-style11"><strong>Appetizers</strong></td>
                </tr>
            </table>
            <asp:CheckBoxList ID="cblappetizer" runat="server" DataSourceID="SqlDataSource3" DataTextField="foodname" DataValueField="price">
            </asp:CheckBoxList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price, foodcategory.Type FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'appetizer')"></asp:SqlDataSource>
            <asp:Label ID="Label3" runat="server" Text="QTY"></asp:Label>
            <asp:DropDownList ID="ddlappetizer" runat="server">
                <asp:ListItem Value="1 ">1 pcs</asp:ListItem>
                <asp:ListItem Value="2 ">2 pcs</asp:ListItem>
                <asp:ListItem Value="3 ">3 pcs</asp:ListItem>
                <asp:ListItem Value="4 ">4 pcs</asp:ListItem>
                <asp:ListItem Value="5">5 pcs</asp:ListItem>
                <asp:ListItem Value="6 ">6 pcs</asp:ListItem>
                <asp:ListItem Value="7 ">7 pcs</asp:ListItem>
                <asp:ListItem Value="8">8 pcs</asp:ListItem>
                <asp:ListItem Value="9 ">9 pcs</asp:ListItem>
                <asp:ListItem Value="10 ">10 pcs</asp:ListItem>
                <asp:ListItem Value="1 ">1 plate</asp:ListItem>
                <asp:ListItem Value="2 ">2 plate</asp:ListItem>
                <asp:ListItem Value="3 ">3 plate</asp:ListItem>
                <asp:ListItem Value="4 ">4 plate</asp:ListItem>
                <asp:ListItem Value="5 ">5 plate</asp:ListItem>
                <asp:ListItem Value="6 ">6 plate</asp:ListItem>
                <asp:ListItem Value="7 ">7 plate</asp:ListItem>
                <asp:ListItem Value="8 ">8 plate</asp:ListItem>
                <asp:ListItem Value="9 ">9 plate</asp:ListItem>
                <asp:ListItem Value="10 ">10 plate</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="gotobreakfastsection" runat="server" Text="&lt;&lt; Back" OnClick="gotobreakfastsection_Click" />
            <asp:Button ID="gotomaindish" runat="server" Text="Go to Main Dish Section" OnClick="gotomaindish_Click" />
        </asp:View>
        <asp:View ID="maindish" runat="server">
            <br />
            <table class="auto-style10">
                <tr>
                    <td class="auto-style11"><strong>Main Dishes</strong></td>
                </tr>
            </table>
            <asp:CheckBoxList ID="cblmaindish" runat="server" DataSourceID="SqlDataSource2" DataTextField="foodname" DataValueField="price">
            </asp:CheckBoxList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price, foodcategory.Type FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'main dish')"></asp:SqlDataSource>
            <asp:Label ID="Label4" runat="server" Text="QTY"></asp:Label>
            <asp:DropDownList ID="ddlmaindish" runat="server">
                <asp:ListItem Value="1 ">1 plate</asp:ListItem>
                <asp:ListItem Value="2 ">2 plate</asp:ListItem>
                <asp:ListItem Value="3 ">3 plate</asp:ListItem>
                <asp:ListItem Value="4 ">4 plate</asp:ListItem>
                <asp:ListItem Value="5 ">5 plate</asp:ListItem>
                <asp:ListItem Value="6 ">6 plate</asp:ListItem>
                <asp:ListItem Value="7 ">7 plate</asp:ListItem>
                <asp:ListItem Value="8 ">8 plate</asp:ListItem>
                <asp:ListItem Value="9 ">9 plate</asp:ListItem>
                <asp:ListItem Value="10 ">10 plate</asp:ListItem>
                <asp:ListItem Value="11 ">11 plate</asp:ListItem>
                <asp:ListItem Value="12">12 plate</asp:ListItem>
                <asp:ListItem Value="13 ">13 plate</asp:ListItem>
                <asp:ListItem Value="14 ">14 plate</asp:ListItem>
                <asp:ListItem Value="15 ">15 plate</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="gotoappetisersection" runat="server" Text="&lt;&lt; Back" OnClick="gotoappetisersection_Click" />
            <asp:Button ID="gotokhajaset" runat="server" Text="Go to Khajaset Section" OnClick="gotokhajaset_Click" />
        </asp:View>
        <asp:View ID="khajaset" runat="server">
            <table class="auto-style10">
                <tr>
                    <td class="auto-style11"><strong>Khajasets</strong></td>
                </tr>
            </table>
            <br />
            <asp:CheckBoxList ID="cblkhajaset" runat="server" DataSourceID="SqlDataSource4" DataTextField="foodname" DataValueField="price">
            </asp:CheckBoxList>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price, foodcategory.Type FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'khaja set')"></asp:SqlDataSource>
            <asp:Label ID="Label5" runat="server" Text="QTY"></asp:Label>
            <asp:DropDownList ID="ddlkhajasets" runat="server">
                <asp:ListItem Value="1">1 plate</asp:ListItem>
                <asp:ListItem Value="2 ">2 plate</asp:ListItem>
                <asp:ListItem Value="3 ">3 plate</asp:ListItem>
                <asp:ListItem Value="4 ">4 plate</asp:ListItem>
                <asp:ListItem Value="5 ">5 plate</asp:ListItem>
                <asp:ListItem Value="6 ">6 plate</asp:ListItem>
                <asp:ListItem Value="7 ">7 plate</asp:ListItem>
                <asp:ListItem Value="8 ">8 plate</asp:ListItem>
                <asp:ListItem Value="9 ">9 plate</asp:ListItem>
                <asp:ListItem Value="10 ">10 plate</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="gotomaindishsection" runat="server" Text="&lt;&lt; Back   " OnClick="gotomaindishsection_Click" />
            <asp:Button ID="gotosalads" runat="server" Text="Go to Salad Section" OnClick="gotosalads_Click" />
            <br />
        </asp:View>
        <asp:View ID="Salads" runat="server">
            <br />
            <table class="auto-style10">
                <tr>
                    <td class="auto-style11"><strong>Salads</strong></td>
                </tr>
            </table>
            <asp:CheckBoxList ID="cblsalads" runat="server" DataSourceID="SqlDataSource5" DataTextField="foodname" DataValueField="price">
            </asp:CheckBoxList>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT food.foodname, menu.price, foodcategory.Type FROM menu INNER JOIN food ON menu.FOODID = food.FOODID INNER JOIN foodcategory ON menu.FCID = foodcategory.FCID WHERE (foodcategory.Type = 'salad')"></asp:SqlDataSource>
            <br />
            <asp:Label ID="Label6" runat="server" Text="QTY"></asp:Label>
            <asp:DropDownList ID="ddlsalads" runat="server">
                <asp:ListItem Value="1 ">1 plate</asp:ListItem>
                <asp:ListItem Value="2">2 plate</asp:ListItem>
                <asp:ListItem Value="3 ">3 plate</asp:ListItem>
                <asp:ListItem Value="4 ">4 plate</asp:ListItem>
                <asp:ListItem Value="5 ">5 plate</asp:ListItem>
                <asp:ListItem Value="6 ">6 plate</asp:ListItem>
                <asp:ListItem Value="7 ">7 plate</asp:ListItem>
                <asp:ListItem Value="8 ">8 plate</asp:ListItem>
                <asp:ListItem Value="9 ">9 plate</asp:ListItem>
                <asp:ListItem Value="10 ">10 plate</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="gotokhajasetsection" runat="server" Text="&lt;&lt; Back" OnClick="gotokhajasetsection_Click" />
            <asp:Button ID="gotobeverage" runat="server" Text="Go to Beverage Section" OnClick="gotobeverage_Click" />
        </asp:View>
        <asp:View ID="Beverages" runat="server">
            <br />
            <table class="auto-style10">
                <tr>
                    <td class="auto-style11"><strong>Beverages</strong></td>
                </tr>
            </table>
            <asp:CheckBoxList ID="cblbeverage" runat="server" DataSourceID="SqlDataSource6" DataTextField="foodname" DataValueField="price">
            </asp:CheckBoxList>
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="select food.foodname,menu.price,foodcategory.type from menu join food on menu.foodid= food.foodid join foodcategory on menu .fcid=foodcategory.fcid where foodcategory.type='beverage'"></asp:SqlDataSource>
            <br />
            <asp:Label ID="Label7" runat="server" Text="QTY"></asp:Label>
            <asp:DropDownList ID="Ddlbeverage" runat="server">
                <asp:ListItem Value="1 ">1 btl</asp:ListItem>
                <asp:ListItem Value="2 ">2 btl</asp:ListItem>
                <asp:ListItem Value="3 ">3 btl</asp:ListItem>
                <asp:ListItem Value="4">4 btl</asp:ListItem>
                <asp:ListItem Value=" 5 "> 5 btl</asp:ListItem>
                <asp:ListItem Value="6">6 btl</asp:ListItem>
                <asp:ListItem Value="7 ">7 btl</asp:ListItem>
                <asp:ListItem Value="8 ">8 btl</asp:ListItem>
                <asp:ListItem Value="9">9 btl</asp:ListItem>
                <asp:ListItem Value="10">10 btl</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="gotosaladsection" runat="server" Text="&lt;&lt; Back" OnClick="gotosaladsection_Click" />
            <asp:Button ID="gotodesserts" runat="server" Text="Go to Dessert section" OnClick="gotodesserts_Click" />
        </asp:View>
        <asp:View ID="Desserts" runat="server">
            <br />
            <table class="auto-style10">
                <tr>
                    <td class="auto-style11"><strong>Desserts</strong></td>
                </tr>
            </table>
            <asp:CheckBoxList ID="cbldesserts" runat="server" DataSourceID="SqlDataSource7" DataTextField="foodname" DataValueField="price">
            </asp:CheckBoxList>
            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="select food.foodname,menu.price,foodcategory.type from menu join food on menu.foodid= food.foodid join foodcategory on menu .fcid=foodcategory.fcid where foodcategory.type='desserts'"></asp:SqlDataSource>
            <asp:Label ID="Label8" runat="server" Text="QTY"></asp:Label>
            <asp:DropDownList ID="Ddldesert" runat="server">
                <asp:ListItem Value="1 ">1 cup</asp:ListItem>
                <asp:ListItem Value="2 ">2 cup</asp:ListItem>
                <asp:ListItem Value="3 ">3 cup</asp:ListItem>
                <asp:ListItem Value="4 ">4 cup</asp:ListItem>
                <asp:ListItem Value="5 ">5 cup</asp:ListItem>
                <asp:ListItem Value="6 ">6 cup</asp:ListItem>
                <asp:ListItem Value="7 ">7 cup</asp:ListItem>
                <asp:ListItem Value="8 ">8 cup</asp:ListItem>
                <asp:ListItem Value="9 ">9 cup</asp:ListItem>
                <asp:ListItem Value="10 ">10 cup</asp:ListItem>
                <asp:ListItem Value=" 1 "> 1 cone</asp:ListItem>
                <asp:ListItem Value="2 ">2 cone</asp:ListItem>
                <asp:ListItem Value="3 ">3 cone</asp:ListItem>
                <asp:ListItem Value="4 ">4 cone</asp:ListItem>
                <asp:ListItem Value="5 ">5 cone</asp:ListItem>
                <asp:ListItem Value="6 ">6 cone</asp:ListItem>
                <asp:ListItem Value="7 ">7 cone</asp:ListItem>
                <asp:ListItem Value="8 ">8 cone</asp:ListItem>
                <asp:ListItem Value="9 ">9 cone</asp:ListItem>
                <asp:ListItem Value="10 ">10 cone</asp:ListItem>
                <asp:ListItem Value="1 ">1 pcs</asp:ListItem>
                <asp:ListItem Value="2 ">2 pcs</asp:ListItem>
                <asp:ListItem Value="3 ">3 pcs</asp:ListItem>
                <asp:ListItem Value="4 ">4 pcs</asp:ListItem>
                <asp:ListItem Value="5 ">5 pcs</asp:ListItem>
                <asp:ListItem Value="7 ">7 pcs</asp:ListItem>
                <asp:ListItem Value="8 ">8 pcs</asp:ListItem>
                <asp:ListItem Value="9 ">9 pcs</asp:ListItem>
                <asp:ListItem Value="10 ">10 pcs</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label13" runat="server" Text=" Your Information for Delivery"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label9" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label10" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label11" runat="server" Text=" Full Address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label12" runat="server" Text="Contact No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcontact" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label14" runat="server" Text="Order Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtorderdate" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
            <br />
            <asp:Button ID="gotobeveragesection" runat="server" Text="&lt;&lt; Back" OnClick="gotobeveragesection_Click" />
            <asp:Button ID="btnplaceorder" runat="server" Text="Place  Your Order" OnClick="btnplaceorder_Click" />

        </asp:View>
        <asp:View ID="View1" runat="server"> 
            <table  class="auto-style1" id="table1" >
                <tr>
                    <td colspan="2"><h3>Your Order Summary</h3></td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label15" runat="server" Text=" Your First Name"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="LblFname" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label16" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lbllastname" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label17" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lbladdress" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label18" runat="server" Text="Contact No."></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblcontact" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label19" runat="server" Text="Order Date:"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblorderdate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label20" runat="server" Text="Particulars"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="Label21" runat="server" Text="Unit Price"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="Label22" runat="server" Text="Qty"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="Label23" runat="server" Text="Total"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="lblparticulars" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblunitprice" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="lblqty" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="lbltotal" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="Label24" runat="server" Text="Grand Total :"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblgrandtotal" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Literal ID="Ltrmsgdisp" runat="server"></asp:Literal>
            <br />
            <asp:Button ID="gotodessertsection" runat="server" Text="&lt;&lt; Back" OnClick="gotodessertsection_Click" />
            <asp:Button ID="btnsubmit" runat="server" Text="submit" OnClick="btnsubmit_Click" />
        </asp:View>
    </asp:MultiView>
    
</asp:Content>

