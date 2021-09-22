using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.PedidosPorLocal
{
    public partial class LogoutLocal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Empresa"] = null;

            Session["rutEmpresa"] = null;
            Session["passEmpresa"] = null;
            Session["Local"] = null;
            Response.Redirect("LoginLocal.aspx");
        }
    }
}