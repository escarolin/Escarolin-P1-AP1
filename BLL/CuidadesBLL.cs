using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using Escarolin_P1_AP1.Entidades;
using Escarolin_P1_AP1.DAL;
using System.Linq.Expressions;


namespace Escarolin_P1_AP1.BLL{
    public class CuidadesBLL{

       //EXISTE
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Cuidades.Any(d => d.CuidadId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        //INSERTAR
        private static bool Insertar(Cuidades ciudades)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Cuidades.Add(ciudades);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        //MODIFICAR
        public static bool Modificar(Cuidades ciudades)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(ciudades).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        //GUARDAR
        public static bool Guardar(Cuidades ciudades)
        {
            if (!Existe(ciudades.CuidadId))
                return Insertar(ciudades);
            else
                return Modificar(ciudades);
        }

        //ELIMINAR
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var ciudades = contexto.Cuidades.Find(id);
                if (ciudades != null)
                {
                    contexto.Cuidades.Remove(ciudades);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        //BUSCAR
        public static Cuidades Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Cuidades ciudades;
            try
            {
                ciudades = contexto.Cuidades.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ciudades;
        }
      public static List<Cuidades> GetList(Expression<Func<Cuidades,bool>> criterio){
          List<Cuidades>lista=new List<Cuidades>();
          Contexto contexto = new Contexto();
          try
          {
              //Obtener la lista y filtrarla segun el criterio recibido por parametro.
               lista =contexto.Cuidades.Where(criterio).ToList();

          }
          catch(Exception)
   {
       throw;
   }
    finally
    {
        contexto.Dispose();

    }
 return lista;
}

}
}