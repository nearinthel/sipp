using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebAppEmpp.Registro
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

  protected void cvRut_ServerValidate(object source, ServerValidateEventArgs args)
        {
            RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
            bool disponible=proxy.comprobarRut(long.Parse(args.Value.ToString()));
            args.IsValid = true;
            if (disponible == false)
            {
                args.IsValid = false;
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                Entities.DTOs.DTOEmpresa dt = new Entities.DTOs.DTOEmpresa();
                dt.Rut = long.Parse(txtRut.Text);

                dt.RazonSocial = txtRSocial.Text.Trim().ToLower();
                dt.Telefono = txtTelefono.Text;
                dt.Pass = proxy.encodePass(txtContrasenia.Text.Trim());

                proxy.registroEmpresa(dt);
                Session["Empresa"] = dt;
                Session["rutEmpresa"] = dt.Rut;


                Session["passEmpresa"] = proxy.encodePass(dt.Pass);

                Response.Redirect("PerfilEmpresa.aspx");
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>Console.log('Error:" + exe.StackTrace+ "');</script>");
            }
        }

      
    }
}