using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturVida.Data
{
    class Conexion
    {
        SqlConnection con;
        public Conexion()
        {
            con = new SqlConnection("Server=DESKTOP-SIU093B;Database=NaturVidaDb;User Id=sa;Password=Juan123;Application Name=NaturVida");
        }

        public SqlConnection conectar()
        {
            try
            {
                con.Open();
                return con;
            }
            catch(Exception e)
            {
                return null;
            }

        }

        public Boolean desconectar()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
