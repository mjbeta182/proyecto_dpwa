using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace proyecto_dpwa.Models
{
    public class CategoriaRepository : DbConnection
    {
        public CategoriaModel getCategoryById(int categoria_id)
        {
            CategoriaModel categoria = null;
            command.CommandText = $"select * from categoria where id = {categoria_id}";
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader[0].ToString());
                string nombre = reader[1].ToString();
                categoria = new CategoriaModel(id, nombre);
            }

            return categoria;
        }
    }
}