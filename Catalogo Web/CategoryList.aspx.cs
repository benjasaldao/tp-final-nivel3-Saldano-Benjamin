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
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoryBusiness business = new CategoryBusiness();
                Session.Add("categoryList", business.list());
                dgvCategories.DataSource = Session["categoryList"];
                dgvCategories.DataBind();
            }
        }

        protected void filter_TextChanged(object sender, EventArgs e)
        {
            List<Brand> list = (List<Brand>)Session["categoryList"];
            List<Brand> filteredList = list.FindAll(x => x.description.ToUpper().Contains(txtFilter.Text.ToUpper()));
            dgvCategories.DataSource = filteredList;
            dgvCategories.DataBind();
        }

        protected void dgvCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvCategories.SelectedDataKey.Value.ToString();
            Response.Redirect("CategoryForm.aspx?id=" + id);
        }

        protected void dgvCategories_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCategories.PageIndex = e.NewPageIndex;
            dgvCategories.DataBind();
        }
    }
}