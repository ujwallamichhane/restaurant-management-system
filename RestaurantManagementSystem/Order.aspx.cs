using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Order : System.Web.UI.Page
{
    ValidataionClass isvalid = new ValidataionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            MultiView1.ActiveViewIndex = 0;
           
        } 
     
    }
   

    protected void gotoappetiser_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }

    protected void gotobreakfastsection_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void gotomaindish_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }

    protected void gotoappetisersection_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }

    protected void gotokhajaset_Click(object sender, EventArgs e)
    {
            MultiView1.ActiveViewIndex = 3;
       
    }

    protected void gotosalads_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
      
    }

    protected void gotobeverage_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 5;
    }

    protected void gotodesserts_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 6;
    }

    protected void gotobeveragesection_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 5;
    }

    protected void gotosaladsection_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
    }

    protected void gotokhajasetsection_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
    }

    protected void gotomaindishsection_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }

    private bool CheckValidation() {
        bool Valid = true;
        if (!isvalid.checkValidation(txtfname.Text)) {
            ltrmsg.Text = "This Field is required";
            txtfname.Focus();
            Valid = false;
        }
        else if (isvalid.isAlldigit(txtfname.Text) || isvalid.checkname(txtfname.Text)) {
            ltrmsg.Text = "Numbers are not accepted as the First name.";
            txtfname.Focus();
            Valid = false;
        }
        else if (!isvalid.checkValidation(txtlname.Text)) {
            ltrmsg.Text = "This Field is required";
            txtlname.Focus();
            Valid = false;
        }
        else if (isvalid.isAlldigit(txtlname.Text) || isvalid.checkname(txtfname.Text))
        {
            ltrmsg.Text = "Numbers or Alphanumeric values Are Not Accepted As  Last Name.";
            txtlname.Focus();
            Valid = false;
        }
        else if (!isvalid.checkValidation(txtaddress.Text)||isvalid.isAlldigit(txtaddress.Text)) {
            ltrmsg.Text = "Enter Valid address.";
            txtfname.Focus();
            Valid = false;
        }
        else if (!isvalid.checkValidation(txtcontact.Text)||!isvalid.isAlldigit(txtcontact.Text)||txtcontact.Text.Trim().Length<7||txtcontact.Text.Trim().Length>10) {
            ltrmsg.Text = "Enter Valid Telephone Number";
            txtcontact.Focus();
            Valid = false;
        }

        else if (!isvalid.checkValidation(txtorderdate.Text)) {
            ltrmsg.Text = "This Field is required";
            txtorderdate.Focus();
            Valid = false;
        }
        return Valid;
    }
    protected void btnplaceorder_Click(object sender, EventArgs e)
    {
        if (!CheckValidation())
            return;
        MultiView1.ActiveViewIndex = 7;
        LblFname.Text = txtfname.Text;
        lbllastname.Text = txtlname.Text;
        lbladdress.Text = txtaddress.Text;
        lblcontact.Text = txtcontact.Text;
        lblorderdate.Text = txtorderdate.Text;

        lblparticulars.Text = "";
        lblunitprice.Text = "";
        lblqty.Text = "";
        lbltotal.Text = "";
        int s = 0;
        int t = 0;
        int u = 0;
        int v = 0;
        int x = 0;
        int y = 0;
        int z = 0;

        foreach (ListItem list in cblbreakfast.Items)
            {
            if (list.Selected)
                {
                lblparticulars.Text += list.Text+"<br/>";
                lblunitprice.Text += list.Value + "<br/>";
                lblqty.Text += ddlbreakfast.SelectedItem.ToString() + "<br/>";
                lbltotal.Text += (Convert.ToInt16(ddlbreakfast.SelectedItem.Value) * Convert.ToInt16(list.Value)).ToString() + "</br>";
                s +=  (Convert.ToInt16(ddlbreakfast.SelectedItem.Value) * Convert.ToInt16(list.Value));
                
            }
          
        }

        foreach (ListItem lst in cblappetizer.Items) {
            if (lst.Selected) {
                
                lblparticulars.Text += lst.Text + "<br/>";
                lblunitprice.Text += lst.Value + "<br/>";
                lblqty.Text += ddlappetizer.SelectedItem.ToString() + "<br/>";
                lbltotal.Text += (Convert.ToInt16(ddlappetizer.SelectedItem.Value) * Convert.ToInt16(lst.Value)).ToString() + "</br>";
                t += (Convert.ToInt16(ddlappetizer.SelectedItem.Value) * Convert.ToInt16(lst.Value));
            }         
        }
        foreach (ListItem lst in cblmaindish.Items)
        {
            if (lst.Selected)
            {
                lblparticulars.Text += lst.Text + "<br/>";
                lblunitprice.Text += lst.Value + "<br/>";
                lblqty.Text += ddlmaindish.SelectedItem.ToString() + "<br/>";
                lbltotal.Text += (Convert.ToInt16(ddlmaindish.SelectedItem.Value) * Convert.ToInt16(lst.Value)).ToString() + "</br>";
               u += (Convert.ToInt16(ddlmaindish.SelectedItem.Value) * Convert.ToInt16(lst.Value));
            }          
        }
        foreach (ListItem lst in cblkhajaset.Items)
        {
            if (lst.Selected)
            {

                lblparticulars.Text += lst.Text + "<br/>";
                lblunitprice.Text += lst.Value + "<br/>";
                lblqty.Text += ddlkhajasets.SelectedItem.ToString() + "<br/>";
                lbltotal.Text += (Convert.ToInt16(ddlkhajasets.SelectedItem.Value) * Convert.ToInt16(lst.Value)).ToString() + "</br>";
               v +=  (Convert.ToInt16(ddlkhajasets.SelectedItem.Value) * Convert.ToInt16(lst.Value));
            }
                  }
        foreach (ListItem lst in cblsalads.Items)
        {
            if (lst.Selected)
            {
                lblparticulars.Text += lst.Text + "<br/>";
                lblunitprice.Text += lst.Value + "<br/>";
                lblqty.Text += ddlsalads.SelectedItem.ToString() + "<br/>";
                lbltotal.Text += (Convert.ToInt16(ddlsalads.SelectedItem.Value) * Convert.ToInt16(lst.Value)).ToString() + "</br>";
               x +=  (Convert.ToInt16(ddlsalads.SelectedItem.Value) * Convert.ToInt16(lst.Value));
            }
            
        }
        foreach (ListItem lst in cblbeverage.Items)
        {
            if (lst.Selected)
            {

                lblparticulars.Text += lst.Text + "<br/>";
                lblunitprice.Text += lst.Value + "<br/>";
                lblqty.Text += Ddlbeverage.SelectedItem.ToString() + "<br/>";
                lbltotal.Text += (Convert.ToInt16(Ddlbeverage.SelectedItem.Value) * Convert.ToInt16(lst.Value)).ToString() + "</br>";
               y +=  (Convert.ToInt16(Ddlbeverage.SelectedItem.Value) * Convert.ToInt16(lst.Value));
            }
           
        }
        foreach (ListItem lst in cbldesserts.Items)
        {
            if (lst.Selected)
            {

                lblparticulars.Text += lst.Text + "<br/>";
                lblunitprice.Text += lst.Value + "<br/>";
                lblqty.Text += Ddldesert.SelectedItem.ToString() + "<br/>";
                lbltotal.Text += (Convert.ToInt16(Ddldesert.SelectedItem.Value) * Convert.ToInt16(lst.Value)).ToString() + "</br>";
                z += (Convert.ToInt16(Ddldesert.SelectedItem.Value) * Convert.ToInt16(lst.Value));
               
            }
          
        }
        lblgrandtotal.Text = (s+t+u+v+x+y+z).ToString();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        int a,b,c,d,f,g,h, s,t,u,v,x,y,z;
        try {
            foreach (ListItem lst in cblbreakfast.Items)
            {
                if (lst.Selected)
                {
                    MenuClass mc = new MenuClass();
                    mc.Foodname = lst.Text;
                    using (DataTable dt=mc.checkFood()) {
                        if (dt.Rows.Count > 0) {
                            x = Convert.ToInt32(dt.Rows[0]["FOODID"].ToString());
                            using (DataTable dtt = mc.getmenuid(x))
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    a = Convert.ToInt16(dtt.Rows[0]["MENUID"].ToString());
                                    OrderClass oc = new OrderClass();
                                    oc.getorder(txtfname.Text, txtlname.Text, txtaddress.Text, a,Convert.ToInt32(ddlbreakfast.SelectedItem.Value),(Convert.ToInt32(lst.Value)*Convert.ToInt32(ddlbreakfast.SelectedItem.Value)) ,txtorderdate.Text,Convert.ToInt32(txtcontact.Text));
                                    Ltrmsgdisp.Text = "Your order has been placed successfully.";
                                }
                            }
                           
                        }
                        else {
                            Ltrmsgdisp.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }                        
                }
            }
            foreach (ListItem lst in cblappetizer.Items)
            {
                if (lst.Selected)
                {
                    MenuClass mc = new MenuClass();
                    mc.Foodname = lst.Text;
                    using (DataTable dt = mc.checkFood())
                    {
                        if (dt.Rows.Count > 0)
                        {
                            y = Convert.ToInt32(dt.Rows[0]["FOODID"].ToString());
                            using (DataTable dtt = mc.getmenuid(y))
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    b = Convert.ToInt16(dtt.Rows[0]["MENUID"].ToString());
                                    OrderClass oc = new OrderClass();
                                    oc.getorder(txtfname.Text, txtlname.Text, txtaddress.Text, b, Convert.ToInt32(ddlappetizer.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(ddlappetizer.SelectedItem.Value)), txtorderdate.Text, Convert.ToInt32(txtcontact.Text));
                                    Ltrmsgdisp.Text = "Your order has been placed successfully.";
                                }
                            }
                           
                        }
                        else
                        {
                            Ltrmsgdisp.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
            foreach (ListItem lst in cblmaindish.Items)
            {
                if (lst.Selected)
                {
                    MenuClass mc = new MenuClass();
                    mc.Foodname = lst.Text;
                    using (DataTable dt = mc.checkFood())
                    {
                        if (dt.Rows.Count > 0)
                        {
                            z = Convert.ToInt32(dt.Rows[0]["FOODID"].ToString());
                            using (DataTable dtt = mc.getmenuid(z))
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    c = Convert.ToInt16(dtt.Rows[0]["MENUID"].ToString());
                                    OrderClass oc = new OrderClass();
                                    oc.getorder(txtfname.Text, txtlname.Text, txtaddress.Text, c, Convert.ToInt32(ddlmaindish.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(ddlmaindish.SelectedItem.Value)), txtorderdate.Text, Convert.ToInt32(txtcontact.Text));
                                    Ltrmsgdisp.Text = "Your order has been placed successfully.";
                                }
                            }
                            
                        }
                        else
                        {
                            Ltrmsgdisp.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
            foreach (ListItem lst in cblkhajaset.Items)
            {
                if (lst.Selected)
                {
                    MenuClass mc = new MenuClass();
                    mc.Foodname = lst.Text;
                    using (DataTable dt = mc.checkFood())
                    {
                        if (dt.Rows.Count > 0)
                        {
                            s = Convert.ToInt32(dt.Rows[0]["FOODID"].ToString());
                            using (DataTable dtt = mc.getmenuid(s))
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    d = Convert.ToInt16(dtt.Rows[0]["MENUID"].ToString());
                                    OrderClass oc = new OrderClass();
                                    oc.getorder(txtfname.Text, txtlname.Text, txtaddress.Text, d, Convert.ToInt32(ddlkhajasets.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(ddlkhajasets.SelectedItem.Value)), txtorderdate.Text, Convert.ToInt32(txtcontact.Text));
                                    Ltrmsgdisp.Text = "Your order has been placed successfully.";
                                }
                            }
                            
                        }
                        else
                        {
                            Ltrmsgdisp.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
            foreach (ListItem lst in cblsalads.Items)
            {
                if (lst.Selected)
                {
                    MenuClass mc = new MenuClass();
                    mc.Foodname = lst.Text;
                    using (DataTable dt = mc.checkFood())
                    {
                        if (dt.Rows.Count > 0)
                        {
                            t = Convert.ToInt32(dt.Rows[0]["FOODID"].ToString());
                            using (DataTable dtt = mc.getmenuid(t))
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    h = Convert.ToInt16(dtt.Rows[0]["MENUID"].ToString());
                                    OrderClass oc = new OrderClass();
                                    oc.getorder(txtfname.Text, txtlname.Text, txtaddress.Text, h, Convert.ToInt32(ddlsalads.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(ddlsalads.SelectedItem.Value)), txtorderdate.Text, Convert.ToInt32(txtcontact.Text));
                                    Ltrmsgdisp.Text = "Your order has been placed successfully.";
                                }
                            }
                           
                        }
                        else
                        {
                            Ltrmsgdisp.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
            foreach (ListItem lst in cblbeverage.Items)
            {
                if (lst.Selected)
                {
                    MenuClass mc = new MenuClass();
                    mc.Foodname = lst.Text;
                    using (DataTable dt = mc.checkFood())
                    {
                        if (dt.Rows.Count > 0)
                        {
                            u= Convert.ToInt32(dt.Rows[0]["FOODID"].ToString());
                            using (DataTable dtt = mc.getmenuid(u))
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    f = Convert.ToInt16(dtt.Rows[0]["MENUID"].ToString());
                                    OrderClass oc = new OrderClass();
                                    oc.getorder(txtfname.Text, txtlname.Text, txtaddress.Text, f, Convert.ToInt32(Ddlbeverage.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(Ddlbeverage.SelectedItem.Value)), txtorderdate.Text, Convert.ToInt32(txtcontact.Text));
                                    Ltrmsgdisp.Text = "Your order has been placed successfully.";
                                }
                            }
                           
                        }
                        else
                        {
                            Ltrmsgdisp.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
            foreach (ListItem lst in cbldesserts.Items)
            {
                if (lst.Selected)
                {
                    MenuClass mc = new MenuClass();
                    mc.Foodname = lst.Text;
                    using (DataTable dt = mc.checkFood())
                    {
                        if (dt.Rows.Count > 0)
                        {
                            v= Convert.ToInt32(dt.Rows[0]["FoodID"].ToString());
                            using (DataTable dtt=mc.getmenuid(v)) {
                                if (dtt.Rows.Count>0) {
                                    g = Convert.ToInt16(dtt.Rows[0]["MENUID"].ToString());
                                    OrderClass oc = new OrderClass();
                                    oc.getorder(txtfname.Text, txtlname.Text, txtaddress.Text, g, Convert.ToInt32(Ddldesert.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(Ddldesert.SelectedItem.Value)), txtorderdate.Text, Convert.ToInt32(txtcontact.Text));
                                    Ltrmsgdisp.Text = "Your order has been placed successfully.";
                                }
                            }
                                
                        }
                        else
                        {
                            Ltrmsgdisp.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
        }
        catch (Exception Ex) {
            Ltrmsgdisp.Text = Ex.Message;
        }
    }

    protected void gotodessertsection_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 6;
    }

    
}