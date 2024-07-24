<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .product-image {
            width: 250px; /* Ajusta este valor según tus necesidades */
            height: 250px; /* Ajusta este valor según tus necesidades */
            display: flex;
            justify-content: center;
            align-items: center;
            overflow: hidden;
        }
        .product-image img {
            max-width: 100%;
            max-height: 100%;
        }
    </style>
    <main>
        <h2 class="mt-4">Bienvenido a nuestro catalogo de productos </h2>
        <h5 class="mt-4">Buscar:</h5>
        <div class="row my-4">
            <div class="col-6">
                <div class="mb-3">
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
                        <asp:Label runat="server" ID="lblError" CssClass="border border-danger bg-danger bg-opacity-25 p-2 my-3 d-block" />
                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnSearch" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
            <%} %>
        </div>

<div class="row row-cols-1 row-cols-md-3 g-4 mb-5">
    <asp:Repeater runat="server" ID="repProductGrid">
        <ItemTemplate>
            <div class="col">
                <div class="border rounded-1 p-3 h-100 d-flex flex-column">
                    <div class="product-image mx-auto">
                        <img src="<%#Eval("imageUrl") %>" class="img-fluid" alt="...">
                    </div>
                    <div class="card-body flex-column flex-lg-grow-1 align-content-end">
                        <h5 class="card-title"><%#Eval("name") %></h5>
                        <p class="card-text"><%#Eval("description")%></p>
                        <a class="btn btn-outline-primary" href="ProductDetail.aspx?id=<%#Eval("id") %>">Ver Detalle</a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
    </main>

</asp:Content>
