using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Catalogo_Web
{
    public partial class ProductList : System.Web.UI.Page
    {
        public bool advancedFilter { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            advancedFilter = chkAvanzado.Checked;
            dgvProducts.DataSource = Session["productList"];
            dgvProducts.DataBind();

            if (!IsPostBack)
            {
                ProductBusiness business = new ProductBusiness();
                List<Product> products = business.list();
                Session.Add("productList", products); 
                dgvProducts.DataSource = products;
                dgvProducts.DataBind();
            }
        }

        protected void dgvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProducts.PageIndex = e.NewPageIndex;
            dgvProducts.DataBind();
        }

        protected void dgvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvProducts.SelectedDataKey.Value.ToString();
            Response.Redirect("ProductForm.aspx?id=" + id);
        }

        protected void filter_TextChanged(object sender, EventArgs e)
        {
            List<Product> list = (List<Product>)Session["productList"];
            List<Product> filteredList = list.FindAll(x => x.name.ToUpper().Contains(txtFilter.Text.ToUpper()));
            dgvProducts.DataSource = filteredList;
            dgvProducts.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            advancedFilter = chkAvanzado.Checked;
            txtFilter.Enabled = !advancedFilter;
        }

        protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = ddlField.Text;

            BrandBusiness brandBusiness = new BrandBusiness();
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            txtAdvancedFilter.Enabled = true;
            try
            {
                switch (option)
                {
                    case "Marca":
                        ddlCriterion.Items.Clear();
                        List<Brand> brandItems = brandBusiness.list();

                        foreach (Brand item in brandItems)
                        {
                            ddlCriterion.Items.Add(item.ToString());
                        }

                        txtAdvancedFilter.Enabled = false;

                        break;
                    case "Categoria":
                        ddlCriterion.Items.Clear();
                        List<Category> categoryItems = categoryBusiness.list();

                        foreach (Category item in categoryItems)
                        {
                            ddlCriterion.Items.Add(item.ToString());
                        }

                        txtAdvancedFilter.Enabled = false;

                        break;
                    case "Precio":
                        ddlCriterion.Items.Clear();
                        ddlCriterion.Items.Add("Mayor a");
                        ddlCriterion.Items.Add("Menor a");
                        break;
                    case "Codigo":
                        ddlCriterion.Items.Clear();
                        ddlCriterion.Items.Add("Letra");
                        ddlCriterion.Items.Add("Numero");
                        ddlCriterion.Items.Add("Codigo completo");
                        break;
                    case "Descripcion":
                        ddlCriterion.Items.Clear();
                        ddlCriterion.Items.Add("Contiene");
                        ddlCriterion.Items.Add("Termina con");
                        ddlCriterion.Items.Add("Empieza con");
                        break;
                    default:
                        ddlCriterion.Items.Clear();
                        break;
                }
            }
            catch (Exception)
            {
                //
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ProductBusiness negocio = new ProductBusiness();
                dgvProducts.DataSource = negocio.filter(
                    ddlField.SelectedItem.ToString(),
                    ddlCriterion.SelectedItem.ToString(),
                    txtAdvancedFilter.Text
                    );
                dgvProducts.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}