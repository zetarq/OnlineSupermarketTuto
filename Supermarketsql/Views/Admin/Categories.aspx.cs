﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogsql.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowCategories();

        }
        private void ShowCategories()
        {
            string Query = "Select * from CategoryTb1";
            CategoryList.DataSource = Con.GetData(Query);
            CategoryList.DataBind();
            CategoryList.HeaderRow.Cells[1].Text = "序号";
            CategoryList.HeaderRow.Cells[2].Text = "类目名称";
            CategoryList.HeaderRow.Cells[3].Text = "详细信息";
           // ManufactList.HeaderRow.Cells[4].Text = "产地";

        }
      
       
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || DescriptionTb.Value == "")
                {
                    ErrMsg.Text = "请选择一行数据";
                }
                else
                {
                    string CName = CatNameTb.Value;
                    string CDesc = DescriptionTb.Value;

                    string Query = " delete from CategoryTb1 where CatId='{0}'";
                    Query = string.Format(Query, CategoryList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "商品类目信息已删除！！！";
                    CatNameTb.Value = "";
                    DescriptionTb.Value = "";



                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
       

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || DescriptionTb.Value == "")
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string CName = CatNameTb.Value;
                    string CDesc = DescriptionTb.Value;

                    string Query = " update  CategoryTb1  set  CatName='{0}',CatDescription= '{1}' where CatId ={2}";
                    Query = string.Format(Query, CName, CDesc, CategoryList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "商品信息已更新！！！";
                    CatNameTb.Value = "";
                    DescriptionTb.Value = "";



                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }


        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || DescriptionTb.Value == "" )
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string CName = CatNameTb.Value;
                    string CDesc = DescriptionTb.Value;
                   
                    string Query = " insert into CategoryTb1 values('{0}','{1}') ";
                    Query = string.Format(Query, CName,CDesc);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "商品信息已添加！！！";
                    CatNameTb.Value = "";
                    DescriptionTb.Value = "";
                   


                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }

        }
        int key = 0;

        protected void CategoryList_SelectedIndexChanged(object sender, EventArgs e)

        {
            CatNameTb.Value = CategoryList.SelectedRow.Cells[2].Text;
            DescriptionTb.Value = CategoryList.SelectedRow.Cells[3].Text;

            if (CatNameTb.Value == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(CategoryList.SelectedRow.Cells[1].Text) ;
            }

        }
    }
}