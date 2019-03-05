<%@ Page Title="" Language="C#" MasterPageFile="~/Public/Public.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.Public.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="registration">Sign-Up</a>
    <br />
    <br />
    <label>Username</label><br/>
    <asp:TextBox runat="server" ID="txtUser" /><br/><br/>

    <label>Password</label><br/>
    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" /><br/><br/>

    <asp:Button runat="server" ID="btnSubmit" Text="Save" OnClick="btnSubmit_Click"/>
</asp:Content>
