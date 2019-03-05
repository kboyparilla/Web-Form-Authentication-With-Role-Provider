<%@ Page Title="" Language="C#" MasterPageFile="~/Public/Public.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="WebApplication.Public.registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="login">Sign-In</a>
    <br />
    <br />

    <label>First Name</label><br/>
    <asp:TextBox runat="server" ID="txtFirstName" /><br/><br/>

    <label>Last Name</label><br/>
    <asp:TextBox runat="server" ID="txtLastName" /><br/><br/>

    <label>Email</label><br/>
    <asp:TextBox runat="server" ID="txtEmail" /><br/><br/>

    <label>Username</label><br/>
    <asp:TextBox runat="server" ID="txtUserName" /><br/><br/>

    <label>Password</label><br/>
    <asp:TextBox runat="server" ID="txtPassword" /><br/><br/>

    <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="BtnSave_Click"/>
</asp:Content>
