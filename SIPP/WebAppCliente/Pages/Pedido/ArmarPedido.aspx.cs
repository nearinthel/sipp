using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using Entities;
using Entities.DTOs;

namespace WebAppCliente.Pages.Pedido
{
    public partial class ArmarPizza : System.Web.UI.Page
    {
        public String ingredientes = "";
        public Nullable<Decimal> precioPorcion = 0;
        public String editor = "";
        public String codigoHTML = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            RemoteServiceLocal.ServiceLocalClient proxy = new RemoteServiceLocal.ServiceLocalClient();

            DTOEspecificacionLocal[] lstDtoEspecificaciones = proxy.getEspecificacionesLocal(Session["Local"].ToString());

            foreach (DTOEspecificacionLocal esp in lstDtoEspecificaciones)
            {
                ingredientes += "<div class='ingredientItem " + esp.Especificacion.Nombre + "Icon' id='" + esp.Especificacion.Nombre + "Icon' title='" + esp.Especificacion.Descripcion + "' precio='" + esp.costo.ToString().Replace(",", ".") + "'>";
                ingredientes += "<p>" + esp.Especificacion.Descripcion + "</p>";
                if (esp.costo == 0)
                {
                    ingredientes += "<p>Sin costo</p>";
                }
                else
                {
                    ingredientes += "<p>" + esp.costo + "</p>";
                }
                ingredientes += "</div>";
            }

            DTOArticuloLocal articulo = proxy.getArticuloByLocal((String)Session["Producto"], (String)Session["Local"]);
           
            precioPorcion = articulo.Costo_base;
            if (Session["CodigoPedido"] == null)
            {
                switch ((String)Session["Producto"])
                {
                    case "pizzaMetro":
                        editor = "<table id='pizzas' cellspacing='0' cellpadding='0'>";
                        editor += "<tr id='pizzasContainer'>";
                        editor += "<td id='tblPizza1' class='tablaPizza tablaPizzaCuarto'>";
                        editor += "<div id='pizza1' class='pizza pizzaCuarto'></div>";
                        editor += "</td>";
                        editor += "<tr>";
                        editor += "</table>";
                        break;
                    case "pizzeta":
                        editor = "<table id='pizzas' cellspacing='0'>";
                        editor += "<tr id='pizzasContainer'>";
                        editor += "<td class='tablaPizza'><div id='pizza1' class='pizza'>";
                        editor += "<table class='tablaIngredientes' cellspacing='0'>";
                        editor += "<tr>";
                        editor += "<td id='pizzaUpLeft' class='pizzaUpLeft cuartoPizza'></td>";
                        editor += "<td id='pizzaUpRight' class='pizzaUpRight cuartoPizza'></td>";
                        editor += "</tr>";
                        editor += "<tr>";
                        editor += "<td id='pizzaDownLeft' class='pizzaDownLeft cuartoPizza'></td>";
                        editor += "<td id='pizzaDownRight' class='pizzaDownRight cuartoPizza'></td>";
                        editor += "</tr>";
                        editor += "</table>";
                        editor += "</div></td>";
                        editor += "<tr>";
                        editor += "</table>";
                        break;
                }
            }
            else
            {
                editor = Session["CodigoPedido"].ToString();
            }
        }

        protected void btnPedido_Click(object sender, EventArgs e)
        {
            codigoHTML = hiddenEstructuraPizza.Value;
            Session["CodigoPedido"] = codigoHTML;
            Response.Redirect("ConfirmarPedido.aspx");
        }
    }
}