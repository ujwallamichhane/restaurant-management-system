using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class StaffOrders : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["username"] != null)
        //{
        //    ltrmsg.Text = "Welcome" + Session["username"].ToString() + "To Admin Panel";
        //}
        //else
        //{
        //    Response.Redirect("Home.aspx");
        //}
        DateTime d = System.DateTime.Now;
        Lbldate.Text = d.ToShortDateString();
    }

    protected void btnorder_Click(object sender, EventArgs e)
    {
        foreach(ListItem lst in rblqty.Items)
        if (lst.Selected==false)
        {
            ltrmsg.Text = "Please Select the Quantity to Order.";
            return;
        }
           
        int a, b, c, d, f, g, h, s, t, u, v, x, y, z;
        try
        {
            foreach (ListItem lst in rblbreakfast.Items)
            {
                if (lst.Selected)
                {
                    MenuClass mc = new MenuClass();
                    mc.Foodname = lst.Text;
                    UserClass uc = new UserClass();
                    using (DataTable dt = mc.checkFood())
                    {
                        if (dt.Rows.Count > 0)
                        {
                            x = Convert.ToInt32(dt.Rows[0]["FOODID"].ToString());
                            using (DataTable dtt = mc.getmenuid(x))
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    a = Convert.ToInt16(dtt.Rows[0]["MENUID"].ToString());
                                    OrderClass oc = new OrderClass();
                                    oc.getStafforder( a, Convert.ToInt32(rblqty.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(rblqty.SelectedItem.Value)), Lbldate.Text,Convert.ToInt16(ddltablename.SelectedItem.Value),GlobalConnection.staffid);
                                    ltrmsg.Text = "Your order has been placed successfully.";
                                }
                            }

                        }
                        else
                        {
                            ltrmsg.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
            foreach (ListItem lst in rblappetizer.Items)
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
                                    oc.getStafforder(b, Convert.ToInt32(rblqty.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(rblqty.SelectedItem.Value)), Lbldate.Text, Convert.ToInt16(ddltablename.SelectedItem.Value), GlobalConnection.staffid);
                                    ltrmsg.Text = "Your order has been placed successfully.";
                                }
                            }

                        }
                        else
                        {
                            ltrmsg.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
            foreach (ListItem lst in rblmaindish.Items)
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
                                    oc.getStafforder(c, Convert.ToInt32(rblqty.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(rblqty.SelectedItem.Value)), Lbldate.Text, Convert.ToInt16(ddltablename.SelectedItem.Value), GlobalConnection.staffid);
                                    ltrmsg.Text = "Your order has been placed successfully.";
                                }
                            }

                        }
                        else
                        {
                            ltrmsg.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
            foreach (ListItem lst in rblkhajaset.Items)
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
                                    oc.getStafforder(d, Convert.ToInt32(rblqty.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(rblqty.SelectedItem.Value)), Lbldate.Text, Convert.ToInt16(ddltablename.SelectedItem.Value), GlobalConnection.staffid);
                                    ltrmsg.Text = "Your order has been placed successfully.";
                                }
                            }

                        }
                        else
                        {
                            ltrmsg.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
            foreach (ListItem lst in rblsalads.Items)
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
                                    oc.getStafforder(h, Convert.ToInt32(rblqty.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(rblqty.SelectedItem.Value)), Lbldate.Text, Convert.ToInt16(ddltablename.SelectedItem.Value), GlobalConnection.staffid);
                                    ltrmsg.Text = "Your order has been placed successfully."; ;
                                }
                            }

                        }
                        else
                        {
                            ltrmsg.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
            foreach (ListItem lst in rblbeverage.Items)
            {
                if (lst.Selected)
                {
                    MenuClass mc = new MenuClass();
                    mc.Foodname = lst.Text;
                    using (DataTable dt = mc.checkFood())
                    {
                        if (dt.Rows.Count > 0)
                        {
                            u = Convert.ToInt32(dt.Rows[0]["FOODID"].ToString());
                            using (DataTable dtt = mc.getmenuid(u))
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    f = Convert.ToInt16(dtt.Rows[0]["MENUID"].ToString());
                                    OrderClass oc = new OrderClass();
                                    oc.getStafforder(f, Convert.ToInt32(rblqty.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(rblqty.SelectedItem.Value)), Lbldate.Text, Convert.ToInt16(ddltablename.SelectedItem.Value), GlobalConnection.staffid);
                                    ltrmsg.Text = "Your order has been placed successfully.";
                                }
                            }

                        }
                        else
                        {
                            ltrmsg.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
            foreach (ListItem lst in rbldesserts.Items)
            {
                if (lst.Selected)
                {
                    MenuClass mc = new MenuClass();
                    mc.Foodname = lst.Text;
                    using (DataTable dt = mc.checkFood())
                    {
                        if (dt.Rows.Count > 0)
                        {
                            v = Convert.ToInt32(dt.Rows[0]["FoodID"].ToString());
                            using (DataTable dtt = mc.getmenuid(v))
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    g = Convert.ToInt16(dtt.Rows[0]["MENUID"].ToString());
                                    OrderClass oc = new OrderClass();
                                    oc.getStafforder(g, Convert.ToInt32(rblqty.SelectedItem.Value), (Convert.ToInt32(lst.Value) * Convert.ToInt32(rblqty.SelectedItem.Value)), Lbldate.Text, Convert.ToInt16(ddltablename.SelectedItem.Value), GlobalConnection.staffid);
                                    ltrmsg.Text = "Your order has been placed successfully.";
                                }
                            }

                        }
                        else
                        {
                            ltrmsg.Text = "No Menu Item corresponding to the foodname.please re consider your selection.";
                        }
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            ltrmsg.Text = Ex.Message;
        }
    }
}





  