<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Custom/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="blogsql.Views.Custom.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintBill() {
            var PGrid = document.getElementById('<%=ShoppingCartList.ClientID%>');
            PGrid.bordr = 0;
            var PWin = window.open('','PrintGrid','Left=100,top=100,width=1024,height=768,tollbar=0,scrollbars=1,status=0,resizable=1');
            PWin.document.write(PGrid.outerHTML);
            PWin.document.close();
            PWin.focus();
            PWin.print();
            PWin.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">

        </div>
         <div class="row">
             <div class="col-md-5">
                 <h3 class="text-center" style="color:teal">商品选购</h3>
                 <div class="row">
                     <div class="col">
                         <div class="mt-3">
                        <lable for=""class="form-label text-success">商品名称</lable>
                        <input type="text" placeholder=""  autocomplete="off" class="form-control" runat="server" id="PNameTb"/>
                    </div>
                     </div>
                     <div class="col">
                         <div class="mt-3">
                        <lable for=""class="form-label text-success">价格</lable>
                        <input type="text" placeholder=""  autocomplete="off" class="form-control" runat="server" id="PriceTb"/>
                    </div>
                     </div>
                     <div class="col">
                         <div class="mt-3">
                        <lable for=""class="form-label text-success">数量</lable>
                        <input type="text" placeholder=""  autocomplete="off" class="form-control" runat="server" id="QtyTb"/>
                    </div>
                     </div>
                     <div class="row mt-3 mb-3 ">
                         <div class=" col d-grid">
                              <asp:Button Text="加入购物车" runat="server" id="AddToBillBtn" class="btn-warning btn-block btn"   OnClick="AddToBillBtn_Click" />
                         </div>
                     </div>
                 </div>
                 <div class="row mt-5">
                     <h4 class="text-center" style="color:teal">商品列表</h4>
                     <div class="col">
                          <asp:GridView ID="ProductList" runat="server" CellPadding="4" AutoGenerateSelectButton="True"  ForeColor="#333333" GridLines="None" Height="142px" Width="561px" OnSelectedIndexChanged="ProductList_SelectedIndexChanged">
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
              <div class="col-md-7">
                   <h4 class="text-center" style="color:firebrick">购物车</h4>
                     <div class="col mt-3 mb-3">
                          <asp:GridView ID="ShoppingCartList" runat="server" CellPadding="4"  ForeColor="#333333" GridLines="None" Height="128px" Width="561px" OnSelectedIndexChanged="ProductList_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                         <div class="row">
                             <div class="row">
                                 <div class="col-md-5">

                                 </div>
                                 <div class="col-md-1">
 <asp:Label runat="server" ID="RMBLabel" class="text-danger text-center"></asp:Label>
                                 </div>
                                 <div class="col-md-6">
<asp:Label runat="server" ID="GrdTotalTb" class="text-danger text-center"></asp:Label><br/>
                                 </div>
                             </div>
                         
                  <div class="row"> 
                      <asp:Button Text="结算" runat="server" id="PrintBtn" class="btn-warning btn-block btn"  OnClientClick="PrintBill()"  OnClick="PrintBtn_Click" />
                  </div>
               
                
             </div>
        </div>
    </div>
             </div>
        </div>
</asp:Content>
