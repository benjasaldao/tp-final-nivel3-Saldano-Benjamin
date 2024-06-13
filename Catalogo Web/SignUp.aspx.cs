using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Domain;
using Utilities;

namespace Catalogo_Web
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {

            try
            {
                User user = new User();
                UserBusiness userBusiness = new UserBusiness();

                validateForm();


                user.email = txtEmail.Text;
                user.password = txtPassword.Text;
                user.name = "";
                user.surname = "";
                user.imageUrl = "";

                if (userBusiness.create(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("/", false);
                }
                else
                {
                    Session.Add("error", "Hubo un problema al registrarse");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                showError(ex.Message);
                Session.Add("error", ex.Message);
            }
        }

        protected void showError(string error)
        {
            lblError.Visible = true;
            lblError.Text = error;
        }

        protected void validateForm()
        {
            if (txtEmail.Text == "")
            {
                throw new Exception("Debes completar el campo mail");
            }

            if (!ValidationUtilities.validEmail(txtEmail.Text))
            {
                throw new Exception("Ingrese un email con formato valido");
            }

            if (txtPassword.Text == "")
            {
                throw new Exception("Ingrese una contraseña");
            }

            if (txtRepeatPassword.Text == "")
            {
                throw new Exception("Repita su contraseña");
            }

            if (!(txtPassword.Text == txtRepeatPassword.Text))
            {
                throw new Exception("Las contraseñas no coinciden");
            }
        }
    }
}