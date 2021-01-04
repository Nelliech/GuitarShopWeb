<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GuitarShopWebV2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br/>
    <span>Email: </span><asp:TextBox ID="LoginTextBox" runat="server" ></asp:TextBox><br/>
    <span>Hasło: </span><asp:TextBox ID="PasswordTextBox" runat="server" Width="127px" TextMode="Password"></asp:TextBox><br/>
    <asp:LinkButton ID="RegisterLinkButton" runat="server" OnClick="RegisterLinkButton_Click">ZałóżKonto</asp:LinkButton>
    <asp:Button ID="SignInButton" runat="server" Text="Zaloguj się" OnClick="SignInButton_Click" />

</asp:Content>
