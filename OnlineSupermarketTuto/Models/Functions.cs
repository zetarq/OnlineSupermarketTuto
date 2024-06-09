using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;//连接数据库

using System.Linq;
using System.Web;

namespace blogsql.Models
{
    public class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;//用于执行数据库命令command
        private DataTable dt;//用于存储从数据库检索的数据表
        private SqlDataAdapter sda;//数据适配器
        private string ConStr;//数据库连接字符，包含数据库的位置和连接配置
        public Functions()
        {
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Asp.net\OnlineSupemarket\OnlineSupermarketTuto\Supermarketsql\SupermarketDb.mdf;Integrated Security=True;Connect Timeout=30";
            Con= new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }
        public DataTable GetData(string Query)//用于执行SELECT查询并返回结果。
        {
            DataTable dt = new DataTable();
            sda = new SqlDataAdapter( Query,ConStr);
            sda.Fill(dt); 
            return dt;
        }

        public int SetData(string Query)//用于执行数据插入、更新或删除操作
        {
            int cnt = 0;
            if(Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            Con.Close();
            return cnt;

        }


    }
}