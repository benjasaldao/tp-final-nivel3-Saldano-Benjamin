<%@ Page Title="Formulario marcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrandForm.aspx.cs" Inherits="Catalogo_Web.BrandForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id:</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescription" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAccept" CssClass="btn btn-primary" OnClick="btnAccept_Click" runat="server" />
                <a href="BrandList.aspx">Cancelar</a>
            </div>
        </div>
        <div class="col-6 d-flex align-items-center">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnDelete_Click" CssClass="btn btn-danger" runat="server" />
                        </div>

                        <%if (ConfirmDelete)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmDelete" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmDelete_Click" CssClass="btn btn-outline-danger" runat="server" />
                        </div>
                        <%} %>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
