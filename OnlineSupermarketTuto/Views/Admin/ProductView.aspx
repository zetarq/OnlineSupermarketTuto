<%@ Page Language="C#" MasterPageFile="~/Views/Admin/AdmainMaster.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="OnlineSupermarketTuto.Views.Admin.ProductView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Custom CSS for alignment and styling */
        .container-fluid {
            padding-top: 20px; /* Add some padding to the top */
        }
        /* Adjust the width of the GridView */
         #ProductVie {
            width: 100%; /* Use 100% of container width */
            margin-top: 20px; /* Add some top margin to align with navigation bar */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
     <div class="container-fluid">
        <div class="row">
             <div class="col-md-4">
                <!-- Your navigation bar goes here -->
                <!-- Assuming your navigation bar is already in the Master page -->
            </div>
             <div class="col-md-8"> 

                         <i class="o-home-1 mr-3 text-black">

     <asp:GridView ID="ProductVie" runat="server"   OnSelectedIndexChanged="ProductVie_SelectedIndexChanged" style="text-align: center;" CellPadding="4" ForeColor="#333333" GridLines="None" Height="104px" Width="764px">
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
      
                 </i>
      
            </div>
       </div>
    </div>
</asp:Content>

