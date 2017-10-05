using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentATruck.Clases;
using System.Data.SqlClient;


namespace RentATruck.Clases
{
    class Utilitarios
    {
        
                
        


        public static string IniciarSesion(string usuario, string password)
        {
            int logueado = 0;
            string mensaje = "";
            string Cadena = @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=RentATruck;Integrated Security=True";
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Cadena;
            conexion.Open();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Loguear";
            cmd.Connection = conexion;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
            cmd.Parameters.Add(new SqlParameter("@password", password));

            SqlParameter pLogueado = new SqlParameter("@logueado",0);
            pLogueado.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(pLogueado);

            SqlParameter pMensaje = new SqlParameter("@mensaje", System.Data.SqlDbType.VarChar);
            pMensaje.Direction = System.Data.ParameterDirection.Output;
            pMensaje.Size = 40;
            cmd.Parameters.Add(pMensaje);

            
            cmd.ExecuteNonQuery();
            conexion.Close();

            logueado = Int32.Parse(cmd.Parameters["@logueado"].Value.ToString());
            if (logueado > 0)
            {
                mensaje = cmd.Parameters["@mensaje"].Value.ToString();
                return mensaje;
            }
            else
                return mensaje;           
        }








    }
}
