﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

    class datos
    {
        private string Cadena = @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=RentATruck;Integrated Security=True";
        public SqlConnection Cn;
        private SqlCommandBuilder cmb;

        private void Conectar()
        {
            Cn = new SqlConnection(Cadena);
            Cn.Open();
        }

        public datos()
        {
            Conectar();
        }

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
