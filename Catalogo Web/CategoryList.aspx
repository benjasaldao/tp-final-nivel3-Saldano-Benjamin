<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="Catalogo_Web.CategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Listado de categorias</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFilter" CssClass="form-control" AutoPostBack="true" OnTextChanged="filter_TextChanged" />
            </div>
        </div>
    </div>
    <asp:GridView ID="dgvCategories" runat="server" DataKeyNames="id"
        CssClass="table" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvCategories_SelectedIndexChanged"
        OnPageIndexChanging="dgvCategories_PageIndexChanging"
        AllowPaging="True" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="description" />
            <asp:BoundField HeaderText="Id" DataField="id" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Cambiar nombre" />
        </Columns>
    </asp:GridView>
    <a href="CategoryForm.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
