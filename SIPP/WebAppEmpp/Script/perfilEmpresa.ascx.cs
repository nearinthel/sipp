using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Script
{
    public partial class perfilEmpresa : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entities.DTOs.DTOEmpresa enterprise = new Entities.DTOs.DTOEmpresa();
            RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();

            enterprise = (Entities.DTOs.DTOEmpresa)Session["Empresa"];
            lblRSocial.Text = enterprise.RazonSocial;
            lblRut.Text = enterprise.Rut.ToString();
            lblTelefono.Text = enterprise.Telefono;
            imgLogo.ImageUrl = "/Images/Logos/" + enterprise.Rut + "/Logo.jpg";
        }
    }
}