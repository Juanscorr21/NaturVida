using NaturVida.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturVida.Data
{
    class ProductoCAD
    {
        public static bool guardar (ProductoM p)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "INSERT INTO Productos VALUES('"+ p.ProCodigo +"','" + p.ProDescripcion + "','"+p.ProValor+"','"+p.ProCantidad+"')";
                SqlCommand comando = new SqlCommand(sql,con.conectar());
                int cantidad = comando.ExecuteNonQuery();
                
                if(cantidad == 1)
                {
                    return true;
                }
                else {
                    con.desconectar();
                    return false; 
                }

            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
