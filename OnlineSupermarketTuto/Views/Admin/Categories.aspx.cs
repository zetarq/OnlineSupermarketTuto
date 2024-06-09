using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace blogsql.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
           

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

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchName.Value == "" )
                {
                    ErrMsg.Text = "请选择一行数据";
                }
                else
                {
                    string productName = searchName.Value;
                    // 构造SQL查询语句
                    string query = "SELECT CatId,CatName,CatDescription FROM CategoryTb1 Where CatName LIKE '%" + productName + "%'";
                  //获取数据
                    
                    DataTable dt = Con.GetData(query);
                    if (dt.Rows.Count > 0)
                    {
                        // 如果查询到结果，显示在 GridView 中
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        // 如果没有查询到结果，显示提示信息
                        lblMessage.Text = "不存在该商品。";
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                    ShowCategories();
                 
                    CatNameTb.Value = "";
                    DescriptionTb.Value = "";



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
                    string CId = CatIdTb.Value;
                    string Query = " insert into CategoryTb1 values('{0}','{1}','{2}') ";
                    Query = string.Format(Query, CId, CName, CDesc);
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
                    string CId = CatIdTb.Value;
                    string Query = " insert into CategoryTb1 values('{0}','{1}','{2}') ";
                    Query = string.Format(Query, CId, CName,CDesc);
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