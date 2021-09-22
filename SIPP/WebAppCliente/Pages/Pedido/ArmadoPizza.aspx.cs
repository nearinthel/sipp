using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.DTOs;
using Entities;
using System.Web.SessionState;

namespace WebAppCliente.Pages.Pedidos
{
    public partial class WebForm1 : WebAppCliente.Pages.PageTemplate
    {
        public String btnArticulo; 
        public String titulo;
        String tipoPizza;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.checkSesion();
                Usuario usr = (Usuario)Session["Usuario"];
                List<Ubicacion> lstUbicaciones = new List<Ubicacion>();

                if (Session["ubi"] != null)
                {
                    lstUbicaciones = (List<Ubicacion>)Session["ubi"];
                }
                else
                {
                    RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();

                    DTOUbicacion[] lstDtoUbicaciones = proxy.getUbicaciones(usr.Id);

                    foreach (DTOUbicacion ubi in lstDtoUbicaciones)
                    {
                        lstUbicaciones.Add(new Ubicacion(ubi));
                    }
                }

                grdDirecciones.DataSource = lstUbicaciones;
                grdDirecciones.DataBind();
                Session["ubi"] = lstUbicaciones;

            }

            if (IsPostBack)
            {
                if (Page.Request.Params["__EVENTTARGET"] == "PizzaClick")
                {
                    string pizzeria = Page.Request.Params["__EVENTARGUMENT"].ToString();
                    this.btnPizzaClick(pizzeria);
                }
            }
        }

        protected void btnPizzaClick(String nombrePizzeria)
        {
            Session["Local"] = nombrePizzeria;
            RemoteServiceLocal.ServiceLocalClient proxy = new RemoteServiceLocal.ServiceLocalClient();
            DTOArticuloLocal[] lstDtoArticulos = proxy.getArticulosLocal(nombrePizzeria);
            titulo += "<span class='titleArticulo'>Cu&aacutel Quer&eacutes?</span><br /><br />";
            foreach (DTOArticuloLocal art in lstDtoArticulos)
            {
                btnArticulo += "<input type='submit' name='ctl00$CPHContent$btnPizza' value='" + art.Articulo.Nombre + "' id='CPHContent_btnPizza' class='btn btnPizza'><br />"; 
                Session["tPizza"] = art.Articulo.Nombre;
            }
        }

        protected void btnPizzaSelect(object sender, EventArgs e)
        {
            Session["Producto"] = Session["tPizza"];
            Response.Redirect("ArmarPedido.aspx");
        }


        protected void grdDirecciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            String nombre = grdDirecciones.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            List<Ubicacion> lstUbicaciones = new List<Ubicacion>();
            List<Local> lstLocales = new List<Local>();
            if (Session["ubi"] != null)
            {
                lstUbicaciones = (List<Ubicacion>)Session["ubi"];
            }

            for (int i = 0; i < lstUbicaciones.Count; i++)
            {
                if (lstUbicaciones[i].Nombre_referencia == nombre)
                {
                    Session["Ubicacion"] = lstUbicaciones[i];

                    String script = "";

                    script = "placeMarkerClientFromDB(new google.maps.LatLng(" + ((Ubicacion)Session["Ubicacion"]).Latitud + "," + ((Ubicacion)Session["Ubicacion"]).Longitud + "));";

                    RemoteServiceLocal.ServiceLocalClient proxy = new RemoteServiceLocal.ServiceLocalClient();

                    DTOLocal[] lstDtoLocales = proxy.getLocalesPorArea(((Ubicacion)Session["Ubicacion"]).Latitud, ((Ubicacion)Session["Ubicacion"]).Longitud);

                    foreach (DTOLocal loc in lstDtoLocales)
                    {
                        script += "placeMarkerPizzeriaFromDB(new google.maps.LatLng(" + loc.Latitud + "," + loc.Longitud + "),'" + loc.Nombre + "');";
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", script, true);
                }
            }
        }
    }
}