<%@ Page Title="Ingresar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Catalogo_Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-8 my-5 mx-auto border rounded p-5">
            <h2>Login</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
            </div>
            <p>No tenes una cuenta? <a class="" href="SignUp.aspx">Registrarme</a></p>

            <asp:Label runat="server" ID="lblError" CssClass="border border-danger bg-danger bg-opacity-25 p-2 my-3 d-block" />

            <asp:Button runat="server" CssClass="btn btn-primary" Text="Ingresar" ID="btnLogin" OnClick="btnLogin_Click" />
        </div>
    </div>

</asp:Content>
