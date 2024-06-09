using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace blogsql.Views
{
    public partial class login : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }

        public static string UName = "";
        public static int User;

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if(UNameTb.Value=="" || PasswordTb.Value=="")
            {
                ErrMsg.Text = "请输入用户名和密码！！";
            }
            else //if(UNameTb.Value == "111@qq.com" && PasswordTb.Value =="111")
            {




                /*string Query = "Select * from CustomerTb1 where CustEmail='{0}' and CustPass = '{1}'";
                Query=String.Format(Query, UNameTb.Value,PasswordTb.Value);
                DataTable dt = Con.GetData(Query);
                if(dt.Rows.Count ==0)
                {
                    ErrMsg.Text = "用户名或密码错误";
                }else
                {
                    UName = UNameTb.Value;
                    User = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Custom/Billing.aspx");
                }
                */
                //聚合查询
                string query = string.Format("SELECT * FROM Users WHERE UserName='{0}' AND UserPwd='{1}'", UNameTb.Value, PasswordTb.Value);
                

                DataTable dt = Con.GetData(query);
                if (dt.Rows.Count == 1)//匹配成功，存在该用户，且密码输入正确
                 {
                    Response.Redirect("Admin/Products.aspx");//页面重定向，跳到products页
                }
                else    if (dt.Rows.Count == 0)
                {
                    ErrMsg.Text = "用户名或密码错误";
                }
            }
        }
        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            UNameTb.Value = ""; // 清空用户名输入框的值
            PasswordTb.Value = ""; // 清空密码输入框的值
        }
    }
}