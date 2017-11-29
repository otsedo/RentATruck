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
        public static int codigo_perfil, codigo_usuario;
        public static string IniciarSesion(string usuario, string password)
        {
            int logueado = 0;
            string mensaje = "";
            string Cadena = @"Data Source=10.0.0.2,1433\SQLEXPRESS;Initial Catalog=RentATruck;User ID=Test;Password=Test123";
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Cadena;
            conexion.Open();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Loguear";
            cmd.Connection = conexion;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
            cmd.Parameters.Add(new SqlParameter("@password", password));

            SqlParameter pLogueado = new SqlParameter("@logueado", 0);
            pLogueado.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(pLogueado);

            SqlParameter pMensaje = new SqlParameter("@mensaje", System.Data.SqlDbType.VarChar);
            pMensaje.Direction = System.Data.ParameterDirection.Output;
            pMensaje.Size = 40;
            cmd.Parameters.Add(pMensaje);

            SqlParameter pCodigo_Perfil = new SqlParameter("@codigo_perfil", System.Data.SqlDbType.Int);
            pCodigo_Perfil.Direction = System.Data.ParameterDirection.Output;
            //pCodigo_Perfil.Size = 40;
            cmd.Parameters.Add(pCodigo_Perfil);

            SqlParameter pCodigo_Usuario = new SqlParameter("@codigo_usuario", System.Data.SqlDbType.Int);
            pCodigo_Usuario.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(pCodigo_Usuario);

            cmd.ExecuteNonQuery();
            conexion.Close();

            logueado = Int32.Parse(cmd.Parameters["@logueado"].Value.ToString());
            if (logueado == 1)
            {
                codigo_perfil = Int32.Parse(cmd.Parameters["@codigo_perfil"].Value.ToString());
                codigo_usuario = Int32.Parse(cmd.Parameters["@codigo_usuario"].Value.ToString());
            }


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
