<%@ Page Title="Listado de productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Catalogo_Web.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Listado de productos</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFilter" CssClass="form-control" AutoPostBack="true" OnTextChanged="filter_TextChanged" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado"
                    CssClass="" ID="chkAvanzado" runat="server"
                    AutoPostBack="true"
                    OnCheckedChanged="chkAvanzado_CheckedChanged" />
            </div>
        </div>

        <%if (chkAvanzado.Checked)
            { %>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblField" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlField" OnSelectedIndexChanged="ddlField_SelectedIndexChanged">
                        <asp:ListItem Text="-- Seleccionar --" />
                        <asp:ListItem Text="Precio" />
                        <asp:ListItem Text="Marca" />
                        <asp:ListItem Text="Codigo" />
                        <asp:ListItem Text="Categoria" />
                        <asp:ListItem Text="Descripcion" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterion" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtAdvancedFilter" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnSearch" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>
        <%} %>
    </div>
    <asp:GridView ID="dgvProducts" runat="server" DataKeyNames="id"
        CssClass="table" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvProducts_SelectedIndexChanged"
        OnPageIndexChanging="dgvProducts_PageIndexChanging"
        AllowPaging="True" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="name" />
            <asp:BoundField HeaderText="Codigo" DataField="code" />
            <asp:BoundField HeaderText="Categoria" DataField="category" />
            <asp:BoundField HeaderText="Precio" DataField="price" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>
    <a href="ProductForm.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
