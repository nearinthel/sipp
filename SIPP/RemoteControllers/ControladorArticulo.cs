using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using RemoteControllers.Exceptions;


namespace RemoteControllers
{
    public partial class ControladorArticulo
    {
        private static ControladorArticulo instance;

        private ControladorArticulo(){

        }
        public static ControladorArticulo getInstance(){
            if (instance == null)
            {
                instance = new ControladorArticulo(); 
            }
            return instance;
        }

        public bool agregarArticulo(Articulo item){
            
            using (AlacartaEntities handler= new AlacartaEntities()){
                              
                Articulo nuevoArticulo = handler.Articulo.Add(item);

                bool salvado = false;

                int resultado = handler.SaveChanges();
                if (resultado <= 0)
                {
                    throw new NoSalvadoException();

                }
                else
                {
                    salvado = true;
                }
                return salvado;
            }
        }

        //public bool modificarArticulo(Articulo item, Local sucursal){
        //    using (AlacartaEntities handler = new AlacartaEntities())
        //    {
        //        Articulo itemModificar = handler.Articulo.FirstOrDefault(i => i.Nombre == item.Nombre);
        //        if (itemModificar != null)
        //        {
        //            itemModificar.Nombre = item.Nombre;
                    
        //            itemModificar.Descripcion = item.Descripcion;
        //            //itemModificar.ArticuloLocal. = item.Local;
        //            //itemModificar.Nombre_local = item.Nombre_local;
        //            itemModificar.Unidad_base = item.Unidad_base;
        //        }
        //        bool salvado = false;

        //        int resultado = handler.SaveChanges();
        //        if (resultado <= 0)
        //        {
        //            throw new NoSalvadoException();

        //        }
        //        else
        //        {
        //            salvado = true;
        //        }
        //        return salvado;
        //    }
        //}

//Hugo revisate este para que haga update del articulo-local

        public bool removerArticulo(Articulo item)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                Articulo itemBorrar = handler.Articulo.FirstOrDefault(i => i.Nombre == item.Nombre); ;

                handler.Articulo.Remove(itemBorrar);
                bool salvado = false;

                int resultado = handler.SaveChanges();
                if (resultado <= 0)
                {
                    throw new NoSalvadoException();

                }
                else
                {
                    salvado = true;
                }
                return salvado;
            }
        }

        public static List<Articulo> getArticulos()
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    List<Articulo> lstDir = contexto.Articulo.Select(s => s).ToList();
                    return lstDir;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private bool salvar()
        //{
        //    using (AlacartaEntities handler = new AlacartaEntities())
        //    {
        //        bool salvado = false;

        //        int resultado = handler.SaveChanges();
        //        if (resultado <= 0)
        //        {
        //            throw new NoSalvadoException();

        //        }
        //        else
        //        {
        //            salvado = true;
        //        }
        //        return salvado;
        //    }
        //}


        //fredd
        public Articulo getArticulo(string nombreArticulo)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                Articulo articulo = handler.Articulo.FirstOrDefault(s => s.Nombre == nombreArticulo);
                if (articulo == null)
                {
                    throw new NoSePuedeConectarException();
                }
                else
                {
                    return articulo;
                }
            }
        }


    }
}
