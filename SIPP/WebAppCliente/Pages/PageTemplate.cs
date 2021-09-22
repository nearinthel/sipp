using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCliente.Pages
{
    public partial class PageTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // this.checkSesion();
        }

        protected void checkSesion()
        {
            if (Session["Usuario"] == null)
            {
                Session["PrevPage"] = HttpContext.Current.Request.Url.AbsoluteUri;
                Response.Redirect("/Pages/Account/Login.aspx");
            }
        }
    }
}