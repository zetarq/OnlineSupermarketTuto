﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogsql.Views.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if(! IsPostBack)
            {
                ShowProducts();
                GetCategories();
                GetManufacts();
            }
           
        }
        private void ShowProducts()
        {
            string Query = "Select * from ProductTb1";
            ProductList.DataSource = Con.GetData(Query);
            ProductList.DataBind();
            ProductList.HeaderRow.Cells[1].Text = "序号";
            ProductList.HeaderRow.Cells[2].Text = "品牌名称";
            ProductList.HeaderRow.Cells[3].Text = "生产许可证号";
            ProductList.HeaderRow.Cells[4].Text = "产地";

        }
         
        private void GetCategories()
        {
            string Query = "select * from CategoryTb1";
            PCatCb.DataTextField = Con.GetData(Query).Columns["CatName"].ToString();
            PCatCb.DataValueField = Con.GetData(Query).Columns["CatId"].ToString();
            PCatCb.DataSource = Con.GetData(Query);
            PCatCb.DataBind();
        }
        private void GetManufacts()
        {
            string Query = "select * from ManufactorTb1";
            PManufactCb.DataTextField = Con.GetData(Query).Columns["ManufactName"].ToString();
            PManufactCb.DataValueField = Con.GetData(Query).Columns["ManufactId"].ToString();
            PManufactCb.DataSource = Con.GetData(Query);
            PManufactCb.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == "" || PManufactCb.SelectedIndex == -1  || PCatCb.SelectedIndex == -1 || PriceTb.Value =="" || QtyTb.Value=="")
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string PName = PNameTb.Value;
                    string PCat = PCatCb.SelectedValue.ToString();
                    string PManufact = PManufactCb.SelectedValue.ToString();
                    int Price =Convert.ToInt32(PriceTb.Value);
                    int Qty = Convert.ToInt32(QtyTb.Value);
                    string Query = " insert into ProductTb1 values('{0}','{1}','{2}','{3}','{4}') ";
                    Query = string.Format(Query, PName,  PCat,PManufact, Qty,Price);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "商品信息已添加！！！";
                    PNameTb.Value = "";
                    PriceTb.Value = "";
                    QtyTb.Value = "";
                    PCatCb.SelectedIndex = -1;
                    PManufactCb.SelectedIndex = -1;


                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        int key = 0;
        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PNameTb.Value = ProductList.SelectedRow.Cells[2].Text;
            PManufactCb.SelectedValue = ProductList.SelectedRow.Cells[4].Text;
            PCatCb.SelectedValue = ProductList.SelectedRow.Cells[3].Text;
            QtyTb.Value = ProductList.SelectedRow.Cells[5].Text;
            PriceTb.Value = ProductList.SelectedRow.Cells[6].Text;


            if (PNameTb.Value == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(ProductList.SelectedRow.Cells[1].Text);
            }

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == "" || PManufactCb.SelectedIndex == -1 || PCatCb.SelectedIndex == -1 || PriceTb.Value == "" || QtyTb.Value == "")
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string PName = PNameTb.Value;
                    string PCat = PCatCb.SelectedValue.ToString();
                    string PManufact = PManufactCb.SelectedValue.ToString();
                    int Price = Convert.ToInt32(PriceTb.Value);
                    int Qty = Convert.ToInt32(QtyTb.Value);
                    string Query = " update  ProductTb1 set PName='{0}',PCategory='{1}',PManufact='{2}',PQty='{3}',PPrice='{4}' where PId='{5}'";
                    Query = string.Format(Query, PName, PCat, PManufact, Qty, Price,ProductList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "商品信息已更新！！！";
                    PNameTb.Value = "";
                    PriceTb.Value = "";
                    QtyTb.Value = "";
                    PCatCb.SelectedIndex = -1;
                    PManufactCb.SelectedIndex = -1;


                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == "" || PManufactCb.SelectedIndex == -1 || PCatCb.SelectedIndex == -1 || PriceTb.Value == "" || QtyTb.Value == "")
                {
                    ErrMsg.Text = "请选择一行数据";
                }
                else
                {
                    string PName = PNameTb.Value;
                    string PCat = PCatCb.SelectedValue.ToString();
                    string PManufact = PManufactCb.SelectedValue.ToString();
                    int Price = Convert.ToInt32(PriceTb.Value);
                    int Qty = Convert.ToInt32(QtyTb.Value);
                    string Query = " delete from ProductTb1 where PId='{0}'";
                    Query = string.Format(Query,  ProductList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "商品信息已删除！";
                    PNameTb.Value = "";
                    PriceTb.Value = "";
                    QtyTb.Value = "";
                    PCatCb.SelectedIndex = -1;
                    PManufactCb.SelectedIndex = -1;


                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}