using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Collections;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Reflection;

namespace OnlineSupermarketTuto.Views
{
    public partial class Register : System.Web.UI.Page
    {
        blogsql.Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new blogsql.Models.Functions();

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string UName = txtUserName.Text;
            string UPwd = txtPwd.Text;
            string Query = " insert into Users values('{0}','{1}') ";
            Query = string.Format(Query, UName, UPwd);
            // 检查 Con 对象是否为空
            if (Con != null)
            {
                // 调用 SetData 方法
                Con.SetData(Query);
            }



            Response.Write("<script>alert('注册成功')</script>");
            
        }
        protected void btnRevert_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");//返回登录页面
        }
    }
}