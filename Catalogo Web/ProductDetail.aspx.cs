using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using Dominio;

namespace Catalogo_Web
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        public bool isFavorite { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ProductBusiness negocio = new ProductBusiness();
                    Product product = (negocio.list(id))[0];

                    Session.Add("product", product);



                    // Cargamos la informacion del producto
                    lblName.Text = product.name;
                    lblDescription.Text = product.description;
                    imgProduct.ImageUrl = product.imageUrl;
                    lblPrice.Text = product.price.ToString();
                    lblCategory.Text = product.category.description;
                    lblBrand.Text = product.brand.description;
                    lblCode.Text = product.code;

                    // Chequeamos si existe en favoritos del usuario
                    if (Security.activeSession(Session["user"]))
                    {
                        User user = new User();
                        user = (User)Session["user"];
                        isFavorite = negocio.isFavorite(product.id, user.id);
                    }
                }


            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnFav_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user = (User)Session["user"];

                Product product = new Product();
                product = (Product)Session["product"];

                ProductBusiness business = new ProductBusiness();
                bool added = business.addFavorite(product.id, user.id);

                if (added)
                {
                    isFavorite = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnDeleteFav_Click(Object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user = (User)Session["user"];

                Product product = new Product();
                product = (Product)Session["product"];

                ProductBusiness business = new ProductBusiness();
                bool deleted = business.deleteFavorite(product.id, user.id);

                if (deleted)
                {
                    isFavorite = false;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}