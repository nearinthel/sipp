using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    public partial class Pedido
    {

        //public Pedido()
        //{
        //}

        public DTOs.DTOPedido getDT()
        {
            DTOs.DTOPedido dt = new DTOs.DTOPedido();
            dt.Costo = this.Costo;
            dt.Estado = this.Estado;
            dt.Id_usuario = this.Id_usuario;
            dt.Id = this.Id;
            dt.Nombre_Local = this.Nombre_Local;
            dt.Descripcion = this.Descripcion;
            dt.Codigo_html = this.Codigo_html;
            dt.DireccionPedido = this.DireccionPedido;
            dt.LatitudDireccion = this.LatitudDireccion;
            dt.LongitudDireccion = this.LongitudDireccion;
            return dt;

            /*              public decimal Costo { get; set; }
        public bool Estado { get; set; }
        public long Id_usuario { get; set; }
        public long Id { get; set; }
        public string Nombre_Local { get; set; }
        public string Descripcion { get; set; }
        public string Codigo_html { get; set; }
        public string DireccionPedido { get; set; }
        public string LatitudDireccion { get; set; }
        public string LongitudDireccion { get; set; }/**/
        }

        public Pedido(decimal Costo, bool Estado, long Id_usuario, long Id, string Nombre_Local, string Descripcion, string Codigo_html, string DireccionPedido, string LatitudDireccion, string LongitudDireccion)
        {
            this.Costo = Costo;
            this.Estado = Estado;
            this.Id_usuario = Id_usuario;
            this.Id = Id;
            this.Nombre_Local = Nombre_Local;
            this.Descripcion = Descripcion;
            this.Codigo_html = Codigo_html;
            this.DireccionPedido = DireccionPedido;
            this.LatitudDireccion = LatitudDireccion;
            this.LongitudDireccion = LongitudDireccion;
        }

        public Pedido(DTOs.DTOPedido dto)
        {
            this.Costo = dto.Costo;
            this.Estado = dto.Estado;
            this.Id_usuario = dto.Id_usuario;
            this.Id = dto.Id;
            this.Nombre_Local = dto.Nombre_Local;
            this.Descripcion = dto.Descripcion;
            this.Codigo_html = dto.Codigo_html;
            this.DireccionPedido = dto.DireccionPedido;
            this.LatitudDireccion = dto.LatitudDireccion;
            this.LongitudDireccion = dto.LongitudDireccion;
        }
    }
}

