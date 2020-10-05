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

namespace Escarolin_P1_AP1.BLL{
    public class CuidadesBLL{


         public static bool Guardar(Cuidades cuidades){
             if(!Existe(cuidades.CuidadesId))
             return Insertar(cuidades);
             else{
                 return Modificar (cuidades);
             }
         }

        private static bool Insertar()

    }
}