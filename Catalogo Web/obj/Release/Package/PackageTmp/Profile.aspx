<%@ Page Title="Mi perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Catalogo_Web.Profile" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h2 class="mt-5">Mi perfil</h2>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email: </label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtName" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtSurname" class="form-label">Apellido: </label>
                <asp:TextBox runat="server" ID="txtSurname" CssClass="form-control" />
            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImageUrl" class="form-label">Url Imagen de perfil:</label>
                        <asp:TextBox runat="server" ID="txtImageUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImageUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                        runat="server" ID="imgProfile" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mb-3">
                <asp:Button Text="Editar" ID="btnEdit" CssClass="btn btn-warning m-2" OnClick="btnEdit_Click" runat="server" />
                <asp:Button Text="Guardar" ID="btnSave" CssClass="btn btn-primary m-2" OnClick="btnSave_Click" runat="server" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Borrar mi cuenta" ID="btnEliminar" OnClick="btnDelete_Click" CssClass="btn btn-danger" runat="server" />
                    </div>

                    <%if (ConfirmDelete)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirme que quiere eliminar su cuenta, no podra recuperarla luego de hacerlo" ID="chkConfirmDelete" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmDelete_Click" CssClass="btn btn-outline-danger" runat="server" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>

</asp:Content>
