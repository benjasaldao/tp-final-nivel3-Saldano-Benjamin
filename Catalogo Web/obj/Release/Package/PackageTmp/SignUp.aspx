<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Catalogo_Web.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-8 border mx-auto my-5 p-5">
            <h2>Registrate</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
            </div>
            <div class="mb-3">
                <label class="form-label">Repetir contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtRepeatPassword" TextMode="Password" />
            </div>

            <asp:Label runat="server" ID="lblError" CssClass="border border-danger bg-danger bg-opacity-25 p-2 my-3 d-block" />

            <p>Ya tenes una cuenta? <a href="Login.aspx">Inicia sesion</a></p>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Registrarme" ID="btnLogin" OnClick="btnSignup_Click" />
        </div>
    </div>

</asp:Content>
