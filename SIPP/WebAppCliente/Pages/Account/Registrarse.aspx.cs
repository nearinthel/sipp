using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;

namespace WebAppCliente.Pages.Account
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();
            DTOUsuario dt = new DTOUsuario();
            dt.Nombre = txtNombre.Text;
            dt.Apellido = txtApellido.Text;
            dt.Celular = txtCelular.Text;
            dt.Telefono = txtTelefono.Text;
            dt.Email = txtEmail.Text;
            dt.Pass = Encript.EncodePassword(txtPassword.Text);

            dt = proxy.registroUsuario(dt);

            if (dt.Id != 0)
            {
                //lblNombre.CssClass = "okLogin";
                //lblNombre.Text = "Registrado Id:"+dt.Id;
                //crear sesion
                string r = Response.RedirectLocation;
                Session["Usuario"] = new Usuario(dt);
                
               // Response.Write("<script language=javascript>alert('Registrado Correctamente Id de Usuario:"+dt.Id+"');</script>");
                Server.Transfer("EditarPerfil.aspx", true);
                
            }
            else
            {
                //lblNombre.CssClass = "errorLogin";
               // Response.Write("<script language=javascript>alert('Registro Incorrecto:" + dt.Id + "');</script>");
                
            }


           
        }

        protected void comprobarEmail(object sender, EventArgs e)
        {
            RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();
            string email = "";
            bool usado = false;
            DTOUsuario us = new DTOUsuario();

            email = txtEmail.Text;
            us.Email = email;
            usado = proxy.ComprobarEmail(us);

            if (usado == true)
            {
                lblComprobarEmail.CssClass = "errorReg";
                lblComprobarEmail.Text = "Email NO Disponible";
            }
            else
            {
                if (usado == true)
                {
                    lblComprobarEmail.CssClass = "okReg";
                    lblComprobarEmail.Text = "Email Disponible";
                }
            }
        
            //Label1.Text = "hola";
        }
    }
}