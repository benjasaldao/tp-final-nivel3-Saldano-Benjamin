using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo_Web
{
    public partial class CategoryForm : System.Web.UI.Page
    {
        public bool ConfirmDelete { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmDelete = false;
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    CategoryBusiness business = new CategoryBusiness();
                    Category selected = (business.list(id))[0];

                    Session.Add("selectedBrand", selected);

                    txtId.Text = id;
                    txtName.Text = selected.description;

                }
                else
                {
                    btnEliminar.Visible = false;
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
                if (txtName.Text == "")
                {
                    throw new Exception("Debes completar el campo de nombre");
                }

                Category newCategory = new Category();
                CategoryBusiness business = new CategoryBusiness();

                newCategory.description = txtName.Text;

                if (Request.QueryString["id"] != null)
                {
                    newCategory.id = int.Parse(txtId.Text);
                    business.update(newCategory);
                }
                else
                    business.add(newCategory);


                Response.Redirect("CategoryList.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
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
                    CategoryBusiness business = new CategoryBusiness();
                    Category selected = (Category)Session["selectedCategory"];
                    business.delete(selected);
                    Response.Redirect("categoryList.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}