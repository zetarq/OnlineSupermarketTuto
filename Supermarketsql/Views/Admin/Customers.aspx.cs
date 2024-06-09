using System;
using System.Collections.Generic;
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
            CustomerList.HeaderRow.Cells[3].Text = "电子📫";
            CustomerList.HeaderRow.Cells[4].Text = "电话";
            CustomerList.HeaderRow.Cells[5].Text = "密码";
       

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

        

        protected void EditBtn_Click(object sender, EventArgs e)
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

                    string Query = " update  CustomerTb1 set CustName='{0}',CustEmail='{1}',CustPhone='{2}',CustAddress='{3}' where CustId='{4}'";
                    Query = string.Format(Query, CusName, CusEmail, CusPhone, CusPass, CustomerList.SelectedRow.Cells[1].Text);
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

        protected void SaveBtn_Click(object sender, EventArgs e)
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

                    string Query = " insert into CustomerTb1 values('{0}','{1}','{2}','{3}') ";
                    Query = string.Format(Query, CusName, CusEmail,CusPhone,CusPass);
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