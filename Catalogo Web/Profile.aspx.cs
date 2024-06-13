using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace Catalogo_Web
{
    public partial class Profile : System.Web.UI.Page
    {
        public bool ConfirmDelete { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Visible = false;

            if (!IsPostBack)
            {
                txtEmail.Enabled = false;
                txtName.Enabled = false;
                txtSurname.Enabled = false;
                txtImageUrl.Enabled = false;
                User user = new User();
                user = (User)Session["user"];

                txtEmail.Text = user.email;
                txtName.Text = user.name;
                txtSurname.Text = user.surname;
                txtImageUrl.Text = user.imageUrl;
                if (!string.IsNullOrEmpty(user.imageUrl) && txtEmail.Text != "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png")
                {
                    imgProfile.ImageUrl = user.imageUrl;
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtSurname.Enabled = true;
            txtName.Enabled = true;
            txtEmail.Enabled = true;
            txtImageUrl.Enabled = true;
            btnSave.Visible = true;

            btnEdit.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UserBusiness userBusiness = new UserBusiness();
                User user = new User();
                user = (User)Session["user"];

                user.email = txtEmail.Text;
                user.name = txtName.Text;
                user.surname = txtSurname.Text;
                user.imageUrl = txtImageUrl.Text;

                userBusiness.update(user);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            txtEmail.Enabled = false;
            txtName.Enabled = false;
            txtSurname.Enabled = false;
            txtImageUrl.Enabled = false;

            btnEdit.Visible = true;
        }

        protected void txtImageUrl_TextChanged(object sender, EventArgs e)
        {
            imgProfile.ImageUrl = txtImageUrl.Text;
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
                    UserBusiness userBusiness = new UserBusiness();
                    User selected = (User)Session["user"];
                    userBusiness.delete(selected);
                    Session.Clear();
                    Response.Redirect("Login.aspx", false);
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