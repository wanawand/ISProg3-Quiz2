using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class Admin_Products_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            int prodID = 0;
            bool validProd = int.TryParse(Request.QueryString["ID"].ToString(), out prodID);

            if (validProd)
            {
                if (!IsPostBack)
                {
                    GetCategories();
                    GetInfo(prodID);
                }
            }
            else
                Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    void GetCategories()
    {
        using (SqlConnection con = new SqlConnection(Util.GetConnection()))
        {
            con.Open();
            string SQL = @"SELECT CatID, Category FROM Categories";

            using (SqlCommand cmd = new SqlCommand(SQL, con))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    ddlCategory.DataSource = dr;
                    ddlCategory.DataTextField = "Category";
                    ddlCategory.DataValueField = "CatID";
                    ddlCategory.DataBind();

                    ddlCategory.Items.Insert(0, new ListItem("Select one...", ""));
                }
            }
        }
    }

    void GetInfo(int ID)
    {
        using (SqlConnection con = new SqlConnection(Util.GetConnection()))
        {
            con.Open();
            string Sql = "SELECT ProductID, Name, CatID, Code, Description, Image, Price, IsFeatured,Status,CriticalLevel, Maximum From Products Where ProductID=@ProductID";
            using (SqlCommand cmd = new SqlCommand(Sql, con))
            {
                cmd.Parameters.AddWithValue("@ProductID", ID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ltID.Text = dr["ProductID"].ToString();
                            txtName.Text = dr["Name"].ToString();
                            ddlCategory.SelectedValue = dr["CatID"].ToString();
                            txtCode.Text = dr["Code"].ToString();
                            txtDescription.Text = dr["Description"].ToString();
                            Session["image"] = dr["Image"].ToString();
                            txtPrice.Text = dr["Price"].ToString();
                            ddlFeatured.SelectedValue = dr["IsFeatured"].ToString();
                            ddlStatus.SelectedValue = dr["Status"].ToString();
                            txtcritical.Text = dr["CriticalLevel"].ToString();
                            txtMax.Text = dr["Maximum"].ToString();
                        }
                        UploadedImage.ImageUrl = "~/img/products/" + Session["image"].ToString();
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(Util.GetConnection()))
        {
            con.Open();
            string SQL = @"UPDATE Products SET Name=@Name, CatID=@CatID, Code=@Code, Description=@Description, Image=@Image, Price=@Price, IsFeatured=@IsFeatured,Status=@Status, CriticalLevel=@CriticalLevel, Maximum=@Maximum, DateModified=@DateModified WHERE ProductID=@ProductID";

            using (SqlCommand cmd = new SqlCommand(SQL, con))
            {
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@CatID", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Code", txtCode.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                if (Images.HasFile)
                {
                    string file = Path.GetExtension(Images.FileName);
                    string id = Guid.NewGuid().ToString();
                    cmd.Parameters.AddWithValue("@Image", id + file);
                    Images.SaveAs(Server.MapPath("~/img/products/" + id + file));
                }

                else
                {
                    cmd.Parameters.AddWithValue("@Image", Session["image"].ToString());
                }
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@IsFeatured", ddlFeatured.SelectedValue);
                cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);
                cmd.Parameters.AddWithValue("@Available", 0);
                cmd.Parameters.AddWithValue("@CriticalLevel", txtcritical.Text);
                cmd.Parameters.AddWithValue("@Maximum", txtMax.Text);
                cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                cmd.Parameters.AddWithValue("@ProductID", Request.QueryString["ID"].ToString());
                cmd.ExecuteNonQuery();

                Response.Redirect("Default.aspx");
            }
        }
    }
}