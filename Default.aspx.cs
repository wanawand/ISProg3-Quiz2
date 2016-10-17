using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class Admin_Products_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetProducts();
        }
    }

    void GetProducts()
    {
        using (SqlConnection con = new SqlConnection(Util.GetConnection()))
        {
            con.Open();
            string SQL = @"SELECT Products.ProductID, Products.Name,Products.Code, Categories.Category, Products.Description, 
            Products.Image, Products.Price, Products.IsFeatured,Products.Status, Products.DateAdded, Products.DateModified FROM Products  " +
           "INNER JOIN Categories  ON Products.CatID = Categories.CatID";
            using (SqlCommand cmd = new SqlCommand(SQL, con))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Products");

                    lvProducts.DataSource = ds;
                    lvProducts.DataBind();
                }
            }
        }
    }

    void GetProducts(string keyword)
    {
        using (SqlConnection con = new SqlConnection(Util.GetConnection()))
        {
            con.Open();
            string SQL = @"SELECT ProductID, Name, Code,CatID, Description, Image, Price, IsFeatured, CriticalLevel, Maximum, Status, DateAdded, DateModified FROM Products WHERE ProductID LIKE @keyword OR Name LIKE @keyword OR
            CatID Like @keyword OR Description Like @keyword OR Image Like @keyword OR Price Like @keyword OR IsFeaturedLike @keyword OR Status Like @keyword OR CriticalLevel Like @keyword OR Maximum Like @keyword";

            using (SqlCommand cmd = new SqlCommand(SQL, con))
            {
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Products");

                    lvProducts.DataSource = ds;
                    lvProducts.DataBind();
                }
            }
        }
        //con.Open();
        //using (SqlConnection con = new SqlConnection(Util.GetConnection()))
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "SELECT Products.ProductID,Products.Name,Categories.Category, Products.Code, Products.Description, Products.Image, Products.Price, Products.IsFeatured, Products.CriticalLevel, Products.Maximum, Products.Status, Products.DateAdded, Products.DateModified FROM Products" +
        //        "INNER JOIN Categories ON Products.CatID = Categories.CatID" + "WHERE Products.ProductID LIKE '%" + keyword + "%' OR Products.Name LIKE '%" + keyword + "%' OR Categories.Category LIKE '%" + keyword + "%' OR Products.Code LIKE '%" + keyword + "%' OR" +
        //        "Products.Description LIKE '%" + keyword + "%' OR Products.Image LIKE '%" + keyword + "%' OR Products.Price LIKE '%" + keyword + "%' OR Products.IsFeatured LIKE '%" + keyword + "%' OR Products.CriticaLevel  LIKE '%" + keyword + "%' OR" +
        //        "Products.Maximum LIKE '%" + keyword + "%' OR Products.Status LIKE '%" + keyword + "%' OR Products.DateAdded LIKE '%" + keyword + "%' OR Products.DateModified LIKE '%" + keyword + "%'";
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds, "Products");
        //    lvProducts.DataSource = ds;
        //    lvProducts.DataBind();
        //    con.Close();
        //}
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtKeyword.Text == "")
        {
            GetProducts();
        }
        else
        {
            GetProducts(txtKeyword.Text);
        }
    }
    protected void lvProducts_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        dpProducts.SetPageProperties(e.StartRowIndex,
            e.MaximumRows, false);
        if (txtKeyword.Text == "")
        {
            GetProducts();
        }
        else
        {
            GetProducts(txtKeyword.Text);
        }
    }
}