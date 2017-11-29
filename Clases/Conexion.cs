using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

class datos
{
    string Cadena = @"Data Source=10.0.0.2,1433\SQLEXPRESS;Initial Catalog=RentATruck;User ID=Test;Password=Test123";
    public SqlConnection Cn;
    private SqlCommandBuilder cmb;
    public DataSet ds = new DataSet();
    public SqlDataAdapter da;


    public void consultar(string ssql, string tabla)
    {
        string sql = ssql + tabla;
        ds.Tables.Clear();
        da = new SqlDataAdapter(sql, Cn);
        cmb = new SqlCommandBuilder(da);
        da.Fill(ds, tabla);
    }

    private SqlCommand comando;
    public bool Insertar(string sql)
    {
        Cn.Close();
        Cn.Open();
        comando = new SqlCommand(sql, Cn);
        int i = comando.ExecuteNonQuery();
        Cn.Close();
        if (i > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Conectar()
    {
        Cn = new SqlConnection(Cadena);
        Cn.Open();
    }

    public void Desconectar()
    {
        Cn.Close();
    }


    public DataTable ConsultaTabla(string tabla, string orderBy)
    {
        string sql = "select * from " + tabla + orderBy;
        da = new SqlDataAdapter(sql, Cn);
        DataSet dts = new DataSet();
        da.Fill(dts, tabla);
        DataTable dt = new DataTable();
        dt = dts.Tables[tabla];
        return dt;
    }

    public bool Eliminar(string tabla, string condicion)
    {
        Cn.Open();
        string sql = "delete from " + tabla + " where " + condicion;
        comando = new SqlCommand(sql, Cn);
        int i = comando.ExecuteNonQuery();
        Cn.Close();
        if (i > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Actualizar(string tabla, string campos, string condicion)
    {
        Cn.Open();
        string sql = "update " + tabla + "set " + campos + " where " + condicion;
        comando = new SqlCommand(sql, Cn);
        int i = comando.ExecuteNonQuery();
        Cn.Close();
        if (i > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public DataTable Consulta_query(string query, string tabla, string condicion, string orderBy)
    {
        string sql = query + tabla + condicion + "order by " + orderBy;
        da = new SqlDataAdapter(sql, Cn);
        DataSet dts = new DataSet();
        da.Fill(dts, tabla);
        DataTable dt = new DataTable();
        dt = dts.Tables[tabla];
        return dt;
    }


    public void consultar2(string ssql, string tabla, string condicion)
    {
        string sql = ssql + tabla + condicion;
        //ds.Tables.Clear();
        da = new SqlDataAdapter(sql, Cn);
        cmb = new SqlCommandBuilder(da);
        da.Fill(ds, tabla);
    }

    public void Consulta_llenar_datos(string cadena)
    {
        ds.Tables.Clear();
        da = new SqlDataAdapter(cadena, Cn);
        cmb = new SqlCommandBuilder(da);
        da.Fill(ds);
    }
}
