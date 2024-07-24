<%@ Page Title="Mis favoritos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favorites.aspx.cs" Inherits="Catalogo_Web.Favorites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h2>Mis productos favoritos</h2>

        <div class="row row-cols-1 row-cols-md-3 g-4 mb-5">
            <asp:Repeater runat="server" ID="repFavoritesGrid">
                <ItemTemplate>
                    <div class="col">
                        <div class="border rounded-1 p-3 h-100 d-flex flex-column">
                            <div class="mx-auto">
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
    </div>

</asp:Content>
