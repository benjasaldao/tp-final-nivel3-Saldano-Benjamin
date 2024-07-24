<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="Catalogo_Web.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mx-auto">
        <div class="col-4">
            <asp:Image runat="server" ID="imgProduct" class="img-fluid" alt="..."></asp:Image>
            <p>
                <asp:Label runat="server" ID="lblDescription"></asp:Label>
            </p>
        </div>

        <div class="col-1"></div>

        <div class="col-4">
            <h3>
                <asp:Label runat="server" ID="lblName"></asp:Label></h3>
            <h6 class="mb-0">Precio:</h6>
            <asp:Label CssClass="mb-2 d-block" runat="server" ID="lblPrice"></asp:Label>

            <h6 class="mb-0">Categoria:</h6>
            <asp:Label CssClass="mb-2 d-block" runat="server" ID="lblCategory"></asp:Label>

            <h6 class="mb-0">Marca:</h6>
            <asp:Label CssClass="mb-2 d-block" runat="server" ID="lblBrand"></asp:Label>

            <h6 class="mb-0">Codigo del producto:</h6>
            <asp:Label CssClass="mb-2 d-block" runat="server" ID="lblCode"></asp:Label>


            <% if (isFavorite)
            { %>
            <asp:Button Text="Eliminar de favoritos " ID="btnDeleteFav" OnClick="btnDeleteFav_Click" CssClass="btn btn-warning" runat="server" />
            <% }
            else
            {  %>
            <asp:Button Text="Añadir a favoritos ❤️" ID="btnFav" OnClick="btnFav_Click" CssClass="btn btn-primary" runat="server" />
            <% } %>
        </div>

    </div>

</asp:Content>
