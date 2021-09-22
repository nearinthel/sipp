using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.DTOs;
using Entities;

namespace WebAppCliente.Pages.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();
            DTOUsuario dt = new DTOUsuario();
            dt.Email = txtUserName.Text;
            dt.Pass = txtPassword.Text;
            dt = proxy.loginUsuario(dt);
            Usuario usr = new Usuario(dt);
            if(dt.Id != 0){
                lblEstado.CssClass = "okLogin";
                lblEstado.Text = "Login Correcto";
                Session["Usuario"] = usr;
                String prevPage = "/Pages/Account/EditarPerfil.aspx";
                if (Session["PrevPage"] != null)
                {
                    prevPage = (String) Session["PrevPage"];
                }
                Response.Redirect(prevPage);
            }else{
                lblEstado.CssClass = "errorLogin";
                lblEstado.Text = "Usuario o contraseña incorrecta";
            }
        }

    }
}