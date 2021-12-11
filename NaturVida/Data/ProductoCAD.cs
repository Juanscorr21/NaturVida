using NaturVida.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturVida.Data
{
    class ProductoCAD
    {
        public static bool guardar(Producto p)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "INSERT INTO Productos VALUES('" + p.ProCodigo + "','" + p.ProDescripcion + "','" + p.ProValor + "','" + p.ProCantidad + "')";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cantidad = comando.ExecuteNonQuery();

                if (cantidad == 1)
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

        public static bool actualizar(Producto p)
        {
            try
            {
                Conexion con = new Conexion();
             
                string sql = "UPDATE Productos " +
                             "SET proCodigo = '" + p.ProCodigo + "', proDescripcion = '" + p.ProDescripcion + "', proValor = '" + p.ProValor + "', proCantidad = '" + p.ProCantidad + "' " +
                             "WHERE proCodigo = '" + p.ProCodigo + "'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cantidad = comando.ExecuteNonQuery();

                if (cantidad == 1)
                {
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static DataTable buscarProductoActualizar(Producto p)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = ("SELECT proCodigo AS 'Codigo', proDescripcion AS 'Descripcion',proValor AS 'Valor', proCantidad AS 'Cantidad' " +
                              "FROM Productos " +
                              "WHERE proDescripcion LIKE '" + p.ProDescripcion + '%' + "'");
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);
                con.desconectar();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable listar()
        {
            try
            {
                Conexion con = new Conexion();
                string sql = ("SELECT proCodigo AS 'Codigo', proDescripcion AS 'Descripcion',proValor AS 'Valor' " +
                              "FROM Productos");
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);
                con.desconectar();
                return dt;
                

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable listarPorDescripcion()
        {
            try
            {
                Conexion con = new Conexion();
                string sql = ("SELECT proCodigo, proDescripcion FROM Productos");
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);
                con.desconectar();
                DataRow fila = dt.NewRow();
                fila["proCodigo"] = -1;
                fila["proDescripcion"] = "TODOS";
                dt.Rows.InsertAt(fila, 0);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable buscarProducto(Producto p)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = ("SELECT proCodigo AS 'Codigo', proDescripcion AS 'Descripcion',proValor AS 'Valor' " +
                              "FROM Productos " +
                              "WHERE proDescripcion LIKE '" + p.ProDescripcion + '%' + "'");
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);
                con.desconectar();
                return dt;


            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable eliminarProducto(Producto p)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = ("DELETE FROM Productos " +
                              "WHERE proCodigo = '" + p.ProCodigo + "'");
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                con.desconectar();
                return dt;


            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
