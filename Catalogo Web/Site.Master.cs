using Dominio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;

namespace Catalogo_Web
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            if (!(Page is Login || Page is SignUp || Page is _Default || Page is Error) && !Security.activeSession(Session["user"]))
            {
                Response.Redirect("Login.aspx", false);
            }
            else if (Security.activeSession(Session["user"]))
            {
                User user = (User)Session["user"];
                if (!string.IsNullOrEmpty(user.imageUrl))
                    imgAvatar.ImageUrl = user.imageUrl;

            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}