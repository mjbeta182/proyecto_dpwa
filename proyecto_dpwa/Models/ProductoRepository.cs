using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_dpwa.Models
{
    public class ProductoRepository : DbConnection
    {
        public List<ProductoModel> findAll()
        {
            List<ProductoModel> productos = new List<ProductoModel>();
            command.CommandText = @"
                select p.id, p.descripcion, p.precio, p.imagenes, c.nombre
                from producto as p
                join categoria as c on p.categoria_id = c.id;
            ";
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader[0].ToString());
                string descripcion = reader[1].ToString();
                double precio = double.Parse(reader[2].ToString());
                string[] images = reader[3].ToString().Split(',');
                string categoria = reader[4].ToString();
                productos.Add(new ProductoModel(id, descripcion, precio, categoria, images));
            }
            command.Connection.Close();
            reader.Close();
            return productos;
        }


        public List<ProductoModel> findByCategoryName(string category_name)
        {
            List<ProductoModel> productos = new List<ProductoModel>();
            command.CommandText = $@"
                select p.id, p.descripcion, p.precio, p.imagenes, c.nombre
                from producto as p
                join categoria as c on p.categoria_id = c.id
                where c.nombre = '{category_name}';
            ";
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader[0].ToString());
                string descripcion = reader[1].ToString();
                double precio = double.Parse(reader[2].ToString());
                string[] images = reader[3].ToString().Split(',');
                string categoria = reader[4].ToString();
                productos.Add(new ProductoModel(id, descripcion, precio, categoria, images));
            }
            command.Connection.Close();
            reader.Close();
            return productos;
        }
    }
}