<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdmainMaster.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="blogsql.Views.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">商品管理</h3>
            </div>

        </div>
        
        <div class="row">
            <div class="col-md-4">
                 <div  class="mb-3">
                         <lable for=""class="form-label text-success">序号</lable>
                         <input type="text" placeholder="请输入"  autocomplete="off" runat="server" id="PIdTb" class="form-control"/>
                  </div>
                <div  class="mb-3">
                        <lable for=""class="form-label text-success">商品名称</lable>
                        <input type="text" placeholder="请输入"  autocomplete="off" runat="server" id="PNameTb" class="form-control"/>
                </div>
                <div  class="mb-3">
                        <lable for=""class="form-label text-success" >厂家</lable>
                        <asp:DropDownList ID="PManufactCb" runat="server" class="form-control">
                             
                        </asp:DropDownList>
                </div>
                <div  class="mb-3">
                        <lable for=""class="form-label text-success">商品类目</lable>
                        <asp:DropDownList ID="PCatCb" runat="server" class="form-control">
                            
                        </asp:DropDownList>
                </div>
                <div  class="mb-3">
                        <lable for=""class="form-label text-success">价格</lable>
                        <input type="text" placeholder="请输入"  autocomplete="off" runat="server" id="PriceTb" class="form-control"/>
                </div>
                <div  class="mb-3">
                        <lable for=""class="form-label text-success">数量</lable>
                        <input type="text" placeholder="请输入"  autocomplete="off" runat="server" id="QtyTb" class="form-control"/>
                    </div>
                            <div class="row">
                <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label>
                <div class="col-md-4"> <asp:Button Text="编辑" runat="server" id="EditBtn" class="btn-warning btn-block btn"  Width="100px" OnClick="EditBtn_Click"/></div>
                <div class="col-md-4"> <asp:Button Text="保存" runat="server" id="SaveBtn" class="btn-success btn-block btn" Width="100px" OnClick="SaveBtn_Click" /></div>
                <div class="col-md-4"> <asp:Button Text="删除" runat="server" id="DeleteBtn" class="btn-danger btn-block btn"  Width="100px" OnClick="DeleteBtn_Click"/></div>
            </div>
            </div>
            <div  class="mb-3">
                    <asp:Button Text="查询" runat="server" id="btnSearch" class="btn-danger btn-block btn"  Width="100px" OnClick="SearchBtn_Click" BackColor="#990099" />
                    <input type="text" placeholder="输入名称"  autocomplete="off" class="form-control" runat="server" id="searchName"/>
            </div>
            &nbsp;&nbsp;&nbsp;
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <div class="col-md-8">
            <asp:GridView ID="ProductList" runat="server"   AutoGenerateSelectButton="True" OnSelectedIndexChanged="ProductList_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Height="104px" Width="764px">
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
