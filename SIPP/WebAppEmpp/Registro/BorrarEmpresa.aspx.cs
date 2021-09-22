using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Registro
{
    public partial class BorrarEmpresa : WebAppEmpp.PageTemplate
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
                imgLogo.ImageUrl = "/Logos/" + enterprise.Rut + "/Logo.jpg";
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }
            
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.DTOs.DTOEmpresa enterprise = new Entities.DTOs.DTOEmpresa();
                enterprise = (Entities.DTOs.DTOEmpresa)Session["Empresa"];

                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                proxy.borrarEmpresa(enterprise.Rut);
          
                string url = "/Images/Logos/" + enterprise.Rut;
                if (System.IO.Directory.Exists(Server.MapPath(url)))
                {
                    System.IO.Directory.Delete(Server.MapPath(url), true);
                }
                Response.Redirect("/Default.aspx");
                
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>Console.log('Error:" + exe.Message + "');</script>");
            }
           
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("PerfilEmpresa.aspx");
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }
        }
    }//this.Controls.Add(Page.LoadControl("PerfilEmpresa.aspx"));
}