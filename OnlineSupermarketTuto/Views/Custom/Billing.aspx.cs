using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace blogsql.Views.Custom
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.Functions Con;
        int customer = login.User;
        string CName = login.UName;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();

            if (!IsPostBack)
            {
                ShowProducts();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("序号"),
                    new DataColumn("商品名称"),
                    new DataColumn("价格"),
                    new DataColumn("数量"),
                    new DataColumn("总计"),
                });
            ViewState["账单"] = dt;
            this.BindGrid();
               
            }
        }
        private void ShowProducts()
        {
            string Query = "Select PId,PName,PPrice,PQty from ProductTb1";
            ProductList.DataSource = Con.GetData(Query);
            ProductList.DataBind();
            ProductList.HeaderRow.Cells[1].Text = "序号";
            ProductList.HeaderRow.Cells[2].Text = "商品名称";
            ProductList.HeaderRow.Cells[4].Text = "库存总量";
            ProductList.HeaderRow.Cells[3].Text = "商品价格";

        }
        protected void BindGrid()
        {
            ShoppingCartList.DataSource = ViewState["账单"];
            ShoppingCartList.DataBind(); 
        }

        int key = 0;
        int stock = 0;
        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PNameTb.Value = ProductList.SelectedRow.Cells[2].Text;
            PriceTb.Value = ProductList.SelectedRow.Cells[3].Text;

            stock= Convert.ToInt32(ProductList.SelectedRow.Cells[4].Text);
           


            if (PNameTb.Value == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(ProductList.SelectedRow.Cells[1].Text);
            }
        }
        private void InsertBill()
        {
            try
            {
                string Query = "insert into BillTb1 values('{0}','{1}','{2}')";
                Query = string.Format(Query, DateTime.Today.Date.ToString(), customer, Convert.ToInt32(GrdTotalTb.Text));
                Con.SetData(Query);
            }
            catch (Exception ex)
            {

            }
        }

        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            InsertBill();

        }

        private void UpdateStock()
        {
            int NewQty;
            NewQty = Convert.ToInt32(ProductList.SelectedRow.Cells[4].Text)-Convert.ToInt32(QtyTb.Value);
            string Query = " update  ProductTb1 set PQty='{0}' where PId='{1}'";
            Query = string.Format(Query, NewQty,ProductList.SelectedRow.Cells[1].Text);
            Con.SetData(Query);
            ShowProducts();
        }

        int GrdTotal = 0;
        int Amount;
        protected void AddToBillBtn_Click(object sender, EventArgs e)
        {
            if(PNameTb.Value ==""||QtyTb.Value=="" ||PriceTb.Value=="")
            {

            }
            else
            {
                int total =Convert.ToInt32(QtyTb.Value) *Convert.ToInt32(PriceTb.Value);
                DataTable dt = (DataTable)ViewState["账单"];
                dt.Rows.Add(ShoppingCartList.Rows.Count+1,
                PNameTb.Value.Trim(),
                PriceTb.Value.Trim(),
                QtyTb.Value.Trim(),
                total);

                ViewState["账单"] = dt;
                this.BindGrid();
                UpdateStock();
                GrdTotal = 0;
                for(int i=0;i<ShoppingCartList.Rows.Count;i++)
                    {
                        GrdTotal=GrdTotal+Convert.ToInt32(ShoppingCartList.Rows[i].Cells[4].Text);
                    }
                Amount = GrdTotal;
                RMBLabel.Text = "￥";
                GrdTotalTb.Text =  Convert.ToString(GrdTotal);
                PNameTb.Value = "";
                QtyTb.Value = "";
                PriceTb.Value = "";
             }
            
        }

       
    }
}