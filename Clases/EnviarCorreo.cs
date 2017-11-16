using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RentATruck.Clases
{
    class EnviarCorreo
    {
        string camion;
        datos objDatos = new datos();
        datos objDatos2 = new datos();
        datos objDatos3 = new datos();

        public bool enviarCorreo15(string email)
        {
            objDatos2.Conectar();
            objDatos2.Consulta_llenar_datos("select fecha_enviado from control_mensajes_enviados where fecha_enviado = '" + DateTime.Now.Date.Date.ToString("MM-dd-yyyy") + "'");
            if (objDatos2.ds.Tables[0].Rows.Count > 0)
            {
                //Si trae datos es porque el dia de hoy ya ese correo se envió
            }
            else
            {
                try
                {
                    objDatos.Conectar();
                    objDatos.Consulta_llenar_datos("select m.descripcion + ' '  + mv.descripcion + ', año ' + convert(varchar(4),v.anoveh_veh) + ', Placa ' + convert(varchar(12),v.numpla_veh) + ', Chasis ' +  convert(varchar(17),v.numcha_veh) as vehiculo,mav.seguro as 'Fecha Vencimiento Seguro' from vehiculo v, marca_articulos m, tipo_vehiculos tv, modelos_vehiculos mv, colores c, mantenimiento_vehiculos mav where v.codigo_marca = m.codigo_marca and v.codigo_tipo_vehiculo = tv.codigo_tipo_vehiculo and v.codigo_modelos =mv.codigo_modelos and c.codigo_color = v.codigo_color and mav.codveh_veh = v.codveh_veh and mav.seguro in(SELECT cast(getdate() + 15 as DATE))");

                    if (objDatos.ds.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < objDatos.ds.Tables[0].Rows.Count; i++)
                        {
                            try
                            {
                                camion = objDatos.ds.Tables[0].Rows[i][0].ToString() + ", Fecha Vencimiento:" + objDatos.ds.Tables[0].Rows[i][1].ToString(); ;
                                System.Web.UI.WebControls.MailDefinition md = new System.Web.UI.WebControls.MailDefinition();
                                md.From = "anthonyrentatruck@gmail.com";
                                md.IsBodyHtml = true;
                                md.Subject = "Test of MailDefinition";

                                System.Collections.Specialized.ListDictionary replacements = new System.Collections.Specialized.ListDictionary();
                                replacements.Add("{camion1}", camion);

                                string body = "<!DOCTYPE html><html><head><title>Anthony Rent A Truck</title></head><body><center><h1>Vencimiento de Seguro de Camión</h1><h4>A los siguientes camiones se le vence el seguro roximamente:  </h4>{camion1}</ center ></body></html>";

                                MailMessage msg = md.CreateMailMessage("you@anywhere.com", replacements, body, new System.Web.UI.Control());

                                msg.To.Add(email);
                                msg.Subject = "Notificación de Vencimiento de Seguro - Anthony RentATruck";
                                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                                msg.BodyEncoding = System.Text.Encoding.UTF8;
                                msg.From = new System.Net.Mail.MailAddress("anthonyrentatruck@gmail.com");

                                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                                cliente.Credentials = new System.Net.NetworkCredential("anthonyrentatruck@gmail.com", "kebrbkqkbqjhiscs");

                                cliente.Port = 587;
                                cliente.EnableSsl = true;
                                cliente.Host = "smtp.gmail.com";

                                if (CheckForInternetConnection() == true)
                                {
                                    cliente.Send(msg);
                                    string fechaMensaje = "insert into control_mensajes_enviados values ('" + DateTime.Now.Date.Date.ToString("MM-dd-yyyy") + "')"; ;
                                    objDatos3.Conectar();
                                    objDatos3.Consulta_llenar_datos(fechaMensaje);
                                    objDatos3.Desconectar();
                                }
                            }
                            catch (System.Data.SqlClient.SqlException ex)
                            {
                                return false;
                            }
                        }

                        objDatos.Desconectar();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    return false;
                }
            }
            return true;
        }


        public bool enviarCorreo5(string email)
        {
            objDatos2.Conectar();
            objDatos2.Consulta_llenar_datos("select fecha_enviado from control_mensajes_enviados where fecha_enviado = '" + DateTime.Now.Date.Date.ToString("MM-dd-yyyy") + "'");
            if (objDatos2.ds.Tables[0].Rows.Count > 0)
            {
                //Si trae datos es porque el dia de hoy ya ese correo se envió
            }
            else
            {
                try
                {
                    objDatos.Conectar();
                    objDatos.Consulta_llenar_datos("select m.descripcion + ' '  + mv.descripcion + ', año ' + convert(varchar(4),v.anoveh_veh) + ', Placa ' + convert(varchar(12),v.numpla_veh) + ', Chasis ' +  convert(varchar(17),v.numcha_veh) as vehiculo,mav.seguro as 'Fecha Vencimiento Seguro' from vehiculo v, marca_articulos m, tipo_vehiculos tv, modelos_vehiculos mv, colores c, mantenimiento_vehiculos mav where v.codigo_marca = m.codigo_marca and v.codigo_tipo_vehiculo = tv.codigo_tipo_vehiculo and v.codigo_modelos =mv.codigo_modelos and c.codigo_color = v.codigo_color and mav.codveh_veh = v.codveh_veh and mav.seguro in(SELECT cast(getdate() + 5 as DATE))");

                    if (objDatos.ds.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < objDatos.ds.Tables[0].Rows.Count; i++)
                        {
                            try
                            {
                                camion = objDatos.ds.Tables[0].Rows[i][0].ToString() + ", Fecha Vencimiento:" + objDatos.ds.Tables[0].Rows[i][1].ToString(); ;
                                System.Web.UI.WebControls.MailDefinition md = new System.Web.UI.WebControls.MailDefinition();
                                md.From = "anthonyrentatruck@gmail.com";
                                md.IsBodyHtml = true;
                                md.Subject = "Test of MailDefinition";

                                System.Collections.Specialized.ListDictionary replacements = new System.Collections.Specialized.ListDictionary();
                                replacements.Add("{camion1}", camion);

                                string body = "<!DOCTYPE html><html><head><title>Anthony Rent A Truck</title></head><body><center><h1>Vencimiento de Seguro de Camión</h1><h4>A los siguientes camiones se le vence el seguro roximamente:  </h4>{camion1}</ center ></body></html>";

                                MailMessage msg = md.CreateMailMessage("you@anywhere.com", replacements, body, new System.Web.UI.Control());

                                msg.To.Add(email);
                                msg.Subject = "Notificación de Vencimiento de Seguro - Anthony RentATruck";
                                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                                msg.BodyEncoding = System.Text.Encoding.UTF8;
                                msg.From = new System.Net.Mail.MailAddress("anthonyrentatruck@gmail.com");

                                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                                cliente.Credentials = new System.Net.NetworkCredential("anthonyrentatruck@gmail.com", "kebrbkqkbqjhiscs");

                                cliente.Port = 587;
                                cliente.EnableSsl = true;
                                cliente.Host = "smtp.gmail.com";

                                if (CheckForInternetConnection() == true)
                                {
                                    cliente.Send(msg);
                                    string fechaMensaje = "insert into control_mensajes_enviados values ('" + DateTime.Now.Date.Date.ToString("MM-dd-yyyy") + "')"; ;
                                    objDatos.Consulta_llenar_datos(fechaMensaje);
                                }
                            }
                            catch (System.Data.SqlClient.SqlException ex)
                            {
                                return false;
                            }
                        }

                        objDatos.Desconectar();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    return false;
                }
            }
            return true;
        }








        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


    }
}

