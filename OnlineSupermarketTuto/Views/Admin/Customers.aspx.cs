using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogsql.Views.Admin
{
    public partial class Customers : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowCustomers();

        }

        private void ShowCustomers()
        {
            string Query = "Select * from CustomerTb1";
            CustomerList.DataSource = Con.GetData(Query);
            CustomerList.DataBind();
           CustomerList.HeaderRow.Cells[1].Text = "序号";
           CustomerList.HeaderRow.Cells[2].Text = "用户名";
            CustomerList.HeaderRow.Cells[3].Text = "电子邮箱";
            CustomerList.HeaderRow.Cells[4].Text = "电话";
           
       

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchName.Value == "")
                {
                    ErrMsg.Text = "请选择一行数据";
                }
                else
                {
                    string productName = searchName.Value;
                    // 构造SQL查询语句
                    string query = "SELECT CustId,CustName,CustEmail,CustPhone,CustAddress FROM CustomerTb1 Where CustName LIKE '%" + productName + "%'";
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
                if (CNameTb.Value == "" || CEmailTb.Value == "" || CPhoneTb.Value == "" || PassTb.Value == "")
                {
                    ErrMsg.Text = "请选择一行数据";
                }
                else
                {
                    string CusName = CNameTb.Value;
                    string CusEmail = CEmailTb.Value;
                    string CusPhone = CPhoneTb.Value;
                    string CustPass = PassTb.Value;

                    string Query = " delete from CustomerTb1 where CustId='{0}'";
                    Query = string.Format(Query, CustomerList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCustomers();
                    ErrMsg.Text = "用户信息已删除！！！";
                    CNameTb.Value = "";
                    CEmailTb.Value = "";
                    CPhoneTb.Value = "";
                    PassTb.Value = "";



                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        

        protected void EditBtn_Click(object sender, EventArgs e)//编辑数据
        {
            try
            {
                if (CNameTb.Value == "" || CEmailTb.Value == "" || CPhoneTb.Value == "" || PassTb.Value == "")
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string CusName = CNameTb.Value;
                    string CusEmail = CEmailTb.Value;
                    string CusPhone = CPhoneTb.Value;
                    string CusPass = PassTb.Value;
                    string CId = CIdTb.Value;
                    string CAd = CAddressTb.Value;
                    string Query = " insert into CustomerTb1 values('{0}','{1}','{2}','{3}','{4}','{5}') ";
                    Query = string.Format(Query, CId, CusName, CusEmail, CusPhone, CAd, CusPass);
                    Con.SetData(Query);
                    ShowCustomers();
                    ErrMsg.Text = "用户信息已更新！！！";
                    CNameTb.Value = "";
                    CEmailTb.Value = "";
                    CPhoneTb.Value = "";
                    PassTb.Value = "";



                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }

        }

        protected void SaveBtn_Click(object sender, EventArgs e)//添加数据
        {
            try
            {
                if (CNameTb.Value == "" || CEmailTb.Value == "" || CPhoneTb.Value == "" || PassTb.Value == "" )
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string CusName = CNameTb.Value;
                    string CusEmail = CEmailTb.Value;
                    string CusPhone = CPhoneTb.Value;
                    string CusPass = PassTb.Value;
                    string CId = CIdTb.Value;
                    string CAd = CAddressTb.Value;
                    string Query = " insert into CustomerTb1 values('{0}','{1}','{2}','{3}','{4}','{5}') ";
                    Query = string.Format(Query,CId, CusName, CusEmail,CusPhone,CAd,CusPass);
                    Con.SetData(Query);
                    ShowCustomers();
                    ErrMsg.Text = "用户信息已添加！！！";
                    CNameTb.Value = "";
                    CEmailTb.Value = "";
                    CPhoneTb.Value = "";
                    PassTb.Value = "";
                   


                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }

        }
        int key = 0;

        protected void CustomerList_SelectedIndexChanged(object sender, EventArgs e)

        {
            CNameTb.Value = CustomerList.SelectedRow.Cells[2].Text;
            CEmailTb.Value = CustomerList.SelectedRow.Cells[3].Text;
            CPhoneTb.Value = CustomerList.SelectedRow.Cells[4].Text;
            PassTb.Value = CustomerList.SelectedRow.Cells[5].Text;
           

            if (CNameTb.Value == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(CustomerList.SelectedRow.Cells[1].Text);
            }

        }
    }
    
}