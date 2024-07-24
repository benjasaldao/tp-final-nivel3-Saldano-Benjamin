<%@ Page Title="Marcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrandList.aspx.cs" Inherits="Catalogo_Web.BrandList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Listado de marcas</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFilter" CssClass="form-control" AutoPostBack="true" OnTextChanged="filter_TextChanged" />
            </div>
        </div>
    </div>
    <asp:GridView ID="dgvBrands" runat="server" DataKeyNames="id"
        CssClass="table" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvBrands_SelectedIndexChanged"
        OnPageIndexChanging="dgvBrands_PageIndexChanging"
        AllowPaging="True" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="description" />
            <asp:BoundField HeaderText="Id" DataField="id" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Cambiar nombre" />
        </Columns>
    </asp:GridView>
    <a href="BrandForm.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
