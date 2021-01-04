<%@ Page Title="Shop" Language="C#" MasterPageFile="~/SiteLogged.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="GuitarShopWebV2.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" runat="server">
    
    <asp:GridView CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary text-white" AutoGenerateColumns="False" ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">  
        <Columns>  
            <asp:BoundField HeaderText="Kod Produktu" DataField="ProductCode" />
            <asp:BoundField HeaderText="Producent" DataField="Producer" />  
            <asp:BoundField HeaderText="Model" DataField="Model" />  
            <asp:BoundField HeaderText="Cena ZŁ" DataField="Price" />  
            
            <asp:CommandField ShowCancelButton="False" ShowSelectButton="True" />
            
        </Columns>  

<HeaderStyle CssClass="bg-primary text-white"></HeaderStyle>
    </asp:GridView>  
    
</asp:Content>  
