using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Registro
{
    public partial class MPRegistro : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Empresa"] != null)
            {
                UserControl menuEmpresa = (UserControl)Page.LoadControl("~/Script/menuEmpresa.ascx");
                cpMenu.Controls.Add(menuEmpresa);

            }
            if (Session["Local"] != null)
            {
                UserControl menuLocal = (UserControl)Page.LoadControl("~/Script/menuLocal.ascx");
                cpMenu.Controls.Add(menuLocal);
            }
        }
    }
}