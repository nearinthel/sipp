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
    public class ControladorEmpresa:ControladorHerenciable
    {
        private static ControladorEmpresa instance;

        private ControladorEmpresa()
        {
        }

        public static ControladorEmpresa getInstance()
        {
            if (instance == null)
            {
                instance = new ControladorEmpresa();
            }
            return instance;
        }
        

        public static Valoracion ingresarValoracion(Valoracion v)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    
                    Valoracion val = new Valoracion();
                    val.comentario = v.comentario;
                    val.id_empresa = v.id_empresa;
                    val.puntaje = v.puntaje;
                    val.id_usuario = v.id_usuario;
                    val.fecha = v.fecha;
                    



                    Valoracion valResult = contexto.Valoracion.Add(val);
                    int result = contexto.SaveChanges();
                    long id = contexto.Valoracion.Max(va => va.id);

                    if (result > 0)
                    {
                        val.id = id;

                        return val;
                    }

                    else
                        return new Valoracion();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }






        public static Empresa obtenerEmpresaPorLocal(string local) {



            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {   
                    Local loc = ControladorEmpresa.obtenerLocal(local);
                    Empresa emp = ControladorEmpresa.getEmpresa(loc.Rut_empresa);
                    return emp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static Local obtenerLocal(string local)
        {


            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    Local loc = contexto.Local.FirstOrDefault(l => l.Nombre == local);
                    return loc;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public bool registroEmpresa(Empresa enterprise){
            using (AlacartaEntities handler = new AlacartaEntities())
            {

                handler.Empresa.Add(enterprise);

                return this.salvar(handler);
            }
        }

        public bool modificarEmpresa(Empresa enterprise, long rut){
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                bool salvado = false;
                Empresa empresaModificar = handler.Empresa.FirstOrDefault(s => s.Rut == rut);
                if (empresaModificar != null)
                {
                    empresaModificar.Rut = enterprise.Rut;

                    empresaModificar.Razon_social = enterprise.Razon_social;
                    empresaModificar.Telefono = enterprise.Telefono;
                    empresaModificar.Pass = enterprise.Pass;
                    //handler.Entry(empresaModificar).CurrentValues.SetValues(enterprise);
                    
             
                    salvado = this.salvar(handler);
                }

                    return salvado;
                //}
               

            }
        }
        public bool modificarPassEmpresa(long rut, string nuevaPass)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                Empresa empresaPassVieja = handler.Empresa.First(s=>s.Rut==rut);
                empresaPassVieja.Pass = nuevaPass;
                
 
                return this.salvar(handler);

            }
        }
        public Empresa loginEmpresa(string nombreEmpresa, string passEmpresa)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                Empresa enterprise = handler.Empresa.FirstOrDefault(s => s.Razon_social == nombreEmpresa && s.Pass == passEmpresa);

                
                return enterprise;
                
            }
        }
        public bool removeEmpresa(long rut)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {

                Empresa empresaRemover = handler.Empresa.First(s => s.Rut == rut);
                if (empresaRemover.Local.Count != 0)
                {
                    ControladorLocal controller = ControladorLocal.getInstance();
                    foreach (Local sucursal in empresaRemover.Local)
                    {
                        controller.borrarLocal(sucursal.Nombre, rut);
                        //empresaRemover.Local.Remove(sucursal);
                    }
                    this.removeEmpresa(rut);
                }
                
                handler.Empresa.Remove(empresaRemover);

                return this.salvar(handler);
            }
        }

        public bool agregarLocalEmpresa(long rut, Local sucursal)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {

                Empresa enterprise = handler.Empresa.First(s => s.Rut == rut);
                enterprise.Local.Add(sucursal);


                return this.salvar(handler);
            }
        }

        public static Empresa getEmpresa(long rut)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                Empresa enterprise = handler.Empresa.First(s => s.Rut==rut);
                if (enterprise == null)
                {
                    throw new ObjetoNoExisteException(String.Format("La empresa con rut \"{0}\" ",rut));
                }
                return enterprise;
            }
        }
        public bool comprobarRut(long rut)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                bool disponible= true;
                Empresa enterprise = handler.Empresa.FirstOrDefault(emp => emp.Rut == rut);
                if (enterprise != null)
                {
                    disponible = false;
                }
                return disponible;
            }
        }
        public bool comprobarRazonSocialLogin(string razonSocial)
        {
           
                using (AlacartaEntities handler = new AlacartaEntities())
                {
                    bool existe = false;
                    Empresa enterprise = handler.Empresa.FirstOrDefault(emp => emp.Razon_social == razonSocial);
                    if (enterprise != null)
                    {
                        existe = true;
                    }
                    return existe;
                }
            
        
        }



        public static List<Valoracion> obtenerValoracionesDeEmpresa(long rut)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {


                    //Usuario usr = new Usuario();
                    List<Valoracion> lstValoraciones = contexto.Valoracion.Where(val => val.id_empresa == rut).ToList();





                    if (lstValoraciones == null)
                    {


                        return null;
                    }

                    else
                        return lstValoraciones;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                throw new NotImplementedException();
            }
            
        }
    }
}
