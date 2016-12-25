using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

public partial class _Default : System.Web.UI.Page
{
    GlobalConnection gc = new GlobalConnection();
    BillingClass bc = new BillingClass();
    int orderid;
    int totalamount;
    string orderplacedby;
    int i;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void getbillid()
    {
        SqlCommand cmd = new SqlCommand("Select count(billid)from billing", gc.cn);
        i = Convert.ToInt32(cmd.ExecuteScalar());
        i++;


    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = true;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            totalamount += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "totalamount"));
            orderplacedby = DataBinder.Eval(e.Row.DataItem, "Cust_FName").ToString()+" "+DataBinder.Eval(e.Row.DataItem,"Cust_LName").ToString();
            e.Row.Cells[0].Visible = true;
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[4].Text = "Grand Total";
            e.Row.Font.Bold = true;
            e.Row.Cells[5].Text = totalamount.ToString();
            e.Row.Font.Bold = true;
            e.Row.Cells[0].Text = "Bill ID :";
            e.Row.Cells[1].Text = i.ToString();
            e.Row.Cells[2].Text = "Order Placed By :";
            e.Row.Cells[3].Text = orderplacedby;
        }
    }

    protected void btngetbill_Click(object sender, EventArgs e)
    {
        BillingClass bill = new BillingClass();
        bill.Customername = ddlcustomername.SelectedItem.Text;
        bill.Ordereddate = Convert.ToDateTime(txtordereddate.Text);
        bill.Phone = Convert.ToInt64(txtphone.Text.Trim());
        getbillid();
        DataTable dt = bill.getcustomerorder();
        if (dt.Rows.Count>0) {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    protected void btnprintbill_Click(object sender, EventArgs e)
    {

        PdfPTable pdftable = new PdfPTable(GridView1.HeaderRow.Cells.Count);

        foreach (TableCell headercell in GridView1.HeaderRow.Cells)
        {
            Font font = new Font();
            font.Color = new BaseColor(GridView1.HeaderStyle.ForeColor);
            PdfPCell pdfcell = new PdfPCell(new Phrase(headercell.Text, font));
            pdfcell.BackgroundColor = new BaseColor(GridView1.HeaderStyle.BackColor);
            pdftable.AddCell(pdfcell);
        }

        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            foreach (TableCell cell in gvrow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(GridView1.RowStyle.ForeColor);
                PdfPCell pdfcell = new PdfPCell(new Phrase(cell.Text, font));
                pdfcell.BackgroundColor = new BaseColor(GridView1.RowStyle.BackColor);
                pdftable.AddCell(pdfcell);
            }
        }

        foreach (TableCell footercell in GridView1.FooterRow.Cells)
        {
            Font font = new Font();
            font.Color = new BaseColor(GridView1.FooterStyle.ForeColor);
            PdfPCell pdfcell = new PdfPCell(new Phrase(footercell.Text, font));
            pdfcell.BackgroundColor = new BaseColor(GridView1.FooterStyle.BackColor);
            pdftable.AddCell(pdfcell);
        }

        Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
        PdfWriter.GetInstance(pdfdoc, Response.OutputStream);
        pdfdoc.Open();
        pdfdoc.AddTitle("Restaurant Management System");
        pdfdoc.AddHeader("Restaurant Management Sytem", "Restaurant Management System");
        pdfdoc.AddKeywords("Restaurant Management System");
        pdfdoc.Add(pdftable);
        pdfdoc.Close();
        Response.ContentType = "application/pdf";
        Response.AppendHeader("content-disposition", "attachment;filename=Restaurantbilling.pdf");
        Response.Write(pdfdoc);
        Response.Flush();
        
        bc.addfromcustomerorder(ddlcustomername.SelectedItem.Text,System.DateTime.Now.Date,Convert.ToInt64(txtphone.Text));
        using (DataTable dt = bc.getcustorderid(ddlcustomername.SelectedItem.Text, Convert.ToDateTime(txtordereddate.Text), Convert.ToInt64(txtphone.Text)))
        {
            if (dt.Rows.Count > 0)
            {
                orderid = Convert.ToInt32(dt.Rows[0]["orderid"].ToString());
            }
            else
            {
                ltrmsg.Text = "Record Not found";
            }
        }
        bc.addbill(orderid);
        bc.deletefromcustomerorder(ddlcustomername.SelectedItem.Text,Convert.ToDateTime(txtordereddate.Text),Convert.ToInt64(txtphone.Text));
        ltrmsg.Text = "Billing successfully made";
        Response.End();
    }

    protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
    {

    }

    protected void Calendar_SelectionChanged(object sender, EventArgs e)
    {
        txtordereddate.Text = Calendar.SelectedDate.Year + "-" + Calendar.SelectedDate.Month + "-" + Calendar.SelectedDate.Day.ToString();
        Calendar.Visible = false;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar.Visible)
        {
            Calendar.Visible = false;
        }
        else
        {
            Calendar.Visible = true;
        }
    }
}