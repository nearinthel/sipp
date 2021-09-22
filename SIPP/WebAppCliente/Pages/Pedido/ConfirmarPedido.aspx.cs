using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using Entities.DTOs;


namespace WebAppCliente.Pages.Pedido
{
    public partial class ConfirmarPedido : WebAppCliente.Pages.PageTemplate
    {
        public string local = "Nombre del local";
        public string direccion = "Direccion del cliente";
        public string resumen = "";
        private decimal costo = 0;
        private string descripcion = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkSesion();

            Ubicacion ubi = new Ubicacion();
            ubi.Direccion = "Maldonado";
            ubi.Latitud = "-35,00015544545";
            ubi.Longitud = "-34,45645646546";
            Session["Direccion"] = ubi;



            if (Session["CodigoPedido"] != null)
            {
                string codigoHTML = (String)Session["CodigoPedido"];
                local = Session["Local"].ToString();
               direccion = ((Ubicacion)Session["Direccion"]).Direccion;

                List<List<String>> productos = obtenerProductos(codigoHTML);
                ArmarResumen(productos);
            }
            else
            {
                Response.Redirect("/Pages/Pedido/ArmarPedido.aspx");
            }
        }

        protected List<List<String>> obtenerProductos(String codigoHTML)
        {
            RemoteServiceLocal.ServiceLocalClient proxy = new RemoteServiceLocal.ServiceLocalClient();

            DTOEspecificacionLocal[] lstDtoEspecificaciones = proxy.getEspecificacionesLocal(Session["Local"].ToString());

            List<List<String>> especificaciones = new List<List<String>>();

            int pizzas = codigoHTML.Split(new string[] { "pizza " }, StringSplitOptions.None).Length - 1;
            if (pizzas == 0)
            {
                pizzas = codigoHTML.Split(new string[] { "\"pizza\"" }, StringSplitOptions.None).Length - 1;
            }
            List<String> temp = new List<string>();

            DTOArticuloLocal articulo = proxy.getArticuloByLocal((String)Session["Producto"], (String)Session["Local"]);
            temp.Add(articulo.Articulo.Descripcion);
            temp.Add(pizzas.ToString());
            temp.Add(articulo.Costo_base.ToString());
            temp.Add(articulo.Articulo.Unidad_base.ToString());



            especificaciones.Add(temp);

            foreach (DTOEspecificacionLocal esp in lstDtoEspecificaciones)
            {
                temp = new List<string>();
                int count = codigoHTML.Split(new string[] { " " + esp.Especificacion.Nombre + " " }, StringSplitOptions.None).Length - 1;
                temp.Add(esp.Especificacion.Descripcion);
                temp.Add(count.ToString());
                temp.Add(esp.costo.ToString());
                especificaciones.Add(temp);
            }

            return especificaciones;
        }

        protected void ArmarResumen(List<List<String>> productos)
        {
            resumen = "<table class='resumenIngredientes'>";
            resumen += "    <tbody>";
            resumen += "        <tr>";
            resumen += "            <th>Descripción</th>";
            resumen += "            <th>Precio</th>";
            resumen += "        </tr>";

            List<String> pizza = productos[0];
            decimal precioTotal = 0;
            decimal precioPizzas = (int.Parse(pizza[1])) * (decimal.Parse(pizza[2]));
            precioTotal += precioPizzas;

            resumen += "        <tr>";
            string nombreArticulo = "";
            if (Decimal.Parse(pizza[3]) == 1)
            {
                nombreArticulo = pizza[1] + " " + pizza[0];
            }
            else
            {
                nombreArticulo = contarCuartos(pizza, "") + " " + pizza[0];
            }

            descripcion += nombreArticulo + ", ";
            resumen += "            <td>" + nombreArticulo + "</td>";

            resumen += "            <td>" + precioPizzas + "</td>";
            resumen += "        </tr>";
            String medida = pizza[0].Split(' ')[0];

            productos.RemoveAt(0); //Quitamos el articulo pizza de la lista

            foreach (List<String> producto in productos)
            {
                if (int.Parse(producto[1]) > 0)
                {
                    decimal precioProducto = (int.Parse(producto[1])) * (decimal.Parse(producto[2]));
                    precioTotal += precioProducto;
                    nombreArticulo = contarCuartos(producto, medida) + " " + producto[0];

                    descripcion += nombreArticulo + ", ";

                    resumen += "        <tr>";
                    resumen += "            <td>" + nombreArticulo + "</td>";
                    resumen += "            <td>" + precioProducto + "</td>";
                    resumen += "        </tr>";
                }
            }
            resumen += "        <tr id='rowTotal'>";
            resumen += "            <td style='text-align:right'>Total:</td>";
            resumen += "            <td id='precioTotal'>" + precioTotal + "</td>";
            resumen += "        </tr>";

            resumen += "    </tbody>";
            resumen += "</table>";

            descripcion = descripcion.Trim();
            descripcion = descripcion.TrimEnd(',');
            costo = precioTotal;
        }

        private String contarCuartos(List<String> producto, String medida)
        {
            int count = int.Parse(producto[1]);
            String cuartos = "";
            if (count < 4)
            {
                if (count != 2)
                {
                    cuartos = count + "/4 " + medida;
                }
                else
                {
                    cuartos = "1/2 " + medida;
                }
            }
            else if (count % 4 == 0)
            {
                cuartos = (count / 4).ToString() + " " + medida;
            }
            else
            {
                cuartos = (Decimal.Ceiling(count / 4)).ToString();
                cuartos += " " + (count % 4) + "/4 " + medida;
            }

            return cuartos;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            Entities.Pedido p = new Entities.Pedido();
            p.Costo = this.costo;
            p.Estado = false;
            p.Id_usuario = ((Usuario)Session["Usuario"]).Id;
            p.Id = 0;
            p.Nombre_Local = Session["Local"].ToString();
            p.Descripcion = this.descripcion;
            p.Codigo_html = Session["CodigoPedido"].ToString();
            p.DireccionPedido = ((Ubicacion)Session["Direccion"]).Direccion;
            p.LatitudDireccion = ((Ubicacion)Session["Direccion"]).Latitud;
            p.LongitudDireccion = ((Ubicacion)Session["Direccion"]).Longitud;

            RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();
            
            DTOPedido pedResult = proxy.IngresarPedido(p.getDT());
            if (pedResult.Id > 0)
            {
                Session["CodigoPedido"] = null;
                Response.Redirect("/Pages/Pedido/EstadoPedidos.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["CodigoPedido"] = null;
            Response.Redirect("/Pages/Pedido/ArmarPedido.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Pedido/ArmarPedido.aspx");
        }
    }
}