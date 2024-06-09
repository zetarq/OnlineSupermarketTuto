using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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
            else if(UNameTb.Value == "222333@qq.com" && PasswordTb.Value =="114514")
            {
                Response.Redirect("Admin/Products.aspx");
            }
            else
            {
                string Query = "Select * from CustomerTb1 where CustEmail='{0}' and CustPass = '{1}'";
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
            }
        }
    }
}