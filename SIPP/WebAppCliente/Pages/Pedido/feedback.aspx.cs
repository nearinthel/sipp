using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCliente.Pages.Pedido
{
    public partial class feedback : WebAppCliente.Pages.PageTemplate
    {
        public String com;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkSesion();
            
            String loc = Request.QueryString["loc"];
            Usuario usr = (Usuario)Session["Usuario"];
                 imgPerfil.ImageUrl = "/UploadedImages/" + usr.Id + "/Perfil.jpg";
            

           RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();

            DTOEmpresa emp = new DTOEmpresa();
            emp = proxy.obtenerEmpresaPorLocal(loc);
            tituloEmpresa.Text = emp.RazonSocial;
           // Label1.Text = emp.RazonSocial+" "+emp.Rut+" "+emp.Telefono;
            DTOValoracion[] lstVal = proxy.obtenerValoracionesDeEmpresa(emp.Rut);
            int cant = lstVal.Length;
            //DTOUsuario[cant] usrs;
            DTOUsuario u = new DTOUsuario();
             int i =0;
            for(i=0;i<lstVal.Length;i++) {

               // usrs[i] = new DTOUsuario();
               // usrs[i].Id = lstVal[i].IdUsuario;
                u = proxy.ObtenerUsuario(lstVal[i].IdUsuario);

                   

    com  +=        "<div class='comentario'>      <img  src='/UploadedImages/"+lstVal[i].IdUsuario+"/Perfil.jpg' class='media-object pull-left' style='width: 64px; height: 64px; margin-right:10px; margin-bottom:10px;'/>";

      com  +=  " <div class='arriba'>";
      com  +=     "  <div class='fecha pull-right'>";
      com += ""+ lstVal[i].Fecha;
     com  +=  "  </div>";
      com  +=      " <div >";
      com  +=    "   ESTRELLAS ("+lstVal[i].Puntaje+")";
      com  +=   "</div>";
            
            
     com  +=   " </div>";
    com  +=   "  <div >";
    com += ""+lstVal[i].Comentario;

           
      com  +=  " </div>";
      com  +=   " <div >";
      com += "" + u.Nombre;
     com  +=    "</div>";

    
   com  +=  "</div>";
   
                }
            comentarios.InnerHtml = com;
        }

        protected void BtnComentar_Click(object sender, EventArgs e)
        {
             String loc = Request.QueryString["loc"];
            Usuario usr = (Usuario)Session["Usuario"];
            RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();
            DTOEmpresa emp = new DTOEmpresa();
            emp = proxy.obtenerEmpresaPorLocal(loc);

            Valoracion v = new Valoracion();
            v.fecha = new DateTime(2014 - 11 - 12);
            v.comentario = TextArea1.Value;
            v.id_empresa = emp.Rut;
            v.id_usuario = usr.Id;

            if(est1.Checked)
            {
            v.puntaje = 1;}
            if (est2.Checked)
            {
                v.puntaje = 2;
            }
            if (est3.Checked)
            {
                v.puntaje = 3;
            }
            if (est4.Checked)
            {
                v.puntaje = 4;
            }
            if (est5.Checked)
            {
                v.puntaje = 5;
            }
           
            DTOValoracion valo = proxy.ingresarValoracion(v.getDT());
            
        }
    }
}