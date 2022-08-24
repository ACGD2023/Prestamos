using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prestamoApp
{
    class clientes:conexion
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _cedula;

        public string cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }
        
        private string _nombres;

        public string nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }

        private string _apellidos;

        public string apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        private string _direccion;

        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private int _idbarrio;

        public int idbarrio
        {
            get { return _idbarrio; }
            set { _idbarrio = value; }
        }
        private string _telefono;

        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private int _idcategoria;

        public int idcategoria
        {
            get { return _idcategoria; }
            set { _idcategoria = value; }
        }
        private double _lon;

        public double lon
        {
            get { return _lon; }
            set { _lon = value; }
        }

        private double _lat;

        public double lat
        {
            get { return _lat; }
            set { _lat = value; }
        }

        private DataTable _dt;

        public DataTable dt
        {
            get { return _dt; }
            set { _dt = value; }
        }

        private DataSet ds = new DataSet();

        public void crear() {
            con.Open();
            using (MySqlCommand  cmd=new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO prestamosdb.clientes(cedula,nombres,apellidos,direccion,idbarrio,telefono,idcategoria,lon,lat)" +
                    "VALUES(@cedula,@nombres,@apellidos,@direccion,@idbarrio,@telefono,@idcategoria,@lon,@lat);";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@cedula", MySqlDbType.VarChar).Value = cedula;
                cmd.Parameters.Add("@nombres", MySqlDbType.VarChar).Value = nombres ;
                cmd.Parameters.Add("@apellidos", MySqlDbType.VarChar).Value = apellidos ;
                cmd.Parameters.Add("@direccion", MySqlDbType.VarChar).Value = direccion ;
                cmd.Parameters.Add("@idbarrio", MySqlDbType.Int32).Value = idbarrio ;
                cmd.Parameters.Add("@telefono", MySqlDbType.VarChar).Value = telefono ;
                cmd.Parameters.Add("@idcategoria", MySqlDbType.Int32).Value = idcategoria ;
                cmd.Parameters.Add("@lon", MySqlDbType.Double ).Value = lon;
                cmd.Parameters.Add("@lat", MySqlDbType.Double ).Value = lat;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void actualizar()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE clientes SET cedula = @cedula,nombres = @nombres,apellidos = @apellidos,direccion = @direccion,idbarrio = @idbarrio,telefono = @telefono ,idcategoria =@idcategoria,lon = @lon,lat = @lat ,updated_at= @updated_at WHERE id = @id;";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id", MySqlDbType.Int32 ).Value = id;
                cmd.Parameters.Add("@cedula", MySqlDbType.VarChar).Value = cedula;
                cmd.Parameters.Add("@nombres", MySqlDbType.VarChar).Value = nombres;
                cmd.Parameters.Add("@apellidos", MySqlDbType.VarChar).Value = apellidos;
                cmd.Parameters.Add("@direccion", MySqlDbType.VarChar).Value = direccion;
                cmd.Parameters.Add("@idbarrio", MySqlDbType.Int32).Value = idbarrio;
                cmd.Parameters.Add("@telefono", MySqlDbType.VarChar).Value = telefono;
                cmd.Parameters.Add("@idcategoria", MySqlDbType.Int32).Value = idcategoria;
                cmd.Parameters.Add("@lon", MySqlDbType.Double).Value = lon;
                cmd.Parameters.Add("@lat", MySqlDbType.Double).Value = lat;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        

        public void listar()
        {
            dt = new DataTable();
            dt.Clear();
            string consulta = "SELECT clientes.id,clientes.cedula,clientes.nombres,clientes.apellidos,clientes.direccion,clientes.idbarrio,clientes.telefono,clientes.idcategoria,clientes.lon,clientes.lat,clientes.created_at,clientes.updated_at FROM prestamosdb.clientes;";
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, con);
            da.Fill(ds);
            dt = ds.Tables[0];
            
        }

        
        public void eliminar()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM `prestamosdb`.`clientes` WHERE id=@id;";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add("@id", MySqlDbType.Int32 ).Value = id;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public string barrio()
        {
            string dato = "";
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT barrios.barrio as barrio FROM prestamosdb.barrios where barrios.id=@id;";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = idbarrio;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dato=reader["barrio"].ToString();
                }
                con.Close();
            }
            return dato;
        }
            

        
        

        
        

    }
}
