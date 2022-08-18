using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace AngularBackEnd.Models
{
    public class GestrorMascotas
    {
        

        public List<Mascotas> GetMascotas() {

            List<Mascotas> lista = new List<Mascotas>();
            string con = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();

            using (SqlConnection conn = new SqlConnection(con)) {
                conn.Open();

                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = "Mascota_all";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1).Trim();
                    int edad = reader.GetInt32(2);
                    string descripcion = reader.GetString(3).Trim();

                    Mascotas mascotas = new Mascotas(id,nombre,edad,descripcion);

                    lista.Add(mascotas);
                }

                reader.Close();
                conn.Close();

            }

            return lista;
        
        
        
        }


        public bool AddMascotas(Mascotas mascotas)
        {
            bool resp = false;

            string con = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();

            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlCommand sqlCommand = conn.CreateCommand();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.CommandText = "Mascota_add";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@nombre", mascotas.nombre);
                sqlCommand.Parameters.AddWithValue("@edad", mascotas.edad);
                sqlCommand.Parameters.AddWithValue("@descripcion", mascotas.descripcion);

                try
                {
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    resp = true;

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    resp = false;
                    throw;
                }
                finally
                {
                    sqlCommand.Parameters.Clear();
                    conn.Close();


                }
                return resp;
            }
            }

        public bool UpdateMascotas( int id ,Mascotas mascotas)
        {
            bool resp = false;

            string con = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();

            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlCommand sqlCommand = conn.CreateCommand();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.CommandText = "Mascota_update";
                sqlCommand.CommandType = CommandType.StoredProcedure;


                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@nombre", mascotas.nombre);
                sqlCommand.Parameters.AddWithValue("@edad", mascotas.edad);
                sqlCommand.Parameters.AddWithValue("@descripcion", mascotas.descripcion);

                try
                {
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    resp = true;

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    resp = false;
                    throw;
                }
                finally
                {
                    sqlCommand.Parameters.Clear();
                    conn.Close();


                }
                return resp;
            }
        }

    

        public bool deleteMascotas(int id)
        {
            bool resp = false;

            string con = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();

            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlCommand sqlCommand = conn.CreateCommand();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.CommandText = "Mascota_Delete";
                sqlCommand.CommandType = CommandType.StoredProcedure;


                sqlCommand.Parameters.AddWithValue("@id", id);
           
                try
                {
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    resp = true;

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    resp = false;
                    throw;
                }
                finally
                {
                    sqlCommand.Parameters.Clear();
                    conn.Close();


                }
                return resp;
            }
        }




    }
}