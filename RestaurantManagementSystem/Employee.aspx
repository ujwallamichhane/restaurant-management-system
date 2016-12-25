<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style3 {
            width: 100px;
        }
    .auto-style4 {
        height: 23px;
        width: 100px;
    }
    .auto-style5 {
        width: 210px;
    }
    .auto-style6 {
        height: 23px;
        width: 210px;
    }
    .auto-style7 {
        margin-left: 0px;
    }
        .auto-style8 {
            width: 100px;
            height: 26px;
        }
        .auto-style9 {
            width: 210px;
            height: 26px;
        }
        .auto-style10 {
            width: 214px;
        }
        .auto-style11 {
            width: 214px;
            height: 26px;
        }
        .auto-style12 {
            height: 23px;
            width: 214px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="btnsearch" runat="server" CssClass="auto-style7" Text="Search" Width="66px" OnClick="btnsearch_Click" />
        </td>
        <td class="auto-style5">
            <asp:Literal ID="ltrstaffimage" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label3" runat="server" Text="Mid Name"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtmidname" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label4" runat="server" Text="Last Name"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            Gender</td>
        <td class="auto-style10">
            <asp:RadioButtonList ID="rblgender" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label6" runat="server" Text="DOB"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
            <asp:ImageButton ID="calenderimage" runat="server" ImageUrl="~/images/calender.jpg" OnClick="ImageButton1_Click" />
            <br />
            <asp:Calendar ID="Calendar" runat="server" OnDayRender="Calendar_DayRender" OnSelectionChanged="Calendar_SelectionChanged"></asp:Calendar>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label18" runat="server" Text="Contact No."></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtcontact" runat="server" MaxLength="10" TextMode="Phone"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label7" runat="server" Text="Father's Name"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtfathername" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label8" runat="server" Text="Mother's Name"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtmothername" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8">
            <asp:Label ID="Label9" runat="server" Text="Grand Father's Name"></asp:Label>
        </td>
        <td class="auto-style11">
            <asp:TextBox ID="txtgrandname" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label10" runat="server" Text="Address"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="Label11" runat="server" Text="Experience(yrs)"></asp:Label>
        </td>
        <td class="auto-style12">
            <asp:TextBox ID="txtexperience" runat="server" TextMode="Number"></asp:TextBox>
        </td>
        <td class="auto-style6">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label12" runat="server" Text="Trainings"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txttraining" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label13" runat="server" Text="Post"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtpost" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label14" runat="server" Text="Salary"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtsalary" runat="server" TextMode="Number"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label15" runat="server" Text="Username"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label16" runat="server" Text="Password"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label19" runat="server" Text="Role"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:DropDownList ID="ddlrole" runat="server" DataSourceID="SqlDataSource1" DataTextField="rolename" DataValueField="RID" Height="17px" Width="129px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rmsConnectionString %>" SelectCommand="SELECT * FROM [role]"></asp:SqlDataSource>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label17" runat="server" Text="Photo"></asp:Label>
        </td>
        <td class="auto-style10">
            <asp:FileUpload ID="fuphoto" runat="server" />
        </td>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;&nbsp;
            <asp:Button ID="btnsave" runat="server" Text="Save" Width="63px" OnClick="btnsave_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

