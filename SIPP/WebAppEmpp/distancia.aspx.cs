using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp
{
    public partial class distancia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                RemoteServiceLocal.IServiceLocal contolar = new RemoteServiceLocal.ServiceLocalClient();
                List<Entities.DTOs.DTOLocal> sucursales = contolar.getLocalesPorLocalidad("Maldonado").ToList();
                rptMarkers.DataSource = sucursales;
                rptMarkers.DataBind();
            }

        }
    }
}