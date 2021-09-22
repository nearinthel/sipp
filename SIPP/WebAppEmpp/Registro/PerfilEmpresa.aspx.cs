using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Registro
{
    public partial class PerfilEmpresa : WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.checkSesion();


                Entities.DTOs.DTOEmpresa enterprise = new Entities.DTOs.DTOEmpresa();
                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();

                enterprise = (Entities.DTOs.DTOEmpresa)Session["Empresa"];
                lblRSocial.Text = enterprise.RazonSocial;
                lblRut.Text = enterprise.Rut.ToString();
                lblTelefono.Text = enterprise.Telefono;
                imgLogo.ImageUrl = "/Images/Logos/" + enterprise.Rut + "/Logo.jpg";
                    

                
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }


        }
    }
}