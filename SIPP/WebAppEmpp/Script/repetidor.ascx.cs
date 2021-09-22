using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Script
{
    public partial class repetidor : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
            long rutEmpresa = this.rutEmpresa;
            List<Entities.DTOs.DTOLocal> sucursales = this.getSucursales(rutEmpresa);//proxy.getLocalesPorEmpresa(rutEmpresa).ToList();
            rptMarkers.DataSource = sucursales;
            rptMarkers.DataBind();

        }
        public long rutEmpresa { get; set; }
        //public List<Entities.DTOs.DTOLocal> sucursales { get; set; }

        public List<Entities.DTOs.DTOLocal> getSucursales(long rutEmpresa){
            
            RemoteServiceLocal.IServiceLocal proxy= new RemoteServiceLocal.ServiceLocalClient();
            List<Entities.DTOs.DTOLocal> sucursales=proxy.getLocalesPorEmpresa(rutEmpresa).ToList();
            return sucursales;
        }
    }
}