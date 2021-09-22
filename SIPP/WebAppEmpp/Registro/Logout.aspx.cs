using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Registro
{
    public partial class Logout : WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkSesion();
            Session["Empresa"] = null;
            
            Session["rutEmpresa"] = null;
            Session["passEmpresa"] = null;
            Session["Local"] = null;
            Response.Redirect("/Default.aspx");

        }
    }
}