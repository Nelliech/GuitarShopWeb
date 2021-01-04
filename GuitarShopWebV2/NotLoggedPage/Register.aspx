<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GuitarShopWebV2.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <span>Imie: </span> <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="NameTextBox" 
                                ErrorMessage="Wprowadź imię" 
                                ForeColor="red"
                                EnableViewState="False" 
                                ValidationGroup="rej">

    </asp:RequiredFieldValidator><br/>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                    ControlToValidate="NameTextBox" 
                                    ErrorMessage="Wprowadź prawidłowe imię"
                                    ForeColor="red"
                                    ValidationExpression="^[a-żA-Ż]{3,}$" 
                                    ValidationGroup="rej">

    </asp:RegularExpressionValidator><br/>

    <span>Nazwisko: </span> <asp:TextBox ID="SurnameTextBox" runat="server"></asp:TextBox><br/>
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="SurnameTextBox" 
                                ErrorMessage="Wprowadź nazwisko" 
                                ForeColor="red"
                                EnableViewState="False"
                                ValidationGroup="rej">
    </asp:RequiredFieldValidator><br/>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                                    runat="server" 
                                    ControlToValidate="SurnameTextBox"
                                    ErrorMessage="Wprowadź prawidłowe nazwisko"
                                    ForeColor="red"
                                    ValidationExpression="^[a-żA-Ż]{3,}$" 
                                    ValidationGroup="rej">
    </asp:RegularExpressionValidator><br/>
  

    <span>Email: </span> <asp:TextBox ID="LoginTextBox" runat="server"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="LoginTextBox" 
                                ErrorMessage="Wprowadź login" 
                                ForeColor="red"
                                EnableViewState="False" 
                                ValidationGroup="rej">
        
    </asp:RequiredFieldValidator><br/>
    <asp:RegularExpressionValidator
        ID="RegularExpressionValidator1" runat="server"
        ControlToValidate="LoginTextBox"
        ErrorMessage="Email musi posiadać poprawny format"
        ForeColor="red"
        ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        ValidationGroup="rej">
        
    </asp:RegularExpressionValidator><br/>

    <span>Hasło: </span> <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="PasswordTextBox" 
                                ErrorMessage="Wprowadź hasło"
                                ForeColor="red"
                                EnableViewState="False" 
                                ValidationGroup="rej">
        
    </asp:RequiredFieldValidator><br/>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ControlToValidate="PasswordTextBox" 
                                    ErrorMessage="Hasło nie może zawierać znaków specjalnych a ilość znaków może wynosić minimalnie 5, a maksymalnie 16"
                                    ForeColor="red"
                                    ValidationExpression="^[a-żA-Ż0-9]{5,16}$" 
                                    ValidationGroup="rej">
        
    </asp:RegularExpressionValidator><br/>
    
    <asp:Label ID="SingInLabel" runat="server" Text="Taki Login już istnieje" ForeColor="#990000" Visible="False" ></asp:Label><br/>
    <asp:Button ID="RegisterButton" runat="server" Text="Załóż Konto" OnClick="RegisterButton_Click" />
</asp:Content>
