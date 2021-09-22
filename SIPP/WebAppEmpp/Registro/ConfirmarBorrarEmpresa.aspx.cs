using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Registro
{
    public partial class ConfirmarBorrarEmpresa : WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkSesion();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                string pass = Session["passEmpresa"].ToString();
                string rut=Session["rutEmpresa"].ToString();
                string nombre = ((Entities.DTOs.DTOEmpresa)Session["Empresa"]).RazonSocial;
                if (proxy.encodePass(txtPass.Text) == pass)
                {
                    Response.Write("<script language=javascript>alert('La empresa se borrara');</script>");
                    proxy.borrarEmpresa(long.Parse(rut));

                    Response.Redirect("Logout.aspx");

                }
                else
                {
                    Response.Write("<script language=javascript>alert('Contraseña equivocada la empresa'" + nombre + " no se borrara);</script>");
                    Response.Redirect("PerfilEmpresa.aspx");
                }
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
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
    }
}