﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdmainMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="blogsql.Views.Admin.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h3 class="text-center">类目管理</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="CatIdTb" class="form-label text-success">序号</label>
                    <input type="text" placeholder="请输入序号" autocomplete="off" class="form-control" runat="server" id="CatIdTb"/>
                </div>
                <div class="mb-3">
                    <label for="CatNameTb" class="form-label text-success">类目名称</label>
                    <input type="text" placeholder="请输入类目名称" autocomplete="off" class="form-control" runat="server" id="CatNameTb"/>
                </div>
                <div class="mb-3">
                    <label for="DescriptionTb" class="form-label text-success">详细信息</label>
                    <input type="text" placeholder="请输入类目描述" autocomplete="off" class="form-control" runat="server" id="DescriptionTb"/>
                </div>
                <div class="row">
                    <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger text-center"></asp:Label>
                    <div class="col-md-4">
                        <asp:Button Text="编辑" runat="server" ID="EditBtn" CssClass="btn-warning btn-block btn" Width="100px" OnClick="EditBtn_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:Button Text="保存" runat="server" ID="SaveBtn" CssClass="btn-success btn-block btn" Width="100px" OnClick="SaveBtn_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:Button Text="删除" runat="server" ID="DeleteBtn" CssClass="btn-danger btn-block btn" Width="100px" OnClick="DeleteBtn_Click" />
                    </div>
                </div>
                <div class="mb-3">
                    <asp:Button Text="查询" runat="server" ID="btnSearch" CssClass="btn-danger btn-block btn" Width="100px" OnClick="SearchBtn_Click" BackColor="#990099"/>
                    <input type="text" placeholder="输入名称" autocomplete="off" class="form-control" runat="server" id="searchName"/>
                </div>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="col-md-8">
                <asp:GridView ID="CategoryList" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="CategoryList_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
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
