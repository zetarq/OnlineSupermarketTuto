using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSupermarketTuto.Views.Admin
{
    public partial class Manufactorview : System.Web.UI.Page
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
            ManufactView.DataSource = Con.GetData(Query);
            ManufactView.DataBind();
            ManufactView.HeaderRow.Cells[0].Text = "序号";
            ManufactView.HeaderRow.Cells[1].Text = "品牌名称";
            ManufactView.HeaderRow.Cells[2].Text = "种类";
            ManufactView.HeaderRow.Cells[3].Text = "数量";
            ManufactView.HeaderRow.Cells[4].Text = "价格";
            ManufactView.HeaderRow.Cells[5].Text = "厂家";


        }
        protected void ManufactView_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}