using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Domain;
using Utilities;

namespace Catalogo_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserBusiness userBusiness = new UserBusiness();

            try
            {
                if (txtEmail.Text == "")
                {
                    throw new Exception("Debes completar el campo Email");
                }
                if (!ValidationUtilities.validEmail(txtEmail.Text))
                {
                    throw new Exception("Ingrese un email con un formato valido");
                }
                if (txtPassword.Text == "")
                {
                    throw new Exception("Debes completar el campo contraseña");
                }


                user.email = txtEmail.Text;
                user.password = txtPassword.Text;

                if (userBusiness.login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("/", false);
                }
                else
                {
                    throw new Exception("Email o Contraseña incorrectos");
                }

            } catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                showError(ex.Message);
            }
        }

        private void showError(string error)
        {
            lblError.Visible = true;
            lblError.Text = error;
        }
    }
}