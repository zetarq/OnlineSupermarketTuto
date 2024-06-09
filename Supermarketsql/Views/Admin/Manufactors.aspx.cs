using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogsql.Views.Admin
{
    public partial class support : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowManufactors();
        }
        private  void  ShowManufactors()
        {
            string Query = "Select * from ManufactorTb1";
            ManufactList.DataSource = Con.GetData(Query);
            ManufactList.DataBind();
            ManufactList.HeaderRow.Cells[1].Text = "序号";
            ManufactList.HeaderRow.Cells[2].Text = "品牌名称";
            ManufactList.HeaderRow.Cells[3].Text = "生产许可证号";
            ManufactList.HeaderRow.Cells[4].Text = "产地";

        }



        protected void EditBtn_Click1(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string MName = MNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();
                    string Query = " update  ManufactorTb1 set ManufactName ='{0}' ,ManufactPermNum='{1}' , ManufactPlace='{2}'  where ManufactId = '{3}'";
                    Query = string.Format(Query, MName, PermNum, Place,ManufactList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowManufactors();
                    ErrMsg.Text = "供应商信息已更新！！！";
                    MNameTb.Value = "";
                    PermNumTb.Value = "";
                    PlaceCb.SelectedIndex = -1;


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
                if (MNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string MName = MNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();
                    string Query = " insert into ManufactorTb1 values('{0}','{1}','{2}') ";
                    Query = string.Format(Query, MName, PermNum, Place);
                    Con.SetData(Query);
                    ShowManufactors();
                    ErrMsg.Text = "商品信息已添加！！！";
                    MNameTb.Value = "";
                    PermNumTb.Value = "";
                    PlaceCb.SelectedIndex = -1;


                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }

        }


        int key = 0;
        protected void ManufactList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MNameTb.Value = ManufactList.SelectedRow.Cells[2].Text;
            PermNumTb.Value = ManufactList.SelectedRow.Cells[3].Text;
            PlaceCb.SelectedValue = ManufactList.SelectedRow.Cells[4].Text;
            if(MNameTb.Value==  "")
            {
                key = 0;

            }else
            {
                key = Convert.ToInt32(ManufactList.SelectedRow.Cells[1].Text);
            }

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "请选择一行数据";
                }
                else
                {
                    string MName = MNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();
                    string Query = " delete from ManufactorTb1 where ManufactId='{0}'";
                    Query = string.Format(Query, ManufactList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowManufactors();
                    ErrMsg.Text = "商品信息已删除！！！";
                    MNameTb.Value = "";
                    PermNumTb.Value = "";
                    PlaceCb.SelectedIndex = -1;


                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }

        }
    }
}