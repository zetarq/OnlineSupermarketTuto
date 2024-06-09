using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSupermarketTuto.Views.Admin
{
    public partial class ProductView : System.Web.UI.Page
    {
        blogsql.Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new blogsql.Models.Functions();
            if (!IsPostBack)
            {
                ShowProducts();
               
            }

        }
        private void ShowProducts()
        {
            string Query = "Select * from ProductTb1";
            ProductVie.DataSource = Con.GetData(Query);
            ProductVie.DataBind();
            ProductVie.HeaderRow.Cells[0].Text = "序号";
            ProductVie.HeaderRow.Cells[1].Text = "品牌名称";
            ProductVie.HeaderRow.Cells[2].Text = "种类";
            ProductVie.HeaderRow.Cells[3].Text = "数量";
            ProductVie.HeaderRow.Cells[4].Text = "价格";
            ProductVie.HeaderRow.Cells[5].Text = "厂家";


        }
        protected void ProductVie_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

    }
}