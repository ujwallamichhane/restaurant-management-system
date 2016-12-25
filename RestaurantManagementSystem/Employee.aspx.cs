using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Employee : System.Web.UI.Page
{
    GlobalConnection gc = new GlobalConnection();
    ValidataionClass isvalid = new ValidataionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            ltrmsg.Text = "Welcome  " + Session["username"].ToString() + "  To Admin Panel";
            Calendar.Visible = false;
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
    private bool Checkvalidation()
    {
        //int age = Convert.ToInt32(txtAge.Text);
        bool Valid = true;
        if (!isvalid.checkValidation(txtfname.Text))
        {
            ltrmsg.Text = "Give proper first name";
            txtfname.Focus();
            Valid = false;
        }
        else
            if (!isvalid.checkValidation(txtmidname.Text))
        {
            ltrmsg.Text = "Give proper middle name";
            txtmidname.Focus();
            Valid = false;
        }

        else
                if (!isvalid.checkValidation(txtlname.Text))
        {
            ltrmsg.Text = "Give proper last name";
            txtlname.Focus();
            Valid = false;
        }
        else
                    if (rblgender.Items[0].Selected == false && rblgender.Items[1].Selected == false)
        {
            ltrmsg.Text = "Select Gender";
            Valid = false;
        }

        else
                        if (!isvalid.checkValidation(txtdate.Text))
        {
            ltrmsg.Text = "select a date";
            txtdate.Focus();
            Valid = false;
        }
        else
                            if (!isvalid.checkValidation(txtcontact.Text) || !isvalid.isAlldigit(txtcontact.Text) || txtcontact.Text.Trim().Length < 10 || txtcontact.Text.Trim().Length > 10)
        {
            ltrmsg.Text = "Give proper age";
            txtcontact.Focus();
            Valid = false;
        }
        else
                                if (!isvalid.checkValidation(txtfathername.Text) || isvalid.isAlldigit(txtfathername.Text))
        {
            ltrmsg.Text = "Enter Proper  Father's Name";
            txtfathername.Focus();
            Valid = false;
        }
        else
                                    if (!isvalid.checkValidation(txtmothername.Text) || isvalid.isAlldigit(txtmothername.Text))
        {
            ltrmsg.Text = "Enter Proper  Mother's Name";
            txtmothername.Focus();
            Valid = false;
        }
        else
                                        if (!isvalid.checkValidation(txtgrandname.Text) || isvalid.isAlldigit(txtgrandname.Text))
        {
            ltrmsg.Text = "Enter Proper  GrandFather's Name";
            txtgrandname.Focus();
            Valid = false;
        }
        else
                                            if (!isvalid.checkValidation(txtaddress.Text) || isvalid.isAlldigit(txtaddress.Text))
        {
            ltrmsg.Text = "Enter Proper Address Field ";
            txtaddress.Focus();
            Valid = false;
        }
        else
                                                if (!isvalid.checkValidation(txtexperience.Text) || !isvalid.isAlldigit(txtexperience.Text) || txtcontact.Text.Trim().Length < 1 || txtcontact.Text.Trim().Length > 2)
        {
            ltrmsg.Text = "Contact number length must be between 7 to 10.";
            txtexperience.Focus();
            Valid = false;
        }
        else
            if (!isvalid.checkValidation(txttraining.Text) || isvalid.isAlldigit(txttraining.Text)) {
            ltrmsg.Text = "Enter Proper Training.";
            txttraining.Focus();
            Valid = false;
        }
        else
        if (!isvalid.checkValidation(txtpost.Text) || isvalid.isAlldigit(txtpost.Text)) {
            ltrmsg.Text = "Enter Proper Training.";
            txtpost.Focus();
            Valid = false;

        }
        else
            if (!isvalid.checkValidation(txtsalary.Text) || !isvalid.isAlldigit(txtsalary.Text) || txtsalary.Text.Trim().Length < 1 || txtsalary.Text.Trim().Length > 2) {
            ltrmsg.Text = "Enter Proper Training.";
            txtsalary.Focus();
            Valid = false;
        }
        else
            if (!isvalid.checkValidation(txtusername.Text) || isvalid.isAlldigit(txtusername.Text)) {
            ltrmsg.Text = "Enter Proper Training.";
            txtusername.Focus();
            Valid = false;
        }
        else
            if (!isvalid.checkValidation(txtpassword.Text)) {
            ltrmsg.Text = "Enter Proper Training.";
            txtpassword.Focus();
            Valid = false;
        }

        return Valid;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        Staff sc = new Staff();
        UserClass uc = new UserClass();
        sc.Name = txtfname.Text;
        sc.Post = txtpost.Text;
        int x;
        try
        {
            if (!Checkvalidation())
                return;
            sc.addstaff(txtfname.Text, txtmidname.Text, txtlname.Text, rblgender.SelectedItem.ToString(), txtdate.Text, Convert.ToInt32(txtcontact.Text), txtfathername.Text, txtmothername.Text, txtgrandname.Text, txtaddress.Text, Convert.ToInt16(txtexperience.Text), txttraining.Text, txtpost.Text, Convert.ToInt32(txtsalary.Text), fuphoto.FileName);
            fuphoto.SaveAs(Server.MapPath("~/StaffImages/" + fuphoto.FileName));
            using (DataTable dt = sc.getstaff())
            {
                if (dt.Rows.Count > 0)
                {
                    x = Convert.ToInt32(dt.Rows[0]["STAFFID"].ToString());
                    uc.addusers(txtusername.Text, txtpassword.Text, Convert.ToInt32(ddlrole.SelectedItem.Value), Convert.ToInt32(x));
                }

                else
                {
                    ltrmsg.Text = "Staff is not created as the user.";
                }
            }
            ltrmsg.Text = "Staff Record Maintained";
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        Staff sc = new Staff();
        UserClass uc = new UserClass();
        try
        {
            if(!Checkvalidation())
            sc.updatestaff(Convert.ToInt16(txtid.Text), txtfname.Text, txtmidname.Text, txtlname.Text, rblgender.SelectedItem.ToString(), txtdate.Text, Convert.ToInt32(txtcontact.Text), txtfathername.Text, txtmothername.Text, txtgrandname.Text, txtaddress.Text, Convert.ToInt16(txtexperience.Text), txttraining.Text, txtpost.Text, Convert.ToInt16(txtsalary.Text), fuphoto.FileName);
            fuphoto.SaveAs(Server.MapPath("~/StaffImages/" + fuphoto.FileName));
            uc.saveusers(txtusername.Text, txtpassword.Text, Convert.ToInt32(ddlrole.SelectedItem.Value));
            ltrmsg.Text = "Record Updated successfully";
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        Staff sc = new Staff();       
        sc.deletestaff(Convert.ToInt16(txtid.Text));
        ltrmsg.Text = "Staff record deleted successfully";
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        Staff sc = new Staff();
        UserClass uc = new UserClass();
        sc.ID = Convert.ToInt16(txtid.Text);
        uc.id = Convert.ToInt16(txtid.Text);
        int x;
        using (DataTable dt = sc.searchstaff()) {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    txtfname.Text = dt.Rows[0]["firstname"].ToString();
                    txtmidname.Text = dt.Rows[0]["midname"].ToString();
                    txtlname.Text = dt.Rows[0]["lastname"].ToString();
                    rblgender.Text = dt.Rows[0]["gender"].ToString();
                    txtdate.Text = dt.Rows[0]["dob"].ToString();
                    txtcontact.Text = dt.Rows[0]["contactnumber"].ToString();
                    txtfathername.Text = dt.Rows[0]["fathername"].ToString();
                    txtmothername.Text = dt.Rows[0]["mothername"].ToString();
                    txtgrandname.Text = dt.Rows[0]["grandfathername"].ToString();
                    txtaddress.Text = dt.Rows[0]["address"].ToString();
                    txtexperience.Text = dt.Rows[0]["experience"].ToString();
                    txttraining.Text = dt.Rows[0]["trainings"].ToString();
                    txtpost.Text = dt.Rows[0]["post"].ToString();
                    txtsalary.Text = dt.Rows[0]["salary"].ToString();
                    ltrstaffimage.Text = "<img Width=\"50\" Height=\"50\" runat=\"Server\" src=\"StaffImages/" + row["photo"].ToString() + "\" alt=" + row["firstname"].ToString() + " />";
                    using (DataTable dtt = uc.searchuserfromstaffid())
                    {
                        if (dtt.Rows.Count > 0)
                        {
                            txtusername.Text = dtt.Rows[0]["username"].ToString();
                            txtpassword.Text = dtt.Rows[0]["password"].ToString();
                            x = Convert.ToInt32(dtt.Rows[0]["RID"].ToString());
                            using (DataTable d = uc.checkrole(x))
                            {
                                if (d.Rows.Count > 0)
                                {
                                    ddlrole.Text = d.Rows[0]["rolename"].ToString();
                                }
                                else
                                {
                                    ltrmsg.Text = "No Role Assigned to the user.";
                                }
                            }
                        }
                        else
                        {
                            ltrmsg.Text = dt.Rows[0]["firstname"].ToString() + "  "+ "doesnot have username and password.";
                        }
                    }

                }
            }

            else
            {
                ltrmsg.Text = "Record Not Found.Please Enter Correct StaffID .";
            }            
        }
    }

    protected void Calendar_SelectionChanged(object sender, EventArgs e)
    {
        txtdate.Text = Calendar.SelectedDate.Year + "-" + Calendar.SelectedDate.Month + "-" + Calendar.SelectedDate.Day.ToString();
        Calendar.Visible = false;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar.Visible) {
            Calendar.Visible = false;
        }
        else {
            Calendar.Visible = true;
        }
    }

    protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
    {
        //if (e.Day.IsOtherMonth)
        //{
        //    e.Day.IsSelectable = false;
        //    e.Cell.BackColor = System.Drawing.Color.Red;
        //}
        
    }

    
}