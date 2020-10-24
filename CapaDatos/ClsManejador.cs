using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ClsManejador
    {
        //CADENA DE CONEXION
        SqlConnection Conexion = new SqlConnection("Server=ARODRIGUEZ\\SQLEXPRESS; DataBase=Rincon_Guatemalteco; Integrated Security=True");

        //METODO ABRIR CONEXION
        public void abrir_conexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
        }
        //METODO CERRAR CONEXION
        public void cerrar_conexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
        }

        //METODO PARA PROCEDIMIENTOS ALMACENADOS(insert,update,delete)
        public void EjecutarSP(String NombreSP,List<ClsParametros> lst) {

            SqlCommand cmd;

            try {
                abrir_conexion();
                cmd = new SqlCommand(NombreSP, Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if(lst != null)
                {
                    for(int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].Direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(lst[i].Nombre,lst[i].Valor); //ADDWITHVALUE SE UTILIZA PARA PARAMETROS DE ENTRADA
                        }

                        if (lst[i].Direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(lst[i].Nombre,lst[i].TipoDato, lst[i].Tamaño).Direction = ParameterDirection.Output; //ADD SE UTILIZA PARA PARAMETROS DE SALIDA
                        }
                    }
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                        {
                            lst[i].Valor = cmd.Parameters[i].Value.ToString();
                        }
                    }
                }
                

            } catch (Exception ex) {
                throw ex;
            }
            cerrar_conexion();
        }

        //METODO PARA EJECUTAR CONSULTAS(SELECT)
        public DataTable Listado(String NombreSP, List<ClsParametros> lst)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;  

            try {

                da = new SqlDataAdapter(NombreSP,Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if(lst != null)
                {
                    for(int i = 0; i < lst.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                    }
                }

                da.Fill(dt);

            } catch (Exception ex) {
                throw ex;
            }

            return dt;
        }

    }
}
