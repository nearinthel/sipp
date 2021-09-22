using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Empresa"] != null)
            {
                Entities.DTOs.DTOEmpresa enterprise = (Entities.DTOs.DTOEmpresa)Session["Empresa"];
                string url = "/Images/Logos/" + enterprise.Rut + "/Logo.jpg";
                if (System.IO.File.Exists(Server.MapPath(url)))
                {
                    imgLogo.ImageUrl = "/Images/Logos/" + enterprise.Rut + "/Logo.jpg";
                }
                else
                {
                    imgLogo.ImageUrl = "/Images/LogoEmpresa.png";
                }
            }
            else
            {


                if (Session["Local"] != null)
                {
                    Entities.DTOs.DTOLocal sucursal = (Entities.DTOs.DTOLocal)Session["Local"];
                    string url="/Images/Logos/" + sucursal.Rut_empresa + "/Logo.jpg";
                    if (System.IO.File.Exists(Server.MapPath(url)))
                    {
                        imgLogo.ImageUrl = url;
                    }
                    else
                    {
                        imgLogo.ImageUrl = "/Images/LogoEmpresa.png";
                    }


                }
                else
                {

                    imgLogo.ImageUrl = "/Images/LogoEmpresa.png";
                }
            }

        }
    }
}