using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSupermarketTuto.Views.Admin
{
    public partial class CategoryView : System.Web.UI.Page
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
            CateView.DataSource = Con.GetData(Query);
            CateView.DataBind();
            CateView.HeaderRow.Cells[0].Text = "序号";
            CateView.HeaderRow.Cells[1].Text = "品牌名称";
            CateView.HeaderRow.Cells[2].Text = "种类";
            CateView.HeaderRow.Cells[3].Text = "数量";
            CateView.HeaderRow.Cells[4].Text = "价格";
            CateView.HeaderRow.Cells[5].Text = "厂家";


        }
        protected void CateView_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}