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
public partial class Billing : System.Web.UI.Page
{
    GlobalConnection gc = new GlobalConnection();
    BillingClass bc = new BillingClass();
    int totalamount = 0;
    string ordertakenby;
    int i;
    int orderid;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["username"] != null)
        //{
        //   // ltrmsg.Text = "Welcome" + Session["username"].ToString() + "To Admin Panel";
        //}
        //else
        //{
        //    Response.Redirect("Home.aspx");
        //}
        lbldate.Text = System.DateTime.Now.ToString();
    }

   

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        
        PdfPTable pdftable = new PdfPTable(GridView1.HeaderRow.Cells.Count);
       
            foreach (TableCell headercell in GridView1.HeaderRow.Cells) {
            Font font = new Font();
            font.Color = new BaseColor(GridView1.HeaderStyle.ForeColor);
            PdfPCell pdfcell = new PdfPCell(new Phrase(headercell.Text,font));
            pdfcell.BackgroundColor = new BaseColor(GridView1.HeaderStyle.BackColor);
                pdftable.AddCell(pdfcell); 
            }
        
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            foreach (TableCell cell in gvrow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(GridView1.RowStyle.ForeColor);
                PdfPCell pdfcell = new PdfPCell(new Phrase(cell.Text,font));
                pdfcell.BackgroundColor = new BaseColor(GridView1.RowStyle.BackColor);
                pdftable.AddCell(pdfcell);
            }
        }
      
            foreach (TableCell footercell in GridView1.FooterRow.Cells)
            {
            Font font = new Font();
            font.Color = new BaseColor(GridView1.FooterStyle.ForeColor);
            PdfPCell pdfcell = new PdfPCell(new Phrase(footercell.Text,font));
            pdfcell.BackgroundColor = new BaseColor(GridView1.FooterStyle.BackColor);
            pdftable.AddCell(pdfcell);
            }
        
        Document pdfdoc = new Document(PageSize.A4,10f,10f,10f,10f);
        PdfWriter.GetInstance(pdfdoc,Response.OutputStream);
        pdfdoc.Open();
        pdfdoc.AddTitle("Restaurant Management System");
        pdfdoc.AddHeader("Restaurant Management Sytem", "Restaurant Management System");
        pdfdoc.AddKeywords("Restaurant Management System");
        pdfdoc.Add(pdftable);
        pdfdoc.Close();
        Response.ContentType = "application/pdf";
        Response.AppendHeader("content-disposition","attachment;filename=Restaurantbilling.pdf");
        Response.Write(pdfdoc);
        Response.Flush();
        
        bc.addfromstafforder(Convert.ToInt32(ddltable.SelectedItem.Value));
        using (DataTable dt = bc.getstafforderid(Convert.ToInt16(ddltable.SelectedItem.Value), System.DateTime.Now.Date)) {
            if (dt.Rows.Count>0) {
                orderid = Convert.ToInt32(dt.Rows[0]["orderid"].ToString());
            }
            else {
                ltrMessage.Text = "Record Not found";
            }
        }
        bc.addbill(orderid);
        bc.deletefromstafforder(Convert.ToInt32(ddltable.SelectedItem.Value));
        Response.End();
        ltrMessage.Text = "Billing successfully made";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BillingClass bill = new BillingClass();
        bill.Tableid = Convert.ToInt16(ddltable.SelectedItem.Value);
      
        try {
            DataTable dt = bill.gettheorder();
            if (dt.Rows.Count>0) {
                getbillid();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        catch (Exception) {
            throw;
        }
    }
    private void getbillid() {
        SqlCommand cmd = new SqlCommand("Select count(billid)from billing",gc.cn);
        i = Convert.ToInt32(cmd.ExecuteScalar());
        i++;

        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.Header) {
            e.Row.Cells[0].Visible = true;
        }
       
        if (e.Row.RowType == DataControlRowType.DataRow) {
            totalamount += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "totalamount"));
            ordertakenby= DataBinder.Eval(e.Row.DataItem, "firstname").ToString();
            e.Row.Cells[0].Visible = true;
        }
        else if (e.Row.RowType==DataControlRowType.Footer) {
            e.Row.Cells[4].Text = "Grand Total";
            e.Row.Font.Bold = true;
            e.Row.Cells[5].Text = totalamount.ToString();
            e.Row.Font.Bold = true;
            e.Row.Cells[0].Text = "Bill ID :";
            e.Row.Cells[1].Text = i.ToString();
            e.Row.Cells[2].Text = "Order Taken By :";
            e.Row.Cells[3].Text = ordertakenby;
        }
    }
}