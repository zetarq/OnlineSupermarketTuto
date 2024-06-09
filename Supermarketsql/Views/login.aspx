<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="blogsql.Views.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../Assets/lib/css/bootstrap.min.css" /> 
   
</head>
<body>
    <div classs="container-fluid">
        <div class="row mt-5 mb-5">

        </div>
        
        <div class="row">
            <div class="col-md-4">

             </div>
             <div class="col-md-4">
                <form id="form1" runat="server">
                    <div class="row">
                        <div class="col-md-3"></div>
                        <div class="col-md-9">
                        <img src="../Assets/img/shop/登录.png"/>
                    </div>
                        </div>
                  
                    <div class="mt-3">
                        <lable for=""class="form-label">用户名</lable>
                        <input type="email" placeholder="请输入用户名"  autocomplete="off" class="form-control" runat="server" id="UNameTb"/>
                    </div>
                    <div class="mt-3">
                        <lable for=""class="form-label">密码</lable>
                        <input type="password" placeholder="请输入账户密码"  autocomplete="off" class="form-control" runat="server" id="PasswordTb"/>
                    </div>
                    <div class="mt-3 d-grid">
                        <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label><br/>
                        <asp:Button Text="登录" runat="server" CssClass="btn-success btn" ID="LoginBtn" OnClick="LoginBtn_Click"  />

                    </div>
                </form>
             </div>
            <div class="col-md-4">

             </div>
        </div>
    </div>
   
</body>
</html>
