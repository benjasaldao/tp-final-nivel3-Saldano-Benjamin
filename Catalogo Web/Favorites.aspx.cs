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
    public partial class Favorites : System.Web.UI.Page
    {
        public List<Product> favorites = new List<Product>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductBusiness business = new ProductBusiness();
            User user = new User();
            user = (User)Session["user"];
            favorites = business.getFavorites(user.id);

            if (!IsPostBack)
            {
                repFavoritesGrid.DataSource = favorites;
                repFavoritesGrid.DataBind();
            }
        }
    }
}