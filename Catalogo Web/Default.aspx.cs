using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;

namespace Catalogo_Web
{
    public partial class _Default : Page
    {
        public List<Product> productList { get; set; }
        public List<Product> filteredList { get; set; }
        public bool advancedFilter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductBusiness business = new ProductBusiness();
            productList = business.list();

            advancedFilter = chkAvanzado.Checked;
            lblError.Visible = false;


            if (!IsPostBack)
            {
                repProductGrid.DataSource = productList;
                repProductGrid.DataBind();
            }
        }

        protected void filter_TextChanged(object sender, EventArgs e)
        {
            filteredList = productList.FindAll(x => x.name.ToUpper().Contains(txtFilter.Text.ToUpper()));
            repProductGrid.DataSource = filteredList;
            repProductGrid.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            advancedFilter = chkAvanzado.Checked;
            txtFilter.Text = "";
            txtFilter.Enabled = !advancedFilter;
            repProductGrid.DataSource = productList;
            repProductGrid.DataBind();
        }

        protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = ddlField.Text;
            txtAdvancedFilter.Text = "";

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
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlField.SelectedItem.ToString() == "-- Seleccionar --")
                {
                    throw new Exception("Debes elegir un campo por el cual filtrar");
                }
                if (ddlCriterion.SelectedItem.ToString() == null)
                {
                    throw new Exception("Debes elegir un criterio");
                }
                if (txtAdvancedFilter.Text == "" && txtAdvancedFilter.Enabled) 
                {
                    throw new Exception("Debes completar el campo filtro");
                }

                ProductBusiness negocio = new ProductBusiness();
                repProductGrid.DataSource = negocio.filter(
                    ddlField.SelectedItem.ToString(),
                    ddlCriterion.SelectedItem.ToString(),
                    txtAdvancedFilter.Text
                    );
                repProductGrid.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

    }
}