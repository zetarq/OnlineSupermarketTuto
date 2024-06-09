<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdmainMaster.Master" AutoEventWireup="true" CodeBehind="Manufactors.aspx.cs" Inherits="blogsql.Views.Admin.support" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
       <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">生产商管理</h3>
            </div>

        </div>
        
        <div class="row">
            <div class="col-md-4">
                <div  class="mb-3">
                        <lable for=""class="form-label text-success">序号</lable>
                        <input type="text" placeholder="请输入"  autocomplete="off" class="form-control" runat="server" ID="MNameTb"/>
                </div>
                <div  class="mb-3">
                        <lable for=""class="form-label text-success" >生产许可证号</lable>
                         <input type="text" placeholder="请输入"  autocomplete="off" class="form-control" runat="server" ID="PermNumTb"/>
                </div>
                <div  class="mb-3">
                        <lable for=""class="form-label text-success">生产来源地</lable>
                        <asp:DropDownList class="form-control" runat="server" ID="ManufactPlaceTb">
                              <asp:ListItem Text="China" Value="beijing"></asp:ListItem>
                            <asp:ListItem>Ameriaca</asp:ListItem>
                            <asp:ListItem>German</asp:ListItem>
                            <asp:ListItem>etc</asp:ListItem>
                      
                           
                        </asp:DropDownList>
                </div>
             
                <div class="row">
                    <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label>
                    <div class="col-md-4"> <asp:Button Text="编辑" runat="server" id="EditBtn" class="btn-warning btn-block btn"  Width="100px" OnClick="EditBtn_Click1" /></div>
                    <div class="col-md-4"> <asp:Button Text="保存" runat="server" id="SaveBtn"  class ="btn-success btn-block btn" Width="100px" OnClick="SaveBtn_Click" /></div>
                    <div class="col-md-4"> <asp:Button Text="删除" runat="server" id="DeleteBtn" class="btn-danger btn-block btn"  Width="100px" OnClick="DeleteBtn_Click"/></div>
                </div>

            </div>
            <div class="col-md-8">
                <asp:GridView ID="ManufactList" runat="server"  AutoGenerateSelectButton="True" OnSelectedIndexChanged="ManufactList_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Height="149px" Width="757px">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>

            </div>

        </div>

    </div>
</asp:Content>
