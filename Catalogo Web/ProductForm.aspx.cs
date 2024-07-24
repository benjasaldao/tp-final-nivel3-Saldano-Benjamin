using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Utilities;

namespace Catalogo_Web
{
    public partial class ProductForm : System.Web.UI.Page
    {
        public bool ConfirmDelete { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmDelete = false;
            try
            {
                if (!IsPostBack)
                {
                    CategoryBusiness categoryBusiness = new CategoryBusiness();
                    List<Category> categories = categoryBusiness.list();

                    BrandBusiness brandBusiness = new BrandBusiness();
                    List<Brand> brands = brandBusiness.list();

                    ddlCategory.DataSource = categories;
                    ddlCategory.DataValueField = "id";
                    ddlCategory.DataTextField = "description";
                    ddlCategory.DataBind();

                    ddlBrand.DataSource = brands;
                    ddlBrand.DataValueField = "id";
                    ddlBrand.DataTextField = "description";
                    ddlBrand.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ProductBusiness negocio = new ProductBusiness();
                    Product selected = (negocio.list(id))[0];

                    Session.Add("selectedProduct", selected);

                    Page.Title = selected.name;

                    txtId.Text = id;
                    txtName.Text = selected.name;
                    txtDescription.Text = selected.description;
                    txtPrice.Text = Math.Round(selected.price).ToString();
                    txtImageUrl.Text = selected.imageUrl;
                    txtCode.Text = selected.code.ToString();

                    ddlCategory.SelectedValue = selected.category.id.ToString();
                    ddlBrand.SelectedValue = selected.brand.id.ToString();
                    txtImageUrl_TextChanged(sender, e);


                }
                else
                {
                    btnEliminar.Visible = false;
                    Page.Title = "Añadir producto";
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                validateForm();

                Product newProduct = new Product();
                ProductBusiness negocio = new ProductBusiness();

                newProduct.code = txtCode.Text;
                newProduct.name = txtName.Text;
                newProduct.description = txtDescription.Text;
                newProduct.imageUrl = txtImageUrl.Text;
                newProduct.price = int.Parse(txtPrice.Text);

                newProduct.category = new Category();
                newProduct.category.id = int.Parse(ddlCategory.SelectedValue);
                newProduct.brand = new Brand();
                newProduct.brand.id = int.Parse(ddlBrand.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    newProduct.id = int.Parse(txtId.Text);
                    negocio.update(newProduct);
                }
                else
                    negocio.add(newProduct);


                Response.Redirect("ProductList.aspx", false);
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }

        protected void txtImageUrl_TextChanged(object sender, EventArgs e)
        {
            imgProduct.ImageUrl = txtImageUrl.Text;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ConfirmDelete = true;
        }

        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmDelete.Checked)
                {
                    ProductBusiness negocio = new ProductBusiness();
                    Product selected = (Product)Session["selectedProduct"];
                    negocio.delete(selected);
                    Response.Redirect("ProductList.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void validateForm()
        {
            if (txtName.Text == "")
            {
                throw new Exception("Es necesario agregar un nombre");
            }

            if (txtCode.Text == "")
            {
                throw new Exception("Es necesario agregar un codigo de producto");
            }

            if (!ValidationUtilities.isProductCode(txtCode.Text))
            {
                throw new Exception("Ingrese un codigo con el formato correcto");
            }

            if (txtPrice.Text == "")
            {
                throw new Exception("Es necesario agregar un precio");
            }
            if (!ValidationUtilities.onlyNumbers(txtPrice.Text))
            {
                throw new Exception("Solo se pueden ingresar numeros en el precio");
            }
        }

        protected void showError(string error)
        {
            lblError.Visible = true;
            lblError.Text = error;
        }
    }
}