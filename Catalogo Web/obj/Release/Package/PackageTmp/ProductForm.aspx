<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductForm.aspx.cs" Inherits="Catalogo_Web.ProductForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id:</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtName" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCode" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="txtCode" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPrice" class="form-label">Precio: </label>
                <asp:TextBox  runat="server" ID="txtPrice" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlCategory" class="form-label">Categoria: </label>
                <asp:DropDownList ID="ddlCategory" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlBrand" class="form-label">Marca:</label>
                <asp:DropDownList ID="ddlBrand" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" ID="lblError" Visible="false" CssClass="border border-danger bg-danger bg-opacity-25 p-2 my-3 d-block" />
                <asp:Button Text="Aceptar" ID="btnAccept" CssClass="btn btn-primary" OnClick="btnAccept_Click" runat="server" />
                <a href="ProductList.aspx">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescription" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescription" CssClass="form-control" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImageUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImageUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImageUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                        runat="server" ID="imgProduct" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
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
