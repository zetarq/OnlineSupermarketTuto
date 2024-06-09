using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSupermarketTuto.Views.Admin
{
    public partial class CustomerView : System.Web.UI.Page
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
            CustomView.DataSource = Con.GetData(Query);
            CustomView.DataBind();
            CustomView.HeaderRow.Cells[0].Text = "序号";
            CustomView.HeaderRow.Cells[1].Text = "品牌名称";
            CustomView.HeaderRow.Cells[2].Text = "种类";
            CustomView.HeaderRow.Cells[3].Text = "数量";
            CustomView.HeaderRow.Cells[4].Text = "价格";
            CustomView.HeaderRow.Cells[5].Text = "厂家";


        }
        protected void CustomView_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}