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
    public partial class BrandList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BrandBusiness business = new BrandBusiness();
                Session.Add("brandList", business.list());
                dgvBrands.DataSource = Session["brandList"];
                dgvBrands.DataBind();
            }
        }

        protected void filter_TextChanged(object sender, EventArgs e)
        {
            List<Brand> list = (List<Brand>)Session["brandList"];
            List<Brand> filteredList = list.FindAll(x => x.description.ToUpper().Contains(txtFilter.Text.ToUpper()));
            dgvBrands.DataSource = filteredList;
            dgvBrands.DataBind();
        }

        protected void dgvBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvBrands.SelectedDataKey.Value.ToString();
            Response.Redirect("BrandForm.aspx?id=" + id);
        }

        protected void dgvBrands_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvBrands.PageIndex = e.NewPageIndex;
            dgvBrands.DataBind();
        }
    }
}