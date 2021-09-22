using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Local
{
    public partial class LoginLocal : WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                Entities.DTOs.DTOLocal sucursal = new Entities.DTOs.DTOLocal();
                string nombreLocal = txtLocal.Text.Trim().ToLower();
                string pass = proxy.encodePass(txtPass.Text.Trim());
                sucursal = proxy.loginLocal(nombreLocal, pass);
                if (sucursal != null)
                {
                    Session["Local"] = sucursal;
                    Response.Redirect("verPedidos.aspx");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('No existe ese local');</script>");
                }
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Local incorrecto o pass incorrecto');</script>");
            }

        }

        protected void cvLocal_ServerValidate(object source, ServerValidateEventArgs args)
        {
            RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
            
            bool existe = proxy.comprobarNombreLocalLogin(args.Value.ToString().Trim().ToLower());
            args.IsValid = false;
            if (existe !=false)
            {
                args.IsValid = true;
            }
           
        }
    }
}